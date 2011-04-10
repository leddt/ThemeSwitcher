using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ThemeSwitcher.Model
{
    [Serializable]
    public class Config
    {
        public Config()
        {
            Themes = new List<Theme>();
        }

        public List<Theme> Themes { get; set; }
        public string CurrentThemeName { get; set; }
    }
}