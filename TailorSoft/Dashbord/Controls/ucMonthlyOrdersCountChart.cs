using System.Windows.Forms.DataVisualization.Charting;
using TailorSoft_Models;

namespace TailorSoft.Dashbord.Controls
{
    public partial class ucMonthlyOrdersCountChart : UserControl
    {
        private  Chart chart1 = new Chart
        {
            Dock = DockStyle.Fill,
            RightToLeft = RightToLeft.No
        };

        private  Series  series = new Series("Nombre de commandes")
        {
            ChartType = SeriesChartType.Column,
            IsValueShownAsLabel = true,
            Font = new System.Drawing.Font("Tahoma", 12),
            XValueType = ChartValueType.String,
            IsXValueIndexed = true
        };

        ChartArea chartArea1 = new ChartArea("Commandes_mensuelles");
        Title chartTitle1 = new Title("Statistiques des commandes mensuelles", Docking.Top, new Font("Tahoma", 14, FontStyle.Bold), Color.Black);

        private  string[] months = { "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };

        private readonly Random random = new Random();

        private Color GetRandomColor()
        {
            // Avoid very dark or very light colors
            return Color.FromArgb(
                random.Next(50, 200),
                random.Next(50, 200),
                random.Next(50, 200)
            );
        }


       
        public ucMonthlyOrdersCountChart()
        {
            InitializeComponent();
            ShowMonthlyOrdersChart(2026);
        }
        private void ShowMonthlyOrdersChart(int year)
        {

            chartArea1.AxisX.Title = "Mois";
            chartArea1.AxisY.Title = "Nombre de commandes";

            chartArea1.AxisX.TitleFont = new Font("Tahoma", 12);
            chartArea1.AxisY.TitleFont = new Font("Tahoma", 12);

            chartArea1.AxisX.Interval = 1;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisY.MajorGrid.LineWidth = 1;
            chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray; 
            chartArea1.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas.Add(chartArea1);
            int i = 0;
            foreach (clsOrderStatisticsDTO orderStatistics in clsOrder.GetOrdersStatisticsForEachMonthByYear(year))
            {
                series.Points.AddXY(months[i], orderStatistics.NumberOfOrders);
                i++;
            }

            chart1.Series.Add(series);

            
            chart1.Titles.Add(chartTitle1);

            this.Controls.Add(chart1);
        }
        public void RefreshData(int year)
        {
            var data = clsOrder.GetOrdersStatisticsForEachMonthByYear(year);
            
            if (data == null)
            {
                return; // Exit early if data retrieval fails
            }
            
            series.Points.Clear();

            int index = 0;
            foreach (var item in data)
            {
                if (index >= months.Length) break; // safety

                double value = (double)item.NumberOfOrders;

                var point = new DataPoint
                {
                    AxisLabel = months[index],
                    YValues = new[] { value },
                    Color = GetRandomColor(),
                    Label = value % 1 == 0 ? value.ToString("F0") : value.ToString("F1")
                };

                series.Points.Add(point);
                index++;
            }
        }

    }
}
