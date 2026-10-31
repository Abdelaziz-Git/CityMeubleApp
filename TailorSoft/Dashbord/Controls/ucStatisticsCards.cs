using Microsoft.Identity.Client;
using TailorSoft_Business_Layer;
using TailorSoft_Data_Layer;
using TailorSoft_Models;

namespace TailorSoft.Dashbord.Controls
{
    public partial class ucStatisticsCards : UserControl
    {
       
        public ucStatisticsCards()
        {
            InitializeComponent();
            RefreshStatisticsCard();
        }
        public void RefreshStatisticsCard(int Year=2026)
        {
            clsStatisticsCardDTO statisticsCardDTO = clsStatistics.GetStatisticsCard(Year);

            lblTotalOrders.Text = statisticsCardDTO.TotalOrders.ToString();
            lblTotalCustomers.Text = statisticsCardDTO.TotalCustomers.ToString();
            lblTotalProducts.Text = statisticsCardDTO.TotalProducts.ToString();
            lblAnnualIncome.Text = statisticsCardDTO.AnnualIncome.ToString("F1") + " د.م";
        }
       
    }
}
