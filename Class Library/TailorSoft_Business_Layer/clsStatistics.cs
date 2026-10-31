using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorSoft_Models;
using TailorSoft_Data_Layer;

namespace TailorSoft_Business_Layer
{
    public class clsStatistics
    {
        public static clsStatisticsCardDTO GetStatisticsCard(int year)
        {
            return clsStatisticsData.GetStatisticsCardData(year);
        }
    }
}
