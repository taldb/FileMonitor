//Copyright © Dennis 2024 https://github.com/taldb





using FileMonitor.ThemeRenderer.CustomTheme;
using FileMonitor.ThemeRenderer.SkyBlueMode;
namespace FileMonitor
{
    public partial class Form1 : Form
    {

        private static ToolStripDropDownMenu dropDownMenu = new ToolStripDropDownMenu();
        private ThemeManager themeManager;
        public static string _filePath = "";
        private FileSystemWatcher fileWatcher;

        #region Theme Code
        //Default Themes


        public void DarkMode()
        {
            this.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            menuStrip1.Renderer = new CustomToolStripDropDownRenderer();
            statusStrip1.Renderer = new CustomBorderlessStatusStripRenderer();
            dropDownMenu.Renderer = new CustomToolStripDropDownRenderer();

            Color toolStripStatusLabel1Dark = Color.FromArgb(26, 26, 26);
            toolStripStatusLabel1.BackColor = toolStripStatusLabel1Dark;
            statusStrip1.BackColor = toolStripStatusLabel1Dark;

            openToolStripMenuItem.ForeColor = Color.White;
            toolStripStatusLabel1.ForeColor = Color.White;
            txtFileContent.BackColor = Color.FromArgb(22, 22, 22);
            txtFileContent.ForeColor = Color.White;

            menuStrip1.BackColor = Color.FromArgb(30, 30, 30);

            settingsToolStripMenuItem.ForeColor = Color.White;
            whatchToolStripMenuItem.ForeColor = Color.White;
            fileToolStripMenuItem.ForeColor = Color.White;

            themesToolStripMenuItem.ForeColor = Color.White;
            aboutToolStripMenuItem.ForeColor = Color.White;

            lightToolStripMenuItem.ForeColor = Color.White;
            darkToolStripMenuItem.ForeColor = Color.White;
            skyBlueToolStripMenuItem.ForeColor = Color.White;
            ChangeToolStripMenuItemForeColor(Color.White);
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
                item.BackColor = ColorTranslator.FromHtml("#1e1e1e");
            }
        }
        public void LightMode()
        {
            // Background colors
            this.BackColor = Color.White;
            menuStrip1.BackColor = Color.White;
            statusStrip1.BackColor = Color.White;
            toolStripStatusLabel1.BackColor = Color.White;

            // Foreground colors
            toolStripStatusLabel1.ForeColor = Color.Black; // Assuming black for contrast

            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.Black; // Assuming black for contrast
                item.BackColor = Color.White;
            }

            txtFileContent.BackColor = Color.White;
            txtFileContent.ForeColor = Color.Black;

            openToolStripMenuItem.BackColor = Color.White;
            openToolStripMenuItem.ForeColor = Color.Black;
            startToolStripMenuItem.BackColor = Color.White;
            stopToolStripMenuItem.BackColor = Color.White;

            // Menu items
            settingsToolStripMenuItem.ForeColor = Color.Black;
            whatchToolStripMenuItem.ForeColor = Color.Black;
            fileToolStripMenuItem.ForeColor = Color.Black;
            themesToolStripMenuItem.ForeColor = Color.Black;
            aboutToolStripMenuItem.ForeColor = Color.Black;
            lightToolStripMenuItem.ForeColor = Color.Black;
            darkToolStripMenuItem.ForeColor = Color.Black;
            skyBlueToolStripMenuItem.ForeColor = Color.Black;

