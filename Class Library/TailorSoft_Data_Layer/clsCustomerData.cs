using Microsoft.Data.SqlClient;
using System.Data;
using TailorSoft_Models;

namespace TailorSoft_Data_Layer
{
    public class clsCustomerData
    {
        enum enColumn
        {
            Id, PersonID, CreatedDate, CreatedByUserID
        }

        private static clsCustomerDTO? _MapReaderToCustomerDTO(SqlDataReader reader)
        {
            if (reader.Read())
            {
                return new clsCustomerDTO
                {
                    Id = reader.GetInt32((byte)enColumn.Id),
                    PersonID = reader.GetInt32((byte)enColumn.PersonID),
                    CreatedDate = reader.GetDateTime((byte)enColumn.CreatedDate),
                    CreatedByUserID = reader.GetInt32((byte)enColumn.CreatedByUserID)
                };
            }
            return null;
        }
        private static List<clsCustomerDTO> _MapReaderToCustomerList(SqlDataReader reader)
        {
            List<clsCustomerDTO> customers = new List<clsCustomerDTO>();
            while (reader.Read())
            {
                customers.Add(new clsCustomerDTO
                {
                    Id = reader.GetInt32((byte)enColumn.Id),
                    PersonID = reader.GetInt32((byte)enColumn.PersonID),
                    CreatedDate = reader.GetDateTime((byte)enColumn.CreatedDate),
                    CreatedByUserID = reader.GetInt32((byte)enColumn.CreatedByUserID)
                });
            }
            return customers;
        }
        private static void _SetCommandParameters(SqlCommand command, clsCustomerDTO customerDTO)
        {
            command.Parameters.AddWithValue("@PersonID", customerDTO.PersonID);
            command.Parameters.AddWithValue("@CreatedDate", customerDTO.CreatedDate);
            command.Parameters.AddWithValue("@CreatedByUserID", customerDTO.CreatedByUserID);
        }

        public static int? AddNewCustomer(clsCustomerDTO customerDTO)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Customer_AddNew", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        _SetCommandParameters(cmd, customerDTO);

                        SqlParameter OutputIdParam = new SqlParameter("@NewCustomerID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(OutputIdParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return (cmd.Parameters["@NewCustomerID"].Value as int?) ?? null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static clsCustomerDTO? GetCustomerByID(int customerID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Customer_GetByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return _MapReaderToCustomerDTO(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting customer by id.", ex);
            }
        }
        public static clsCustomerDTO? GetCustomerByPersonID(int personID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Customer_GetByPersonID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", personID);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return _MapReaderToCustomerDTO(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting customer by PersonID.", ex);
            }
        }

        public static List<clsCustomerDTO> GetAllCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Customer_GetAll", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return _MapReaderToCustomerList(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all customers.", ex);
            }
        }
        public static bool UpdateCustomer(clsCustomerDTO customerDTO)
        {
            if (customerDTO == null || customerDTO.Id < 1)
                return false;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Customer_Update", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerID", customerDTO.Id);
                        _SetCommandParameters(cmd, customerDTO);

                        SqlParameter rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(rowsAffectedParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return (int)rowsAffectedParam.Value > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating customer.", ex);
            }
        }

        public static bool DeleteCustomer(int customerID)
        {
            if (customerID < 1)
                return false;

            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Customer_DeleteByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);

                        SqlParameter rowsAffectedParam = new SqlParameter("@RowsAffected", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(rowsAffectedParam);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        return (int)rowsAffectedParam.Value > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}