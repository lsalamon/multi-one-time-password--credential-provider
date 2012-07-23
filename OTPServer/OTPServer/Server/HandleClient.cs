﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Security.Authentication;
using OTPServer.XML.OTPPacket;
using System.IO;
using OTPServer.Communication.Local.Observer;
using OTPServer.Communication.Local;

namespace OTPServer.Server
{
    class HandleClient : Observer, IDisposable
    {
        private TcpClient _ClientSocket;
        private volatile AutoResetEvent _Waiting = new AutoResetEvent(false);

        private Thread _ClientThread = null;
        public Thread ClientThread
        {
            get { return this._ClientThread; }
        }

        // TODO: Implement a (static) signaling mechanism to communicate the active state with the ClientThread
        private bool _Active;
        public bool Active
        {
            get { return this._Active; }
        }

        public HandleClient(TcpClient clientSocket)
        {
            this._ClientSocket = clientSocket;
            this._Active = false;
        }

        ~HandleClient()
        {
            this._ClientSocket = null;
            this._ClientThread = null;
            this._Active = false;
        }

        public bool Start()
        {
            bool started = false;
            if (!Active && _ClientThread == null)
            {
                this._Active = started = true;
                _ClientThread = new Thread(CommunicationThread);
                _ClientThread.Start();
            }
            return started;
        }

        public void Stop(bool stopThread)
        {
            this._Active = false;            

            if (stopThread && _ClientThread != null)
                _ClientThread.Abort();
            _ClientThread.Join();

            this._ClientSocket.Close();
        }

