using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PerformanceComparison.ControlLibrary.DomainObjects;
using PerformanceComparison.ControlLibrary.Internal;

namespace PerformanceComparison.ControlLibrary
{
    public partial class TurnPerformanceUserControl : UserControl
    {
        public TurnPerformanceUserControl()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            NumberOfMinorXAxisGridMarks = 14;
            plots = new List<TurnPerformancePlot>();
            MinorAxisMarkingsPen = Pens.LightGray;
            XAxisPen = Pens.Black;
            YAxisPen = Pens.Black;
            MinorTitlePen = Pens.Black;
            TitlePen = Pens.Black;
            UnitMultiple = 25;
            ControlTextFontFamily = "Arial New";
            ShowToolTipRegions = false;



            #region TestData REMOVE ME

            //this.Title = "Sustained Turn Performance";

            //TurnPerformancePlot plot4 = new TurnPerformancePlot();
            //plot4.PlotPen = new Pen(Brushes.DeepSkyBlue);
            //plot4.PlotPen.Width = 1;
            //plot4.PlotPen.DashPattern = new float[] { 2, 2 };
            //plot4.TurnRaduis = 280;
            //plot4.TurnRateInDegPerSecond = 30;
            //plot4.PlotTitle = "F4u-1D";
            //plot4.FlapSetting = TurnPerformancePlot.FlapPosition.Full;
            //Plots.Add(plot4);

            //TurnPerformancePlot plot1 = new TurnPerformancePlot();
            //plot1.PlotPen = new Pen(Brushes.DeepSkyBlue);
            //plot1.TurnRaduis = 513;
            //plot1.TurnRateInDegPerSecond = 28;
            //plot1.PlotTitle = "F4u-1D";
            //plot1.FlapSetting = TurnPerformancePlot.FlapPosition.None;
            //Plots.Add(plot1);

            ////TurnPerformancePlot plot2 = new TurnPerformancePlot();
            ////plot2.PlotPen = new Pen(Brushes.DarkSalmon);
            ////plot2.TurnRaduis = 379F;
            ////plot2.TurnRateInDegPerSecond = 27.7F;
            ////plot2.PlotTitle = "A6M2-Sustained";
            ////plot2.FlapSetting = TurnPerformancePlot.FlapPosition.None;
            ////Plots.Add(plot2);

            ////TurnPerformancePlot plot3 = new TurnPerformancePlot();
            ////plot3.PlotPen = new Pen(Brushes.DarkSalmon);
            ////plot3.TurnRaduis = 362F;
            ////plot3.TurnRateInDegPerSecond = 41.6F;
            ////plot3.PlotTitle = "A6M2-Instantaneous";
            ////plot3.FlapSetting = TurnPerformancePlot.FlapPosition.None;
            ////Plots.Add(plot3);

            #endregion
        }

        public void ClearPlots()
        {
            plots.Clear();
        }

        public void ResetControl()
        {
            this.plots.Clear();
            this.Title = string.Empty;
            this.Refresh();
        }

        public void AddPlot(TurnPerformancePlot plot)
        {
            plots.Add(plot);
        }

        public enum Orientation { Portrait, Landscape };

        #region Private Fields

        private readonly ToolTip tTip = new ToolTip();
        private readonly List<ToolTipRegion> tipRegionCollection = new List<ToolTipRegion>();
        private const int MAXDISPLAYTURNDEGREES = 150;
        private const int MINDISPLAYTURNDEGREES = 40;
        private int displayTurnDegrees = MAXDISPLAYTURNDEGREES;
        private List<TurnPerformancePlot> plots;
        private Point mouseLocation;

        #endregion

        #region Public Properties

        public bool ShowToolTipRegions { get; set; }

        public int NumberOfMinorXAxisGridMarks { get;set; }

        public string Title { get; set; }

        public Pen MinorAxisMarkingsPen { get; set; }

        public Pen XAxisPen { get; set; }

        public Pen YAxisPen { get; set; }

