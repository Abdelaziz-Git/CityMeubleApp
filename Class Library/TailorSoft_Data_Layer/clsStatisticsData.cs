using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorSoft_Models;

namespace TailorSoft_Data_Layer
{
    public class clsStatisticsData
    {
        public static clsStatisticsCardDTO GetStatisticsCardData(int year)
        {
            using (SqlConnection connection = new SqlConnection(clsDatabaseSettings.DefaultConnection))
            {
                using (SqlCommand command = new SqlCommand("SP_GetStatistics", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Year", year);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalOrders = Convert.ToInt32(reader["TotalOrders"]);
                                int totalCustomers = Convert.ToInt32(reader["TotalCustomers"]);
                                int totalProducts = Convert.ToInt32(reader["TotalProducts"]);
                                double annualIncome = Convert.ToDouble(reader["AnnualIncome"]);

                                return new clsStatisticsCardDTO(totalOrders, totalCustomers, totalProducts, annualIncome);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            return new clsStatisticsCardDTO(0, 0, 0, 0);
        }
    }
}
