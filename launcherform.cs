using System.Diagnostics;
using System.Reflection;
using LauncherUtils;
using static LauncherUtils.Utils;
using LogUtils;

namespace LEHuDModLauncher
{
    public partial class launcherform : Form

    {
        public static string game_filename = "LELauncher.bat";
        public static string version_filename = @"version.dll";
        public static string version_back_filename = @"version.dll.back";
        
        public Utils utils = new Utils();

        private Process gameProcess;
        public Logger dlog = new Logger();
           

        public void SetStatus(string text) { statusStripLabel.SafeInvoke(() => statusStripLabel.Text = text); }
        
        public launcherform()
        {
            

            var assembly = Assembly.GetExecutingAssembly();
            InitializeComponent();
            this.Text = $"{assembly.GetName().Name} - {assembly.GetName().Version}";

            MessageBox.Show($"{SettingsManager.Instance.Settings.GameDir}\n{SettingsManager.Instance.Settings.Steampath}\n{SettingsManager.Instance.Settings.TmpDownloadFolder}");
            
            // Que downloads
            utils.AddDownload(2, "Melonloader", "https://nightly.link/LavaGang/MelonLoader/actions/runs/16608539627/MelonLoader.Windows.x64.CI.Debug.zip", SettingsManager.Instance.Settings.GameDir, SettingsManager.Instance.Settings.GameDir, "MelonLoader.Windows.x64.CI.Debug.zip", false, true);
            utils.AddDownload(1, "Mod", "https://github.com/jpeaglesandkatz/LEHuDModLauncher/releases/download/1.0/LastEpoch_Hud.Keyboard.rar", SettingsManager.Instance.Settings.GameDir, SettingsManager.Instance.Settings.GameDir + @"\mods", "LastEpoch_Hud(Keyboard).rar", false, false);

            textGamePath.Text = SettingsManager.Instance.Settings.GameDir;
            textSteamPath.Text = SettingsManager.Instance.Settings.Steampath;
            textGameVersion.Text = utils.GetGameversion(SettingsManager.Instance.Settings.Steampath + @"\steamapps\appmanifest_899770.acf");
            toolStripProgress.Enabled = true;
            toolStripProgress.Visible = false;
            statusStripLabel.Text = "";
            
            // Cleanup existing melonloader dir
            if (!Directory.Exists(SettingsManager.Instance.Settings.TmpDownloadFolder)) Directory.CreateDirectory(SettingsManager.Instance.Settings.TmpDownloadFolder);
            else utils.Deletefiles(SettingsManager.Instance.Settings.TmpDownloadFolder);
            CleanupDirs();

            // Extract embedded resources to temp folder
            ExtractAllResourcesToTempFolder();
            
            utils.ExtractFile("LELauncher.zip", SettingsManager.Instance.Settings.TmpDownloadFolder, SettingsManager.Instance.Settings.GameDir);

            textGamePath.Text = SettingsManager.Instance.Settings.GameDir;
        }

        public void CleanupDirs()
        {
            if (Directory.Exists(SettingsManager.Instance.Settings.GameDir + @"\Melonloader")) Directory.Delete(SettingsManager.Instance.Settings.GameDir + @"\Melonloader", true);
            //if (Directory.Exists(settings.GameDir + @"\UserLibs")) Directory.Delete(settings.GameDir + @"\UserLibs", true);
            //if (Directory.Exists(settings.GameDir + @"\UserData")) Directory.Delete(settings.GameDir + @"\UserData", true);
            if (!Directory.Exists(SettingsManager.Instance.Settings.GameDir + @"\Mods")) Directory.CreateDirectory(SettingsManager.Instance.Settings.GameDir + @"\Mods");
        }

        private void launcherform_Load(object sender, EventArgs e) { ApplyDarkTheme(); }

        // Extract all embedded resources to the temporary folder
        public void ExtractAllResourcesToTempFolder()
        {
            var assembly = Assembly.GetExecutingAssembly();

            string resourcePrefix = "LEHuDModLauncher.Resources."; // Adjust if your resources are in a different namespace/folder

            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                dlog.Debug($"RESOURCENAME {resourceName}]");
                string fileName = resourceName.StartsWith(resourcePrefix)
                    ? resourceName.Substring(resourcePrefix.Length)
                    : resourceName;

                var outputPath = SettingsManager.Instance.Settings.TmpDownloadFolder;

                using var stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null) continue;
                using var fileStream = new FileStream(SettingsManager.Instance.Settings.TmpDownloadFolder + @"\" + fileName, FileMode.Create, FileAccess.Write);
                stream.CopyTo(fileStream);
                dlog.Debug($"[RESOURCES { fileName} extracted to {outputPath}");
            }
        }