            // Reset renderers to default if needed
            menuStrip1.Renderer = new ToolStripProfessionalRenderer();
            statusStrip1.Renderer = new ToolStripProfessionalRenderer();
            dropDownMenu.Renderer = new ToolStripProfessionalRenderer();
        }
        public void SkyBlueMode()
        {
            Color dc = ColorTranslator.FromHtml("#74b5e4");
            Color dcw = ColorTranslator.FromHtml("#edf7fc");
            this.BackColor = dc;
            menuStrip1.Renderer = new CustomToolStripDropDownRenderer_skyMode();
            statusStrip1.Renderer = new BorderlessStatusStripRenderer_skyMode();
            dropDownMenu.Renderer = new CustomToolStripDropDownRenderer_skyMode();
            openToolStripMenuItem.ForeColor = dcw;

            toolStripStatusLabel1.BackColor = dc;
            statusStrip1.BackColor = dc;

            txtFileContent.BackColor = dc;
            txtFileContent.ForeColor = dcw;

            toolStripStatusLabel1.ForeColor = dcw;

            settingsToolStripMenuItem.ForeColor = dcw;
            whatchToolStripMenuItem.ForeColor = dcw;
            fileToolStripMenuItem.ForeColor = dcw;

            themesToolStripMenuItem.ForeColor = dcw;
            aboutToolStripMenuItem.ForeColor = dcw;

            lightToolStripMenuItem.ForeColor = dcw;
            darkToolStripMenuItem.ForeColor = dcw;
            skyBlueToolStripMenuItem.ForeColor = dcw;
            ChangeToolStripMenuItemForeColor(dcw);
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = dcw;
                item.BackColor = dc;
            }
        }


        private void ChangeToolStripMenuItemForeColor(Color color)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                // Set ForeColor for each ToolStripMenuItem
                item.ForeColor = color;

                // Recursively set ForeColor for items within drop-down menus
                SetForeColorForDropDownItems(item, color);
            }
        }

        private void SetForeColorForDropDownItems(ToolStripMenuItem parentItem, Color color)
        {
            foreach (ToolStripItem item in parentItem.DropDownItems)
            {
                // Check if the item is ToolStripMenuItem (to handle nested menus)
                if (item is ToolStripMenuItem)
                {
                    ToolStripMenuItem dropDownItem = (ToolStripMenuItem)item;
                    dropDownItem.ForeColor = color;

                    // Recursively set ForeColor for items within nested drop-down menus
                    SetForeColorForDropDownItems(dropDownItem, color);
                }
            }
        }
        public void InstallTheme(string filename)
        {
            string[] theme = ImportTheme.ParseTheme(filename);
            if (theme[0].Contains("Error"))
            {
                MessageBox.Show(theme[0],"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appdir = $"{directory}\\FileMonitor\\themes\\";
                Directory.CreateDirectory(appdir);
                File.Copy(filename, $"{appdir}{theme[7]}", true);

                EnvironmentManager.CreateEnvironment("FileMonitor_Themes");
                if (!EnvironmentManager.GetAllVariables("FileMonitor_Themes").Contains(theme[7]))
                {
                    EnvironmentManager.AddVariable("FileMonitor_Themes", theme[7], $"{appdir}{theme[7]}");
                }

                CustomTheme($"{appdir}{theme[7]}");
            }
        }

        public void CustomTheme(string filename)
        {
            string[] theme = ImportTheme.ParseTheme(filename);

            vars.MenuItemBackground = theme[0];
            vars.ToolStripBackground = theme[1];
            vars.ToolStripBackground1 = theme[2];
            vars.TextColor = theme[3];
            vars.BackColor = theme[4];
            vars.ToolStripItemText = theme[5];
            vars.ToolStripItemBackground = theme[6];

            Color txtc = ColorTranslator.FromHtml(theme[3]);

            Color bg = ColorTranslator.FromHtml(vars.BackColor);
            this.BackColor = bg;
            menuStrip1.Renderer = new CustomToolStripDropDownRendererC();
            statusStrip1.Renderer = new CustomBorderlessStatusStripRendererC();
            dropDownMenu.Renderer = new CustomToolStripDropDownRendererC();

            Color toolStripStatusLabel1Dark = txtc;
            toolStripStatusLabel1.BackColor = toolStripStatusLabel1Dark;
            statusStrip1.BackColor = toolStripStatusLabel1Dark;

            openToolStripMenuItem.ForeColor = txtc;
            toolStripStatusLabel1.ForeColor = txtc;
            txtFileContent.BackColor = bg;
            txtFileContent.ForeColor = txtc;

            menuStrip1.BackColor = bg;





            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ToolStripMenuItem)
                {
                    ctrl.ForeColor = txtc;
                }
            }

            foreach (Control ctrl in dropDownMenu.Controls)
            {
                if (ctrl is ToolStripDropDownMenu)
                {
                    ToolStripDropDownMenu v = (ToolStripDropDownMenu)ctrl;
                    v.ForeColor = txtc;
                }
            }



            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.ForeColor = txtc;
                item.BackColor = ColorTranslator.FromHtml(theme[6]);
            }
        }

        private void AddThemeToMenu(string themeName)
        {
            ToolStripMenuItem themeMenuItem = new ToolStripMenuItem(themeName);
            themeMenuItem.Tag = themeName; // Store theme name for identification
            themeMenuItem.Click += ThemeMenuItem_Click; // Handle click event to apply theme
            themesToolStripMenuItem.DropDownItems.Add(themeMenuItem);
        }

        // Handle theme selection from menu
        private void ThemeMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
            if (clickedItem != null)
            {
                string themeName = clickedItem.Tag as string;
                if (!string.IsNullOrEmpty(themeName))
                {
                    string themeFilePath = themeManager.GetThemes()[themeName];
                    CustomTheme(themeFilePath); // Apply the selected theme
                }
            }
        }
        public void ResetTheme()
        {
            this.Controls.Clear();
            InitializeComponent();
            LightMode();

        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LightMode();
        }

        private void darkToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DarkMode();

        }

        private void skyBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SkyBlueMode();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetTheme();
        }

        private void InitializeThemes()
        {
            themeManager = new ThemeManager();
            Dictionary<string, string> loadedThemes = themeManager.GetThemes();

            // Add loaded themes to your themes menu dynamically
            foreach (var theme in loadedThemes)
            {
                AddThemeToMenu(theme.Key); // Assuming AddThemeToMenu adds to themesToolStripMenuItem
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (themefileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = themefileDialog.FileName;
                InstallTheme(filePath);

                string[] f = ImportTheme.ParseTheme(filePath);
                string name = f[7];

                AddThemeToMenu(name); // Add theme to menu
                Application.Restart();
            }
        }

        private void deleteAllThemesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all installed themes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DeleteAllThemes();
                MessageBox.Show("All themes deleted successfully.");
            }
        }

        public void DeleteAllThemes()
        {
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string themeDir = $"{directory}\\FileMonitor\\themes\\";

            // Get all theme variables
            List<string> themeNames = EnvironmentManager.GetAllVariables("FileMonitor_Themes");

            // Delete theme files from directory
            foreach (var themeName in themeNames)
            {
                string themeFilePath = EnvironmentManager.ReadVariable("FileMonitor_Themes", themeName);
                if (!string.IsNullOrEmpty(themeFilePath))
                {
                    try
                    {
                        File.Delete(themeFilePath);
                    }
                    catch (Exception ex)
                    {
                        // Handle deletion error if needed
                        MessageBox.Show($"Error deleting theme '{themeName}': {ex.Message}");
                    }
                }
            }

            // Clear environment variables or configuration entries
            EnvironmentManager.DeleteEnvironment("FileMonitor_Themes");

            // Clear internal theme list
            themeManager = new ThemeManager(); // Assuming you have a ThemeManager instance
            InitializeThemes(); // Refresh themes in UI after deletion
            Application.Restart();
        }

        #endregion
        public Form1()
        {
            InitializeComponent();
            InitializeThemes(); // Load themes during form initialization
            LightMode();
            this.KeyPreview = true; // Ensure form receives key events
            this.KeyDown += MainForm_KeyDown; // Subscribe to KeyDown event

        }

        //File Monitoring
        private void DisplayFile(string filePath)
        {
            try
            {
                // Read the file content
                string fileContent = File.ReadAllText(filePath);

                // Display the content in the TextBox (assuming txtFileContent is your TextBox control)
                txtFileContent.Text = fileContent;
                _filePath = filePath;
                // Monitor file for changes using FileSystemWatcher
                MonitorFile(filePath);
            }
            catch (Exception ex) { }
        }
        private void MonitorFile(string filePath)
        {
            try
            {
                // Create a new FileSystemWatcher and set its properties
                fileWatcher = new FileSystemWatcher();
                fileWatcher.Path = Path.GetDirectoryName(filePath);
                fileWatcher.Filter = Path.GetFileName(filePath);
                fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fileWatcher.Changed += FileWatcher_Changed;

                // Begin watching the file
                fileWatcher.EnableRaisingEvents = true;
            }
            catch (Exception ex) { }
        }
        private void FileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                // When the file changes, update the displayed content
                string fileContent = File.ReadAllText(e.FullPath);

                // Invoke the UI thread to update the TextBox
                Invoke(new Action(() =>
                {
                    txtFileContent.Text = fileContent;
                }));
            }
            catch (Exception ex) { }
        }

        //Open File
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DisplayFile(filePath);
                startToolStripMenuItem.Enabled = false;
                stopToolStripMenuItem.Enabled = true;
                toolStripStatusLabel1.Text = "Monitoring File: " + filePath;
            }
        }


        //Start Monitoring
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = true;
            toolStripStatusLabel1.Text = "Monitoring File: " + _filePath;
            MonitorFile(_filePath);

        }

        //Stop Monitoring
        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = true;
            stopToolStripMenuItem.Enabled = false;
            toolStripStatusLabel1.Text = "Stopped Watching!";
            if (fileWatcher != null)
            {
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fileWatcher != null)
            {
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
            }
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            txtFileContent.Width = this.Width;
            txtFileContent.Height = this.Height;
        }

        private void txtFileContent_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle scrolling with arrow keys
            if (e.KeyCode == Keys.Up)
            {
                txtFileContent.SelectionStart = Math.Max(0, txtFileContent.SelectionStart - 1);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtFileContent.SelectionStart = Math.Min(txtFileContent.TextLength, txtFileContent.SelectionStart + 1);
                e.Handled = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for Control + N key combination
            if (e.Control && e.KeyCode == Keys.N)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    DisplayFile(filePath);
                    startToolStripMenuItem.Enabled = false;
                    stopToolStripMenuItem.Enabled = true;
                    toolStripStatusLabel1.Text = "Monitoring File: " + filePath;
                }
            }
        }

    }
}
