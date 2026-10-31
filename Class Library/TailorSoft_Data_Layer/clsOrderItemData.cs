using Microsoft.Data.SqlClient;
using TailorSoft_Models;

namespace TailorSoft_Data_Layer
{
    public class clsOrderItemData
    {
        #region Private Methods
        private static SqlParameter[] _GetParameters(clsOrderItemDTO orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem), "Order item cannot be null.");
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@ItemID", orderItem.Id);
            parameters[1] = new SqlParameter("@OrderID", orderItem.OrderId);
            parameters[2] = new SqlParameter("@ProductID", orderItem.ProductId ?? (object)DBNull.Value);
            parameters[3] = new SqlParameter("@ProductName", orderItem.ProductName);
            parameters[4] = new SqlParameter("@Quantity", orderItem.Quantity);
            parameters[5] = new SqlParameter("@UnitPrice", orderItem.UnitPrice);
            parameters[6] = new SqlParameter("@Notes", orderItem.Note ?? (object)DBNull.Value);

            return parameters;
        }
        private static clsOrderItemDTO? _MapReaderTo_clsOrderItemDTO(SqlDataReader reader)
        {
            if (reader == null || !reader.HasRows)
                return null;
            return new clsOrderItemDTO(reader.GetInt32(reader.GetOrdinal("Id")),
                                       reader.GetInt32(reader.GetOrdinal("OrderId")),
                                       reader.IsDBNull(reader.GetOrdinal("ProductID")) ? null : reader.GetInt32(reader.GetOrdinal("ProductID")),
                                       reader.GetString(reader.GetOrdinal("ProductName")),
                                       reader.GetDecimal(reader.GetOrdinal("Quantity")),
                                       reader.GetDecimal(reader.GetOrdinal("UnitPrice")),
                                       reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes")));

        }
        private static List<clsOrderItemDTO> _ExecuteQueryToReadData(string StoredProcedureName, SqlParameter[] parameters)
        {
            List<clsOrderItemDTO> orderItems = new List<clsOrderItemDTO>();
            if (string.IsNullOrEmpty(StoredProcedureName))
                throw new ArgumentException("StoredProcedureName cannot be null or empty.", nameof(StoredProcedureName));
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedureName, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                clsOrderItemDTO? orderItem = _MapReaderTo_clsOrderItemDTO(reader);
                                if (orderItem != null)
                                    orderItems.Add(orderItem);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"An error occurred while executing the query: {ex.Message}", ex);
            }
            return orderItems;
        }
        private static int? _ExecuteNonQuery(string StoredProcedureName, SqlParameter[]? parameters, string OutputParameterName)
        {
            if (string.IsNullOrEmpty(StoredProcedureName))
                throw new ArgumentException("StoredProcedureName cannot be null or empty.", nameof(StoredProcedureName));
            try
            {
                using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedureName, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        if (string.IsNullOrEmpty(OutputParameterName))
                        {
                            throw new ArgumentException("OutputParameterName cannot be null or empty.", nameof(OutputParameterName));
                        }
                        SqlParameter OutputParameter = new SqlParameter(OutputParameterName, System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(OutputParameter);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Object obj = cmd.Parameters[OutputParameter?.ParameterName].Value;
                        if (obj != null && obj != DBNull.Value)
                        {
                            return Convert.ToInt32(obj);
                        }
                        return null;
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"An error occurred while executing the non-query: {ex.Message}", ex);
            }
        }
        #endregion

        #region Public Methods
        #region Create Methods
        public static int? AddNew(clsOrderItemDTO orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem), "Order item cannot be null.");

            return _ExecuteNonQuery(
                "SP_OrderItem_AddNew",
                _GetParameters(orderItem).Where(param => param.ParameterName != "@ItemID").ToArray(),
                "@NewOrderItemID");
        }
        #endregion
        #region Read Methods
        public static clsOrderItemDTO? GetByID(int orderItemId)
        {
            return _ExecuteQueryToReadData
                ("SP_OrderItem_GetByID",
                new SqlParameter[] { new SqlParameter("@OrderItemID", orderItemId) }).FirstOrDefault();
        }
        public static List<clsOrderItemDTO> GetByOrderID(int orderID)
        {
            return _ExecuteQueryToReadData
                ("SP_OrderItem_GetByOrderID",
                new SqlParameter[] { new SqlParameter("@OrderID", orderID) });
        }
        #endregion
        #region Update Methods
        public static bool Update(clsOrderItemDTO orderItem)
        {
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem), "Order item cannot be null.");
            int? RowsAffected = _ExecuteNonQuery("SP_OrderItem_Update",
                _GetParameters(orderItem).Where(param => param.ParameterName != "@OrderID").ToArray(),
                "@RowsAffected");
            return RowsAffected.HasValue && RowsAffected.Value > 0;
        }
        #endregion
        #region Delete Methods
        public static bool Delete(int orderItemId)
        {
            if (orderItemId <= 0)
                throw new ArgumentOutOfRangeException(nameof(orderItemId), "Order item ID must be greater than zero.");

            int? RowsAffected = _ExecuteNonQuery("SP_OrderItem_DeleteByID",
                new SqlParameter[] { new SqlParameter("@ItemID", orderItemId) },
                "@RowsAffected");
            return RowsAffected.HasValue && RowsAffected.Value > 0;
        }
        #endregion
        #endregion
    }
}
