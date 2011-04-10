using EnvDTE;
using EnvDTE80;
using ThemeSwitcher.Services;

namespace ThemeSwitcher.Model
{
    public class Context
    {
        public static DTE2 Application { get; set; }
        public static AddIn AddIn { get; set; }

        private static Config _config;
        public static Config Config
        {
            get
            {
                if (_config == null)
                    LoadConfig();

                return _config;
            }
        }

        private static void LoadConfig()
        {
            _config = ConfigManager.LoadConfig();
        }
    }
}
