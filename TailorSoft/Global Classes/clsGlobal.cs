using TailorSoft_Business_Layer;
using TailorSoft_Models;


public class clsGlobal
{

    public static clsUser? CurrentUser { get; set; }
    public static List<clsOrderStatisticsDTO> orderStatisticsDTOs { get; set; }
        = clsOrder.GetOrdersStatisticsForEachMonthByYear(DateTime.Now.Year);
}