        public Pen TitlePen { get; set; }

        public Pen MinorTitlePen { get; set; }

        public int UnitMultiple { get; set; }

        public string ControlTextFontFamily { get; set; }

        public int DisplayTurnDegrees 
        {
            get
            {
                return displayTurnDegrees;
            }
            set
            {
                if (value > MAXDISPLAYTURNDEGREES)
                    displayTurnDegrees = MAXDISPLAYTURNDEGREES;
                else if (value < MINDISPLAYTURNDEGREES)
                    displayTurnDegrees = MINDISPLAYTURNDEGREES;

                displayTurnDegrees = value;
 
                Refresh();
            }
        }

        #endregion

        #region Private Properties

        private string TurnRadiusUnitName 
        {
            get { return "Feet";}
        }

        private string TurnSpeedUnitName
        {
            get { return "MPH"; }
        }


        private int LeftPadding
        {
            get { return (int)this.Width / 10; }
        }

        private int RightPadding
        {
            get { return (int)this.Width / 5; }
        }

        private int TopPadding
        {
            get { return (int)TitleFont.GetHeight() * 3; }
        }

        private int BottomPadding
        {
            get { return (int)this.Height / 6; }
        }

        private Font LegendFont
        {
            get
            {
                float fontEmSize = this.Size.Width / 80 ;
                return new Font(ControlTextFontFamily, fontEmSize, FontStyle.Regular);
            }
        }

        private Font AxisMarkingsFont
        {
            get
            {
                float fontEmSize = this.Size.Width / 90;
                return new Font(ControlTextFontFamily, fontEmSize, FontStyle.Regular);
            }
        }

        private Font TitleFont
        {
            get
            {
                float fontEmSize = this.Size.Width / 40;
                return new Font(ControlTextFontFamily, fontEmSize, FontStyle.Bold);
            }
        }

        private Font MinorTitleFont
        {
            get
            {
                float fontEmSize = this.Size.Width / 80;
                return new Font(ControlTextFontFamily, fontEmSize, FontStyle.Bold);
            }
        }



        #endregion

        #region Events 


        /// <summary>
        /// Handle the Paint event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            Size controlSize = e.ClipRectangle.Size;

            DrawTitle(grfx, controlSize);

            int initialGraphWidth = (this.Size.Width - LeftPadding - RightPadding);
            int initialGraphHeight = (int) initialGraphWidth / 2;
            int minorGridLinesSpacing = (int)(initialGraphWidth / NumberOfMinorXAxisGridMarks);

            // Define the graph rectangle. The X axis runs along the bottom, the Y axis runs along the Left.
            Rectangle graphRectangle = new Rectangle(LeftPadding,
                                         TopPadding,
                                         NumberOfMinorXAxisGridMarks * minorGridLinesSpacing,
                                         NumberOfMinorXAxisGridMarks * minorGridLinesSpacing / 2);

            // Draw the graph Axis
            DrawGraphAxis(grfx, graphRectangle);

            // Draw the minor grid lines.
            DrawMinorGridLines(grfx, graphRectangle, minorGridLinesSpacing);

            TurnPerformancePlot largestTurnRadiusPlot = FindLargestTurnRadius();
            float largestTurnRadius = largestTurnRadiusPlot.TurnRaduis;
            float largestTurnDiameter = largestTurnRadius * 2;
            int largestRoundedUpTurnRadius = (int)(largestTurnDiameter / UnitMultiple + 1) * UnitMultiple;
            int unitWidth = (int)(((largestRoundedUpTurnRadius / NumberOfMinorXAxisGridMarks) / UnitMultiple) + 1) * UnitMultiple;
            int widthPxBetweenMinorMarkings = (int)(graphRectangle.Width / NumberOfMinorXAxisGridMarks);

            // Draw X Axis minor gridline values.
            DrawXAxisMinorGridLineValues(grfx, graphRectangle, widthPxBetweenMinorMarkings, unitWidth);

