using System.Collections.Generic;
using System.Linq;
using ThemeSwitcher.Model;

namespace ThemeSwitcher.Services
{
    public static class ThemeCycler
    {
        public static void LoadNextTheme()
        {
            LoadNextTheme(Context.Config.CurrentThemeName, Context.Config.Themes);
        }

        private static void LoadNextTheme(string currentThemeName, IList<Theme> allThemes)
        {
            if (allThemes.All(x => !x.Active)) return; // No active theme, so exit immediatly.

            var idx = GetCurrentThemeIndex(allThemes, currentThemeName);
            var themeToLoad = GetNextActiveTheme(allThemes, idx);

            ThemeLoader.LoadTheme(themeToLoad);
        }

        private static int GetCurrentThemeIndex(IList<Theme> allThemes, string currentThemeName)
        {
            var currentTheme = allThemes.FirstOrDefault(x => x.Name == currentThemeName);

            var idx = -1;
            if (currentTheme != null)
                idx = allThemes.IndexOf(currentTheme);

            return idx;
        }

        private static Theme GetNextActiveTheme(IList<Theme> allThemes, int idx)
        {
            Theme themeToLoad;

            do
            {
                idx++;

                if (idx >= allThemes.Count)
                    idx = 0;

                themeToLoad = allThemes[idx];
            } while (!themeToLoad.Active);

            return themeToLoad;
        }
    }
}