        // Get the installation path of Last Epoch from the Windows registry
        

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            dialog.Description = "Select destination folder";
            dialog.SelectedPath = SettingsManager.Instance.Settings.GameDir;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textGamePath.Text = dialog.SelectedPath;
                SettingsManager.Instance.Settings.GameDir = dialog.SelectedPath;
            }
        }

        // Download and extract files
        private void buttonStartDownload_Click(object sender, EventArgs e)
        {

        }

        public void UpdateStatusLabel(string text)
        {
            statusStripLabel.Text = text;
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            
        }

        private void ApplyDarkTheme()
        {
            Color backColor = Color.FromArgb(32, 32, 32);
            Color foreColor = Color.White;
            Color buttonBack = Color.FromArgb(45, 45, 48);

            void SetTheme(Control control)
            {
                control.BackColor = backColor;
                control.ForeColor = foreColor;

                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.BackColor = buttonBack;
                    btn.ForeColor = foreColor;
                    btn.FlatAppearance.BorderColor = Color.DimGray;
                }
                else if (control is TextBox || control is ComboBox || control is ProgressBar || control is MenuStrip)
                {
                    control.BackColor = Color.FromArgb(40, 40, 40);
                    control.ForeColor = foreColor;
                }
                else if (control is ProgressBar pb)
                {
                    pb.BackColor = backColor;
                    pb.ForeColor = foreColor;
                }

                foreach (Control child in control.Controls)
                    SetTheme(child);
            }
            SetTheme(this);
        }

        public void StartGame(bool online)
        {

            if (online)
            {
                if (File.Exists(SettingsManager.Instance.Settings.GameDir + version_filename))
                {
                    if (File.Exists(SettingsManager.Instance.Settings.GameDir + version_back_filename)) { File.Delete(SettingsManager.Instance.Settings.GameDir + version_filename); }
                    else { File.Move(SettingsManager.Instance.Settings.GameDir + version_filename, SettingsManager.Instance.Settings.GameDir + version_back_filename); }
                }
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = $"steam://rungameid/{899770}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WorkingDirectory = SettingsManager.Instance.Settings.GameDir
                };
                using var process = new Process { StartInfo = processStartInfo };
                process.Start();

                //Process.Start(new ProcessStartInfo { FileName = $"steam://rungameid/{899770}", UseShellExecute = true, WorkingDirectory = settings.GameDir });
            }
            else
            {
                if (!File.Exists(SettingsManager.Instance.Settings.GameDir + version_filename))
                {
                    if (File.Exists(SettingsManager.Instance.Settings.GameDir + version_back_filename))
                    {
                        File.Move(SettingsManager.Instance.Settings.GameDir + version_back_filename, SettingsManager.Instance.Settings.GameDir + version_filename);
                    }
                }
                else if (File.Exists(SettingsManager.Instance.Settings.GameDir + version_back_filename)) { File.Delete(SettingsManager.Instance.Settings.GameDir + version_back_filename); }
                
                
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = $"{SettingsManager.Instance.Settings.GameDir}\\{game_filename}",
                    Arguments = $"--offline \"{SettingsManager.Instance.Settings.GameDir}\"",
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    //WorkingDirectory = settings.GameDir                    
                };
                MessageBox.Show($"{SettingsManager.Instance.Settings.GameDir}\\{game_filename}\n{SettingsManager.Instance.Settings.GameDir}\n{processStartInfo.Arguments}");
                //using var process = new Process { StartInfo = processStartInfo };
                gameProcess = new Process { StartInfo = processStartInfo, EnableRaisingEvents = true };
                gameProcess.Exited += GameProcess_Exited;

                gameProcess.Start();

                statusStripLabel.Text = "Last Epoch started...";

            }
            //Application.Exit();
        }

        private void GameProcess_Exited(object sender, EventArgs e)
        {
            // This event is raised on a background thread → marshal back to UI
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => GameProcess_Exited(sender, e)));
                return;
            }

            statusStripLabel.Text = "Game Exited!";
        }




        private void buttonOnline_Click(object sender, EventArgs e)
        {
            StartGame(true);
        }

        private void buttonOffline_Click(object sender, EventArgs e)
        {
            StartGame(false);
        }

        private void launcherform_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsManager.Instance.Save();
        }

        private void textPath_TextChanged(object sender, EventArgs e)
        {
            SettingsManager.Instance.Settings.GameDir = textGamePath.Text;

        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CleanupDirs();

            toolStripProgress.Visible = true;
            toolStripProgress.Value = 0;
            SettingsManager.Instance.Settings.ErrorCount = 0;

            utils.StartDownloads();

            toolStripProgress.Value = 0;
            toolStripProgress.Visible = false;
            if (SettingsManager.Instance.Settings.ErrorCount == 0) MessageBox.Show("All done! You can now start Last Epoch with the HUD mod installed.\n\n" +
                "But make sure to run the game at least once and exit. This should fix most common issues."
                , "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else MessageBox.Show("Finished with errors. Please check the log.", "Errors occurred", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            statusStripLabel.Text = "Installation finished... Run the game once and exit the game!";
        }

        private void buttonBrowseSteamFolder_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();
            dialog.Description = "Select steam folder";
            dialog.SelectedPath = SettingsManager.Instance.Settings.Steampath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textGamePath.Text = dialog.SelectedPath;
                SettingsManager.Instance.Settings.GameDir = dialog.SelectedPath;
                SettingsManager.Instance.Save();
            }
        }

        private void buttonGetGameFolder_Click(object sender, EventArgs e)
        {
            SettingsManager.Instance.Settings.GameDir = utils.GetPathFromRegistry("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\Steam App 899770", "Installlocation");
            textGamePath.Text = SettingsManager.Instance.Settings.GameDir;
        }

        private void buttonGetSteamFolder_Click(object sender, EventArgs e)
        {
            if (SettingsManager.Instance.Settings.Steampath == "") SettingsManager.Instance.Settings.Steampath = utils.GetPathFromRegistry("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath");

            SettingsManager.Instance.Settings.Steampath = Path.GetFullPath(SettingsManager.Instance.Settings.Steampath);
            textSteamPath.Text = SettingsManager.Instance.Settings.Steampath;
        }
    }
}