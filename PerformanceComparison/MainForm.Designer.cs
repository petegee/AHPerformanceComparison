namespace PerformanceComparison
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.WepCheck = new System.Windows.Forms.CheckBox();
            this.MilCheck = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.AircraftList = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.speedTab = new System.Windows.Forms.TabPage();
            this.SpeedPlot = new NPlot.Windows.PlotSurface2D();
            this.climbTab = new System.Windows.Forms.TabPage();
            this.ClimbPlot = new NPlot.Windows.PlotSurface2D();
            this.turnTab = new System.Windows.Forms.TabPage();
            this.grpboxDuration = new System.Windows.Forms.GroupBox();
            this.trackBarDuration = new System.Windows.Forms.TrackBar();
            this.grpboxConfiguration = new System.Windows.Forms.GroupBox();
            this.chkboxClean = new System.Windows.Forms.CheckBox();
            this.chkboxFullFlaps = new System.Windows.Forms.CheckBox();
            this.grpboxSelectTurnType = new System.Windows.Forms.GroupBox();
            this.chkboxInstantTurn = new System.Windows.Forms.CheckBox();
            this.chkboxSustainedTurn = new System.Windows.Forms.CheckBox();
            this.turnPerformanceUserControl = new PerformanceComparison.ControlLibrary.TurnPerformanceUserControl();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.speedTab.SuspendLayout();
            this.climbTab.SuspendLayout();
            this.turnTab.SuspendLayout();
            this.grpboxDuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).BeginInit();
            this.grpboxConfiguration.SuspendLayout();
            this.grpboxSelectTurnType.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.WepCheck);
            this.panel1.Controls.Add(this.MilCheck);
            this.panel1.Location = new System.Drawing.Point(0, 687);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 45);
            this.panel1.TabIndex = 5;
            // 
            // WepCheck
            // 
            this.WepCheck.AutoSize = true;
            this.WepCheck.Checked = true;
            this.WepCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WepCheck.Location = new System.Drawing.Point(5, 26);
            this.WepCheck.Name = "WepCheck";
            this.WepCheck.Size = new System.Drawing.Size(51, 17);
            this.WepCheck.TabIndex = 5;
            this.WepCheck.Text = "WEP";
            this.WepCheck.CheckedChanged += new System.EventHandler(this.WepCheck_CheckedChanged);
            // 
            // MilCheck
            // 
            this.MilCheck.AutoSize = true;
            this.MilCheck.Checked = true;
            this.MilCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MilCheck.Location = new System.Drawing.Point(5, 3);
            this.MilCheck.Name = "MilCheck";
            this.MilCheck.Size = new System.Drawing.Size(44, 17);
            this.MilCheck.TabIndex = 4;
            this.MilCheck.Text = "MIL";
            this.MilCheck.CheckedChanged += new System.EventHandler(this.MilCheck_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(1038, 64);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::PerformanceComparison.AppResource.AKUAG;
            this.pictureBox1.Location = new System.Drawing.Point(238, 0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(800, 64);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(64, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox3.Image = global::PerformanceComparison.AppResource.AKUAG;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(800, 64);
            this.pictureBox3.MinimumSize = new System.Drawing.Size(64, 64);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(800, 64);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "&Application";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(152, 700);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(43, 13);
            this.statusLabel.TabIndex = 14;
            this.statusLabel.Text = "[Status]";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 91);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.AircraftList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer2.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(1038, 590);
            this.splitContainer2.SplitterDistance = 130;
            this.splitContainer2.TabIndex = 12;
            this.splitContainer2.Text = "splitContainer2";
            // 
            // AircraftList
            // 
            this.AircraftList.CausesValidation = false;
            this.AircraftList.CheckOnClick = true;
            this.AircraftList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftList.FormattingEnabled = true;
            this.AircraftList.IntegralHeight = false;
            this.AircraftList.Location = new System.Drawing.Point(0, 0);
            this.AircraftList.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftList.MinimumSize = new System.Drawing.Size(110, 200);
            this.AircraftList.Name = "AircraftList";
            this.AircraftList.Size = new System.Drawing.Size(126, 586);
            this.AircraftList.TabIndex = 2;
            this.AircraftList.SelectedIndexChanged += new System.EventHandler(this.AircraftList_SelectedIndexChanged);
            this.AircraftList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.AircraftList_ItemCheck);
            this.AircraftList.DoubleClick += new System.EventHandler(this.AircraftList_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.speedTab);
            this.tabControl1.Controls.Add(this.climbTab);
            this.tabControl1.Controls.Add(this.turnTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 586);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // speedTab
            // 
            this.speedTab.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.speedTab.Controls.Add(this.SpeedPlot);
            this.speedTab.Location = new System.Drawing.Point(4, 22);
            this.speedTab.Name = "speedTab";
            this.speedTab.Padding = new System.Windows.Forms.Padding(3);
            this.speedTab.Size = new System.Drawing.Size(892, 560);
            this.speedTab.TabIndex = 0;
            this.speedTab.Text = "Speed Performance";
            // 
            // SpeedPlot
            // 
            this.SpeedPlot.AutoScaleAutoGeneratedAxes = false;
            this.SpeedPlot.AutoScaleTitle = false;
            this.SpeedPlot.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SpeedPlot.DateTimeToolTip = false;
            this.SpeedPlot.Dock = System.Windows.Forms.DockStyle.Left;
            this.SpeedPlot.Legend = null;
            this.SpeedPlot.LegendZOrder = -1;
            this.SpeedPlot.Location = new System.Drawing.Point(3, 3);
            this.SpeedPlot.Name = "SpeedPlot";
            this.SpeedPlot.RightMenu = null;
            this.SpeedPlot.ShowCoordinates = true;
            this.SpeedPlot.Size = new System.Drawing.Size(681, 554);
            this.SpeedPlot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.SpeedPlot.TabIndex = 8;
            this.SpeedPlot.Text = "plotSurface2D1";
            this.SpeedPlot.Title = "";
            this.SpeedPlot.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SpeedPlot.XAxis1 = null;
            this.SpeedPlot.XAxis2 = null;
            this.SpeedPlot.YAxis1 = null;
            this.SpeedPlot.YAxis2 = null;
            // 
            // climbTab
            // 
            this.climbTab.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.climbTab.Controls.Add(this.ClimbPlot);
            this.climbTab.Location = new System.Drawing.Point(4, 22);
            this.climbTab.Name = "climbTab";
            this.climbTab.Padding = new System.Windows.Forms.Padding(3);
            this.climbTab.Size = new System.Drawing.Size(876, 560);
            this.climbTab.TabIndex = 1;
            this.climbTab.Text = "Climb Performance";
            // 
            // ClimbPlot
            // 
            this.ClimbPlot.AutoScaleAutoGeneratedAxes = false;
            this.ClimbPlot.AutoScaleTitle = false;
            this.ClimbPlot.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClimbPlot.DateTimeToolTip = false;
            this.ClimbPlot.Dock = System.Windows.Forms.DockStyle.Left;
            this.ClimbPlot.Legend = null;
            this.ClimbPlot.LegendZOrder = -1;
            this.ClimbPlot.Location = new System.Drawing.Point(3, 3);
            this.ClimbPlot.Name = "ClimbPlot";
            this.ClimbPlot.RightMenu = null;
            this.ClimbPlot.ShowCoordinates = true;
            this.ClimbPlot.Size = new System.Drawing.Size(681, 554);
            this.ClimbPlot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.ClimbPlot.TabIndex = 9;
            this.ClimbPlot.Text = "plotSurface2D1";
            this.ClimbPlot.Title = "";
            this.ClimbPlot.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ClimbPlot.XAxis1 = null;
            this.ClimbPlot.XAxis2 = null;
            this.ClimbPlot.YAxis1 = null;
            this.ClimbPlot.YAxis2 = null;
            // 
            // turnTab
            // 
            this.turnTab.BackColor = System.Drawing.Color.White;
            this.turnTab.Controls.Add(this.grpboxDuration);
            this.turnTab.Controls.Add(this.grpboxConfiguration);
            this.turnTab.Controls.Add(this.grpboxSelectTurnType);
            this.turnTab.Controls.Add(this.turnPerformanceUserControl);
            this.turnTab.Location = new System.Drawing.Point(4, 22);
            this.turnTab.Name = "turnTab";
            this.turnTab.Padding = new System.Windows.Forms.Padding(3);
            this.turnTab.Size = new System.Drawing.Size(876, 560);
            this.turnTab.TabIndex = 2;
            this.turnTab.Text = "Turn Performance";
            // 
            // grpboxDuration
            // 
            this.grpboxDuration.Controls.Add(this.trackBarDuration);
            this.grpboxDuration.Location = new System.Drawing.Point(507, 491);
            this.grpboxDuration.Name = "grpboxDuration";
            this.grpboxDuration.Size = new System.Drawing.Size(245, 62);
            this.grpboxDuration.TabIndex = 12;
            this.grpboxDuration.TabStop = false;
            this.grpboxDuration.Text = "Ellapsed Time";
            // 
            // trackBarDuration
            // 
            this.trackBarDuration.Location = new System.Drawing.Point(21, 14);
            this.trackBarDuration.Maximum = 36;
            this.trackBarDuration.Name = "trackBarDuration";
            this.trackBarDuration.Size = new System.Drawing.Size(206, 45);
            this.trackBarDuration.TabIndex = 11;
            this.trackBarDuration.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarDuration.ValueChanged += new System.EventHandler(this.trackBarDuration_ValueChanged);
            // 
            // grpboxConfiguration
            // 
            this.grpboxConfiguration.Controls.Add(this.chkboxClean);
            this.grpboxConfiguration.Controls.Add(this.chkboxFullFlaps);
            this.grpboxConfiguration.Location = new System.Drawing.Point(255, 491);
            this.grpboxConfiguration.Name = "grpboxConfiguration";
            this.grpboxConfiguration.Size = new System.Drawing.Size(245, 62);
            this.grpboxConfiguration.TabIndex = 10;
            this.grpboxConfiguration.TabStop = false;
            this.grpboxConfiguration.Text = "Select Configuration";
            // 
            // chkboxClean
            // 
            this.chkboxClean.AutoSize = true;
            this.chkboxClean.Checked = true;
            this.chkboxClean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxClean.Location = new System.Drawing.Point(11, 19);
            this.chkboxClean.Name = "chkboxClean";
            this.chkboxClean.Size = new System.Drawing.Size(53, 17);
            this.chkboxClean.TabIndex = 2;
            this.chkboxClean.Text = "Clean";
            this.chkboxClean.UseVisualStyleBackColor = true;
            this.chkboxClean.CheckedChanged += new System.EventHandler(this.chkboxClean_CheckedChanged);
            // 
            // chkboxFullFlaps
            // 
            this.chkboxFullFlaps.AutoSize = true;
            this.chkboxFullFlaps.Location = new System.Drawing.Point(118, 19);
            this.chkboxFullFlaps.Name = "chkboxFullFlaps";
            this.chkboxFullFlaps.Size = new System.Drawing.Size(70, 17);
            this.chkboxFullFlaps.TabIndex = 3;
            this.chkboxFullFlaps.Text = "Full Flaps";
            this.chkboxFullFlaps.UseVisualStyleBackColor = true;
            this.chkboxFullFlaps.CheckedChanged += new System.EventHandler(this.chkboxFullFlaps_CheckedChanged);
            // 
            // grpboxSelectTurnType
            // 
            this.grpboxSelectTurnType.Controls.Add(this.chkboxInstantTurn);
            this.grpboxSelectTurnType.Controls.Add(this.chkboxSustainedTurn);
            this.grpboxSelectTurnType.Location = new System.Drawing.Point(6, 491);
            this.grpboxSelectTurnType.Name = "grpboxSelectTurnType";
            this.grpboxSelectTurnType.Size = new System.Drawing.Size(243, 62);
            this.grpboxSelectTurnType.TabIndex = 9;
            this.grpboxSelectTurnType.TabStop = false;
            this.grpboxSelectTurnType.Text = "Select Turn Type";
            // 
            // chkboxInstantTurn
            // 
            this.chkboxInstantTurn.AutoSize = true;
            this.chkboxInstantTurn.Location = new System.Drawing.Point(116, 19);
            this.chkboxInstantTurn.Name = "chkboxInstantTurn";
            this.chkboxInstantTurn.Size = new System.Drawing.Size(118, 17);
            this.chkboxInstantTurn.TabIndex = 1;
            this.chkboxInstantTurn.Text = "Instantaneous Turn";
            this.chkboxInstantTurn.UseVisualStyleBackColor = true;
            this.chkboxInstantTurn.CheckedChanged += new System.EventHandler(this.chkboxInstantTurn_CheckedChanged);
            // 
            // chkboxSustainedTurn
            // 
            this.chkboxSustainedTurn.AutoSize = true;
            this.chkboxSustainedTurn.Checked = true;
            this.chkboxSustainedTurn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxSustainedTurn.Location = new System.Drawing.Point(9, 19);
            this.chkboxSustainedTurn.Name = "chkboxSustainedTurn";
            this.chkboxSustainedTurn.Size = new System.Drawing.Size(98, 17);
            this.chkboxSustainedTurn.TabIndex = 0;
            this.chkboxSustainedTurn.Text = "Sustained Turn";
            this.chkboxSustainedTurn.UseVisualStyleBackColor = true;
            this.chkboxSustainedTurn.CheckedChanged += new System.EventHandler(this.chkboxSustainedTurn_CheckedChanged);
            // 
            // turnPerformanceUserControl
            // 
            this.turnPerformanceUserControl.ControlTextFontFamily = "Arial New";
            this.turnPerformanceUserControl.DisplayTurnDegrees = 150;
            this.turnPerformanceUserControl.Location = new System.Drawing.Point(0, 0);
            this.turnPerformanceUserControl.Name = "turnPerformanceUserControl";
            this.turnPerformanceUserControl.NumberOfMinorXAxisGridMarks = 14;
            this.turnPerformanceUserControl.ShowToolTipRegions = false;
            this.turnPerformanceUserControl.Size = new System.Drawing.Size(877, 502);
            this.turnPerformanceUserControl.TabIndex = 8;
            this.turnPerformanceUserControl.Title = null;
            this.turnPerformanceUserControl.UnitMultiple = 25;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(422, 700);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(55, 13);
            this.lblMessage.TabIndex = 15;
            this.lblMessage.Text = "[message]";
            this.lblMessage.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 732);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer2);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1046, 768);
            this.MinimumSize = new System.Drawing.Size(1046, 768);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Aces High II Aircraft Performance Comparison";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.speedTab.ResumeLayout(false);
            this.climbTab.ResumeLayout(false);
            this.turnTab.ResumeLayout(false);
            this.grpboxDuration.ResumeLayout(false);
            this.grpboxDuration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).EndInit();
            this.grpboxConfiguration.ResumeLayout(false);
            this.grpboxConfiguration.PerformLayout();
            this.grpboxSelectTurnType.ResumeLayout(false);
            this.grpboxSelectTurnType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox AircraftList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox WepCheck;
        private System.Windows.Forms.CheckBox MilCheck;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NPlot.Windows.PlotSurface2D SpeedPlot;
        private NPlot.Windows.PlotSurface2D ClimbPlot;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage speedTab;
        private System.Windows.Forms.TabPage climbTab;
        private System.Windows.Forms.TabPage turnTab;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private PerformanceComparison.ControlLibrary.TurnPerformanceUserControl turnPerformanceUserControl;
        private System.Windows.Forms.GroupBox grpboxSelectTurnType;
        private System.Windows.Forms.CheckBox chkboxFullFlaps;
        private System.Windows.Forms.CheckBox chkboxClean;
        private System.Windows.Forms.CheckBox chkboxInstantTurn;
        private System.Windows.Forms.CheckBox chkboxSustainedTurn;
        private System.Windows.Forms.GroupBox grpboxConfiguration;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TrackBar trackBarDuration;
        private System.Windows.Forms.GroupBox grpboxDuration;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label lblMessage;

    }
}