            // Draw Y Axis minor gridline values.
            DrawYAxisMinorGridLineValues(grfx, graphRectangle, widthPxBetweenMinorMarkings, unitWidth);

            // Draw the axis labels.
            DrawAxisLabels(grfx, graphRectangle);

            TurnPerformancePlot fastestTurnRatePlot = FindFastestTurnRate();

            // Draw the minor title.
            DrawMinorTitle(grfx, fastestTurnRatePlot);

            tipRegionCollection.Clear();

            // For each plot to draw...
            foreach (TurnPerformancePlot plot in plots)
            {
                if (plot.TurnRateInDegPerSecond <= 0F)
                    continue;

                float arcDegrees = plot.TurnRateInDegPerSecond * (this.displayTurnDegrees / fastestTurnRatePlot.TurnRateInDegPerSecond);
                int arcRadius = (int)((plot.TurnRaduis / unitWidth) * widthPxBetweenMinorMarkings);
                int arcBoundingRectangleLeft = LeftPadding + 1;
                int arcBoundingRectangleTop = (graphRectangle.Height - arcRadius) + graphRectangle.Y - 1;

                //Draw the turn circle.
                grfx.DrawArc(plot.PlotPen,
                             new Rectangle((int)arcBoundingRectangleLeft, (int)arcBoundingRectangleTop, arcRadius * 2, arcRadius * 2),
                             180,
                             arcDegrees);

                // Draw the 'continuation' dashed line.
                int widthOfDashes = (int)(graphRectangle.Height / 60);
                if (widthOfDashes == 0)
                    widthOfDashes = 1;

                // draw the continuation dashed arc to complete the 180 degrees.
                Pen dashedPen = new Pen(Brushes.Gray);
                dashedPen.DashPattern = new float[] { widthOfDashes, widthOfDashes };
                grfx.DrawArc(dashedPen,
                             new Rectangle((int)arcBoundingRectangleLeft, (int)arcBoundingRectangleTop, arcRadius * 2, arcRadius * 2),
                             180 + arcDegrees,
                             180 - arcDegrees);

                // Find the end point of the arc so we can pop an end-cap and a label on it.
                int Y = (int)(arcRadius * Math.Sin(arcDegrees * Math.PI / 180));
                int X = (int)(arcRadius * Math.Cos(arcDegrees * Math.PI / 180));
                Y = arcBoundingRectangleTop + arcRadius - Y;
                X = arcBoundingRectangleLeft + arcRadius - X;

                // draw an end-cap at the end of the arc.
                int widthOfEndCap = (int)(graphRectangle.Height / 70);
                Pen endPointPen = new Pen(plot.PlotPen.Brush, widthOfEndCap/(float)1.3);
                grfx.DrawPolygon(endPointPen, GetFlapPositionTrianglePoints(plot, widthOfEndCap, X, Y));

                Point toolTipPoint = new Point(X - (widthOfEndCap / 2) * 2 + 1,
                                               Y - (widthOfEndCap / 2) * 2 + 1);

                Rectangle toolTipRectangle = new Rectangle(toolTipPoint.X - widthOfEndCap, toolTipPoint.Y - widthOfEndCap, widthOfEndCap * 3, widthOfEndCap * 3);
                tipRegionCollection.Add(new ToolTipRegion(toolTipRectangle, GetToolTipText(plot)));
            }

            AddLegend(grfx, graphRectangle);

