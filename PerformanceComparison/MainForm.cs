using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using NPlot;
using System.Collections.Generic;
using PerformanceComparison.ControlLibrary.DomainObjects;


namespace PerformanceComparison
{

    /// <summary>
    /// Main application form.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly object lockObj = new object();
        private enum plotType { Climb, Speed };
        private int _numPlots;
        private Timer flashTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();

            string[] aircraft = System.IO.Directory.GetFiles(@"airData","*.xml");

            foreach (string s in aircraft)
            {   
                string t = s.Substring(s.IndexOf(@"\")+1);
                AircraftList.Items.Add(t.Substring(0,t.IndexOf(".")), false);
            }

            trackBarDuration.Value = 30;
            flashTimer.Interval = 500;
            flashTimer.Tick += new EventHandler(flashTimer_Tick);
        }

        #region Event Handlers

        void flashTimer_Tick(object sender, EventArgs e)
        {
            statusLabel.Visible = !statusLabel.Visible;
        }

        private void trackBarDuration_ValueChanged(object sender, EventArgs e)
        {
            turnPerformanceUserControl.DisplayTurnDegrees = trackBarDuration.Value * 5;
        }

        private void AircraftList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string selectedAircraftName = AircraftList.SelectedItem.ToString();

            if (e.NewValue == CheckState.Unchecked)
            {
                Registry.Instance.AircraftColours.RemoveAircraftAssociation(selectedAircraftName);
            }
        }

