//Copyright © Dennis 2024 https://github.com/taldb

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMonitor.ThemeRenderer.CustomTheme
{
    public static class ImportTheme
    {
        public static string[] ParseTheme(string themeFilePath)
        {
            try
            {
                string themename = "null";
                string MenuItemBackground = "#FFFFFF";
                string ToolStripBackground = "#FFFFFF";
                string ToolStripBackground1 = "#FFFFFF";
                string TextColor = "#FFFFFF";
                string BackColor = "#FFFFFF";
                string ToolStripItemText = "#FFFFFF";
                string ToolStripItemBackground = "#FFFFFF";
                /*
                 ///Sky Theme

                 MenuItemBackground: #99cbec
                 ToolStripBackground: #99cbec
                 TextColor: #FFFFFF
                 BackColor: #74b5e4
                 ToolStripItemText: #FFFFFF
                 ToolStripItemBackground: #74b5e4

                 */

                string[] r = File.ReadAllLines(themeFilePath);
                if (r.Length == 6)
                {

                }
                foreach (var line in r)
                {
                    string l = line.ToString().ToLower().Replace(" ", "");
                    if (l.StartsWith("name:"))
                    {
                        themename = l.Remove(0, "name:".Length);
                    }
                    else if (l.StartsWith("menuitembackground:"))
                    {
                        MenuItemBackground = l.Remove(0, "menuitembackground:".Length);
                    }
                    else if (l.StartsWith("toolstripbackground:"))
                    {
                        ToolStripBackground = l.Remove(0, "toolstripbackground:".Length);
                        ToolStripBackground1 = ToolStripBackground;
                    }
                    else if (l.StartsWith("textcolor:"))
                    {
                        TextColor = l.Remove(0, "textcolor:".Length);
                    }
                    else if (l.StartsWith("backcolor:"))
                    {
                        BackColor = l.Remove(0, "backcolor:".Length);
                    }
                    else if (l.StartsWith("toolstripitemtext:"))
                    {
                        ToolStripItemText = l.Remove(0, "toolstripitemtext:".Length);
                    }
                    else if (l.StartsWith("toolstripitembackground:"))
                    {
                        ToolStripItemBackground = l.Remove(0, "toolstripitembackground:".Length);
                    }
                }




                return new string[] { MenuItemBackground, ToolStripBackground, ToolStripBackground1, TextColor, BackColor, ToolStripItemText, ToolStripItemBackground, themename };
            }
            catch (Exception ex)
            {
                return new string[] {"Error"+ ex.Message };
            }
        }
    }
}
