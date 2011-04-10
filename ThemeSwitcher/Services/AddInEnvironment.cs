using System;
using System.IO;
using ThemeSwitcher.Model;

namespace ThemeSwitcher.Services
{
    public static class AddInEnvironment
    {
        public static string DataFolder
        {
            get
            {
                var baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                           "ThemeSwitcher");

                return Path.Combine(baseDir, Context.Application.Version);
            }
        }

        public static string ThemesPath
        {
            get { return Path.Combine(DataFolder, "themes"); }
        }

        public static string ConfigFile
        {
            get { return Path.Combine(DataFolder, "config.xml"); }
        }
    }
}