namespace PiecewiseLinearGraphing
{
    partial class PiecewiseForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PiecewiseGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.slope_UpDown = new System.Windows.Forms.NumericUpDown();
            this.slope_Lbl = new System.Windows.Forms.Label();
            this.kneeOneX_UpDown = new System.Windows.Forms.NumericUpDown();
            this.kneeOneX_Lbl = new System.Windows.Forms.Label();
            this.kneeOneY_Lbl = new System.Windows.Forms.Label();
            this.kneeOneY_UpDown = new System.Windows.Forms.NumericUpDown();
            this.kneeTwoY_Lbl = new System.Windows.Forms.Label();
            this.kneeTwoY_UpDown = new System.Windows.Forms.NumericUpDown();
            this.kneeTwoX_Lbl = new System.Windows.Forms.Label();
            this.kneeTwoX_UpDown = new System.Windows.Forms.NumericUpDown();
            this.exposureTime_Lbl = new System.Windows.Forms.Label();
            this.exposureTime_UpDown = new System.Windows.Forms.NumericUpDown();
            this.exposureType_GroupBox = new System.Windows.Forms.GroupBox();
            this.singleExposure_RadioButton = new System.Windows.Forms.RadioButton();
            this.multipleExposures_RadioButton = new System.Windows.Forms.RadioButton();
            this.newExposures_Button = new System.Windows.Forms.Button();
            this.relationship_CheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PiecewiseGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slope_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeOneX_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeOneY_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeTwoY_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeTwoX_UpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureTime_UpDown)).BeginInit();
            this.exposureType_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PiecewiseGraph
            // 
            this.PiecewiseGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea5.Name = "ChartArea1";
            this.PiecewiseGraph.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.PiecewiseGraph.Legends.Add(legend5);
            this.PiecewiseGraph.Location = new System.Drawing.Point(13, 13);
            this.PiecewiseGraph.Name = "PiecewiseGraph";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.PiecewiseGraph.Series.Add(series5);
            this.PiecewiseGraph.Size = new System.Drawing.Size(516, 351);
            this.PiecewiseGraph.TabIndex = 0;
            this.PiecewiseGraph.Text = "chart1";
            // 
            // slope_UpDown
            // 
            this.slope_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.slope_UpDown.DecimalPlaces = 2;
            this.slope_UpDown.Enabled = false;
            this.slope_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.slope_UpDown.Location = new System.Drawing.Point(441, 425);
            this.slope_UpDown.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.slope_UpDown.Name = "slope_UpDown";
            this.slope_UpDown.Size = new System.Drawing.Size(92, 20);
            this.slope_UpDown.TabIndex = 1;
            this.slope_UpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.slope_UpDown.ValueChanged += new System.EventHandler(this.slope_UpDown_ValueChanged);
            // 
            // slope_Lbl
            // 
            this.slope_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.slope_Lbl.AutoSize = true;
            this.slope_Lbl.Location = new System.Drawing.Point(442, 409);
            this.slope_Lbl.Name = "slope_Lbl";
            this.slope_Lbl.Size = new System.Drawing.Size(95, 13);
            this.slope_Lbl.TabIndex = 2;
            this.slope_Lbl.Text = "Slope (in degrees):";
            // 
            // kneeOneX_UpDown
            // 
            this.kneeOneX_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeOneX_UpDown.DecimalPlaces = 3;
            this.kneeOneX_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.kneeOneX_UpDown.Location = new System.Drawing.Point(15, 386);
            this.kneeOneX_UpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kneeOneX_UpDown.Name = "kneeOneX_UpDown";
            this.kneeOneX_UpDown.Size = new System.Drawing.Size(77, 20);
            this.kneeOneX_UpDown.TabIndex = 3;
            this.kneeOneX_UpDown.ValueChanged += new System.EventHandler(this.kneeOneX_UpDown_ValueChanged);
            // 
            // kneeOneX_Lbl
            // 
            this.kneeOneX_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeOneX_Lbl.AutoSize = true;
            this.kneeOneX_Lbl.Location = new System.Drawing.Point(12, 370);
            this.kneeOneX_Lbl.Name = "kneeOneX_Lbl";
            this.kneeOneX_Lbl.Size = new System.Drawing.Size(74, 13);
            this.kneeOneX_Lbl.TabIndex = 4;
            this.kneeOneX_Lbl.Text = "Kneepoint 1 X";
            // 
            // kneeOneY_Lbl
            // 
            this.kneeOneY_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeOneY_Lbl.AutoSize = true;
            this.kneeOneY_Lbl.Location = new System.Drawing.Point(98, 370);
            this.kneeOneY_Lbl.Name = "kneeOneY_Lbl";
            this.kneeOneY_Lbl.Size = new System.Drawing.Size(74, 13);
            this.kneeOneY_Lbl.TabIndex = 6;
            this.kneeOneY_Lbl.Text = "Kneepoint 1 Y";
            // 
            // kneeOneY_UpDown
            // 
            this.kneeOneY_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeOneY_UpDown.DecimalPlaces = 3;
            this.kneeOneY_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.kneeOneY_UpDown.Location = new System.Drawing.Point(101, 386);
            this.kneeOneY_UpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kneeOneY_UpDown.Name = "kneeOneY_UpDown";
            this.kneeOneY_UpDown.Size = new System.Drawing.Size(77, 20);
            this.kneeOneY_UpDown.TabIndex = 5;
            this.kneeOneY_UpDown.ValueChanged += new System.EventHandler(this.kneeOneY_UpDown_ValueChanged);
            // 
            // kneeTwoY_Lbl
            // 
            this.kneeTwoY_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeTwoY_Lbl.AutoSize = true;
            this.kneeTwoY_Lbl.Location = new System.Drawing.Point(98, 409);
            this.kneeTwoY_Lbl.Name = "kneeTwoY_Lbl";
            this.kneeTwoY_Lbl.Size = new System.Drawing.Size(74, 13);
            this.kneeTwoY_Lbl.TabIndex = 10;
            this.kneeTwoY_Lbl.Text = "Kneepoint 2 Y";
            // 
            // kneeTwoY_UpDown
            // 
            this.kneeTwoY_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeTwoY_UpDown.DecimalPlaces = 3;
            this.kneeTwoY_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.kneeTwoY_UpDown.Location = new System.Drawing.Point(101, 425);
            this.kneeTwoY_UpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kneeTwoY_UpDown.Name = "kneeTwoY_UpDown";
            this.kneeTwoY_UpDown.Size = new System.Drawing.Size(77, 20);
            this.kneeTwoY_UpDown.TabIndex = 9;
            this.kneeTwoY_UpDown.ValueChanged += new System.EventHandler(this.kneeTwoY_UpDown_ValueChanged);
            // 
            // kneeTwoX_Lbl
            // 
            this.kneeTwoX_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeTwoX_Lbl.AutoSize = true;
            this.kneeTwoX_Lbl.Location = new System.Drawing.Point(12, 409);
            this.kneeTwoX_Lbl.Name = "kneeTwoX_Lbl";
            this.kneeTwoX_Lbl.Size = new System.Drawing.Size(74, 13);
            this.kneeTwoX_Lbl.TabIndex = 8;
            this.kneeTwoX_Lbl.Text = "Kneepoint 2 X";
            // 
            // kneeTwoX_UpDown
            // 
            this.kneeTwoX_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kneeTwoX_UpDown.DecimalPlaces = 3;
            this.kneeTwoX_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.kneeTwoX_UpDown.Location = new System.Drawing.Point(15, 425);
            this.kneeTwoX_UpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kneeTwoX_UpDown.Name = "kneeTwoX_UpDown";
            this.kneeTwoX_UpDown.Size = new System.Drawing.Size(77, 20);
            this.kneeTwoX_UpDown.TabIndex = 7;
            this.kneeTwoX_UpDown.ValueChanged += new System.EventHandler(this.kneeTwoX_UpDown_ValueChanged);
            // 
            // exposureTime_Lbl
            // 
            this.exposureTime_Lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exposureTime_Lbl.AutoSize = true;
            this.exposureTime_Lbl.Location = new System.Drawing.Point(188, 370);
            this.exposureTime_Lbl.Name = "exposureTime_Lbl";
            this.exposureTime_Lbl.Size = new System.Drawing.Size(99, 13);
            this.exposureTime_Lbl.TabIndex = 12;
            this.exposureTime_Lbl.Text = "Exposure Time (ms)";
            // 
            // exposureTime_UpDown
            // 
            this.exposureTime_UpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exposureTime_UpDown.DecimalPlaces = 1;
            this.exposureTime_UpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.exposureTime_UpDown.Location = new System.Drawing.Point(191, 386);
            this.exposureTime_UpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.exposureTime_UpDown.Name = "exposureTime_UpDown";
            this.exposureTime_UpDown.Size = new System.Drawing.Size(77, 20);
            this.exposureTime_UpDown.TabIndex = 11;
            this.exposureTime_UpDown.ValueChanged += new System.EventHandler(this.exposureTime_UpDown_ValueChanged);
            // 
            // exposureType_GroupBox
            // 
            this.exposureType_GroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exposureType_GroupBox.Controls.Add(this.singleExposure_RadioButton);
            this.exposureType_GroupBox.Controls.Add(this.multipleExposures_RadioButton);
            this.exposureType_GroupBox.Location = new System.Drawing.Point(294, 370);
            this.exposureType_GroupBox.Name = "exposureType_GroupBox";
            this.exposureType_GroupBox.Size = new System.Drawing.Size(142, 74);
            this.exposureType_GroupBox.TabIndex = 13;
            this.exposureType_GroupBox.TabStop = false;
            this.exposureType_GroupBox.Text = "Exposure Type";
            // 
            // singleExposure_RadioButton
            // 
            this.singleExposure_RadioButton.AutoSize = true;
            this.singleExposure_RadioButton.Location = new System.Drawing.Point(6, 42);
            this.singleExposure_RadioButton.Name = "singleExposure_RadioButton";
            this.singleExposure_RadioButton.Size = new System.Drawing.Size(101, 17);
            this.singleExposure_RadioButton.TabIndex = 1;
            this.singleExposure_RadioButton.Text = "Single Exposure";
            this.singleExposure_RadioButton.UseVisualStyleBackColor = true;
            this.singleExposure_RadioButton.CheckedChanged += new System.EventHandler(this.Exposure_CheckedChanged);
            // 
            // multipleExposures_RadioButton
            // 
            this.multipleExposures_RadioButton.AutoSize = true;
            this.multipleExposures_RadioButton.Checked = true;
            this.multipleExposures_RadioButton.Location = new System.Drawing.Point(6, 19);
            this.multipleExposures_RadioButton.Name = "multipleExposures_RadioButton";
            this.multipleExposures_RadioButton.Size = new System.Drawing.Size(113, 17);
            this.multipleExposures_RadioButton.TabIndex = 0;
            this.multipleExposures_RadioButton.TabStop = true;
            this.multipleExposures_RadioButton.Text = "Multiple Exposures";
            this.multipleExposures_RadioButton.UseVisualStyleBackColor = true;
            this.multipleExposures_RadioButton.CheckedChanged += new System.EventHandler(this.Exposure_CheckedChanged);
            // 
            // newExposures_Button
            // 
            this.newExposures_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newExposures_Button.Location = new System.Drawing.Point(441, 370);
            this.newExposures_Button.Name = "newExposures_Button";
            this.newExposures_Button.Size = new System.Drawing.Size(92, 23);
            this.newExposures_Button.TabIndex = 14;
            this.newExposures_Button.Text = "New Exposures";
            this.newExposures_Button.UseVisualStyleBackColor = true;
            this.newExposures_Button.Click += new System.EventHandler(this.newExposures_Button_Click);
            // 
            // relationship_CheckBox
            // 
            this.relationship_CheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.relationship_CheckBox.AutoSize = true;
            this.relationship_CheckBox.Location = new System.Drawing.Point(191, 419);
            this.relationship_CheckBox.Name = "relationship_CheckBox";
            this.relationship_CheckBox.Size = new System.Drawing.Size(84, 30);
            this.relationship_CheckBox.TabIndex = 15;
            this.relationship_CheckBox.Text = "Preserve\r\nRelationship";
            this.relationship_CheckBox.UseVisualStyleBackColor = true;
            this.relationship_CheckBox.CheckedChanged += new System.EventHandler(this.relationship_CheckBox_CheckedChanged);
            // 
            // PiecewiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 456);
            this.Controls.Add(this.relationship_CheckBox);
            this.Controls.Add(this.newExposures_Button);
            this.Controls.Add(this.exposureType_GroupBox);
            this.Controls.Add(this.exposureTime_Lbl);
            this.Controls.Add(this.exposureTime_UpDown);
            this.Controls.Add(this.kneeTwoY_Lbl);
            this.Controls.Add(this.kneeTwoY_UpDown);
            this.Controls.Add(this.kneeTwoX_Lbl);
            this.Controls.Add(this.kneeTwoX_UpDown);
            this.Controls.Add(this.kneeOneY_Lbl);
            this.Controls.Add(this.kneeOneY_UpDown);
            this.Controls.Add(this.kneeOneX_Lbl);
            this.Controls.Add(this.kneeOneX_UpDown);
            this.Controls.Add(this.slope_Lbl);
            this.Controls.Add(this.slope_UpDown);
            this.Controls.Add(this.PiecewiseGraph);
            this.Name = "PiecewiseForm";
            this.Text = "Piecewise Linear Graphing";
            ((System.ComponentModel.ISupportInitialize)(this.PiecewiseGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slope_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeOneX_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeOneY_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeTwoY_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kneeTwoX_UpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exposureTime_UpDown)).EndInit();
            this.exposureType_GroupBox.ResumeLayout(false);
            this.exposureType_GroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart PiecewiseGraph;
        private System.Windows.Forms.NumericUpDown slope_UpDown;
        private System.Windows.Forms.Label slope_Lbl;
        private System.Windows.Forms.NumericUpDown kneeOneX_UpDown;
        private System.Windows.Forms.Label kneeOneX_Lbl;
        private System.Windows.Forms.Label kneeOneY_Lbl;
        private System.Windows.Forms.NumericUpDown kneeOneY_UpDown;
        private System.Windows.Forms.Label kneeTwoY_Lbl;
        private System.Windows.Forms.NumericUpDown kneeTwoY_UpDown;
        private System.Windows.Forms.Label kneeTwoX_Lbl;
        private System.Windows.Forms.NumericUpDown kneeTwoX_UpDown;
        private System.Windows.Forms.Label exposureTime_Lbl;
        private System.Windows.Forms.NumericUpDown exposureTime_UpDown;
        private System.Windows.Forms.GroupBox exposureType_GroupBox;
        private System.Windows.Forms.RadioButton singleExposure_RadioButton;
        private System.Windows.Forms.RadioButton multipleExposures_RadioButton;
        private System.Windows.Forms.Button newExposures_Button;
        private System.Windows.Forms.CheckBox relationship_CheckBox;
    }
}