            if (ShowToolTipRegions)
            {
                foreach (ToolTipRegion region in tipRegionCollection)
                {
                    grfx.DrawRectangle(new Pen(Brushes.Black, 2f), region.Region);
                }
            }
        }


        /// <summary>
        /// Handle the mouse move event. display tool tips if mouse is in the tool tips region.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TurnPerformanceUserControl_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (mouseLocation.Equals(e.Location))
                    return;

                foreach (ToolTipRegion region in tipRegionCollection)
                {
                    if (region.Region.Contains(e.Location))
                    {
                        tTip.Show(region.ToolTipText, this, e.X + 20, e.Y - 20);
                        return;
                    }
                }
                if (tTip.Active)
                {
                    tTip.Hide(this);
                }
            }
            finally
            {
                mouseLocation = e.Location;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Add the legend on the right hand side of the control to show which lines
        /// are which.
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="graphRectangle"></param>
        private void AddLegend(Graphics grfx, Rectangle graphRectangle)
        {
            if (plots.Count == 0)
                return;

            float maxLegendTxtWidth = 0;
            foreach (TurnPerformancePlot plot in plots)
            { 
                SizeF size = grfx.MeasureString(plot.PlotTitle, LegendFont);
                if (size.Width > maxLegendTxtWidth)
                    maxLegendTxtWidth = size.Width;
            }

            const int lineLength = 25;

            int legendHeight = LegendFont.Height * plots.Count + LegendFont.Height;
            int legendWidth = (int)(maxLegendTxtWidth + lineLength + 20);

            Point legendLocation = new Point(this.Width - legendWidth - 10, graphRectangle.Top - 5);
            Size legendSize = new Size(legendWidth, legendHeight);
            Rectangle legendRectangle = new Rectangle(legendLocation, legendSize);

            int shadowWidth = (int)(graphRectangle.Height / 50);
            Point shadowLocation = new Point(legendRectangle.Left + shadowWidth, legendRectangle.Top + shadowWidth);
            Rectangle shadowRectangle = new Rectangle(shadowLocation, legendSize);
            grfx.DrawRectangle(Pens.LightGray, shadowRectangle);
            grfx.FillRectangle(Brushes.LightGray, shadowRectangle.X + 1, shadowRectangle.Y + 1, shadowRectangle.Width - 1, shadowRectangle.Height - 1);


            grfx.DrawRectangle(Pens.Black, legendRectangle);
            grfx.FillRectangle(new Pen(this.BackColor).Brush, legendRectangle.X+1, legendRectangle.Y+1, legendRectangle.Width-1, legendRectangle.Height-1);
            
            for (int i = 1; i < plots.Count + 1; i++)
            { 
                TurnPerformancePlot plot = plots[i-1];
                const int linePadding = 10;

                // Draw the plot line as the key.
                Point startLinePoint = new Point(legendRectangle.Left + linePadding, legendRectangle.Top + i * LegendFont.Height);
                Point endLinePoint = new Point(legendRectangle.Left + linePadding + lineLength, legendRectangle.Top + i * LegendFont.Height);
                grfx.DrawLine(plot.PlotPen, startLinePoint, endLinePoint);

                // draw the triangle end cap at the end of the line.
                int widthOfEndCap = (int)(graphRectangle.Height / 70);
                Pen endPointPen = new Pen(plot.PlotPen.Brush, widthOfEndCap / (float)1.3);
                grfx.DrawPolygon(endPointPen, GetFlapPositionTrianglePoints(plot, widthOfEndCap, endLinePoint.X, endLinePoint.Y));

                // Draw the text description of the line.
                string legendText = plot.PlotTitle;
                PointF textLocationPointF = new PointF(legendRectangle.Left + lineLength + linePadding * 2,
                                                       (legendRectangle.Top + i * LegendFont.Height) - (LegendFont.Height / 2));
                grfx.DrawString(legendText, LegendFont, Brushes.Black, textLocationPointF);


                // Add the tooltip.
                Rectangle toolTipRectangle = new Rectangle(legendRectangle.Left, (int)textLocationPointF.Y + 2, legendRectangle.Width, LegendFont.Height - 2);
                tipRegionCollection.Add(new ToolTipRegion(toolTipRectangle, GetToolTipText(plot)));
            }
        }

        /// <summary>
        /// Draw the minor title under the major title.
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="fastestTurnRatePlot"></param>
        private void DrawMinorTitle(Graphics grfx, TurnPerformancePlot fastestTurnRatePlot)
        { 
            if (plots != null && plots.Count > 0)
            {
                string elapsedTimeMinorTitle = string.Format("After {0} elapsed seconds", Math.Round(this.displayTurnDegrees / fastestTurnRatePlot.TurnRateInDegPerSecond, 1));
                Point minorTitlePoint = GetTitleLocationPoint(grfx);
                minorTitlePoint.Y += (int)TitleFont.GetHeight();
                minorTitlePoint.X = (int)(this.Width / 2 - grfx.MeasureString(elapsedTimeMinorTitle, MinorTitleFont).Width / 2);
                grfx.DrawString(elapsedTimeMinorTitle, MinorTitleFont, MinorTitlePen.Brush, minorTitlePoint);
            }
        }


        /// <summary>
        /// Format up the tool tip text.
        /// </summary>
        /// <param name="plot"></param>
        /// <returns></returns>
        private string GetToolTipText(TurnPerformancePlot plot)
        {
            return string.Format("  {0}\n    Turn Radius = {1} {2}\n    Turn Rate = {3} degrees/second\n    Turn Speed = {4} {5}\n    Stall Speed = {6} {5}\n    Time To Turn 360 = {7} seconds",
                                    plot.PlotTitle,
                                    Math.Round(plot.TurnRaduis,1),
                                    TurnRadiusUnitName,
                                    Math.Round(plot.TurnRateInDegPerSecond,1),
                                    Math.Round(CalculateSpeed(plot), 0),
                                    TurnSpeedUnitName,
                                    Math.Round(plot.StallSpeed,1),
                                    Math.Round(360 / plot.TurnRateInDegPerSecond, 1));
        }


        /// <summary>
        /// Get the point array which represents a small equlateral triangle to be used as the arc end-cap.
        /// </summary>
        /// <param name="plot"></param>
        /// <param name="widthOfTriangleSide"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private Point[] GetFlapPositionTrianglePoints(TurnPerformancePlot plot, int widthOfTriangleSide, int X, int Y)
        {
            if (plot.FlapSetting == TurnPerformancePlot.FlapPosition.None)
            {
                Point pointA = new Point(X - widthOfTriangleSide, Y + widthOfTriangleSide);
                Point pointB = new Point(X + widthOfTriangleSide, Y + widthOfTriangleSide);
                Point pointC = new Point(X, Y - widthOfTriangleSide);
                Point pointD = new Point(X - widthOfTriangleSide, Y + widthOfTriangleSide);
                return new Point[] { pointA, pointB, pointC, pointD };
            }
            else
            {
                Point pointA = new Point(X - widthOfTriangleSide, Y - widthOfTriangleSide);
                Point pointB = new Point(X + widthOfTriangleSide, Y - widthOfTriangleSide);
                Point pointC = new Point(X, Y + widthOfTriangleSide);
                Point pointD = new Point(X - widthOfTriangleSide, Y - widthOfTriangleSide);
                return new Point[] { pointA, pointB, pointC, pointD };
            }
        }


        /// <summary>
        /// Calculate the speed from the turn rate and radius.
        /// </summary>
        /// <param name="plot"></param>
        /// <returns></returns>
        private double CalculateSpeed(TurnPerformancePlot plot)
        {
            double timeToTurnCompleteCircleInSecs = 360 / plot.TurnRateInDegPerSecond;
            double cirumference = (plot.TurnRaduis * 2) * Math.PI;
            return (cirumference / 5280) / (timeToTurnCompleteCircleInSecs / 60 / 60);
        }


        /// <summary>
        /// The the title's location point on the control.
        /// </summary>
        /// <param name="grfx"></param>
        /// <returns></returns>
        private Point GetTitleLocationPoint(Graphics grfx)
        {
            SizeF sizeOfTitle = grfx.MeasureString(Title, TitleFont);
            return new Point((int)(this.Size.Width / 2 - sizeOfTitle.Width / 2), (int)(sizeOfTitle.Height * 0.5) ); 
        }


        /// <summary>
        /// Draw the axis labels.
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="graphRectangle"></param>
        private void DrawAxisLabels(Graphics grfx, Rectangle graphRectangle)
        {
            string xAxisLabel = string.Format("Across Range({0})", TurnRadiusUnitName);
            SizeF sizeOfXAxisLabel = grfx.MeasureString(xAxisLabel, AxisMarkingsFont);
            PointF locationOfXAxisLabel = new PointF(graphRectangle.Width / 2 + graphRectangle.Left - sizeOfXAxisLabel.Width / 2,
                                                     graphRectangle.Bottom + sizeOfXAxisLabel.Height * 2 + 5);
            grfx.DrawString(xAxisLabel, AxisMarkingsFont, XAxisPen.Brush, locationOfXAxisLabel);

            string yAxisLabel = string.Format("Down Range ({0})", TurnRadiusUnitName);
            SizeF sizeOfYAxisLabel = grfx.MeasureString(yAxisLabel, AxisMarkingsFont);
            
            string widestLabel = "100";
            if (FindLargestTurnRadius().TurnRaduis != 0)
                widestLabel = FindLargestTurnRadius().TurnRaduis.ToString();

            PointF locationOfYAxisLabel = new PointF(graphRectangle.Left - sizeOfYAxisLabel.Height - grfx.MeasureString(widestLabel, AxisMarkingsFont).Width - 12,
                                                     graphRectangle.Bottom - graphRectangle.Height / 2 - sizeOfYAxisLabel.Width / 2);
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionVertical;
            grfx.DrawString(yAxisLabel, AxisMarkingsFont, YAxisPen.Brush, locationOfYAxisLabel, sf);
        }


        /// <summary>
        /// Draw the Y Axis minor grid line values along the Y axis.
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="graphRectangle"></param>
        /// <param name="widthPxBetweenMinorMarkings"></param>
        /// <param name="unitWidth"></param>
        private void DrawYAxisMinorGridLineValues(Graphics grfx, Rectangle graphRectangle, int widthPxBetweenMinorMarkings, int unitWidth)
        {
            //  Draw the Y axis point labels.
            for (int yUnit = 0; yUnit <= NumberOfMinorXAxisGridMarks / 2; yUnit++)
            {
                if (yUnit == 0)
                    continue;

                SizeF sizeOfMarking = grfx.MeasureString(yUnit.ToString(), AxisMarkingsFont);

                PointF markingLocation = new PointF(graphRectangle.Left - sizeOfMarking.Width - sizeOfMarking.Height * (float)1.5 ,
                                                    graphRectangle.Bottom - (yUnit * widthPxBetweenMinorMarkings) - (sizeOfMarking.Height / 2));

                grfx.DrawString((yUnit * unitWidth).ToString(), AxisMarkingsFont, YAxisPen.Brush, markingLocation);
            }
        }


        /// <summary>
        /// Draw the X Axis minor grid line values along the X axis.
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="graphRectangle"></param>
        /// <param name="widthPxBetweenMinorMarkings"></param>
        /// <param name="unitWidth"></param>
        private void DrawXAxisMinorGridLineValues(Graphics grfx, Rectangle graphRectangle, int widthPxBetweenMinorMarkings, int unitWidth)
        {
            //  Draw the X axis point labels.
            for (int xUnit = 0; xUnit <= NumberOfMinorXAxisGridMarks; xUnit++)
            {
                if (xUnit == 0)
                    continue;

                SizeF sizeOfMarking = grfx.MeasureString((xUnit * unitWidth).ToString(), AxisMarkingsFont);

                PointF markingLocation = new PointF(graphRectangle.Left + (xUnit * widthPxBetweenMinorMarkings) - (sizeOfMarking.Width / 2),
                                                    graphRectangle.Bottom + AxisMarkingsFont.GetHeight());

                grfx.DrawString((xUnit * unitWidth).ToString(), AxisMarkingsFont, XAxisPen.Brush, markingLocation);
            }
        }


        /// <summary>
        /// Draw the actual X and Y axis of the graph
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="graphRectangle"></param>
        private void DrawGraphAxis(Graphics grfx, Rectangle graphRectangle)
        {
            // Draw the Y axis
            grfx.DrawLine(XAxisPen,
                          new Point(graphRectangle.Left, graphRectangle.Top),
                          new Point(graphRectangle.Left, graphRectangle.Bottom));

            // Draw the X axis
            grfx.DrawLine(YAxisPen,
                          new Point(graphRectangle.Left, graphRectangle.Bottom),
                          new Point(graphRectangle.Right, graphRectangle.Bottom));
        }


        /// <summary>
        /// Draw the minor gridlines on the graph.
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="graphRectangle"></param>
        /// <param name="minorGridLinesSpacing"></param>
        private void DrawMinorGridLines(Graphics grfx, Rectangle graphRectangle, int minorGridLinesSpacing)
        {
            // Draw the X minor grid lines.
            for (int xItr = 1; xItr <= NumberOfMinorXAxisGridMarks; xItr++)
            {
                grfx.DrawLine(MinorAxisMarkingsPen,
                              new Point(graphRectangle.Left + xItr * minorGridLinesSpacing, graphRectangle.Top),
                              new Point(graphRectangle.Left + xItr * minorGridLinesSpacing, graphRectangle.Bottom - 1));

                grfx.DrawLine(XAxisPen,
                              new Point(graphRectangle.Left + xItr * minorGridLinesSpacing, graphRectangle.Bottom + 2),
                              new Point(graphRectangle.Left + xItr * minorGridLinesSpacing, graphRectangle.Bottom + 1));
            }

            // Draw the Y minor grid lines.
            for (int yItr = (NumberOfMinorXAxisGridMarks / 2); yItr > 0; yItr--)
            {
                grfx.DrawLine(MinorAxisMarkingsPen,
                              new Point(graphRectangle.Left + 1, graphRectangle.Bottom - yItr * minorGridLinesSpacing),
                              new Point(graphRectangle.Right, graphRectangle.Bottom - yItr * minorGridLinesSpacing));

                grfx.DrawLine(YAxisPen,
                              new Point(graphRectangle.Left - 1, graphRectangle.Bottom - yItr * minorGridLinesSpacing),
                              new Point(graphRectangle.Left - 2, graphRectangle.Bottom - yItr * minorGridLinesSpacing));
            }
        }


        /// <summary>
        /// Find the plot with the largest turn radius.
        /// </summary>
        /// <returns></returns>
        private TurnPerformancePlot FindLargestTurnRadius()
        {
            TurnPerformancePlot largestTurnRadiusPlot = new TurnPerformancePlot();

            foreach (TurnPerformancePlot plot in plots)
            {
                if (plot.TurnRaduis > largestTurnRadiusPlot.TurnRaduis)
                    largestTurnRadiusPlot = plot;
            }

            return largestTurnRadiusPlot;
        }


        /// <summary>
        /// Find the plot with the quickest turn rate.
        /// </summary>
        /// <returns></returns>
        private TurnPerformancePlot FindFastestTurnRate()
        {
            TurnPerformancePlot fastestTurnRatePlot = new TurnPerformancePlot();

            foreach (TurnPerformancePlot plot in plots)
            {
                if (plot.TurnRateInDegPerSecond > fastestTurnRatePlot.TurnRateInDegPerSecond)
                    fastestTurnRatePlot = plot;
            }

            return fastestTurnRatePlot;
        }


        /// <summary>
        /// Render the Graph Title.
        /// </summary>
        /// <param name="grfx"></param>
        /// <param name="controlSize"></param>
        private void DrawTitle(Graphics grfx, Size controlSize)
        {
            grfx.DrawString(Title,
                            TitleFont,
                            TitlePen.Brush,
                            GetTitleLocationPoint(grfx));
        }

        #endregion



    }
}
