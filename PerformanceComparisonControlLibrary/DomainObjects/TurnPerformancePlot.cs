using System.Drawing;

namespace PerformanceComparison.ControlLibrary.DomainObjects
{
    /// <summary>
    /// Defines a single turn plot to add to the graph control.
    /// </summary>
    public class TurnPerformancePlot
    {
        public enum FlapPosition { None, Full };

        public FlapPosition FlapSetting { get; set; }

        public Pen PlotPen { get; set; }

        public string PlotTitle { get; set; }

        public float TurnRaduis { get; set; }

        public float StallSpeed { get; set; }

        public float TurnRateInDegPerSecond { get; set; }

        public string Configuration
        {
            get
            {
                if (FlapSetting == FlapPosition.None)
                    return "Clean";
                else
                    return "Full Flaps";
            }
        }
    }
}
