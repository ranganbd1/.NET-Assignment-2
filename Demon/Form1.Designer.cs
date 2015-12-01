namespace Demon
{
    partial class DemonForm
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
            demon.Dispose();
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
            this.seedBox = new System.Windows.Forms.TextBox();
            this.genBox = new System.Windows.Forms.TextBox();
            this.RulesComBox = new System.Windows.Forms.ComboBox();
            this.PaletteComBox = new System.Windows.Forms.ComboBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.StartButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.colorsLabel = new System.Windows.Forms.Label();
            this.rulesLabel = new System.Windows.Forms.Label();
            this.GenLabel = new System.Windows.Forms.Label();
            this.seedLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.belowPanel = new System.Windows.Forms.Panel();
            this.bottomStatusStrip = new System.Windows.Forms.StatusStrip();
            this.generationCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.finalHashValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel.SuspendLayout();
            this.belowPanel.SuspendLayout();
            this.bottomStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // seedBox
            // 
            this.seedBox.Location = new System.Drawing.Point(50, 12);
            this.seedBox.Name = "seedBox";
            this.seedBox.Size = new System.Drawing.Size(70, 20);
            this.seedBox.TabIndex = 0;
            this.seedBox.Text = "0";
            this.seedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // genBox
            // 
            this.genBox.Location = new System.Drawing.Point(50, 39);
            this.genBox.Name = "genBox";
            this.genBox.Size = new System.Drawing.Size(70, 20);
            this.genBox.TabIndex = 1;
            this.genBox.Text = "100";
            this.genBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // RulesComBox
            // 
            this.RulesComBox.FormattingEnabled = true;
            this.RulesComBox.Items.AddRange(new object[] {
            "Orthogonal",
            "Diagonal",
            "Alternating"});
            this.RulesComBox.Location = new System.Drawing.Point(182, 12);
            this.RulesComBox.Name = "RulesComBox";
            this.RulesComBox.Size = new System.Drawing.Size(90, 21);
            this.RulesComBox.TabIndex = 2;
            this.RulesComBox.SelectedIndexChanged += new System.EventHandler(this.RulesComBox_SelectedIndexChanged);
            // 
            // PaletteComBox
            // 
            this.PaletteComBox.FormattingEnabled = true;
            this.PaletteComBox.Items.AddRange(new object[] {
            "Rainbow",
            "Malachite",
            "PurpleSky",
            "CoralReef"});
            this.PaletteComBox.Location = new System.Drawing.Point(182, 39);
            this.PaletteComBox.Name = "PaletteComBox";
            this.PaletteComBox.Size = new System.Drawing.Size(90, 21);
            this.PaletteComBox.TabIndex = 3;
            this.PaletteComBox.SelectedIndexChanged += new System.EventHandler(this.PaletteComBox_SelectedIndexChanged);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.StartButton);
            this.topPanel.Controls.Add(this.ResetButton);
            this.topPanel.Controls.Add(this.colorsLabel);
            this.topPanel.Controls.Add(this.rulesLabel);
            this.topPanel.Controls.Add(this.GenLabel);
            this.topPanel.Controls.Add(this.seedLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(640, 68);
            this.topPanel.TabIndex = 4;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(314, 39);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(65, 23);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(314, 12);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(65, 23);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // colorsLabel
            // 
            this.colorsLabel.AutoSize = true;
            this.colorsLabel.Location = new System.Drawing.Point(140, 42);
            this.colorsLabel.Name = "colorsLabel";
            this.colorsLabel.Size = new System.Drawing.Size(36, 13);
            this.colorsLabel.TabIndex = 3;
            this.colorsLabel.Text = "Colors";
            // 
            // rulesLabel
            // 
            this.rulesLabel.AutoSize = true;
            this.rulesLabel.Location = new System.Drawing.Point(140, 15);
            this.rulesLabel.Name = "rulesLabel";
            this.rulesLabel.Size = new System.Drawing.Size(34, 13);
            this.rulesLabel.TabIndex = 2;
            this.rulesLabel.Text = "Rules";
            // 
            // GenLabel
            // 
            this.GenLabel.AutoSize = true;
            this.GenLabel.Location = new System.Drawing.Point(10, 42);
            this.GenLabel.Name = "GenLabel";
            this.GenLabel.Size = new System.Drawing.Size(32, 13);
            this.GenLabel.TabIndex = 1;
            this.GenLabel.Text = "Gens";
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.Location = new System.Drawing.Point(10, 15);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(32, 13);
            this.seedLabel.TabIndex = 0;
            this.seedLabel.Text = "Seed";
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(640, 480);
            this.mainPanel.TabIndex = 5;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // belowPanel
            // 
            this.belowPanel.Controls.Add(this.bottomStatusStrip);
            this.belowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.belowPanel.Location = new System.Drawing.Point(0, 548);
            this.belowPanel.Name = "belowPanel";
            this.belowPanel.Size = new System.Drawing.Size(640, 30);
            this.belowPanel.TabIndex = 8;
            // 
            // bottomStatusStrip
            // 
            this.bottomStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generationCounter,
            this.finalHashValue});
            this.bottomStatusStrip.Location = new System.Drawing.Point(0, 0);
            this.bottomStatusStrip.Name = "bottomStatusStrip";
            this.bottomStatusStrip.Size = new System.Drawing.Size(640, 30);
            this.bottomStatusStrip.TabIndex = 0;
            this.bottomStatusStrip.Text = "statusStrip1";
            // 
            // generationCounter
            // 
            this.generationCounter.Name = "generationCounter";
            this.generationCounter.Size = new System.Drawing.Size(61, 25);
            this.generationCounter.Text = "GenCount";
            // 
            // finalHashValue
            // 
            this.finalHashValue.Name = "finalHashValue";
            this.finalHashValue.Size = new System.Drawing.Size(63, 25);
            this.finalHashValue.Text = "HashValue";
            // 
            // DemonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 578);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.PaletteComBox);
            this.Controls.Add(this.RulesComBox);
            this.Controls.Add(this.genBox);
            this.Controls.Add(this.seedBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.belowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "DemonForm";
            this.Text = "Demon - Md Sattar (11789005) - v1.1";
            this.Load += new System.EventHandler(this.DemonForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.belowPanel.ResumeLayout(false);
            this.belowPanel.PerformLayout();
            this.bottomStatusStrip.ResumeLayout(false);
            this.bottomStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox seedBox;
        private System.Windows.Forms.TextBox genBox;
        private System.Windows.Forms.ComboBox RulesComBox;
        private System.Windows.Forms.ComboBox PaletteComBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.Label GenLabel;
        private System.Windows.Forms.Label colorsLabel;
        private System.Windows.Forms.Label rulesLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel belowPanel;
        private System.Windows.Forms.StatusStrip bottomStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel generationCounter;
        private System.Windows.Forms.ToolStripStatusLabel finalHashValue;
    }
}

