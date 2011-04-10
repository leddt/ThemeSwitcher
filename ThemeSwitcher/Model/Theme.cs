using System;
using System.IO;
using System.Xml.Serialization;
using ThemeSwitcher.Services;

namespace ThemeSwitcher.Model
{
    [Serializable]
    public class Theme
    {
        [XmlAttribute] public bool Active { get; set; }
        [XmlAttribute] public string Name { get; set; }

        public string FilePath
        {
            get { return Path.Combine(AddInEnvironment.ThemesPath, Name) + ".vssettings"; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}