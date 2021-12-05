
namespace ImageFiltererV2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.chooseImageBtn = new System.Windows.Forms.Button();
            this.addPolygonBtn = new System.Windows.Forms.Button();
            this.blueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.greenChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.redChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.deletePolygonBtn = new System.Windows.Forms.Button();
            this.filterPolygonBtn = new System.Windows.Forms.Button();
            this.brushBtn = new System.Windows.Forms.Button();
            this.filtersPanel = new System.Windows.Forms.GroupBox();
            this.gammaLabel = new System.Windows.Forms.Label();
            this.gammaBox = new System.Windows.Forms.TextBox();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.brightnessChangeTrackBar = new System.Windows.Forms.TrackBar();
            this.filtersListBox = new System.Windows.Forms.CheckedListBox();
            this.brushSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redChart)).BeginInit();
            this.filtersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessChangeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(27, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(535, 437);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // chooseImageBtn
            // 
            this.chooseImageBtn.Location = new System.Drawing.Point(698, 20);
            this.chooseImageBtn.Name = "chooseImageBtn";
            this.chooseImageBtn.Size = new System.Drawing.Size(96, 33);
            this.chooseImageBtn.TabIndex = 1;
            this.chooseImageBtn.Text = "Choose image";
            this.chooseImageBtn.UseVisualStyleBackColor = true;
            this.chooseImageBtn.Click += new System.EventHandler(this.chooseImageBtn_Click);
            // 
            // addPolygonBtn
            // 
            this.addPolygonBtn.Location = new System.Drawing.Point(698, 75);
            this.addPolygonBtn.Name = "addPolygonBtn";
            this.addPolygonBtn.Size = new System.Drawing.Size(96, 33);
            this.addPolygonBtn.TabIndex = 2;
            this.addPolygonBtn.Text = "Add polygon";
            this.addPolygonBtn.UseVisualStyleBackColor = true;
            this.addPolygonBtn.Click += new System.EventHandler(this.addPolygonBtn_Click);
            // 
            // blueChart
            // 
            chartArea10.Name = "ChartArea1";
            this.blueChart.ChartAreas.Add(chartArea10);
            this.blueChart.Location = new System.Drawing.Point(948, 539);
            this.blueChart.Name = "blueChart";
            this.blueChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.blueChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series10.ChartArea = "ChartArea1";
            series10.Name = "BlueData";
            this.blueChart.Series.Add(series10);
            this.blueChart.Size = new System.Drawing.Size(370, 202);
            this.blueChart.TabIndex = 5;
            this.blueChart.Text = "chart3";
            // 
            // greenChart
            // 
            chartArea11.Name = "ChartArea1";
            this.greenChart.ChartAreas.Add(chartArea11);
            this.greenChart.Location = new System.Drawing.Point(948, 297);
            this.greenChart.Name = "greenChart";
            this.greenChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.greenChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Green};
            series11.ChartArea = "ChartArea1";
            series11.Name = "GreenData";
            this.greenChart.Series.Add(series11);
            this.greenChart.Size = new System.Drawing.Size(370, 207);
            this.greenChart.TabIndex = 6;
            this.greenChart.Text = "chart1";
            // 
            // redChart
            // 
            chartArea12.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea12.Name = "ChartArea1";
            this.redChart.ChartAreas.Add(chartArea12);
            this.redChart.Location = new System.Drawing.Point(948, 57);
            this.redChart.Name = "redChart";
            this.redChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.redChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            series12.ChartArea = "ChartArea1";
            series12.Name = "RedData";
            this.redChart.Series.Add(series12);
            this.redChart.Size = new System.Drawing.Size(370, 198);
            this.redChart.TabIndex = 7;
            this.redChart.Text = "chart2";
            // 
            // deletePolygonBtn
            // 
            this.deletePolygonBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deletePolygonBtn.Location = new System.Drawing.Point(698, 129);
            this.deletePolygonBtn.Name = "deletePolygonBtn";
            this.deletePolygonBtn.Size = new System.Drawing.Size(96, 33);
            this.deletePolygonBtn.TabIndex = 8;
            this.deletePolygonBtn.Text = "Delete polygon";
            this.deletePolygonBtn.UseVisualStyleBackColor = true;
            this.deletePolygonBtn.Click += new System.EventHandler(this.deletePolygonBtn_Click);
            // 
            // filterPolygonBtn
            // 
            this.filterPolygonBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.filterPolygonBtn.Location = new System.Drawing.Point(698, 184);
            this.filterPolygonBtn.Name = "filterPolygonBtn";
            this.filterPolygonBtn.Size = new System.Drawing.Size(96, 33);
            this.filterPolygonBtn.TabIndex = 9;
            this.filterPolygonBtn.Text = "Filter polygon";
            this.filterPolygonBtn.UseVisualStyleBackColor = true;
            this.filterPolygonBtn.Click += new System.EventHandler(this.filterPolygonBtn_Click);
            // 
            // brushBtn
            // 
            this.brushBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.brushBtn.Location = new System.Drawing.Point(698, 240);
            this.brushBtn.Name = "brushBtn";
            this.brushBtn.Size = new System.Drawing.Size(96, 33);
            this.brushBtn.TabIndex = 10;
            this.brushBtn.Text = "Brush";
            this.brushBtn.UseVisualStyleBackColor = true;
            this.brushBtn.Click += new System.EventHandler(this.brushBtn_Click);
            // 
            // filtersPanel
            // 
            this.filtersPanel.Controls.Add(this.gammaLabel);
            this.filtersPanel.Controls.Add(this.gammaBox);
            this.filtersPanel.Controls.Add(this.contrastTrackBar);
            this.filtersPanel.Controls.Add(this.brightnessChangeTrackBar);
            this.filtersPanel.Controls.Add(this.filtersListBox);
            this.filtersPanel.Location = new System.Drawing.Point(651, 344);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(209, 233);
            this.filtersPanel.TabIndex = 11;
            this.filtersPanel.TabStop = false;
            this.filtersPanel.Text = "Filters";
            this.filtersPanel.Visible = false;
            // 
            // gammaLabel
            // 
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Location = new System.Drawing.Point(37, 124);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(43, 13);
            this.gammaLabel.TabIndex = 16;
            this.gammaLabel.Text = "Gamma";
            this.gammaLabel.Visible = false;
            // 
            // gammaBox
            // 
            this.gammaBox.Location = new System.Drawing.Point(40, 140);
            this.gammaBox.Name = "gammaBox";
            this.gammaBox.Size = new System.Drawing.Size(100, 20);
            this.gammaBox.TabIndex = 15;
            this.gammaBox.Visible = false;
            this.gammaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gammaBox_KeyPress);
            this.gammaBox.Validating += new System.ComponentModel.CancelEventHandler(this.gammaBox_Validating);
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(40, 126);
            this.contrastTrackBar.Maximum = 255;
            this.contrastTrackBar.Minimum = -255;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(104, 45);
            this.contrastTrackBar.TabIndex = 14;
            this.contrastTrackBar.Visible = false;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
            // 
            // brightnessChangeTrackBar
            // 
            this.brightnessChangeTrackBar.Location = new System.Drawing.Point(40, 126);
            this.brightnessChangeTrackBar.Maximum = 255;
            this.brightnessChangeTrackBar.Minimum = -255;
            this.brightnessChangeTrackBar.Name = "brightnessChangeTrackBar";
            this.brightnessChangeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.brightnessChangeTrackBar.TabIndex = 13;
            this.brightnessChangeTrackBar.Visible = false;
            this.brightnessChangeTrackBar.Scroll += new System.EventHandler(this.brightnessChangeTrackBar_Scroll);
            // 
            // filtersListBox
            // 
            this.filtersListBox.BackColor = System.Drawing.SystemColors.Control;
            this.filtersListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filtersListBox.CheckOnClick = true;
            this.filtersListBox.FormattingEnabled = true;
            this.filtersListBox.Items.AddRange(new object[] {
            "Identity",
            "Negative",
            "Brightness change",
            "Gamma correction",
            "Contrast",
            "Own function"});
            this.filtersListBox.Location = new System.Drawing.Point(38, 19);
            this.filtersListBox.Name = "filtersListBox";
            this.filtersListBox.Size = new System.Drawing.Size(120, 90);
            this.filtersListBox.TabIndex = 12;
            this.filtersListBox.SelectedIndexChanged += new System.EventHandler(this.filtersListBox_SelectedIndexChanged);
            // 
            // brushSizeTrackBar
            // 
            this.brushSizeTrackBar.Location = new System.Drawing.Point(698, 297);
            this.brushSizeTrackBar.Maximum = 300;
            this.brushSizeTrackBar.Minimum = 25;
            this.brushSizeTrackBar.Name = "brushSizeTrackBar";
            this.brushSizeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.brushSizeTrackBar.TabIndex = 17;
            this.brushSizeTrackBar.Value = 100;
            this.brushSizeTrackBar.Scroll += new System.EventHandler(this.brushSizeTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(698, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Brush size";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 806);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.brushSizeTrackBar);
            this.Controls.Add(this.filtersPanel);
            this.Controls.Add(this.brushBtn);
            this.Controls.Add(this.filterPolygonBtn);
            this.Controls.Add(this.deletePolygonBtn);
            this.Controls.Add(this.redChart);
            this.Controls.Add(this.greenChart);
            this.Controls.Add(this.blueChart);
            this.Controls.Add(this.addPolygonBtn);
            this.Controls.Add(this.chooseImageBtn);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redChart)).EndInit();
            this.filtersPanel.ResumeLayout(false);
            this.filtersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessChangeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button chooseImageBtn;
        private System.Windows.Forms.Button addPolygonBtn;
        private System.Windows.Forms.DataVisualization.Charting.Chart blueChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart greenChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart redChart;
        private System.Windows.Forms.Button deletePolygonBtn;
        private System.Windows.Forms.Button filterPolygonBtn;
        private System.Windows.Forms.Button brushBtn;
        private System.Windows.Forms.GroupBox filtersPanel;
        private System.Windows.Forms.CheckedListBox filtersListBox;
        private System.Windows.Forms.TrackBar brightnessChangeTrackBar;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.Label gammaLabel;
        private System.Windows.Forms.TextBox gammaBox;
        private System.Windows.Forms.TrackBar brushSizeTrackBar;
        private System.Windows.Forms.Label label1;
    }
}

