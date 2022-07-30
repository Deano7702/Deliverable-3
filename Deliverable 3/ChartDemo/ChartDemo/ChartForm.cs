using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartDemo
{
    public partial class ChartForm : Form
    {

        string[] days = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        int[] temperatureHigh = new int[] { 21, 18, 15, 14, 13, 15,19}; 
        int[] temperatureLow = new int[] { 3, 5, 1, 6, 1, 2, 4};

        public ChartForm()
        {
            InitializeComponent();
            initChart();
                   
        }

        private void initChart()
        {
        
            string chart_type_strng = (string)((ComboBox)this.Controls["chartTypeComboBox"]).SelectedItem;
            if (chart_type_strng == null)
            {
                chart_type_strng = "Line";
            }
            SeriesChartType chartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chart_type_strng);

            Chart chart = (Chart)this.Controls["chartGraph"];
        

            chart.Series.Clear();
            chart.Titles.Clear();
            
            chart.Titles.Add("Weekly Temperature Chart");
            chart.ChartAreas["ChartArea"].AxisX.Interval = 1;
            chart.ChartAreas["ChartArea"].AxisX.MajorGrid.LineWidth = 0;
            //chart.ChartAreas["ChartArea"].AxisY.MajorGrid.LineWidth = 0;

            Series series1 = new Series("High");
            series1.ChartType = chartType;

            for (int i = 0; i < days.Length; i++)
             {
                   series1.Points.AddXY(days[i], temperatureHigh[i]);  
                    
            }
            chart.Series.Add(series1);

            Series series2 = new Series("Low");
            series2.ChartType = chartType;
            for (int i = 0; i < days.Length; i++)
            {
                series2.Points.AddXY(days[i], temperatureLow[i]);
            }

            chart.Series.Add(series2);

        }

        private void chartTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            initChart();
        }
    }
}
