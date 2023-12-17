
namespace ElvUI_profile_backup
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            Backup = new TabPage();
            Automatic_Backup = new Button();
            Manual_Backup = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            Restore = new TabPage();
            Undo_restore_btn = new Button();
            Restore_btn = new Button();
            label4 = new Label();
            listBox1 = new ListBox();
            Settings = new TabPage();
            label6 = new Label();
            label5 = new Label();
            Backup_folder_browse = new Button();
            Backup_folder_text = new TextBox();
            label3 = new Label();
            WOW_folder_browse = new Button();
            wow_folder_text = new TextBox();
            label1 = new Label();
            wow_folder_browse_diag = new FolderBrowserDialog();
            backup_folder_browse_diag = new FolderBrowserDialog();
            tabControl1.SuspendLayout();
            Backup.SuspendLayout();
            groupBox1.SuspendLayout();
            Restore.SuspendLayout();
            Settings.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Backup);
            tabControl1.Controls.Add(Restore);
            tabControl1.Controls.Add(Settings);
            tabControl1.Location = new Point(1, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(797, 451);
            tabControl1.TabIndex = 0;
            tabControl1.MouseClick += tabControl1_SelectedIndexChanged;
            // 
            // Backup
            // 
            Backup.Controls.Add(Automatic_Backup);
            Backup.Controls.Add(Manual_Backup);
            Backup.Controls.Add(groupBox1);
            Backup.Location = new Point(4, 24);
            Backup.Name = "Backup";
            Backup.Padding = new Padding(3);
            Backup.Size = new Size(789, 423);
            Backup.TabIndex = 0;
            Backup.Text = "Backup";
            Backup.UseVisualStyleBackColor = true;
            // 
            // Automatic_Backup
            // 
            Automatic_Backup.Location = new Point(261, 145);
            Automatic_Backup.Name = "Automatic_Backup";
            Automatic_Backup.Size = new Size(172, 47);
            Automatic_Backup.TabIndex = 8;
            Automatic_Backup.Text = "Automatic Backup";
            Automatic_Backup.UseVisualStyleBackColor = true;
            Automatic_Backup.Click += Auto_Backup_Click;
            // 
            // Manual_Backup
            // 
            Manual_Backup.Location = new Point(59, 145);
            Manual_Backup.Name = "Manual_Backup";
            Manual_Backup.Size = new Size(172, 47);
            Manual_Backup.TabIndex = 7;
            Manual_Backup.Text = "Manual Backup";
            Manual_Backup.UseVisualStyleBackColor = true;
            Manual_Backup.Click += Manual_Backup_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Location = new Point(7, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(631, 110);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Frequency of backup";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(140, 19);
            label2.MaximumSize = new Size(500, 0);
            label2.Name = "label2";
            label2.Size = new Size(482, 45);
            label2.TabIndex = 3;
            label2.Text = "Select a frequency for your automatic update and a scheduled task will be created for that frequency.\r\n\r\n";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(20, 81);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(71, 19);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Monthly";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(20, 56);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(64, 19);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Weekly";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(20, 31);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(52, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Daily";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            // 
            // Restore
            // 
            Restore.Controls.Add(Undo_restore_btn);
            Restore.Controls.Add(Restore_btn);
            Restore.Controls.Add(label4);
            Restore.Controls.Add(listBox1);
            Restore.Location = new Point(4, 24);
            Restore.Name = "Restore";
            Restore.Padding = new Padding(3);
            Restore.Size = new Size(789, 423);
            Restore.TabIndex = 1;
            Restore.Text = "Restore";
            Restore.UseVisualStyleBackColor = true;
            // 
            // Undo_restore_btn
            // 
            Undo_restore_btn.Location = new Point(617, 303);
            Undo_restore_btn.Name = "Undo_restore_btn";
            Undo_restore_btn.Size = new Size(166, 45);
            Undo_restore_btn.TabIndex = 3;
            Undo_restore_btn.Text = "Undo Restore";
            Undo_restore_btn.UseVisualStyleBackColor = true;
            Undo_restore_btn.Click += Undo_restore_btn_Click;
            // 
            // Restore_btn
            // 
            Restore_btn.Location = new Point(7, 303);
            Restore_btn.Name = "Restore_btn";
            Restore_btn.Size = new Size(166, 45);
            Restore_btn.TabIndex = 2;
            Restore_btn.Text = "Restore";
            Restore_btn.UseVisualStyleBackColor = true;
            Restore_btn.Click += Restore_btn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 5);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 1;
            label4.Text = "Available Backups";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(7, 23);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(776, 274);
            listBox1.TabIndex = 0;
            // 
            // Settings
            // 
            Settings.Controls.Add(label6);
            Settings.Controls.Add(label5);
            Settings.Controls.Add(Backup_folder_browse);
            Settings.Controls.Add(Backup_folder_text);
            Settings.Controls.Add(label3);
            Settings.Controls.Add(WOW_folder_browse);
            Settings.Controls.Add(wow_folder_text);
            Settings.Controls.Add(label1);
            Settings.Location = new Point(4, 24);
            Settings.Name = "Settings";
            Settings.Size = new Size(789, 423);
            Settings.TabIndex = 2;
            Settings.Text = "Settings";
            Settings.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 104);
            label6.Name = "label6";
            label6.Size = new Size(429, 15);
            label6.TabIndex = 10;
            label6.Text = "Once changed here your settings should persist through closing the application.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 89);
            label5.Name = "label5";
            label5.Size = new Size(746, 15);
            label5.TabIndex = 9;
            label5.Text = "WOW folder should point to the _retail_ folder location, Backup folder can point to whatever directory you want to use for the backup folder.";
            // 
            // Backup_folder_browse
            // 
            Backup_folder_browse.Location = new Point(644, 40);
            Backup_folder_browse.Name = "Backup_folder_browse";
            Backup_folder_browse.Size = new Size(75, 23);
            Backup_folder_browse.TabIndex = 8;
            Backup_folder_browse.Text = "Browse";
            Backup_folder_browse.UseVisualStyleBackColor = true;
            Backup_folder_browse.Click += Backup_folder_browse_Click;
            // 
            // Backup_folder_text
            // 
            Backup_folder_text.Location = new Point(85, 40);
            Backup_folder_text.Name = "Backup_folder_text";
            Backup_folder_text.PlaceholderText = "C:\\ElvUI_BU";
            Backup_folder_text.Size = new Size(553, 23);
            Backup_folder_text.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 48);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 6;
            label3.Text = "Backup folder";
            // 
            // WOW_folder_browse
            // 
            WOW_folder_browse.Location = new Point(644, 6);
            WOW_folder_browse.Name = "WOW_folder_browse";
            WOW_folder_browse.Size = new Size(75, 23);
            WOW_folder_browse.TabIndex = 2;
            WOW_folder_browse.Text = "Browse";
            WOW_folder_browse.UseVisualStyleBackColor = true;
            WOW_folder_browse.Click += WOW_folder_browse_Click;
            // 
            // wow_folder_text
            // 
            wow_folder_text.Location = new Point(85, 6);
            wow_folder_text.Name = "wow_folder_text";
            wow_folder_text.PlaceholderText = "C:\\Program Files (x86)\\World of Warcraft\\_retail_";
            wow_folder_text.Size = new Size(553, 23);
            wow_folder_text.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 14);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "WOW folder";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ElvUI Backup tool";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            Backup.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Restore.ResumeLayout(false);
            Restore.PerformLayout();
            Settings.ResumeLayout(false);
            Settings.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private TabControl tabControl1;
        private TabPage Backup;
        private TabPage Restore;
        private TabPage Settings;
        private Button WOW_folder_browse;
        private TextBox wow_folder_text;
        private Label label1;
        private FolderBrowserDialog wow_folder_browse_diag;
        private FolderBrowserDialog backup_folder_browse_diag;
        private Button Backup_folder_browse;
        private TextBox Backup_folder_text;
        private Label label3;
        private GroupBox groupBox1;
        private Label label2;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button Automatic_Backup;
        private Button Manual_Backup;
        private Label label4;
        private ListBox listBox1;
        private Button Undo_restore_btn;
        private Button Restore_btn;
        private Label label6;
        private Label label5;
    }
}
