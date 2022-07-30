namespace ChartDemo
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.chartTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGraph
            // 
            chartArea4.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea";
            this.chartGraph.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartGraph.Legends.Add(legend4);
            this.chartGraph.Location = new System.Drawing.Point(49, 69);
            this.chartGraph.Name = "chartGraph";
            series4.ChartArea = "ChartArea";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartGraph.Series.Add(series4);
            this.chartGraph.Size = new System.Drawing.Size(901, 392);
            this.chartGraph.TabIndex = 0;
            this.chartGraph.Text = "chartGraph";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cart Type";
            // 
            // chartTypeComboBox
            // 
            this.chartTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartTypeComboBox.FormattingEnabled = true;
            this.chartTypeComboBox.Items.AddRange(new object[] {
            "Line",
            "Bar",
            "Point",
            "Column",
            "Pie",
            "Bubble"});
            this.chartTypeComboBox.Location = new System.Drawing.Point(481, 23);
            this.chartTypeComboBox.Name = "chartTypeComboBox";
            this.chartTypeComboBox.Size = new System.Drawing.Size(162, 24);
            this.chartTypeComboBox.TabIndex = 2;
            this.chartTypeComboBox.Text = "Select a Chart Type";
            this.chartTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.chartTypeComboBox_SelectedIndexChanged);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 479);
            this.Controls.Add(this.chartTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartGraph);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chartTypeComboBox;
    }
}