//Copyright © Dennis 2024 https://github.com/taldb

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor.ThemeRenderer.CustomTheme
{
    public class ThemeManager
    {
        private Dictionary<string, string> themes; // Dictionary to store theme name and file path

        public ThemeManager()
        {
            themes = new Dictionary<string, string>();
            LoadThemes(); // Load themes from storage during initialization
        }

        public void LoadThemes()
        {
            List<string> themeNames = EnvironmentManager.GetAllVariables("FileMonitor_Themes");
            foreach (string themeName in themeNames)
            {
                string themePath = EnvironmentManager.ReadVariable("FileMonitor_Themes", themeName);
                themes.Add(themeName, themePath);
            }
        }

        public Dictionary<string, string> GetThemes()
        {
            return themes;
        }
    }

}
