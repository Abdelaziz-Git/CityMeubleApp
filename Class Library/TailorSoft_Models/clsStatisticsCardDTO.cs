using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorSoft_Models
{
    public class clsStatisticsCardDTO
    {
        public int TotalOrders { get; set; } = 0;
        public int TotalCustomers { get; set; } = 0;
        public int TotalProducts { get; set; } = 0;
        public double AnnualIncome { get; set; } = 0;
        public clsStatisticsCardDTO(int totalOrders, int totalCustomers, int totalProducts, double annualIncome)
        {
            TotalOrders = totalOrders;
            TotalCustomers = totalCustomers;
            TotalProducts = totalProducts;
            AnnualIncome = annualIncome;
        }
        
    }
}
