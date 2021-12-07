
using System;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea21 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series21 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea22 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series22 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea23 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series23 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea24 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series24 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.ownFunctionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ownFunctionPanel = new System.Windows.Forms.Panel();
            this.xNumeric = new System.Windows.Forms.NumericUpDown();
            this.yNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addPointBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redChart)).BeginInit();
            this.filtersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessChangeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brushSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ownFunctionChart)).BeginInit();
            this.ownFunctionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(36, 25);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(700, 500);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Visible = false;
            // 
            // chooseImageBtn
            // 
            this.chooseImageBtn.Location = new System.Drawing.Point(931, 25);
            this.chooseImageBtn.Margin = new System.Windows.Forms.Padding(4);
            this.chooseImageBtn.Name = "chooseImageBtn";
            this.chooseImageBtn.Size = new System.Drawing.Size(128, 41);
            this.chooseImageBtn.TabIndex = 1;
            this.chooseImageBtn.Text = "Choose image";
            this.chooseImageBtn.UseVisualStyleBackColor = true;
            this.chooseImageBtn.Click += new System.EventHandler(this.chooseImageBtn_Click);
            // 
            // addPolygonBtn
            // 
            this.addPolygonBtn.Location = new System.Drawing.Point(931, 92);
            this.addPolygonBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addPolygonBtn.Name = "addPolygonBtn";
            this.addPolygonBtn.Size = new System.Drawing.Size(128, 41);
            this.addPolygonBtn.TabIndex = 2;
            this.addPolygonBtn.Text = "Add polygon";
            this.addPolygonBtn.UseVisualStyleBackColor = true;
            this.addPolygonBtn.Click += new System.EventHandler(this.addPolygonBtn_Click);
            // 
            // blueChart
            // 
            chartArea21.Name = "ChartArea1";
            this.blueChart.ChartAreas.Add(chartArea21);
            this.blueChart.Location = new System.Drawing.Point(1264, 663);
            this.blueChart.Margin = new System.Windows.Forms.Padding(4);
            this.blueChart.Name = "blueChart";
            this.blueChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.blueChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Blue};
            series21.ChartArea = "ChartArea1";
            series21.Name = "BlueData";
            this.blueChart.Series.Add(series21);
            this.blueChart.Size = new System.Drawing.Size(493, 249);
            this.blueChart.TabIndex = 5;
            this.blueChart.Text = "chart3";
            // 
            // greenChart
            // 
            chartArea22.Name = "ChartArea1";
            this.greenChart.ChartAreas.Add(chartArea22);
            this.greenChart.Location = new System.Drawing.Point(1264, 366);
            this.greenChart.Margin = new System.Windows.Forms.Padding(4);
            this.greenChart.Name = "greenChart";
            this.greenChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.greenChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Green};
            series22.ChartArea = "ChartArea1";
            series22.Name = "GreenData";
            this.greenChart.Series.Add(series22);
            this.greenChart.Size = new System.Drawing.Size(493, 255);
            this.greenChart.TabIndex = 6;
            this.greenChart.Text = "chart1";
            // 
            // redChart
            // 
            chartArea23.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea23.Name = "ChartArea1";
            this.redChart.ChartAreas.Add(chartArea23);
            this.redChart.Location = new System.Drawing.Point(1264, 70);
            this.redChart.Margin = new System.Windows.Forms.Padding(4);
            this.redChart.Name = "redChart";
            this.redChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.redChart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            series23.ChartArea = "ChartArea1";
            series23.Name = "RedData";
            this.redChart.Series.Add(series23);
            this.redChart.Size = new System.Drawing.Size(493, 244);
            this.redChart.TabIndex = 7;
            this.redChart.Text = "chart2";
            // 
            // deletePolygonBtn
            // 
            this.deletePolygonBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.deletePolygonBtn.Location = new System.Drawing.Point(931, 159);
            this.deletePolygonBtn.Margin = new System.Windows.Forms.Padding(4);
            this.deletePolygonBtn.Name = "deletePolygonBtn";
            this.deletePolygonBtn.Size = new System.Drawing.Size(128, 41);
            this.deletePolygonBtn.TabIndex = 8;
            this.deletePolygonBtn.Text = "Delete polygon";
            this.deletePolygonBtn.UseVisualStyleBackColor = true;
            this.deletePolygonBtn.Click += new System.EventHandler(this.deletePolygonBtn_Click);
            // 
            // filterPolygonBtn
            // 
            this.filterPolygonBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.filterPolygonBtn.Location = new System.Drawing.Point(931, 226);
            this.filterPolygonBtn.Margin = new System.Windows.Forms.Padding(4);
            this.filterPolygonBtn.Name = "filterPolygonBtn";
            this.filterPolygonBtn.Size = new System.Drawing.Size(128, 41);
            this.filterPolygonBtn.TabIndex = 9;
            this.filterPolygonBtn.Text = "Filter polygon";
            this.filterPolygonBtn.UseVisualStyleBackColor = true;
            this.filterPolygonBtn.Click += new System.EventHandler(this.filterPolygonBtn_Click);
            // 
            // brushBtn
            // 
            this.brushBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.brushBtn.Location = new System.Drawing.Point(931, 295);
            this.brushBtn.Margin = new System.Windows.Forms.Padding(4);
            this.brushBtn.Name = "brushBtn";
            this.brushBtn.Size = new System.Drawing.Size(128, 41);
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
            this.filtersPanel.Location = new System.Drawing.Point(868, 423);
            this.filtersPanel.Margin = new System.Windows.Forms.Padding(4);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Padding = new System.Windows.Forms.Padding(4);
            this.filtersPanel.Size = new System.Drawing.Size(279, 229);
            this.filtersPanel.TabIndex = 11;
            this.filtersPanel.TabStop = false;
            this.filtersPanel.Text = "Filters";
            this.filtersPanel.Visible = false;
            // 
            // gammaLabel
            // 
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Location = new System.Drawing.Point(49, 153);
            this.gammaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(57, 17);
            this.gammaLabel.TabIndex = 16;
            this.gammaLabel.Text = "Gamma";
            this.gammaLabel.Visible = false;
            // 
            // gammaBox
            // 
            this.gammaBox.Location = new System.Drawing.Point(53, 172);
            this.gammaBox.Margin = new System.Windows.Forms.Padding(4);
            this.gammaBox.Name = "gammaBox";
            this.gammaBox.Size = new System.Drawing.Size(132, 22);
            this.gammaBox.TabIndex = 15;
            this.gammaBox.Visible = false;
            this.gammaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gammaBox_KeyPress);
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(53, 155);
            this.contrastTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.contrastTrackBar.Maximum = 255;
            this.contrastTrackBar.Minimum = -255;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(139, 56);
            this.contrastTrackBar.TabIndex = 14;
            this.contrastTrackBar.Visible = false;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
            // 
            // brightnessChangeTrackBar
            // 
            this.brightnessChangeTrackBar.Location = new System.Drawing.Point(53, 155);
            this.brightnessChangeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.brightnessChangeTrackBar.Maximum = 255;
            this.brightnessChangeTrackBar.Minimum = -255;
            this.brightnessChangeTrackBar.Name = "brightnessChangeTrackBar";
            this.brightnessChangeTrackBar.Size = new System.Drawing.Size(139, 56);
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
            this.filtersListBox.Location = new System.Drawing.Point(52, 23);
            this.filtersListBox.Margin = new System.Windows.Forms.Padding(4);
            this.filtersListBox.Name = "filtersListBox";
            this.filtersListBox.Size = new System.Drawing.Size(177, 119);
            this.filtersListBox.TabIndex = 12;
            this.filtersListBox.SelectedIndexChanged += new System.EventHandler(this.filtersListBox_SelectedIndexChanged);
            // 
            // brushSizeTrackBar
            // 
            this.brushSizeTrackBar.Location = new System.Drawing.Point(931, 366);
            this.brushSizeTrackBar.Margin = new System.Windows.Forms.Padding(4);
            this.brushSizeTrackBar.Maximum = 300;
            this.brushSizeTrackBar.Minimum = 25;
            this.brushSizeTrackBar.Name = "brushSizeTrackBar";
            this.brushSizeTrackBar.Size = new System.Drawing.Size(139, 56);
            this.brushSizeTrackBar.TabIndex = 17;
            this.brushSizeTrackBar.Value = 100;
            this.brushSizeTrackBar.Scroll += new System.EventHandler(this.brushSizeTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(931, 345);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Brush size";
            // 
            // ownFunctionChart
            // 
            chartArea24.AxisX.MajorGrid.Enabled = false;
            chartArea24.AxisX2.MajorGrid.Enabled = false;
            chartArea24.AxisY.MajorGrid.Enabled = false;
            chartArea24.AxisY2.MajorGrid.Enabled = false;
            chartArea24.Name = "ChartArea1";
            this.ownFunctionChart.ChartAreas.Add(chartArea24);
            this.ownFunctionChart.Location = new System.Drawing.Point(12, 12);
            this.ownFunctionChart.Name = "ownFunctionChart";
            series24.ChartArea = "ChartArea1";
            series24.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series24.IsXValueIndexed = true;
            series24.Name = "OwnFunctionData";
            this.ownFunctionChart.Series.Add(series24);
            this.ownFunctionChart.Size = new System.Drawing.Size(412, 241);
            this.ownFunctionChart.TabIndex = 19;
            // 
            // ownFunctionPanel
            // 
            this.ownFunctionPanel.Controls.Add(this.addPointBtn);
            this.ownFunctionPanel.Controls.Add(this.label3);
            this.ownFunctionPanel.Controls.Add(this.label2);
            this.ownFunctionPanel.Controls.Add(this.yNumeric);
            this.ownFunctionPanel.Controls.Add(this.xNumeric);
            this.ownFunctionPanel.Controls.Add(this.ownFunctionChart);
            this.ownFunctionPanel.Location = new System.Drawing.Point(775, 659);
            this.ownFunctionPanel.Name = "ownFunctionPanel";
            this.ownFunctionPanel.Size = new System.Drawing.Size(438, 321);
            this.ownFunctionPanel.TabIndex = 20;
            this.ownFunctionPanel.Visible = false;
            // 
            // xNumeric
            // 
            this.xNumeric.Location = new System.Drawing.Point(55, 276);
            this.xNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.xNumeric.Name = "xNumeric";
            this.xNumeric.Size = new System.Drawing.Size(120, 22);
            this.xNumeric.TabIndex = 20;
            // 
            // yNumeric
            // 
            this.yNumeric.Location = new System.Drawing.Point(219, 276);
            this.yNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.yNumeric.Name = "yNumeric";
            this.yNumeric.Size = new System.Drawing.Size(120, 22);
            this.yNumeric.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Y";
            // 
            // addPointBtn
            // 
            this.addPointBtn.Location = new System.Drawing.Point(349, 269);
            this.addPointBtn.Name = "addPointBtn";
            this.addPointBtn.Size = new System.Drawing.Size(75, 35);
            this.addPointBtn.TabIndex = 24;
            this.addPointBtn.Text = "Add";
            this.addPointBtn.UseVisualStyleBackColor = true;
            this.addPointBtn.Click += new System.EventHandler(this.addPointBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1837, 992);
            this.Controls.Add(this.ownFunctionPanel);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
            ((System.ComponentModel.ISupportInitialize)(this.ownFunctionChart)).EndInit();
            this.ownFunctionPanel.ResumeLayout(false);
            this.ownFunctionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart ownFunctionChart;
        private System.Windows.Forms.Panel ownFunctionPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown yNumeric;
        private System.Windows.Forms.NumericUpDown xNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addPointBtn;
    }
}

