using System.Drawing;

namespace PerformanceComparison.ControlLibrary.Internal
{
    internal class ToolTipRegion
    {
        private readonly Rectangle region;
        private readonly string toolTipText;

        public ToolTipRegion(Rectangle region, string toolTipText)
        {
            this.region = region;
            this.toolTipText = toolTipText;
        }

        public string ToolTipText
        {
            get { return toolTipText; }
        }

        public Rectangle Region
        {
            get { return region; }
        }
    }
}
