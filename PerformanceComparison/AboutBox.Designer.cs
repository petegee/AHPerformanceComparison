namespace PerformanceComparison
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.okButton = new System.Windows.Forms.Button();
            this.headline = new System.Windows.Forms.Label();
            this.copyright = new System.Windows.Forms.Label();
            this.authors = new System.Windows.Forms.Label();
            this.labelAssemblyVersion = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.textBoxWaffle = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.akuagCrestPicPox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.akuagCrestPicPox)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(383, 326);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // headline
            // 
            this.headline.AutoSize = true;
            this.headline.Location = new System.Drawing.Point(93, 9);
            this.headline.Name = "headline";
            this.headline.Size = new System.Drawing.Size(183, 13);
            this.headline.TabIndex = 27;
            this.headline.Text = "Aces High II Aircraft Comparison Tool";
            // 
            // copyright
            // 
            this.copyright.AutoSize = true;
            this.copyright.Location = new System.Drawing.Point(93, 24);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(263, 13);
            this.copyright.TabIndex = 28;
            this.copyright.Text = "Copyright 2005 Airborne Kitchen Utensil Assualt Group";
            // 
            // authors
            // 
            this.authors.AutoSize = true;
            this.authors.Location = new System.Drawing.Point(93, 39);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(150, 13);
            this.authors.TabIndex = 29;
            this.authors.Text = "Created by Spatula and Ladle.";
            // 
            // labelAssemblyVersion
            // 
            this.labelAssemblyVersion.AutoSize = true;
            this.labelAssemblyVersion.Location = new System.Drawing.Point(144, 54);
            this.labelAssemblyVersion.Name = "labelAssemblyVersion";
            this.labelAssemblyVersion.Size = new System.Drawing.Size(35, 13);
            this.labelAssemblyVersion.TabIndex = 30;
            this.labelAssemblyVersion.Text = "label1";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(95, 54);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(45, 13);
            this.version.TabIndex = 31;
            this.version.Text = "Version:";
            // 
            // textBoxWaffle
            // 
            this.textBoxWaffle.Location = new System.Drawing.Point(11, 80);
            this.textBoxWaffle.Name = "textBoxWaffle";
            this.textBoxWaffle.Size = new System.Drawing.Size(447, 240);
            this.textBoxWaffle.TabIndex = 32;
            this.textBoxWaffle.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 34;
            // 
            // akuagCrestPicPox
            // 
            this.akuagCrestPicPox.Image = ((System.Drawing.Image)(resources.GetObject("akuagCrestPicPox.Image")));
            this.akuagCrestPicPox.Location = new System.Drawing.Point(11, 9);
            this.akuagCrestPicPox.Name = "akuagCrestPicPox";
            this.akuagCrestPicPox.Size = new System.Drawing.Size(66, 65);
            this.akuagCrestPicPox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.akuagCrestPicPox.TabIndex = 33;
            this.akuagCrestPicPox.TabStop = false;
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.akuagCrestPicPox);
            this.Controls.Add(this.textBoxWaffle);
            this.Controls.Add(this.version);
            this.Controls.Add(this.labelAssemblyVersion);
            this.Controls.Add(this.authors);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.headline);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Performance Comparison";
            ((System.ComponentModel.ISupportInitialize)(this.akuagCrestPicPox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label headline;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label authors;
        private System.Windows.Forms.Label labelAssemblyVersion;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.RichTextBox textBoxWaffle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox akuagCrestPicPox;
    }
}