        private void CommunicationThread()
        {
            try
            {
                X509Certificate certificate = Authority.Authority.GetServerCertificate();
                using (SslStream sslStream = new SslStream(this._ClientSocket.GetStream()))
                {
                    try
                    {
                        try
                        {
                            sslStream.AuthenticateAsServer(certificate);
                        }
                        catch (AuthenticationException)
                        {
                            this._Active = false;
                        }

                        /*
                        string test = ReadPacketFromStream(sslStream);

                        byte[] stringAsByteArray = Encoding.UTF8.GetBytes(test);
                        sslStream.Write(stringAsByteArray);

                        this._Active = false;
                        */

                        if (Active)
                        {
                            OTPPacket otpPacket = new OTPPacket();
                            bool success = false;

                            try
                            {
                                success = otpPacket.SetFromXML(sslStream, true);
                            }
                            catch (Exception e)
                            {
                                File.AppendAllText("C:\\logloglog.log", e.InnerException.ToString());
                                File.AppendAllText("C:\\logloglog.log", e.Message.ToString());
                                File.AppendAllText("C:\\logloglog.log", e.Source.ToString());
                                File.AppendAllText("C:\\logloglog.log", e.Data.ToString());
                                File.AppendAllText("C:\\logloglog.log", e.StackTrace.ToString() + ";\n");

                                throw e;
                            }

                            // create a writer and open the file
                            File.AppendAllText("C:\\logloglog.log", otpPacket.Message.Type.ToString() + ";\n");

                            if (!success)
                            {
                                File.AppendAllText("C:\\logloglog.log", "NO SUCCESS;\n");
                                // TODO: Client and server should manage to set-up a matching protocol version. (Now server rejects any request thats above himself)

                                OTPPacket errorPacket = CreateErrorPacket(
                                    ProcessIdentifier.NONE,
                                    "Malformed packet or wrong protocol version",
                                    Message.STATUS.E_ERROR);
                                WritePacketToStream(sslStream, errorPacket);

                                Stop(false); // We don't need to interrupt the thread itself. We already reached the end.
                                return;
                            }

                            RequestObject<OTPPacket, AuthorityResponseObject> reqObj = Authority.Authority.Request(this, otpPacket);

                            File.AppendAllText("C:\\logloglog.log", "WAITING FOR RESPONSE;\n");
                            // Wait for answer from RequestQueue (Observer, see Update())
                            this._Waiting.WaitOne();

                            if (reqObj.Response.SimpleResponse)
                            {
                                OTPPacket successPacket;
                                if (reqObj.Request.Message.Type == Message.TYPE.HELLO)
                                    successPacket = CreateHelloPacket(reqObj.Response.ComplexResponse.ProcessIdentifier);
                                else
                                {
                                    successPacket = CreateSuccessPacket(
                                    reqObj.Response.ComplexResponse.ProcessIdentifier,
                                    reqObj.Response.ComplexResponse.TextMessage,
                                    reqObj.Response.ComplexResponse.StatusCode
                                    );
                                }
                                WritePacketToStream(sslStream, successPacket);
                            }
                            else
                            {
                                OTPPacket errorPacket = CreateErrorPacket(
                                    reqObj.Response.ComplexResponse.ProcessIdentifier,
                                    reqObj.Response.ComplexResponse.TextMessage,
                                    reqObj.Response.ComplexResponse.StatusCode
                                    );
                                WritePacketToStream(sslStream, errorPacket);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        /*
                        lock (sslStream)
                            if (sslStream.CanWrite)
                            {
                                OTPPacket errorPacket = CreateErrorPacket(
                                            ProcessIdentifier.NONE,
                                            "Unknown Error.",
                                            Message.STATUS.E_UNKNOWN);
                                WritePacketToStream(sslStream, errorPacket);
                            }
                        */
                    }
                }

                //Stop(false); // We don't need to interrupt the thread itself. We already reached the end.
            }
            finally
            {
                Stop(false); // We don't need to interrupt the thread itself. We already reached the end.
            }
        }

        private void SetMessageAttributes(ref OTPPacket otpPacket, Message.TYPE type, string textMessage, Message.STATUS statusCode)
        {
            otpPacket.Message.Type = type;
            otpPacket.Message.TextMessage = textMessage;
            otpPacket.Message.StatusCode = statusCode;
        }

        private OTPPacket CreatePacket(int pid)
        {
            OTPPacket otpPacket = new OTPPacket();
            otpPacket.ProcessIdentifier.ID = pid;
            return otpPacket;
        }

        private OTPPacket CreateErrorPacket(int pid, string message, Message.STATUS statusCode)
        {
            File.AppendAllText("C:\\logloglog.log", "Creating MESSAGE packet; ERROR;\n");
            OTPPacket otpPacket = CreatePacket(pid);
            SetMessageAttributes(ref otpPacket, Message.TYPE.ERROR, message, statusCode);

            return otpPacket;
        }

        private OTPPacket CreateSuccessPacket(int pid, string message, Message.STATUS statusCode)
        {
            File.AppendAllText("C:\\logloglog.log", "Creating MESSAGE packet; SUCCESS;\n");
            OTPPacket otpPacket = CreatePacket(pid);
            SetMessageAttributes(ref otpPacket, Message.TYPE.SUCCESS, message, statusCode);

            return otpPacket;
        }

        private OTPPacket CreateHelloPacket(int pid)
        {
            File.AppendAllText("C:\\logloglog.log", "Creating HELLO packet;\n");
            OTPPacket otpPacket = CreatePacket(pid);
            SetMessageAttributes(ref otpPacket, Message.TYPE.HELLO, String.Empty, Message.STATUS.NONE);

            return otpPacket;
        }

        private void WritePacketToStream(SslStream stream, OTPPacket otpPacket)
        {
            File.AppendAllText("C:\\logloglog.log", "Writing packet to stream:\n");

            
            File.AppendAllText("C:\\logloglog.log", "  " + otpPacket.ProcessIdentifier.ID);
            File.AppendAllText("C:\\logloglog.log", "  " + otpPacket.Message.Type.ToString());
            File.AppendAllText("C:\\logloglog.log", "  " + otpPacket.DataItems.Count);

            string otpPacketAsString = otpPacket.ToXMLString();
            byte[] otpPacketAsByteArray = Encoding.UTF8.GetBytes(otpPacketAsString);
            
            stream.Write(otpPacketAsByteArray);
            stream.Flush();
        }

        public override void Update()
        {
            File.AppendAllText("C:\\logloglog.log", "WE WERE NOTIFIED AND CAN PROCEED;\n");
            // Returning from a RequestQueue
            this._Waiting.Set();
        }

        public void Dispose()
        {
            //_Waiting.Dispose();
        }
    }
}