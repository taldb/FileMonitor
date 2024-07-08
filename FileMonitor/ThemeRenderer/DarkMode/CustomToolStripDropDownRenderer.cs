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

public class CustomToolStripDropDownRenderer : ToolStripProfessionalRenderer
{
    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
        // Define your custom background color
        Color bgColor = ColorTranslator.FromHtml("#1e1e1e"); // Dark gray

        // Fill the entire ToolStrip background with the custom background color
        using (SolidBrush brush = new SolidBrush(bgColor))
        {
            e.Graphics.FillRectangle(brush, e.AffectedBounds);
        }
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        // Override to prevent rendering of tool strip border
        // Do not call the base method to ensure no borders are drawn
    }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        if (e.Item is ToolStripMenuItem item)
        {
            // Define your custom background color
            Color bgColor = ColorTranslator.FromHtml("#1e1e1e"); // Dark gray

            // Fill the entire item area with the custom background color
            using (SolidBrush brush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
            }

            // Draw item selection if selected
            if (item.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, new Rectangle(Point.Empty, e.Item.Size));
            }
        }
        else
        {
            base.OnRenderMenuItemBackground(e); // Fallback to base rendering for other items
        }
    }
}
