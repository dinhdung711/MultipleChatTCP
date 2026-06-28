namespace CuoiKiLTMServer
{
    partial class Server
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
            this.butSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.lbStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.butStart = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.butFile = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.userOnline = new System.Windows.Forms.TabPage();
            this.lstUser = new System.Windows.Forms.ListBox();
            this.grOnline = new System.Windows.Forms.TabPage();
            this.lstGroup = new System.Windows.Forms.ListBox();
            this.butExit = new System.Windows.Forms.Button();
            this.butCreatGroup = new System.Windows.Forms.Button();
            this.butDeleteGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.tabControl.SuspendLayout();
            this.userOnline.SuspendLayout();
            this.grOnline.SuspendLayout();
            this.SuspendLayout();
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
            this.butSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.butSend_KeyPress);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(245, 463);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(546, 22);
            this.txtMessage.TabIndex = 35;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // txtBox
            // 
            this.txtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBox.BackColor = System.Drawing.SystemColors.Menu;
            this.txtBox.Location = new System.Drawing.Point(245, 113);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(546, 344);
            this.txtBox.TabIndex = 34;
            // 
            // numPort
            // 
            this.numPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numPort.Location = new System.Drawing.Point(604, 8);
            this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(123, 22);
            this.numPort.TabIndex = 33;
            this.numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numPort.Value = new decimal(new int[] {
            12345,
            0,
            0,
            0});
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbStatus.BackColor = System.Drawing.SystemColors.Info;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(490, 75);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(292, 28);
            this.lbStatus.TabIndex = 32;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStatus.Click += new System.EventHandler(this.lbStatus_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(396, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 28);
            this.label1.TabIndex = 31;
            this.label1.Text = "Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPort
            // 
            this.lbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(517, 4);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(70, 30);
            this.lbPort.TabIndex = 30;
            this.lbPort.Text = "Port";
            this.lbPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // butStart
            // 
            this.butStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butStart.Location = new System.Drawing.Point(752, 0);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(128, 34);
            this.butStart.TabIndex = 29;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // lbUser
            // 
            this.lbUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbUser.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(245, 85);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(156, 25);
            this.lbUser.TabIndex = 38;
            // 
            // butFile
            // 
            this.butFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butFile.Location = new System.Drawing.Point(797, 364);
            this.butFile.Name = "butFile";
            this.butFile.Size = new System.Drawing.Size(76, 74);
            this.butFile.TabIndex = 39;
            this.butFile.Text = "Send File";
            this.butFile.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.userOnline);
            this.tabControl.Controls.Add(this.grOnline);
            this.tabControl.Location = new System.Drawing.Point(12, 94);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(220, 372);
            this.tabControl.TabIndex = 40;
            // 
            // userOnline
            // 
            this.userOnline.Controls.Add(this.lstUser);
            this.userOnline.Location = new System.Drawing.Point(4, 25);
            this.userOnline.Name = "userOnline";
            this.userOnline.Padding = new System.Windows.Forms.Padding(3);
            this.userOnline.Size = new System.Drawing.Size(212, 343);
            this.userOnline.TabIndex = 0;
            this.userOnline.Text = "User Online";
            this.userOnline.UseVisualStyleBackColor = true;
            // 
            // lstUser
            // 
            this.lstUser.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstUser.FormattingEnabled = true;
            this.lstUser.ItemHeight = 16;
            this.lstUser.Location = new System.Drawing.Point(6, 6);
            this.lstUser.Name = "lstUser";
            this.lstUser.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstUser.Size = new System.Drawing.Size(200, 324);
            this.lstUser.TabIndex = 0;
            this.lstUser.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // grOnline
            // 
            this.grOnline.Controls.Add(this.lstGroup);
            this.grOnline.Location = new System.Drawing.Point(4, 25);
            this.grOnline.Name = "grOnline";
            this.grOnline.Padding = new System.Windows.Forms.Padding(3);
            this.grOnline.Size = new System.Drawing.Size(212, 343);
            this.grOnline.TabIndex = 1;
            this.grOnline.Text = "Group";
            this.grOnline.UseVisualStyleBackColor = true;
            // 
            // lstGroup
            // 
            this.lstGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstGroup.FormattingEnabled = true;
            this.lstGroup.ItemHeight = 16;
            this.lstGroup.Location = new System.Drawing.Point(6, 9);
            this.lstGroup.Name = "lstGroup";
            this.lstGroup.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstGroup.Size = new System.Drawing.Size(200, 324);
            this.lstGroup.TabIndex = 1;
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(808, 40);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(72, 48);
            this.butExit.TabIndex = 46;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butCreatGroup
            // 
            this.butCreatGroup.Location = new System.Drawing.Point(797, 290);
            this.butCreatGroup.Name = "butCreatGroup";
            this.butCreatGroup.Size = new System.Drawing.Size(76, 68);
            this.butCreatGroup.TabIndex = 47;
            this.butCreatGroup.Text = "Creat Group";
            this.butCreatGroup.UseVisualStyleBackColor = true;
            // 
            // butDeleteGroup
            // 
            this.butDeleteGroup.Location = new System.Drawing.Point(797, 216);
            this.butDeleteGroup.Name = "butDeleteGroup";
            this.butDeleteGroup.Size = new System.Drawing.Size(76, 68);
            this.butDeleteGroup.TabIndex = 48;
            this.butDeleteGroup.Text = "Delete Group";
            this.butDeleteGroup.UseVisualStyleBackColor = true;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(892, 513);
            this.Controls.Add(this.butDeleteGroup);
            this.Controls.Add(this.butCreatGroup);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.butFile);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.butSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.butStart);
            this.Name = "Server";
            this.Text = "Server Chat";
            this.Load += new System.EventHandler(this.Server_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.userOnline.ResumeLayout(false);
            this.grOnline.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Button butFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage userOnline;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.TabPage grOnline;
        private System.Windows.Forms.Button butCreatGroup;
        private System.Windows.Forms.Button butDeleteGroup;
        private System.Windows.Forms.ListBox lstUser;
        private System.Windows.Forms.ListBox lstGroup;
    }
}

