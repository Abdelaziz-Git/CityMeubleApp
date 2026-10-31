using Microsoft.Data.SqlClient;
using TailorSoft_Models;

namespace TailorSoft_Data_Layer
{
    public class clsProductTypeData
    {
        public static clsProductTypeDTO? GetProductTypeByID(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ProductType_GetByID", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductTypeID", id);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new clsProductTypeDTO
                                {
                                    Id = reader.GetByte(0),
                                    Name = reader.GetString(1)
                                };
                            }
                            else
                                return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static List<clsProductTypeDTO> GetAllProductTypes()
        {
            try
            {
                List<clsProductTypeDTO> productTypes = new List<clsProductTypeDTO>();
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ProductType_GetAll", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                productTypes.Add(new clsProductTypeDTO
                                {
                                    Id = reader.GetByte(0),
                                    Name = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
                return productTypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
