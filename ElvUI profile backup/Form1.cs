using System.IO.Compression;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace ElvUI_profile_backup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void WOW_folder_browse_Click(object sender, EventArgs e)
        {
            if (wow_folder_browse_diag.ShowDialog() == DialogResult.OK)
            {
                wow_folder_text.Text = wow_folder_browse_diag.SelectedPath;

                // Save the selected folder to user settings
                Properties.Settings.Default.WowFolder = wow_folder_text.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void Backup_folder_browse_Click(object sender, EventArgs e)
        {
            if (backup_folder_browse_diag.ShowDialog() == DialogResult.OK)
            {
                Backup_folder_text.Text = backup_folder_browse_diag.SelectedPath;

                // Save the selected folder to user settings
                Properties.Settings.Default.BackupFolder = Backup_folder_text.Text;
                Properties.Settings.Default.Save();
            }

        }

        // In your form load event or constructor, set the initial values
        private void Form1_Load(object sender, EventArgs e)
        {
            // Retrieve values from user settings
            wow_folder_text.Text = Properties.Settings.Default.WowFolder;
            Backup_folder_text.Text = Properties.Settings.Default.BackupFolder;
        }

        private void tabControl1_SelectedIndexChanged(object sender, MouseEventArgs e)
        {
            var BU_DIR = Backup_folder_text.Text;
            listBox1.Items.Clear();
            if (string.IsNullOrEmpty(Backup_folder_text.Text))
            {
                BU_DIR = Backup_folder_text.PlaceholderText;
            }
            else
            {
                BU_DIR = Backup_folder_text.Text;
            }
            string[] files = Directory.GetFiles(BU_DIR);
            foreach (string file in files)
            {
                listBox1.Items.Add(file);
            }
        }


        private string tempBackupDir;
        private string lastBackupFilePath; // Store the path of the last created backup

        private void CreateTempBackup(string wowDir)
        {
            try
            {
                // Create a temporary backup in the AppData folder
                string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ElvUI Backup Tool");
                tempBackupDir = Path.Combine(appDataFolder, "TempBackup");

                // Ensure the temporary backup directory exists
                Directory.CreateDirectory(tempBackupDir);

                // Delete any existing zip files in the temp backup directory
                foreach (var existingZipFile in Directory.GetFiles(tempBackupDir, "RestoreBackup_*.zip"))
                {
                    File.Delete(existingZipFile);
                }

                // Create a zip file for the backup
                string zipFileName = $"RestoreBackup_{DateTime.Now.ToString("ddMMMyy_HHmm")}.zip";
                lastBackupFilePath = Path.Combine(tempBackupDir, zipFileName); // Store the path
                string zipFilePath = lastBackupFilePath;

                using (var fileStream = new FileStream(zipFilePath, FileMode.Create))
                {
                    using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                    {
                        // Add files to the temporary backup (similar to the manual backup logic)
                        var elvuiLuaFiles = Directory.GetFiles(Path.Combine(wowDir, "WTF", "Account"), "ElvUI*.lua", SearchOption.AllDirectories);

                        foreach (var filePath in elvuiLuaFiles)
                        {
                            var entryName = Path.GetRelativePath(Path.Combine(wowDir, "WTF", "Account"), filePath);
                            archive.CreateEntryFromFile(filePath, entryName);
                        }
                    }
                }

                MessageBox.Show("Restore backup created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RestoreFromBackup(string wowDir, string selectedZipFile)
        {
            try
            {
                // Extract the selected item from ListBox1 to the WoW directory
                if (!string.IsNullOrEmpty(selectedZipFile))
                {

                    using (var archive = ZipFile.OpenRead(selectedZipFile))
                    {
                        foreach (var entry in archive.Entries)
                        {
                            var entryDestination = Path.Combine(wowDir, "WTF", "Account", entry.FullName);

                            // Ensure the directory structure exists
                            Directory.CreateDirectory(Path.GetDirectoryName(entryDestination));

                            // Extract the entry
                            entry.ExtractToFile(entryDestination, true);
                        }
                    }

                    MessageBox.Show($"Backup {selectedZipFile} restored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a backup from ListBox1.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Restore_btn_Click(object sender, EventArgs e)
        {
            CreateTempBackup(wow_folder_text.Text);
            string selectedZipFile = listBox1.SelectedItem?.ToString();
            RestoreFromBackup(wow_folder_text.Text, selectedZipFile);
        }

        private void Undo_restore_btn_Click(object sender, EventArgs e)
        {
            RestoreFromBackup(wow_folder_text.Text, lastBackupFilePath);
        }


        public void Manual_Backup_Click(object sender, EventArgs e)
        {
            string backupDirectory = "C:\\ElvUI_BU";

            if (!Directory.Exists(backupDirectory))
            {
                try
                {
                    Directory.CreateDirectory(backupDirectory);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to create the backup directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

           
            var wow_dir = wow_folder_text.Text;
            if (string.IsNullOrEmpty(wow_folder_text.Text))
            {
                wow_dir = wow_folder_text.PlaceholderText;
            }

            var BU_DIR = Backup_folder_text.Text;
            if (string.IsNullOrEmpty(Backup_folder_text.Text))
            {
                BU_DIR = Backup_folder_text.PlaceholderText;
            }

            try
            {
                // Check if the WoW folder exists at the expected location
                string expectedWowPath = Path.Combine(wow_dir, "WTF", "Account");
                if (!Directory.Exists(expectedWowPath))
                {
                    MessageBox.Show("WOW folder not found. Please set WOW folder location in settings tab.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Format the zip file name based on the current date and time
                string zipFileName = DateTime.Now.ToString("ddMMMyy HHmm") + ".zip";

                using (var fileStream = new FileStream(Path.Combine(BU_DIR, zipFileName), FileMode.Create))
                {
                    using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create, true))
                    {
                        // Get all ElvUI*.lua files from the SavedVariables folder
                        var elvuiLuaFiles = Directory.GetFiles(expectedWowPath, "ElvUI*.lua", SearchOption.AllDirectories);

                        foreach (var filePath in elvuiLuaFiles)
                        {
                            var entryName = Path.GetRelativePath(expectedWowPath, filePath);
                            archive.CreateEntryFromFile(filePath, entryName);
                        }
                    }
                }

                MessageBox.Show("Backup completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Auto_Backup_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
            {
                MessageBox.Show("Select an automatic backup frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Create a task scheduler instance
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition
                TaskDefinition td = ts.NewTask();

                // Set the task properties
                td.RegistrationInfo.Description = "ElvUI Backup Task";

                // Get the selected backup frequency
                TriggerType selectedTrigger = GetSelectedTrigger();

                // Add a trigger based on the selected frequency
                if (selectedTrigger != TriggerType.None)
                {
                    Trigger trigger = null;

                    switch (selectedTrigger)
                    {
                        case TriggerType.Daily:
                            trigger = new DailyTrigger();
                            ((DailyTrigger)trigger).DaysInterval = 1; // Set DaysInterval for daily triggers
                            break;

                        case TriggerType.Weekly:
                            trigger = new WeeklyTrigger();
                            ((WeeklyTrigger)trigger).WeeksInterval = 1; // Set WeeksInterval for weekly triggers
                            break;

                        case TriggerType.Monthly:
                            trigger = new MonthlyTrigger();
                            ((MonthlyTrigger)trigger).MonthsOfYear = MonthsOfTheYear.AllMonths; // Set MonthsOfYear for monthly triggers
                            break;
                    }

                    // Set additional trigger properties
                    if (trigger != null)
                    {
                        trigger.StartBoundary = DateTime.Now;

                        // Add the trigger to the task definition
                        td.Triggers.Add(trigger);
                    }
                }
                string executablePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                // Set the action to run the backup method
                td.Actions.Add(new ExecAction(executablePath, "Backup", null));

                // Register the task
                ts.RootFolder.RegisterTaskDefinition("ElvUI Backup Task", td);
            }

            MessageBox.Show("Automatic backup task scheduled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private TriggerType GetSelectedTrigger()
        {
            if (checkBox1.Checked)
                return TriggerType.Daily;
            else if (checkBox2.Checked)
                return TriggerType.Weekly;
            else if (checkBox3.Checked)
                return TriggerType.Monthly;

            return TriggerType.None;
        }

        private enum TriggerType
        {
            None,
            Daily,
            Weekly,
            Monthly
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckBox = sender as CheckBox;

            if (clickedCheckBox.Checked)
            {
                // Uncheck other checkboxes
                if (clickedCheckBox == checkBox1)
                {
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (clickedCheckBox == checkBox2)
                {
                    checkBox1.Checked = false;
                    checkBox3.Checked = false;
                }
                else if (clickedCheckBox == checkBox3)
                {
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                }
            }
        }




    }



}