        private void AircraftList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void AircraftList_DoubleClick(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void MilCheck_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void WepCheck_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkboxSustainedTurn_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void chkboxInstantTurn_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void chkboxClean_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void chkboxFullFlaps_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            RefreshPlots();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Equals(turnTab))
            {
                this.WepCheck.Visible = this.MilCheck.Visible = false;
            }
            else
            {
                this.WepCheck.Visible = this.MilCheck.Visible = true;
                this.lblMessage.Text = string.Empty;
            }
            RefreshPlots();
        }

        #endregion

        #region Private Methods

        private void DrawAircraft(plotType pType, string ac)
        {
            if (MilCheck.Checked)
            {
                DrawAircraftData(ac, pType, false);
            }

            if (WepCheck.Checked)
            {
                DrawAircraftData(ac, pType, true);
            }
        }

        private void DrawAircraftData(string ac, plotType pType, bool wep)
        {
            PerformanceBL bl = new PerformanceBL(ac);

            ArrayList heights = new ArrayList();
            ArrayList rates = new ArrayList();

            if (pType == plotType.Speed)
                bl.GetSpeedData(heights, rates, wep);
            if (pType == plotType.Climb)
                bl.GetClimbData(heights, rates, wep);

            if ((heights.Count == 0) || (rates.Count == 0))
                return;

            _numPlots++;

            LinePlot lp = new LinePlot();
            lp.OrdinateData = heights;
            lp.AbscissaData = rates;

            lp.Color = Registry.Instance.AircraftColours.GetAircraftColour(ac);
            lp.Pen.Width = 2.0f;
            lp.ShowInLegend = true;

            if (wep)
            {
                lp.Label = string.Concat(ac, " - ", "WEP");
                lp.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }
            else
            {
                lp.Label = string.Concat(ac, " - ", "MIL");
                lp.Pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }

            if (pType == plotType.Speed)
                SpeedPlot.Add(lp);
            if (pType == plotType.Climb)
                ClimbPlot.Add(lp);
        }

        private void RefreshPlots()
        {            
            lock (lockObj)
            {
                if (!IsSaneToDisplayData())
                {
                    SetControlVisibility(false);
                    lblMessage.Hide();
                    return;
                }

                Reset();
                SetControlVisibility(true);
                statusLabel.Text = string.Empty;
                lblMessage.Text = string.Empty;
                flashTimer.Stop();

                if (tabControl1.SelectedTab.Equals(climbTab))
                    RefreshPlot(plotType.Climb, true, "Climb Performance", "fpm", 100);

                else if (tabControl1.SelectedTab.Equals(speedTab))
                    RefreshPlot(plotType.Speed, true, "Speed Performance", "mph", 10);
                
                else if (tabControl1.SelectedTab.Equals(turnTab))
                    RefreshTurnPlots();
            }
        }

        private bool AreAllColoursUsed()
        {
            return (AircraftList.CheckedItems.Count > new ColourAssociations().NumberOfColours);
        }

        private void RefreshPlot(plotType pType, bool legend, string title, string XLabel, int margin)
        {
            NPlot.Windows.PlotSurface2D surf = null;

            if (pType == plotType.Speed)
                surf = SpeedPlot;
            if (pType == plotType.Climb)
                surf = ClimbPlot;

            _numPlots = 0;
            foreach (int i in AircraftList.CheckedIndices)
            {
                DrawAircraft(pType, AircraftList.Items[i].ToString());
            }

            if (_numPlots == 0)
                return;

            if (legend)
                AttachLegend(surf);

            surf.Title = title;
            surf.XAxis1.Label = XLabel;
            surf.YAxis1.Label = "feet";

            surf.YAxis1.WorldMin = 0;
            surf.XAxis1.WorldMin -= margin;
            surf.XAxis1.WorldMax += margin;

            Grid grid = new Grid();
            grid.VerticalGridType = Grid.GridType.Fine;
            grid.HorizontalGridType = Grid.GridType.Fine;
            grid.MajorGridPen = new Pen(Color.LightGray, 0.5f);

            surf.Add(grid);
            surf.Refresh();
            
        }

        private void AttachLegend(NPlot.Windows.PlotSurface2D surf)
        {
            Legend leg = new Legend();
            leg.AttachTo(PlotSurface2D.XAxisPosition.Top, PlotSurface2D.YAxisPosition.Right);
            leg.HorizontalEdgePlacement = Legend.Placement.Inside;
            leg.VerticalEdgePlacement = Legend.Placement.Outside;
            leg.XOffset = 10;
            leg.YOffset = 10;
            surf.Legend = leg;
            surf.LegendZOrder = 10;
        }

        private void Reset()
        {
            SpeedPlot.Clear();
            SpeedPlot.Refresh();
            ClimbPlot.Clear();
            ClimbPlot.Refresh();
            turnPerformanceUserControl.ResetControl();
        }

        private void WarnUser(string message)
        {
            statusLabel.ForeColor = Color.Red;
            statusLabel.Text = message;
            flashTimer.Start();
            Reset();
        }

        private bool IsSaneToDisplayData()
        {
            if (AreAllColoursUsed())
            {
                WarnUser("No more colours exist, please de-select an aircraft to display.");
                return false;
            }

            if ((AircraftList.CheckedIndices.Count == 0))
            {
                WarnUser("Please select aircraft from the left to display.");
                return false;
            }

            if (!tabControl1.SelectedTab.Equals(turnTab) && !MilCheck.Checked && !WepCheck.Checked)
            {
                WarnUser("Please choose to display aircraft for either MIL or WEP power settings.");
                return false;
            }

            return true;
        }

        private void SetControlVisibility(bool visible)
        {
            grpboxSelectTurnType.Visible = visible;
            grpboxConfiguration.Visible = visible;
            grpboxDuration.Visible = visible;
            turnPerformanceUserControl.Visible = visible;
        }

        private void RefreshTurnPlots()
        {
            lblMessage.Text = "Turn data obtained at aircraft's maximum power setting";
            lblMessage.Show();

            turnPerformanceUserControl.Title = "Turn Performance";
            foreach (int i in AircraftList.CheckedIndices)
            {
                string acName = AircraftList.Items[i].ToString(); 
                PerformanceBL bl = new PerformanceBL(acName);

                TurnData noFlapsData;
                TurnData fullFlapsData;
                bl.GetAllTurnData(out noFlapsData, out fullFlapsData);

                BuildNewCustomTurnPerformanceGraph(acName, noFlapsData, fullFlapsData);
            }
        }


        private void BuildNewCustomTurnPerformanceGraph(string aircraftName, TurnData noFlapsData, TurnData fullFlapsData)
        {
            if (chkboxSustainedTurn.Checked)
            {
                BuildTurnPerformancePlot(aircraftName, true, noFlapsData, fullFlapsData);       
            }

            if (chkboxInstantTurn.Checked)
            {
                BuildTurnPerformancePlot(aircraftName, false, noFlapsData, fullFlapsData);
            }

            turnPerformanceUserControl.Refresh();
        }


        private void BuildTurnPerformancePlot(string aircraftName, bool sustained, TurnData noFlapsData, TurnData fullFlapsData)
        {
            if (chkboxClean.Checked)
            {
                TurnPerformancePlot cleanPlot = new TurnPerformancePlot();
                AddTurnPlot(cleanPlot, noFlapsData, sustained, aircraftName, TurnPerformancePlot.FlapPosition.None);
            }
            
            if(chkboxFullFlaps.Checked)
            {
                TurnPerformancePlot fullFlapsPlot = new TurnPerformancePlot();
                AddTurnPlot(fullFlapsPlot, fullFlapsData, sustained, aircraftName, TurnPerformancePlot.FlapPosition.Full);
            }
        }


        private void AddTurnPlot(TurnPerformancePlot plot, TurnData turnData, bool sustained, string aircraftName, TurnPerformancePlot.FlapPosition flapPosition)
        {
            plot.StallSpeed = turnData.StallSpeed;
            plot.FlapSetting = flapPosition;
            Pen plotPen = new Pen(Registry.Instance.AircraftColours.GetAircraftColour(aircraftName));
            plotPen.Width = 1F;
            plot.PlotPen = plotPen;
            if (sustained)
            {
                plot.PlotTitle = string.Format("{0} (Sust/{1})", aircraftName, flapPosition == TurnPerformancePlot.FlapPosition.Full ? "Full Flaps" : "Clean");
                plot.TurnRaduis = turnData.SustainedTurnRadius;
                plot.TurnRateInDegPerSecond = turnData.SustainedTurnRate;
            }
            else
            {
                plot.PlotTitle = string.Format("{0} (Inst/{1})", aircraftName, flapPosition == TurnPerformancePlot.FlapPosition.Full ? "Full Flaps" : "Clean");
                plotPen.DashPattern = new float[] { 2, 2 };
                plot.TurnRaduis = turnData.TurnRadiusAtCorner;
                plot.TurnRateInDegPerSecond = turnData.TurnRateAtCorner;
            }

            turnPerformanceUserControl.AddPlot(plot);
        }

        #endregion

    }
}