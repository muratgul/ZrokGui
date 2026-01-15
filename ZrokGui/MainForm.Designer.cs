namespace ZrokGui
{
    partial class MainForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPublicShare = new System.Windows.Forms.TabPage();
            this.btnPublicStop = new System.Windows.Forms.Button();
            this.btnRe = new System.Windows.Forms.Button();
            this.btnPublicShare = new System.Windows.Forms.Button();
            this.chkPublicAuth = new System.Windows.Forms.CheckBox();
            this.cmbPublicBackend = new System.Windows.Forms.ComboBox();
            this.txtPublicPassword = new System.Windows.Forms.TextBox();
            this.txtPublicOutput = new System.Windows.Forms.TextBox();
            this.txtPublicUsername = new System.Windows.Forms.TextBox();
            this.txtPublicTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPrivateShare = new System.Windows.Forms.TabPage();
            this.btnPrivateStop = new System.Windows.Forms.Button();
            this.btnPrivateShare = new System.Windows.Forms.Button();
            this.cmbPrivateBackend = new System.Windows.Forms.ComboBox();
            this.txtPrivateOutput = new System.Windows.Forms.TextBox();
            this.txtPrivateTarget = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabFileShare = new System.Windows.Forms.TabPage();
            this.btnFileStop = new System.Windows.Forms.Button();
            this.btnFileShare = new System.Windows.Forms.Button();
            this.cmbFileMode = new System.Windows.Forms.ComboBox();
            this.rbFilePrivate = new System.Windows.Forms.RadioButton();
            this.rbFilePublic = new System.Windows.Forms.RadioButton();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.txtFileOutput = new System.Windows.Forms.TextBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFolder = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnBrowseZrok = new System.Windows.Forms.Button();
            this.txtStatusOutput = new System.Windows.Forms.TextBox();
            this.txtEnableToken = new System.Windows.Forms.TextBox();
            this.txtZrokPath = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabReserve = new System.Windows.Forms.TabPage();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.btnStartReserved = new System.Windows.Forms.Button();
            this.btnDeleteReserve = new System.Windows.Forms.Button();
            this.btnStopReserved = new System.Windows.Forms.Button();
            this.btnRefreshReserves = new System.Windows.Forms.Button();
            this.lvReservedShares = new System.Windows.Forms.ListView();
            this.Token = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UrlTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.txtReserveOutput = new System.Windows.Forms.TextBox();
            this.btnCreateReserve = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtReserveTarget = new System.Windows.Forms.TextBox();
            this.cmbReserveBackend = new System.Windows.Forms.ComboBox();
            this.cmbReserveType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPublicShare.SuspendLayout();
            this.tabPrivateShare.SuspendLayout();
            this.tabFileShare.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabReserve.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPublicShare);
            this.tabControl.Controls.Add(this.tabPrivateShare);
            this.tabControl.Controls.Add(this.tabFileShare);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.Controls.Add(this.tabReserve);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 542);
            this.tabControl.TabIndex = 0;
            // 
            // tabPublicShare
            // 
            this.tabPublicShare.Controls.Add(this.btnPublicStop);
            this.tabPublicShare.Controls.Add(this.btnRe);
            this.tabPublicShare.Controls.Add(this.btnPublicShare);
            this.tabPublicShare.Controls.Add(this.chkPublicAuth);
            this.tabPublicShare.Controls.Add(this.cmbPublicBackend);
            this.tabPublicShare.Controls.Add(this.txtPublicPassword);
            this.tabPublicShare.Controls.Add(this.txtPublicOutput);
            this.tabPublicShare.Controls.Add(this.txtPublicUsername);
            this.tabPublicShare.Controls.Add(this.txtPublicTarget);
            this.tabPublicShare.Controls.Add(this.label2);
            this.tabPublicShare.Controls.Add(this.label5);
            this.tabPublicShare.Controls.Add(this.label4);
            this.tabPublicShare.Controls.Add(this.label3);
            this.tabPublicShare.Controls.Add(this.label1);
            this.tabPublicShare.Location = new System.Drawing.Point(4, 22);
            this.tabPublicShare.Name = "tabPublicShare";
            this.tabPublicShare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPublicShare.Size = new System.Drawing.Size(768, 516);
            this.tabPublicShare.TabIndex = 0;
            this.tabPublicShare.Text = "Public Share";
            this.tabPublicShare.UseVisualStyleBackColor = true;
            // 
            // btnPublicStop
            // 
            this.btnPublicStop.Enabled = false;
            this.btnPublicStop.Location = new System.Drawing.Point(147, 178);
            this.btnPublicStop.Name = "btnPublicStop";
            this.btnPublicStop.Size = new System.Drawing.Size(118, 23);
            this.btnPublicStop.TabIndex = 4;
            this.btnPublicStop.Text = "Stop";
            this.btnPublicStop.UseVisualStyleBackColor = true;
            this.btnPublicStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnRe
            // 
            this.btnRe.Location = new System.Drawing.Point(542, 104);
            this.btnRe.Name = "btnRe";
            this.btnRe.Size = new System.Drawing.Size(118, 23);
            this.btnRe.TabIndex = 4;
            this.btnRe.Text = "Start Sharing";
            this.btnRe.UseVisualStyleBackColor = true;
            this.btnRe.Click += new System.EventHandler(this.BtnPublicShare_Click);
            // 
            // btnPublicShare
            // 
            this.btnPublicShare.Location = new System.Drawing.Point(23, 178);
            this.btnPublicShare.Name = "btnPublicShare";
            this.btnPublicShare.Size = new System.Drawing.Size(118, 23);
            this.btnPublicShare.TabIndex = 4;
            this.btnPublicShare.Text = "Start Sharing";
            this.btnPublicShare.UseVisualStyleBackColor = true;
            this.btnPublicShare.Click += new System.EventHandler(this.BtnPublicShare_Click);
            // 
            // chkPublicAuth
            // 
            this.chkPublicAuth.AutoSize = true;
            this.chkPublicAuth.Location = new System.Drawing.Point(139, 88);
            this.chkPublicAuth.Name = "chkPublicAuth";
            this.chkPublicAuth.Size = new System.Drawing.Size(159, 17);
            this.chkPublicAuth.TabIndex = 3;
            this.chkPublicAuth.Text = "Enable Basic Authentication";
            this.chkPublicAuth.UseVisualStyleBackColor = true;
            this.chkPublicAuth.CheckedChanged += new System.EventHandler(this.ChkPublicAuth_CheckedChanged);
            // 
            // cmbPublicBackend
            // 
            this.cmbPublicBackend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPublicBackend.FormattingEnabled = true;
            this.cmbPublicBackend.Items.AddRange(new object[] {
            "Default",
            "web",
            "tcpTunnel",
            "udpTunnel"});
            this.cmbPublicBackend.Location = new System.Drawing.Point(139, 43);
            this.cmbPublicBackend.Name = "cmbPublicBackend";
            this.cmbPublicBackend.Size = new System.Drawing.Size(189, 21);
            this.cmbPublicBackend.TabIndex = 2;
            // 
            // txtPublicPassword
            // 
            this.txtPublicPassword.Enabled = false;
            this.txtPublicPassword.Location = new System.Drawing.Point(139, 137);
            this.txtPublicPassword.Name = "txtPublicPassword";
            this.txtPublicPassword.PasswordChar = '*';
            this.txtPublicPassword.Size = new System.Drawing.Size(189, 20);
            this.txtPublicPassword.TabIndex = 1;
            // 
            // txtPublicOutput
            // 
            this.txtPublicOutput.BackColor = System.Drawing.Color.Black;
            this.txtPublicOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPublicOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtPublicOutput.Location = new System.Drawing.Point(23, 228);
            this.txtPublicOutput.Multiline = true;
            this.txtPublicOutput.Name = "txtPublicOutput";
            this.txtPublicOutput.ReadOnly = true;
            this.txtPublicOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublicOutput.Size = new System.Drawing.Size(726, 197);
            this.txtPublicOutput.TabIndex = 1;
            // 
            // txtPublicUsername
            // 
            this.txtPublicUsername.Enabled = false;
            this.txtPublicUsername.Location = new System.Drawing.Point(139, 111);
            this.txtPublicUsername.Name = "txtPublicUsername";
            this.txtPublicUsername.Size = new System.Drawing.Size(189, 20);
            this.txtPublicUsername.TabIndex = 1;
            // 
            // txtPublicTarget
            // 
            this.txtPublicTarget.Location = new System.Drawing.Point(140, 20);
            this.txtPublicTarget.Name = "txtPublicTarget";
            this.txtPublicTarget.Size = new System.Drawing.Size(300, 20);
            this.txtPublicTarget.TabIndex = 1;
            this.txtPublicTarget.Text = "localhost:8080";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Backend Mode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target (localhost:port):";
            // 
            // tabPrivateShare
            // 
            this.tabPrivateShare.Controls.Add(this.btnPrivateStop);
            this.tabPrivateShare.Controls.Add(this.btnPrivateShare);
            this.tabPrivateShare.Controls.Add(this.cmbPrivateBackend);
            this.tabPrivateShare.Controls.Add(this.txtPrivateOutput);
            this.tabPrivateShare.Controls.Add(this.txtPrivateTarget);
            this.tabPrivateShare.Controls.Add(this.label6);
            this.tabPrivateShare.Controls.Add(this.label7);
            this.tabPrivateShare.Controls.Add(this.label8);
            this.tabPrivateShare.Location = new System.Drawing.Point(4, 22);
            this.tabPrivateShare.Name = "tabPrivateShare";
            this.tabPrivateShare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrivateShare.Size = new System.Drawing.Size(768, 516);
            this.tabPrivateShare.TabIndex = 1;
            this.tabPrivateShare.Text = "Private Share";
            this.tabPrivateShare.UseVisualStyleBackColor = true;
            // 
            // btnPrivateStop
            // 
            this.btnPrivateStop.Enabled = false;
            this.btnPrivateStop.Location = new System.Drawing.Point(147, 178);
            this.btnPrivateStop.Name = "btnPrivateStop";
            this.btnPrivateStop.Size = new System.Drawing.Size(118, 23);
            this.btnPrivateStop.TabIndex = 11;
            this.btnPrivateStop.Text = "Stop";
            this.btnPrivateStop.UseVisualStyleBackColor = true;
            this.btnPrivateStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnPrivateShare
            // 
            this.btnPrivateShare.Location = new System.Drawing.Point(23, 178);
            this.btnPrivateShare.Name = "btnPrivateShare";
            this.btnPrivateShare.Size = new System.Drawing.Size(118, 23);
            this.btnPrivateShare.TabIndex = 12;
            this.btnPrivateShare.Text = "Start Sharing";
            this.btnPrivateShare.UseVisualStyleBackColor = true;
            this.btnPrivateShare.Click += new System.EventHandler(this.BtnPrivateShare_Click);
            // 
            // cmbPrivateBackend
            // 
            this.cmbPrivateBackend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrivateBackend.FormattingEnabled = true;
            this.cmbPrivateBackend.Items.AddRange(new object[] {
            "Default",
            "web",
            "tcpTunnel",
            "udpTunnel"});
            this.cmbPrivateBackend.Location = new System.Drawing.Point(140, 43);
            this.cmbPrivateBackend.Name = "cmbPrivateBackend";
            this.cmbPrivateBackend.Size = new System.Drawing.Size(189, 21);
            this.cmbPrivateBackend.TabIndex = 10;
            // 
            // txtPrivateOutput
            // 
            this.txtPrivateOutput.BackColor = System.Drawing.Color.Black;
            this.txtPrivateOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPrivateOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtPrivateOutput.Location = new System.Drawing.Point(23, 228);
            this.txtPrivateOutput.Multiline = true;
            this.txtPrivateOutput.Name = "txtPrivateOutput";
            this.txtPrivateOutput.ReadOnly = true;
            this.txtPrivateOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrivateOutput.Size = new System.Drawing.Size(726, 197);
            this.txtPrivateOutput.TabIndex = 8;
            // 
            // txtPrivateTarget
            // 
            this.txtPrivateTarget.Location = new System.Drawing.Point(140, 20);
            this.txtPrivateTarget.Name = "txtPrivateTarget";
            this.txtPrivateTarget.Size = new System.Drawing.Size(300, 20);
            this.txtPrivateTarget.TabIndex = 9;
            this.txtPrivateTarget.Text = "localhost:8080";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Backend Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(230, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Output (Share this token with authorized users):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Target";
            // 
            // tabFileShare
            // 
            this.tabFileShare.Controls.Add(this.btnFileStop);
            this.tabFileShare.Controls.Add(this.btnFileShare);
            this.tabFileShare.Controls.Add(this.cmbFileMode);
            this.tabFileShare.Controls.Add(this.rbFilePrivate);
            this.tabFileShare.Controls.Add(this.rbFilePublic);
            this.tabFileShare.Controls.Add(this.btnBrowseFolder);
            this.tabFileShare.Controls.Add(this.txtFileOutput);
            this.tabFileShare.Controls.Add(this.txtFilePath);
            this.tabFileShare.Controls.Add(this.label11);
            this.tabFileShare.Controls.Add(this.label12);
            this.tabFileShare.Controls.Add(this.label10);
            this.tabFileShare.Controls.Add(this.label9);
            this.tabFileShare.Controls.Add(this.lblFolder);
            this.tabFileShare.Location = new System.Drawing.Point(4, 22);
            this.tabFileShare.Name = "tabFileShare";
            this.tabFileShare.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileShare.Size = new System.Drawing.Size(768, 516);
            this.tabFileShare.TabIndex = 2;
            this.tabFileShare.Text = "File Share";
            this.tabFileShare.UseVisualStyleBackColor = true;
            // 
            // btnFileStop
            // 
            this.btnFileStop.Enabled = false;
            this.btnFileStop.Location = new System.Drawing.Point(176, 245);
            this.btnFileStop.Name = "btnFileStop";
            this.btnFileStop.Size = new System.Drawing.Size(150, 35);
            this.btnFileStop.TabIndex = 14;
            this.btnFileStop.Text = "Stop";
            this.btnFileStop.UseVisualStyleBackColor = true;
            this.btnFileStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnFileShare
            // 
            this.btnFileShare.Location = new System.Drawing.Point(20, 245);
            this.btnFileShare.Name = "btnFileShare";
            this.btnFileShare.Size = new System.Drawing.Size(150, 35);
            this.btnFileShare.TabIndex = 14;
            this.btnFileShare.Text = "Start File Sharing";
            this.btnFileShare.UseVisualStyleBackColor = true;
            this.btnFileShare.Click += new System.EventHandler(this.BtnFileShare_Click);
            // 
            // cmbFileMode
            // 
            this.cmbFileMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileMode.FormattingEnabled = true;
            this.cmbFileMode.Items.AddRange(new object[] {
            "web",
            "drive"});
            this.cmbFileMode.Location = new System.Drawing.Point(20, 195);
            this.cmbFileMode.Name = "cmbFileMode";
            this.cmbFileMode.Size = new System.Drawing.Size(200, 21);
            this.cmbFileMode.TabIndex = 13;
            // 
            // rbFilePrivate
            // 
            this.rbFilePrivate.AutoSize = true;
            this.rbFilePrivate.Location = new System.Drawing.Point(20, 135);
            this.rbFilePrivate.Name = "rbFilePrivate";
            this.rbFilePrivate.Size = new System.Drawing.Size(139, 17);
            this.rbFilePrivate.TabIndex = 12;
            this.rbFilePrivate.Text = "Private (Token required)";
            this.rbFilePrivate.UseVisualStyleBackColor = true;
            // 
            // rbFilePublic
            // 
            this.rbFilePublic.AutoSize = true;
            this.rbFilePublic.Checked = true;
            this.rbFilePublic.Location = new System.Drawing.Point(20, 110);
            this.rbFilePublic.Name = "rbFilePublic";
            this.rbFilePublic.Size = new System.Drawing.Size(140, 17);
            this.rbFilePublic.TabIndex = 12;
            this.rbFilePublic.TabStop = true;
            this.rbFilePublic.Text = "Public (Anyone with link)";
            this.rbFilePublic.UseVisualStyleBackColor = true;
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(530, 43);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(100, 23);
            this.btnBrowseFolder.TabIndex = 11;
            this.btnBrowseFolder.Text = "Browse...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.BtnBrowseFolder_Click);
            // 
            // txtFileOutput
            // 
            this.txtFileOutput.BackColor = System.Drawing.Color.Black;
            this.txtFileOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFileOutput.ForeColor = System.Drawing.Color.LightGreen;
            this.txtFileOutput.Location = new System.Drawing.Point(20, 315);
            this.txtFileOutput.Multiline = true;
            this.txtFileOutput.Name = "txtFileOutput";
            this.txtFileOutput.ReadOnly = true;
            this.txtFileOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFileOutput.Size = new System.Drawing.Size(720, 185);
            this.txtFileOutput.TabIndex = 10;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(20, 45);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(500, 20);
            this.txtFilePath.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(230, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(337, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "web: Browse files in browser drive: Mount as network drive (WebDAV)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Share URL:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "File Mode:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Share Type:";
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(20, 20);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(115, 13);
            this.lblFolder.TabIndex = 0;
            this.lblFolder.Text = "Select Folder to Share:";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.btnStatus);
            this.tabSettings.Controls.Add(this.btnEnable);
            this.tabSettings.Controls.Add(this.btnBrowseZrok);
            this.tabSettings.Controls.Add(this.txtStatusOutput);
            this.tabSettings.Controls.Add(this.txtEnableToken);
            this.tabSettings.Controls.Add(this.txtZrokPath);
            this.tabSettings.Controls.Add(this.label14);
            this.tabSettings.Controls.Add(this.label13);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(768, 516);
            this.tabSettings.TabIndex = 3;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(20, 185);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(150, 35);
            this.btnStatus.TabIndex = 3;
            this.btnStatus.Text = "Check Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.BtnStatus_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Location = new System.Drawing.Point(530, 42);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(150, 23);
            this.btnEnable.TabIndex = 3;
            this.btnEnable.Text = "Enable Account";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.BtnEnable_Click);
            // 
            // btnBrowseZrok
            // 
            this.btnBrowseZrok.Location = new System.Drawing.Point(533, 115);
            this.btnBrowseZrok.Name = "btnBrowseZrok";
            this.btnBrowseZrok.Size = new System.Drawing.Size(100, 23);
            this.btnBrowseZrok.TabIndex = 3;
            this.btnBrowseZrok.Text = "Browse...";
            this.btnBrowseZrok.UseVisualStyleBackColor = true;
            this.btnBrowseZrok.Visible = false;
            this.btnBrowseZrok.Click += new System.EventHandler(this.BtnBrowseZrok_Click);
            // 
            // txtStatusOutput
            // 
            this.txtStatusOutput.BackColor = System.Drawing.Color.White;
            this.txtStatusOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtStatusOutput.Location = new System.Drawing.Point(20, 230);
            this.txtStatusOutput.Multiline = true;
            this.txtStatusOutput.Name = "txtStatusOutput";
            this.txtStatusOutput.ReadOnly = true;
            this.txtStatusOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStatusOutput.Size = new System.Drawing.Size(720, 270);
            this.txtStatusOutput.TabIndex = 2;
            // 
            // txtEnableToken
            // 
            this.txtEnableToken.Location = new System.Drawing.Point(20, 44);
            this.txtEnableToken.Name = "txtEnableToken";
            this.txtEnableToken.PasswordChar = '*';
            this.txtEnableToken.Size = new System.Drawing.Size(500, 20);
            this.txtEnableToken.TabIndex = 2;
            // 
            // txtZrokPath
            // 
            this.txtZrokPath.Location = new System.Drawing.Point(23, 117);
            this.txtZrokPath.Name = "txtZrokPath";
            this.txtZrokPath.Size = new System.Drawing.Size(500, 20);
            this.txtZrokPath.TabIndex = 2;
            this.txtZrokPath.Text = "zrok.exe";
            this.txtZrokPath.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(182, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Enable Token (from zrok.io account):";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "zrok.exe Path:";
            this.label13.Visible = false;
            // 
            // tabReserve
            // 
            this.tabReserve.Controls.Add(this.rightPanel);
            this.tabReserve.Controls.Add(this.leftPanel);
            this.tabReserve.Location = new System.Drawing.Point(4, 22);
            this.tabReserve.Name = "tabReserve";
            this.tabReserve.Padding = new System.Windows.Forms.Padding(3);
            this.tabReserve.Size = new System.Drawing.Size(768, 516);
            this.tabReserve.TabIndex = 4;
            this.tabReserve.Text = "Reserved Shares";
            this.tabReserve.UseVisualStyleBackColor = true;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.btnStartReserved);
            this.rightPanel.Controls.Add(this.btnDeleteReserve);
            this.rightPanel.Controls.Add(this.btnStopReserved);
            this.rightPanel.Controls.Add(this.btnRefreshReserves);
            this.rightPanel.Controls.Add(this.lvReservedShares);
            this.rightPanel.Controls.Add(this.label21);
            this.rightPanel.Controls.Add(this.label20);
            this.rightPanel.Location = new System.Drawing.Point(370, 10);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(370, 500);
            this.rightPanel.TabIndex = 1;
            // 
            // btnStartReserved
            // 
            this.btnStartReserved.Location = new System.Drawing.Point(120, 400);
            this.btnStartReserved.Name = "btnStartReserved";
            this.btnStartReserved.Size = new System.Drawing.Size(70, 30);
            this.btnStartReserved.TabIndex = 4;
            this.btnStartReserved.Text = "Start";
            this.btnStartReserved.UseVisualStyleBackColor = true;
            this.btnStartReserved.Click += new System.EventHandler(this.BtnStartReserved_Click);
            // 
            // btnDeleteReserve
            // 
            this.btnDeleteReserve.Location = new System.Drawing.Point(280, 400);
            this.btnDeleteReserve.Name = "btnDeleteReserve";
            this.btnDeleteReserve.Size = new System.Drawing.Size(70, 30);
            this.btnDeleteReserve.TabIndex = 3;
            this.btnDeleteReserve.Text = "Delete";
            this.btnDeleteReserve.UseVisualStyleBackColor = true;
            this.btnDeleteReserve.Click += new System.EventHandler(this.BtnDeleteReserve_Click);
            // 
            // btnStopReserved
            // 
            this.btnStopReserved.Location = new System.Drawing.Point(200, 400);
            this.btnStopReserved.Name = "btnStopReserved";
            this.btnStopReserved.Size = new System.Drawing.Size(70, 30);
            this.btnStopReserved.TabIndex = 3;
            this.btnStopReserved.Text = "Stop";
            this.btnStopReserved.UseVisualStyleBackColor = true;
            this.btnStopReserved.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnRefreshReserves
            // 
            this.btnRefreshReserves.Location = new System.Drawing.Point(10, 400);
            this.btnRefreshReserves.Name = "btnRefreshReserves";
            this.btnRefreshReserves.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshReserves.TabIndex = 2;
            this.btnRefreshReserves.Text = "Refresh List";
            this.btnRefreshReserves.UseVisualStyleBackColor = true;
            this.btnRefreshReserves.Click += new System.EventHandler(this.BtnRefreshReserves_Click);
            // 
            // lvReservedShares
            // 
            this.lvReservedShares.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Token,
            this.Type,
            this.UrlTarget});
            this.lvReservedShares.FullRowSelect = true;
            this.lvReservedShares.GridLines = true;
            this.lvReservedShares.HideSelection = false;
            this.lvReservedShares.Location = new System.Drawing.Point(10, 40);
            this.lvReservedShares.Name = "lvReservedShares";
            this.lvReservedShares.Size = new System.Drawing.Size(340, 350);
            this.lvReservedShares.TabIndex = 1;
            this.lvReservedShares.UseCompatibleStateImageBehavior = false;
            this.lvReservedShares.View = System.Windows.Forms.View.Details;
            // 
            // Token
            // 
            this.Token.Text = "Token";
            this.Token.Width = 100;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            // 
            // UrlTarget
            // 
            this.UrlTarget.Text = "Url/Target";
            this.UrlTarget.Width = 160;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(10, 440);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(340, 45);
            this.label21.TabIndex = 0;
            this.label21.Text = "Select a reserved share and click \'Start\' to activate it. Click \'Delete\' to remov" +
    "e a reserved share permanently";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(131, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Manage Reserved Shares";
            // 
            // leftPanel
            // 
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Controls.Add(this.txtReserveOutput);
            this.leftPanel.Controls.Add(this.btnCreateReserve);
            this.leftPanel.Controls.Add(this.label19);
            this.leftPanel.Controls.Add(this.txtReserveTarget);
            this.leftPanel.Controls.Add(this.cmbReserveBackend);
            this.leftPanel.Controls.Add(this.cmbReserveType);
            this.leftPanel.Controls.Add(this.label18);
            this.leftPanel.Controls.Add(this.label17);
            this.leftPanel.Controls.Add(this.label16);
            this.leftPanel.Controls.Add(this.label15);
            this.leftPanel.Location = new System.Drawing.Point(10, 10);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(350, 500);
            this.leftPanel.TabIndex = 0;
            // 
            // txtReserveOutput
            // 
            this.txtReserveOutput.BackColor = System.Drawing.Color.Black;
            this.txtReserveOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtReserveOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtReserveOutput.Location = new System.Drawing.Point(10, 300);
            this.txtReserveOutput.Multiline = true;
            this.txtReserveOutput.Name = "txtReserveOutput";
            this.txtReserveOutput.ReadOnly = true;
            this.txtReserveOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReserveOutput.Size = new System.Drawing.Size(320, 180);
            this.txtReserveOutput.TabIndex = 3;
            // 
            // btnCreateReserve
            // 
            this.btnCreateReserve.Location = new System.Drawing.Point(10, 230);
            this.btnCreateReserve.Name = "btnCreateReserve";
            this.btnCreateReserve.Size = new System.Drawing.Size(300, 35);
            this.btnCreateReserve.TabIndex = 3;
            this.btnCreateReserve.Text = "Create Reserved Share";
            this.btnCreateReserve.UseVisualStyleBackColor = true;
            this.btnCreateReserve.Click += new System.EventHandler(this.BtnCreateReserve_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 285);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Output";
            // 
            // txtReserveTarget
            // 
            this.txtReserveTarget.Location = new System.Drawing.Point(10, 190);
            this.txtReserveTarget.Name = "txtReserveTarget";
            this.txtReserveTarget.Size = new System.Drawing.Size(320, 20);
            this.txtReserveTarget.TabIndex = 2;
            this.txtReserveTarget.Text = "localhost:3000";
            // 
            // cmbReserveBackend
            // 
            this.cmbReserveBackend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReserveBackend.FormattingEnabled = true;
            this.cmbReserveBackend.Items.AddRange(new object[] {
            "Default",
            "web",
            "drive",
            "tcpTunnel",
            "udpTunnel"});
            this.cmbReserveBackend.Location = new System.Drawing.Point(10, 130);
            this.cmbReserveBackend.Name = "cmbReserveBackend";
            this.cmbReserveBackend.Size = new System.Drawing.Size(150, 21);
            this.cmbReserveBackend.TabIndex = 1;
            // 
            // cmbReserveType
            // 
            this.cmbReserveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReserveType.FormattingEnabled = true;
            this.cmbReserveType.Items.AddRange(new object[] {
            "public",
            "private"});
            this.cmbReserveType.Location = new System.Drawing.Point(10, 70);
            this.cmbReserveType.Name = "cmbReserveType";
            this.cmbReserveType.Size = new System.Drawing.Size(150, 21);
            this.cmbReserveType.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 165);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(178, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Target (localhost:port or folder path):";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Backend Mode:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 45);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Share Type:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Create New Reserved Share";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 568);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 607);
            this.MinimumSize = new System.Drawing.Size(816, 607);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zrok GUI Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPublicShare.ResumeLayout(false);
            this.tabPublicShare.PerformLayout();
            this.tabPrivateShare.ResumeLayout(false);
            this.tabPrivateShare.PerformLayout();
            this.tabFileShare.ResumeLayout(false);
            this.tabFileShare.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.tabReserve.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPublicShare;
        private System.Windows.Forms.TabPage tabPrivateShare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPublicTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPublicBackend;
        private System.Windows.Forms.CheckBox chkPublicAuth;
        private System.Windows.Forms.TextBox txtPublicUsername;
        private System.Windows.Forms.TextBox txtPublicPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPublicShare;
        private System.Windows.Forms.Button btnPublicStop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPublicOutput;
        private System.Windows.Forms.Button btnPrivateStop;
        private System.Windows.Forms.Button btnPrivateShare;
        private System.Windows.Forms.ComboBox cmbPrivateBackend;
        private System.Windows.Forms.TextBox txtPrivateOutput;
        private System.Windows.Forms.TextBox txtPrivateTarget;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabFileShare;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbFilePublic;
        private System.Windows.Forms.RadioButton rbFilePrivate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbFileMode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnFileShare;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFileOutput;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtZrokPath;
        private System.Windows.Forms.Button btnBrowseZrok;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtEnableToken;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.TextBox txtStatusOutput;
        private System.Windows.Forms.Button btnFileStop;
        private System.Windows.Forms.Button btnRe;
        private System.Windows.Forms.TabPage tabReserve;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.ComboBox cmbReserveType;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbReserveBackend;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCreateReserve;
        private System.Windows.Forms.TextBox txtReserveTarget;
        private System.Windows.Forms.TextBox txtReserveOutput;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.ListView lvReservedShares;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnRefreshReserves;
        private System.Windows.Forms.ColumnHeader Token;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader UrlTarget;
        private System.Windows.Forms.Button btnDeleteReserve;
        private System.Windows.Forms.Button btnStopReserved;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnStartReserved;
    }
}