namespace CuoiKiLTMClient
{
    partial class Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Online = new System.Windows.Forms.CheckedListBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.butConnect = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.grOnline = new System.Windows.Forms.TabPage();
            this.userOnline = new System.Windows.Forms.TabPage();
            this.butFile = new System.Windows.Forms.Button();
            this.lstGroup = new System.Windows.Forms.CheckedListBox();
            this.butExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabControl.SuspendLayout();
            this.grOnline.SuspendLayout();
            this.userOnline.SuspendLayout();
            this.SuspendLayout();
            // 
            // Online
            // 
            this.Online.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Online.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Online.FormattingEnabled = true;
            this.Online.Location = new System.Drawing.Point(3, 3);
            this.Online.Name = "Online";
            this.Online.Size = new System.Drawing.Size(209, 344);
            this.Online.TabIndex = 39;
            this.Online.SelectedIndexChanged += new System.EventHandler(this.Online_SelectedIndexChanged);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(452, 10);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(95, 22);
            this.txtServerIP.TabIndex = 38;
            this.txtServerIP.Text = "192.168.1.67";
            this.txtServerIP.TextChanged += new System.EventHandler(this.txtServerIP_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(366, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 37;
            this.label2.Text = "Server IP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // butSend
            // 
            this.butSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butSend.Location = new System.Drawing.Point(797, 444);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(76, 41);
            this.butSend.TabIndex = 36;
            this.butSend.Text = "Send";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(245, 463);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(546, 22);
            this.txtMessage.TabIndex = 35;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // txtBox
            // 
            this.txtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBox.Location = new System.Drawing.Point(245, 106);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(546, 344);
            this.txtBox.TabIndex = 34;
            this.txtBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // numPort
            // 
            this.numPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numPort.Location = new System.Drawing.Point(620, 8);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(126, 22);
            this.numPort.TabIndex = 33;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPort.Value = new decimal(new int[] {
            12345,
            0,
            0,
            0});
            this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.BackColor = System.Drawing.SystemColors.Info;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(561, 67);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(230, 25);
            this.lbStatus.TabIndex = 32;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStatus.Click += new System.EventHandler(this.lbStatus_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(476, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 28);
            this.label1.TabIndex = 31;
            this.label1.Text = "Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbPort
            // 
            this.lbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(553, 6);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(61, 29);
            this.lbPort.TabIndex = 30;
            this.lbPort.Text = "Port";
            this.lbPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPort.Click += new System.EventHandler(this.lbPort_Click);
            // 
            // butConnect
            // 
            this.butConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butConnect.Location = new System.Drawing.Point(752, 0);
            this.butConnect.Name = "butConnect";
            this.butConnect.Size = new System.Drawing.Size(128, 45);
            this.butConnect.TabIndex = 29;
            this.butConnect.Text = "Connect";
            this.butConnect.UseVisualStyleBackColor = true;
            this.butConnect.Click += new System.EventHandler(this.butConnect_Click);
            // 
            // lbUser
            // 
            this.lbUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbUser.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(245, 72);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(174, 31);
            this.lbUser.TabIndex = 40;
            this.lbUser.Click += new System.EventHandler(this.lbUser_Click);
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.SystemColors.Info;
            this.lbName.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(16, 6);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(75, 39);
            this.lbName.TabIndex = 41;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.grOnline);
            this.tabControl.Controls.Add(this.userOnline);
            this.tabControl.Location = new System.Drawing.Point(4, 78);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(220, 385);
            this.tabControl.TabIndex = 43;
            // 
            // grOnline
            // 
            this.grOnline.Controls.Add(this.lstGroup);
            this.grOnline.Location = new System.Drawing.Point(4, 25);
            this.grOnline.Name = "grOnline";
            this.grOnline.Padding = new System.Windows.Forms.Padding(3);
            this.grOnline.Size = new System.Drawing.Size(212, 356);
            this.grOnline.TabIndex = 1;
            this.grOnline.Text = "Group";
            this.grOnline.UseVisualStyleBackColor = true;
            // 
            // userOnline
            // 
            this.userOnline.Controls.Add(this.Online);
            this.userOnline.Location = new System.Drawing.Point(4, 25);
            this.userOnline.Name = "userOnline";
            this.userOnline.Padding = new System.Windows.Forms.Padding(3);
            this.userOnline.Size = new System.Drawing.Size(212, 356);
            this.userOnline.TabIndex = 0;
            this.userOnline.Text = "User Online";
            this.userOnline.UseVisualStyleBackColor = true;
            // 
            // butFile
            // 
            this.butFile.Location = new System.Drawing.Point(797, 365);
            this.butFile.Name = "butFile";
            this.butFile.Size = new System.Drawing.Size(76, 73);
            this.butFile.TabIndex = 44;
            this.butFile.Text = "Send File";
            this.butFile.UseVisualStyleBackColor = true;
            this.butFile.Click += new System.EventHandler(this.butFile_Click);
            // 
            // lstGroup
            // 
            this.lstGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstGroup.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lstGroup.FormattingEnabled = true;
            this.lstGroup.Location = new System.Drawing.Point(2, 6);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.Size = new System.Drawing.Size(209, 344);
            this.lstGroup.TabIndex = 40;
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(808, 51);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(72, 48);
            this.butExit.TabIndex = 45;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(892, 513);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butFile);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.butConnect);
            this.Name = "Client";
            this.Text = "Chat Client";
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.grOnline.ResumeLayout(false);
            this.userOnline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox Online;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Button butConnect;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage grOnline;
        private System.Windows.Forms.TabPage userOnline;
        private System.Windows.Forms.Button butFile;
        private System.Windows.Forms.CheckedListBox lstGroup;
        private System.Windows.Forms.Button butExit;
    }
}

