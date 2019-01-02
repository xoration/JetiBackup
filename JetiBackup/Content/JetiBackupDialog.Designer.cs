namespace JetiBackup
{
    partial class JetiBackupDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JetiBackupDialog));
            this.btn_fullBackup = new System.Windows.Forms.Button();
            this.cb_sdBackupMode = new System.Windows.Forms.ComboBox();
            this.cb_sdBackupFrequency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_lastFullBackup = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_modelBackupFrequency = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_modelBackupMode = new System.Windows.Forms.ComboBox();
            this.btn_modelBackup = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_lastModelBackup = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_logBackupFolder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_sdBackupFolder = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_modelBackupFolder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_sdBackupDir = new System.Windows.Forms.Button();
            this.btn_jetiDrive = new System.Windows.Forms.Button();
            this.txt_backupDirectory = new System.Windows.Forms.TextBox();
            this.txt_jetiDrive = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_logBackup = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_logBackupFrequency = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cb_logBackupMode = new System.Windows.Forms.ComboBox();
            this.notifyIconContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_fullBackup
            // 
            this.btn_fullBackup.Location = new System.Drawing.Point(330, 292);
            this.btn_fullBackup.Name = "btn_fullBackup";
            this.btn_fullBackup.Size = new System.Drawing.Size(87, 23);
            this.btn_fullBackup.TabIndex = 2;
            this.btn_fullBackup.Text = "Full Backup";
            this.btn_fullBackup.UseVisualStyleBackColor = true;
            // 
            // cb_sdBackupMode
            // 
            this.cb_sdBackupMode.FormattingEnabled = true;
            this.cb_sdBackupMode.Location = new System.Drawing.Point(72, 20);
            this.cb_sdBackupMode.Name = "cb_sdBackupMode";
            this.cb_sdBackupMode.Size = new System.Drawing.Size(108, 21);
            this.cb_sdBackupMode.TabIndex = 13;
            // 
            // cb_sdBackupFrequency
            // 
            this.cb_sdBackupFrequency.FormattingEnabled = true;
            this.cb_sdBackupFrequency.Location = new System.Drawing.Point(72, 47);
            this.cb_sdBackupFrequency.Name = "cb_sdBackupFrequency";
            this.cb_sdBackupFrequency.Size = new System.Drawing.Size(108, 21);
            this.cb_sdBackupFrequency.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mode:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Frequency:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Last Full Backup:";
            // 
            // lbl_lastFullBackup
            // 
            this.lbl_lastFullBackup.AutoSize = true;
            this.lbl_lastFullBackup.Location = new System.Drawing.Point(124, 261);
            this.lbl_lastFullBackup.Name = "lbl_lastFullBackup";
            this.lbl_lastFullBackup.Size = new System.Drawing.Size(36, 13);
            this.lbl_lastFullBackup.TabIndex = 18;
            this.lbl_lastFullBackup.Text = "Never";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyIconContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Jeti Backup";
            this.notifyIcon.Visible = true;
            // 
            // notifyIconContextMenu
            // 
            this.notifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullBackupToolStripMenuItem,
            this.modelBackupToolStripMenuItem,
            this.logBackupToolStripMenuItem,
            this.configureToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.notifyIconContextMenu.Name = "notifyIconContextMenu";
            this.notifyIconContextMenu.Size = new System.Drawing.Size(151, 114);
            // 
            // fullBackupToolStripMenuItem
            // 
            this.fullBackupToolStripMenuItem.Name = "fullBackupToolStripMenuItem";
            this.fullBackupToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.fullBackupToolStripMenuItem.Text = "Full Backup";
            // 
            // modelBackupToolStripMenuItem
            // 
            this.modelBackupToolStripMenuItem.Name = "modelBackupToolStripMenuItem";
            this.modelBackupToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.modelBackupToolStripMenuItem.Text = "Model Backup";
            // 
            // logBackupToolStripMenuItem
            // 
            this.logBackupToolStripMenuItem.Name = "logBackupToolStripMenuItem";
            this.logBackupToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.logBackupToolStripMenuItem.Text = "Log Backup";
            // 
            // configureToolStripMenuItem
            // 
            this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
            this.configureToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.configureToolStripMenuItem.Text = "Configure";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_sdBackupMode);
            this.groupBox1.Controls.Add(this.cb_sdBackupFrequency);
            this.groupBox1.Location = new System.Drawing.Point(15, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 83);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SD Card";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_modelBackupFrequency);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cb_modelBackupMode);
            this.groupBox2.Location = new System.Drawing.Point(210, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 83);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Models";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Frequency:";
            // 
            // cb_modelBackupFrequency
            // 
            this.cb_modelBackupFrequency.FormattingEnabled = true;
            this.cb_modelBackupFrequency.Location = new System.Drawing.Point(78, 47);
            this.cb_modelBackupFrequency.Name = "cb_modelBackupFrequency";
            this.cb_modelBackupFrequency.Size = new System.Drawing.Size(108, 21);
            this.cb_modelBackupFrequency.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mode:";
            // 
            // cb_modelBackupMode
            // 
            this.cb_modelBackupMode.FormattingEnabled = true;
            this.cb_modelBackupMode.Location = new System.Drawing.Point(78, 20);
            this.cb_modelBackupMode.Name = "cb_modelBackupMode";
            this.cb_modelBackupMode.Size = new System.Drawing.Size(108, 21);
            this.cb_modelBackupMode.TabIndex = 17;
            // 
            // btn_modelBackup
            // 
            this.btn_modelBackup.Location = new System.Drawing.Point(423, 292);
            this.btn_modelBackup.Name = "btn_modelBackup";
            this.btn_modelBackup.Size = new System.Drawing.Size(87, 23);
            this.btn_modelBackup.TabIndex = 24;
            this.btn_modelBackup.Text = "Model Backup";
            this.btn_modelBackup.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Last Model Backup:";
            // 
            // lbl_lastModelBackup
            // 
            this.lbl_lastModelBackup.AutoSize = true;
            this.lbl_lastModelBackup.Location = new System.Drawing.Point(124, 283);
            this.lbl_lastModelBackup.Name = "lbl_lastModelBackup";
            this.lbl_lastModelBackup.Size = new System.Drawing.Size(36, 13);
            this.lbl_lastModelBackup.TabIndex = 26;
            this.lbl_lastModelBackup.Text = "Never";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_logBackupFolder);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txt_sdBackupFolder);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txt_modelBackupFolder);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btn_sdBackupDir);
            this.groupBox3.Controls.Add(this.btn_jetiDrive);
            this.groupBox3.Controls.Add(this.txt_backupDirectory);
            this.groupBox3.Controls.Add(this.txt_jetiDrive);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(15, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(593, 149);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            // 
            // txt_logBackupFolder
            // 
            this.txt_logBackupFolder.Location = new System.Drawing.Point(123, 118);
            this.txt_logBackupFolder.Name = "txt_logBackupFolder";
            this.txt_logBackupFolder.Size = new System.Drawing.Size(426, 20);
            this.txt_logBackupFolder.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Log Backup Folder:";
            // 
            // txt_sdBackupFolder
            // 
            this.txt_sdBackupFolder.Location = new System.Drawing.Point(123, 92);
            this.txt_sdBackupFolder.Name = "txt_sdBackupFolder";
            this.txt_sdBackupFolder.Size = new System.Drawing.Size(426, 20);
            this.txt_sdBackupFolder.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "SD Backup Folder:";
            // 
            // txt_modelBackupFolder
            // 
            this.txt_modelBackupFolder.Location = new System.Drawing.Point(123, 66);
            this.txt_modelBackupFolder.Name = "txt_modelBackupFolder";
            this.txt_modelBackupFolder.Size = new System.Drawing.Size(426, 20);
            this.txt_modelBackupFolder.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Model Backup Folder:";
            // 
            // btn_sdBackupDir
            // 
            this.btn_sdBackupDir.Location = new System.Drawing.Point(555, 40);
            this.btn_sdBackupDir.Name = "btn_sdBackupDir";
            this.btn_sdBackupDir.Size = new System.Drawing.Size(28, 23);
            this.btn_sdBackupDir.TabIndex = 28;
            this.btn_sdBackupDir.Text = "...";
            this.btn_sdBackupDir.UseVisualStyleBackColor = true;
            // 
            // btn_jetiDrive
            // 
            this.btn_jetiDrive.Location = new System.Drawing.Point(555, 11);
            this.btn_jetiDrive.Name = "btn_jetiDrive";
            this.btn_jetiDrive.Size = new System.Drawing.Size(28, 23);
            this.btn_jetiDrive.TabIndex = 27;
            this.btn_jetiDrive.Text = "...";
            this.btn_jetiDrive.UseVisualStyleBackColor = true;
            // 
            // txt_backupDirectory
            // 
            this.txt_backupDirectory.Location = new System.Drawing.Point(123, 40);
            this.txt_backupDirectory.Name = "txt_backupDirectory";
            this.txt_backupDirectory.Size = new System.Drawing.Size(426, 20);
            this.txt_backupDirectory.TabIndex = 26;
            // 
            // txt_jetiDrive
            // 
            this.txt_jetiDrive.Location = new System.Drawing.Point(123, 13);
            this.txt_jetiDrive.Name = "txt_jetiDrive";
            this.txt_jetiDrive.Size = new System.Drawing.Size(426, 20);
            this.txt_jetiDrive.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Backup Directory:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Jeti Drive:";
            // 
            // btn_logBackup
            // 
            this.btn_logBackup.Location = new System.Drawing.Point(516, 292);
            this.btn_logBackup.Name = "btn_logBackup";
            this.btn_logBackup.Size = new System.Drawing.Size(87, 23);
            this.btn_logBackup.TabIndex = 29;
            this.btn_logBackup.Text = "Log Backup";
            this.btn_logBackup.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.cb_logBackupFrequency);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cb_logBackupMode);
            this.groupBox4.Location = new System.Drawing.Point(412, 168);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(196, 83);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Logs";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Frequency:";
            // 
            // cb_logBackupFrequency
            // 
            this.cb_logBackupFrequency.FormattingEnabled = true;
            this.cb_logBackupFrequency.Location = new System.Drawing.Point(78, 47);
            this.cb_logBackupFrequency.Name = "cb_logBackupFrequency";
            this.cb_logBackupFrequency.Size = new System.Drawing.Size(108, 21);
            this.cb_logBackupFrequency.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "Mode:";
            // 
            // cb_logBackupMode
            // 
            this.cb_logBackupMode.FormattingEnabled = true;
            this.cb_logBackupMode.Location = new System.Drawing.Point(78, 20);
            this.cb_logBackupMode.Name = "cb_logBackupMode";
            this.cb_logBackupMode.Size = new System.Drawing.Size(108, 21);
            this.cb_logBackupMode.TabIndex = 17;
            // 
            // JetiBackupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 327);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_logBackup);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbl_lastModelBackup);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_modelBackup);
            this.Controls.Add(this.btn_fullBackup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_lastFullBackup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JetiBackupDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jeti Backup";
            this.notifyIconContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_fullBackup;
        private System.Windows.Forms.ComboBox cb_sdBackupMode;
        private System.Windows.Forms.ComboBox cb_sdBackupFrequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_lastFullBackup;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_modelBackupFrequency;
        private System.Windows.Forms.ComboBox cb_modelBackupMode;
        private System.Windows.Forms.Button btn_modelBackup;
        private System.Windows.Forms.ContextMenuStrip notifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem fullBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_lastModelBackup;
        private System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_logBackupFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_sdBackupFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_modelBackupFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_sdBackupDir;
        private System.Windows.Forms.Button btn_jetiDrive;
        private System.Windows.Forms.TextBox txt_backupDirectory;
        private System.Windows.Forms.TextBox txt_jetiDrive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem logBackupToolStripMenuItem;
        private System.Windows.Forms.Button btn_logBackup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_logBackupFrequency;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cb_logBackupMode;
    }
}

