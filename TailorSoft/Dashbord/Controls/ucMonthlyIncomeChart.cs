using System.Windows.Forms.DataVisualization.Charting;
using TailorSoft_Models;

namespace TailorSoft.Dashbord.Controls
{
    public partial class ucMonthlyIncomeChart : UserControl
    {
        private readonly Chart chart;
        private readonly Series series;

        private readonly string[] months = {
        "Janvier", "Février", "Mars", "Avril", "Mai", "Juin",
        "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };

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

        public ucMonthlyIncomeChart()
        {
            InitializeComponent();

            chart = CreateChart();
            series = CreateSeries();

            chart.Series.Add(series);
            Controls.Add(chart);
        }

        private Chart CreateChart()
        {
            var chart = new Chart
            {
                Dock = DockStyle.Fill,
                RightToLeft = RightToLeft.No
            };

            var chartArea = new ChartArea("MainArea")
            {
                AxisX =
            {
                Title = "Mois",
                Interval = 1,
                TitleFont = new Font("Tahoma", 12),
                LabelStyle = { Font = new Font("Tahoma", 10) },
                MajorGrid = { LineWidth = 0 }
            },
                AxisY =
            {
                Title = "Revenu en Dirham",
                TitleFont = new Font("Tahoma", 12),
                LabelStyle = { Font = new Font("Tahoma", 10) },
                MajorGrid={LineDashStyle = ChartDashStyle.Dash, LineColor = Color.LightGray, LineWidth = 1 }
            }
            };

            chart.ChartAreas.Add(chartArea);

            chart.Titles.Add(new Title(
                "Statistiques des revenus mensuels en Dirham",
                Docking.Top,
                new Font("Tahoma", 12, FontStyle.Bold),
                Color.Black));

            return chart;
        }

        private Series CreateSeries()
        {
            return new Series("Revenu mensuel")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Font = new Font("Tahoma", 9),
                XValueType = ChartValueType.String,
                IsXValueIndexed = true
            };
        }

        private void LoadData(int year)
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

                double value = (double)item.TotalIncome;

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

        public void RefreshData(int year = 2026)
        {
            LoadData(year);
        }
    }
}
