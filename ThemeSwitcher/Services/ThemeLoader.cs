using EnvDTE80;
using ThemeSwitcher.Model;

namespace ThemeSwitcher.Services
{
    public class ThemeLoader
    {
        public static void LoadTheme(Theme theme)
        {
            LoadTheme(theme, Context.Application, Context.Config);
        }

        private static void LoadTheme(Theme theme, DTE2 application, Config config)
        {
            application.ExecuteCommand(
                "Tools.ImportandExportSettings",
                string.Format("/import:\"{0}\"", theme.FilePath));

            config.CurrentThemeName = theme.Name;
            ConfigManager.SaveConfig(config);
        }
    }
}