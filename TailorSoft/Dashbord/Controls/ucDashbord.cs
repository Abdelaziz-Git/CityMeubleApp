namespace TailorSoft.Dashbord.Controls
{
    public partial class ucDashbord : UserControl
    {
        private DateTimePicker _dateTimePicker= new DateTimePicker
        {
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "yyyy",
            ShowUpDown = true,
            Dock = DockStyle.Left,
            Value = DateTime.Now,
            Font = new System.Drawing.Font("Tahoma", 14)
        };
        private  ucStatisticsCards ucStatisticsCards1 = new ucStatisticsCards();
        private  ucMonthlyIncomeChart ucMonthlyIncomeChart1 = new ucMonthlyIncomeChart();
        private  ucMonthlyOrdersCountChart ucMonthlyOrdersCountChart1 = new ucMonthlyOrdersCountChart();
        
        public ucDashbord()
        {
            InitializeComponent();
            InitializeControls();
            RefreshData();
        }
        
        private void InitializeControls()
        {
            _dateTimePicker.ValueChanged += (s, e) =>
            {
                int selectedYear = _dateTimePicker.Value.Year;
                RefreshData(selectedYear);
            };
            ucStatisticsCards1.Dock = DockStyle.Fill;
            ucMonthlyIncomeChart1.Dock = DockStyle.Fill;
            ucMonthlyOrdersCountChart1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(_dateTimePicker, 0, 0);
            this.tableLayoutPanel1.Controls.Add(ucStatisticsCards1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(ucMonthlyIncomeChart1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(ucMonthlyOrdersCountChart1, 0, 3);
        }
        
        public  void RefreshData(int Year=2026)
        {
            ucStatisticsCards1.RefreshStatisticsCard(Year);
            ucMonthlyIncomeChart1.RefreshData(Year);
            ucMonthlyOrdersCountChart1.RefreshData(Year);
        }

        
    }
}
