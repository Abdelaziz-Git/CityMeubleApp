namespace TailorSoft_Models
{
    public class clsOrderStatisticsDTO
    {
        public int Month { get; set; }
        public decimal TotalIncome { get; set; }
        public int NumberOfOrders { get; set; }
        public clsOrderStatisticsDTO(int month, decimal totalIncome, int numberOfOrders)
        {
            Month = month;
            TotalIncome = totalIncome;
            NumberOfOrders = numberOfOrders;
        }
    }
}
