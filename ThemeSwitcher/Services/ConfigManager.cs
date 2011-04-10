using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ThemeSwitcher.Model;

namespace ThemeSwitcher.Services
{
    public static class ConfigManager
    {
        private static readonly XmlSerializer configSerializer = new XmlSerializer(typeof (Config));

        public static Config LoadConfig()
        {
            if (!File.Exists(AddInEnvironment.ConfigFile))
                return new Config();

            try
            {
                using (var file = File.OpenRead(AddInEnvironment.ConfigFile))
                {
                    return (Config) configSerializer.Deserialize(file);
                }
            }
            catch
            {
                MessageBox.Show("Configuration file corrupted. ThemeSwitcher settings could not be loaded.",
                                "ThemeSwitcher",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return new Config();
            }
        }

        public static void SaveConfig(Config config)
        {
            using (var file = File.Create(AddInEnvironment.ConfigFile))
            {
                configSerializer.Serialize(file, config);
            }
        }
    }
}