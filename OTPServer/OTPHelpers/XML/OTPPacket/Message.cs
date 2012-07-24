﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace OTPHelpers.XML.OTPPacket
{
    [Serializable]
    public class Message
    {
        public enum TYPE : int
        {
            NONE    = 0,

            SUCCESS = 1,
            ERROR   = 2,

            HELLO   = 3,
            ADD     = 4, // Add partial data such as Username, OTP, Public Key etc.
            VERIFY  = 5,
            RESYNC  = 6,

            PROTOCOL_VERSION_1_END = 7,
        }

        public enum STATUS : int
        {
            NONE = 0,

            S_OK        = 200, // General success
            S_RESYNC_OK = 201, // Resynchronization successfull

            E_ERROR        = 400, // General error
            E_NOT_VERIFIED = 401, // OTP could not be verified / is wrong
            E_NOT_FOUND    = 404, // Data (e.g. user or pid) not found
            E_INCOMPLETE   = 480, // Incomplete data. E.g. verification: one or all of Username, OTP or Public Key are not set. comm: client didn't send a MAC
            E_UNKNOWN      = 500  // Unspecified error 
        }

        private TYPE _Type;
        public TYPE Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }

        private Object _Content = null;
        public Object Content
        {
            get { return this._Content; }
            set { this._Content = value; }
        }

        public string TextMessage
        {
            get { return (string)Content; }
            set { Content = value; }
        }

        public STATUS _StatusCode;
        public STATUS StatusCode
        {
            get { return this._StatusCode; }
            set { this._StatusCode = value; }
        }

        public string _MAC;
        public byte[] MAC
        {
            get { return Convert.FromBase64String(this._MAC); }
            set { this._MAC = Convert.ToBase64String(value); }
        }

        public int _TimeStamp;
        public int TimeStamp
        {
            get { return this._TimeStamp; }
            set { this._TimeStamp = value; }
        }

        public Message() 
        {
            Type = TYPE.NONE;
            StatusCode = STATUS.NONE;
            TimeStamp = 0;
            this._MAC = String.Empty;
        }

        ~Message() 
        {
            Content = null;
            Type = TYPE.NONE;
            StatusCode = STATUS.NONE;
            TimeStamp = 0;
            this._MAC = String.Empty;
        }

        private void CleanUp()
        {
            Content = null;
            Type = TYPE.NONE;
            StatusCode = STATUS.NONE;
            TimeStamp = 0;
            this._MAC = String.Empty;
        }

        public bool SetFromXMLReader(XmlReader xmlReader)
        {
            bool success = ParseAttributes(xmlReader);
            Content = xmlReader.ReadElementContentAsString();

            if (!success)
                CleanUp();

            return success;
        }

        private bool ParseAttributes(XmlReader xmlReader)
        {
            bool success = true;

            int attributeCount = xmlReader.AttributeCount;
            for (int i = 0; i < attributeCount; i++)
            {
                xmlReader.MoveToAttribute(i);
                if (xmlReader.Name.Equals("type"))
                {
                    if (xmlReader.Value.Equals("HELLO"))
                        Type = TYPE.HELLO;
                    else if (xmlReader.Value.Equals("ADD"))
                        Type = TYPE.ADD;
                    else if (xmlReader.Value.Equals("VERIFY"))
                        Type = TYPE.VERIFY;
                    else if (xmlReader.Value.Equals("RESYNC"))
                        Type = TYPE.RESYNC;
                    else if (xmlReader.Value.Equals("SUCCESS"))
                        Type = TYPE.SUCCESS;
                    else if (xmlReader.Value.Equals("ERROR"))
                        Type = TYPE.ERROR;
                    continue;
                }
                else if (xmlReader.Name.Equals("status"))
                {
                    StatusCode = (STATUS)XmlConvert.ToInt32(xmlReader.Value);
                    continue;
                }
                else if (xmlReader.Name.Equals("timestamp"))
                {
                    StatusCode = (STATUS)XmlConvert.ToInt32(xmlReader.Value);
                    continue;
                }
                else if (xmlReader.Name.Equals("mac"))
                {
                    this._MAC = xmlReader.Value;
                    continue;
                }
            }

            return success;
        }

        public void ToXmlString(ref XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("Message");

            xmlWriter.WriteAttributeString("type", Enum.GetName(typeof(TYPE), ((int)this._Type)));

            if (this._StatusCode != STATUS.NONE)
                xmlWriter.WriteAttributeString("status", ((int)this._StatusCode).ToString());

            if (this._TimeStamp != 0)
                xmlWriter.WriteAttributeString("timestamp", this._TimeStamp.ToString());

            if (this._MAC != String.Empty)
                xmlWriter.WriteAttributeString("mac", this._MAC);

            if (this.TextMessage != String.Empty)
                xmlWriter.WriteString(this.TextMessage);

            xmlWriter.WriteEndElement();
        }
    }
}