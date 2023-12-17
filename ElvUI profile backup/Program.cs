using System;
using System.IO.Compression;

namespace ElvUI_profile_backup
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            

            // Check if "backup" argument is provided
            if (args.Length > 0 && args[0].ToLower() == "backup")
            {
                // Execute manual backup logic
                RunManualBackup();
            }
            else
            {
                // Run the main form
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
        private static void RunManualBackup()
        {
            // Implement the logic for manual backup here
            // This can include calling the necessary methods to perform the backup
            // ...

            // For example, if your backup logic is in Form1, you might instantiate Form1 and call the backup method
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
            var wow_dir = Properties.Settings.Default.WowFolder;
            if (string.IsNullOrEmpty(Properties.Settings.Default.WowFolder))
            {
                wow_dir = "C:\\Program Files (x86)\\World of Warcraft\\_retail_";
            }

            var BU_DIR = Properties.Settings.Default.BackupFolder;
            if (string.IsNullOrEmpty(Properties.Settings.Default.BackupFolder))
            {
                BU_DIR = "C:\\ElvUI_BU";
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

                Console.WriteLine("backup completed.");
                DeleteOlderBackups(backupDirectory, 60);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
        
        }
        static void DeleteOlderBackups(string directoryPath, int maxBackupCount)
        {
            try
            {
                var backupFiles = Directory.GetFiles(directoryPath, "RestoreBackup_*.zip")
                                             .OrderByDescending(file => File.GetLastWriteTime(file))
                                             .ToList();

                while (backupFiles.Count > maxBackupCount)
                {
                    var fileToDelete = backupFiles.Last();
                    File.Delete(fileToDelete);
                    backupFiles.Remove(fileToDelete);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete older backups: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    } 
}