﻿namespace OTPServerConfigurationUtility
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.edit_serialNumber = new System.Windows.Forms.TextBox();
            this.btChoose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btInstallCert = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_status = new System.Windows.Forms.Label();
            this.btEventLog = new System.Windows.Forms.Button();
            this.btRestart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btInstallCA = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btRestore = new System.Windows.Forms.Button();
            this.label_certName = new System.Windows.Forms.Label();
            this.label_certNameValue = new System.Windows.Forms.Label();
            this.label_certAuth = new System.Windows.Forms.Label();
            this.label_certAuthValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "You have to provide a certificate containing a private key to use the OTP server." +
                "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "The certificate has to be installed in your local machine\'s key store.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Certificate\'s serial number: (Choose from your local key store)";
            // 
            // edit_serialNumber
            // 
            this.edit_serialNumber.Location = new System.Drawing.Point(15, 95);
            this.edit_serialNumber.Name = "edit_serialNumber";
            this.edit_serialNumber.Size = new System.Drawing.Size(313, 20);
            this.edit_serialNumber.TabIndex = 3;
            // 
            // btChoose
            // 
            this.btChoose.Location = new System.Drawing.Point(334, 93);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(75, 23);
            this.btChoose.TabIndex = 4;
            this.btChoose.Text = "Choose ...";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Install a new certificate and/or CA in your local key store to use with OTP serve" +
                "r:";
            // 
            // btInstallCert
            // 
            this.btInstallCert.Location = new System.Drawing.Point(15, 265);
            this.btInstallCert.Name = "btInstallCert";
            this.btInstallCert.Size = new System.Drawing.Size(139, 23);
            this.btInstallCert.TabIndex = 6;
            this.btInstallCert.Text = "Install new certificate ...";
            this.btInstallCert.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_status);
            this.panel1.Controls.Add(this.btEventLog);
            this.panel1.Controls.Add(this.btRestart);
            this.panel1.Controls.Add(this.btStop);
            this.panel1.Controls.Add(this.btStart);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(15, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 77);
            this.panel1.TabIndex = 7;
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.ForeColor = System.Drawing.Color.Crimson;
            this.label_status.Location = new System.Drawing.Point(95, 14);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(55, 13);
            this.label_status.TabIndex = 5;
            this.label_status.Text = "XXXXXX";
            // 
            // btEventLog
            // 
            this.btEventLog.Enabled = false;
            this.btEventLog.Location = new System.Drawing.Point(294, 40);
            this.btEventLog.Name = "btEventLog";
            this.btEventLog.Size = new System.Drawing.Size(97, 23);
            this.btEventLog.TabIndex = 4;
            this.btEventLog.Text = "Open EventLog";
            this.btEventLog.UseVisualStyleBackColor = true;
            // 
            // btRestart
            // 
            this.btRestart.Enabled = false;
            this.btRestart.Location = new System.Drawing.Point(165, 40);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(75, 23);
            this.btRestart.TabIndex = 3;
            this.btRestart.Text = "Restart";
            this.btRestart.UseVisualStyleBackColor = true;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(84, 40);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(3, 40);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Service status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "OTP server controll:";
            // 
            // btInstallCA
            // 
            this.btInstallCA.Location = new System.Drawing.Point(160, 265);
            this.btInstallCA.Name = "btInstallCA";
            this.btInstallCA.Size = new System.Drawing.Size(187, 23);
            this.btInstallCA.TabIndex = 9;
            this.btInstallCA.Text = "Install new Certificate Authority ...";
            this.btInstallCA.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(291, 298);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(118, 23);
            this.btSave.TabIndex = 10;
            this.btSave.Text = "Save configuration";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btRestore
            // 
            this.btRestore.Location = new System.Drawing.Point(160, 298);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(125, 23);
            this.btRestore.TabIndex = 11;
            this.btRestore.Text = "Restore configuration";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // label_certName
            // 
            this.label_certName.AutoSize = true;
            this.label_certName.Location = new System.Drawing.Point(12, 128);
            this.label_certName.Name = "label_certName";
            this.label_certName.Size = new System.Drawing.Size(86, 13);
            this.label_certName.TabIndex = 12;
            this.label_certName.Text = "Certificate name:";
            // 
            // label_certNameValue
            // 
            this.label_certNameValue.AutoSize = true;
            this.label_certNameValue.Location = new System.Drawing.Point(144, 128);
            this.label_certNameValue.Name = "label_certNameValue";
            this.label_certNameValue.Size = new System.Drawing.Size(42, 13);
            this.label_certNameValue.TabIndex = 13;
            this.label_certNameValue.Text = "XXXXX";
            // 
            // label_certAuth
            // 
            this.label_certAuth.AutoSize = true;
            this.label_certAuth.Location = new System.Drawing.Point(12, 150);
            this.label_certAuth.Name = "label_certAuth";
            this.label_certAuth.Size = new System.Drawing.Size(124, 13);
            this.label_certAuth.TabIndex = 14;
            this.label_certAuth.Text = "Certificate Authority (CA):";
            // 
            // label_certAuthValue
            // 
            this.label_certAuthValue.AutoSize = true;
            this.label_certAuthValue.Location = new System.Drawing.Point(144, 150);
            this.label_certAuthValue.Name = "label_certAuthValue";
            this.label_certAuthValue.Size = new System.Drawing.Size(42, 13);
            this.label_certAuthValue.TabIndex = 15;
            this.label_certAuthValue.Text = "XXXXX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(394, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "This certificate will be used for SSL/TLS to authenticate the server against clie" +
                "nts.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(386, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "The CA named above has to be installed on/known by each client of this server.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(367, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "When deploying the CA to your clients, please mind that the CA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(348, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "MUST be installed in the local machine account\'s key store,";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(196, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "NOT the current user\'s key store!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 450);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_certAuthValue);
            this.Controls.Add(this.label_certAuth);
            this.Controls.Add(this.label_certNameValue);
            this.Controls.Add(this.label_certName);
            this.Controls.Add(this.btRestore);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btInstallCA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btInstallCert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btChoose);
            this.Controls.Add(this.edit_serialNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OTPServer Configuration Utility";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edit_serialNumber;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btInstallCert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btEventLog;
        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button btInstallCA;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.Label label_certName;
        private System.Windows.Forms.Label label_certNameValue;
        private System.Windows.Forms.Label label_certAuth;
        private System.Windows.Forms.Label label_certAuthValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}
