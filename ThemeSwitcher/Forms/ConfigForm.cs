using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThemeSwitcher.Model;
using ThemeSwitcher.Services;

namespace ThemeSwitcher.Forms
{
    public partial class ConfigForm : Form
    {
        private static readonly char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

        public ConfigForm()
        {
            InitializeComponent();

            foreach (var theme in Context.Config.Themes)
                AvailableThemesList.Items.Add(theme, theme.Active);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (var theme in AvailableThemesList.SelectedItems.Cast<Theme>().ToList())
                AvailableThemesList.Items.Remove(theme);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var sourceFile = PromptForThemeFile();
            if (string.IsNullOrEmpty(sourceFile)) return;

            var themeName = PromptForThemeName(sourceFile);
            if (string.IsNullOrEmpty(themeName)) return;

            CopyTheme(sourceFile, themeName);

            var theme = new Theme
                            {
                                Name = themeName,
                                Active = true
                            };

            AvailableThemesList.Items.Add(theme, true);
        }

        private static void CopyTheme(string sourceFile, string themeName)
        {
            var themesPath = AddInEnvironment.ThemesPath;
            var targetFile = Path.Combine(themesPath, themeName + ".vssettings");

            if (!Directory.Exists(themesPath))
                Directory.CreateDirectory(themesPath);

            File.Copy(sourceFile, targetFile, true);
        }

        private string PromptForThemeFile()
        {
            var ofd = new OpenFileDialog
                          {
                              CheckFileExists = true,
                              Filter = "Visual Studio Settings|*.vssettings",
                              Title = "Select settings file"
                          };

            return ofd.ShowDialog(this) == DialogResult.OK
                       ? ofd.FileName
                       : null;
        }

        private string PromptForThemeName(string defaultName)
        {
            var etnd = new EnterThemeNameDialog
                           {
                               ThemeName = Path.GetFileNameWithoutExtension(defaultName)
                           };

            while (true)
            {
                if (etnd.ShowDialog(this) != DialogResult.OK) return null;

                if (AvailableThemesList.Items.Cast<Theme>().Any(x => x.Name == etnd.ThemeName))
                    MessageBox.Show(this,
                                    "A theme with this name already exists. Please choose a different name.",
                                    "Name already in use",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                else if (etnd.ThemeName.Intersect(invalidFileNameChars).Any())
                    MessageBox.Show(this,
                                    "The specified name is not a valid file name. Please choose a different name.",
                                    "Invalid name",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                else
                    return etnd.ThemeName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Context.Config.Themes.Clear();

            for (var i = 0; i < AvailableThemesList.Items.Count; i++)
            {
                var theme = (Theme) AvailableThemesList.Items[i];
                theme.Active = AvailableThemesList.GetItemChecked(i);

                Context.Config.Themes.Add(theme);
            }

            ConfigManager.SaveConfig(Context.Config);

            Close();
        }
    }
}
