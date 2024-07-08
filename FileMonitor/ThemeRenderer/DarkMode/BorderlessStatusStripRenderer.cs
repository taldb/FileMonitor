//Copyright © Dennis 2024 https://github.com/taldb

using System.Drawing;
using System.Windows.Forms;


/*
Usage:
            menuStrip1.Renderer = new CustomToolStripDropDownRenderer();
            statusStrip1.Renderer = new BorderlessStatusStripRenderer();
            ToolStripDropDownMenu dropDownMenu = new ToolStripDropDownMenu();
            dropDownMenu.Renderer = new CustomToolStripDropDownRenderer();
*/

public class CustomBorderlessStatusStripRenderer : ToolStripProfessionalRenderer
{
    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        // Do not call the base class to skip rendering the border
        //base.OnRenderToolStripBorder(e);
    }
    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        Color hexcolor = ColorTranslator.FromHtml("#1e1e1e");
        // Fill the background with a specific color
        using (SolidBrush brush = new SolidBrush(hexcolor)) // Set your desired color here
        {
            e.Graphics.FillRectangle(brush, e.AffectedBounds);
        }
    }
}
