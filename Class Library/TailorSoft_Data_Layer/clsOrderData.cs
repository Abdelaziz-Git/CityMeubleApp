using Microsoft.Data.SqlClient;
using TailorSoft_Data_Layer;
using TailorSoft_Models;

public class clsOrderData
{
    #region Private Methods
    private static SqlParameter[] _GetParameters(clsOrderDTO order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order), "Order cannot be null.");
        SqlParameter[] parameters = new SqlParameter[12];
        parameters[0] = new SqlParameter("@CustomerID", order.CustomerID);
        parameters[1] = new SqlParameter("@UserID", order.UserID);
        parameters[2] = new SqlParameter("@OrderDate", order.OrderDate);
        parameters[3] = new SqlParameter("@RequiredDate", order.RequiredDate);
        parameters[4] = new SqlParameter("@DeliveryDate", order.DeliveryDate ?? (object)DBNull.Value);
        parameters[5] = new SqlParameter("@Status", order.Status);
        parameters[6] = new SqlParameter("@TotalAmount", order.TotalAmount);
        parameters[7] = new SqlParameter("@InitialAmount", order.InitialAmount);
        parameters[8] = new SqlParameter("@RemainingAmount", order.RemainingAmount);
        parameters[9] = new SqlParameter("@PaymentDate", order.PaymentDate ?? (object)DBNull.Value);
        parameters[10] = new SqlParameter("@Notes", order.Notes ?? (object)DBNull.Value);
        parameters[11] = new SqlParameter("@OrderID", order.Id);
        return parameters;
    }
    private static clsOrderDTO? _MapReaderTo_clsOrderDTO(SqlDataReader reader)
    {
        if (reader == null || !reader.HasRows)
            return null;
        return new clsOrderDTO(
            reader.GetInt32(reader.GetOrdinal("Id")),
            reader.GetInt32(reader.GetOrdinal("CustomerID")),
            reader.GetInt32(reader.GetOrdinal("UserID")),
            reader.GetDateTime(reader.GetOrdinal("OrderDate")),
            reader.GetDateTime(reader.GetOrdinal("RequiredDate")),
            reader.IsDBNull(reader.GetOrdinal("DeliveryDate")) ? null : reader.GetDateTime(reader.GetOrdinal("DeliveryDate")),
            reader.GetByte(reader.GetOrdinal("Status")),
            reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
            reader.GetDecimal(reader.GetOrdinal("InitialAmount")),
            reader.GetDecimal(reader.GetOrdinal("RemainingAmount")),
            reader.IsDBNull(reader.GetOrdinal("PaymentDate")) ? null : reader.GetDateTime(reader.GetOrdinal("PaymentDate")),
            reader.IsDBNull(reader.GetOrdinal("Notes")) ? null : reader.GetString(reader.GetOrdinal("Notes"))
        );
    }
    private static List<clsOrderDTO> _ExecuteQueryToReadData(string StoredProcedureName, SqlParameter[]? parameters)
    {
        List<clsOrderDTO> orders = new List<clsOrderDTO>();
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
                            clsOrderDTO? order = _MapReaderTo_clsOrderDTO(reader);
                            if (order != null)
                                orders.Add(order);
                        }
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            throw new Exception($"An error occurred while executing the query: {ex.Message}", ex);
        }
        return orders;
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
                    object obj = cmd.Parameters[OutputParameter.ParameterName].Value;
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
            throw new Exception($"An error occurred while executing the non-query: {ex.Message}", ex);
        }
    }
    #endregion

    #region Public Methods
    public static int? AddNew(clsOrderDTO order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order), "Order cannot be null.");
        SqlParameter[] parameters = _GetParameters(order).Where(param => (param.ParameterName == "@CustomerID" ||
                                                                              param.ParameterName == "@UserID" ||
                                                                              param.ParameterName == "@RequiredDate" ||
                                                                              param.ParameterName == "@Status" ||
                                                                              param.ParameterName == "@Notes")).ToArray();

        return _ExecuteNonQuery("SP_Order_AddNew", parameters, "@NewOrderID");
    }
    public static clsOrderDTO? GetByID(int orderId)
    {
        return _ExecuteQueryToReadData("SP_Order_GetByID", new SqlParameter[] { new SqlParameter("@OrderID", orderId) }).FirstOrDefault();
    }
    public static List<clsOrderDTO> GetByCustomerID(int customerId)
    {
        return _ExecuteQueryToReadData("SP_Order_GetByCustomerID", new SqlParameter[] { new SqlParameter("@CustomerID", customerId) });
    }
    public static bool Update(clsOrderDTO order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order), "Order cannot be null.");
        SqlParameter[] parameters = _GetParameters(order).Where(param => (
           param.ParameterName == "@OrderID" || param.ParameterName == "@RequiredDate" || param.ParameterName == "@DeliveryDate" ||
           param.ParameterName == "@Status" ||
           param.ParameterName == "@Notes")).ToArray();

        int? RowsAffected = _ExecuteNonQuery("SP_Order_Update", parameters, "@RowsAffected");
        return RowsAffected.HasValue && RowsAffected.Value > 0;
    }
    public static bool Delete(int orderId)
    {
        int? RowsAffected = _ExecuteNonQuery("SP_Order_DeleteByID", new SqlParameter[] { new SqlParameter("@OrderID", orderId) }, "@RowsAffected");
        return RowsAffected.HasValue && RowsAffected.Value > 0;
    }
    public static bool AdjustPayment(int orderID, decimal originalAmount, decimal newAmount)
    {

        int? RowsAffected = _ExecuteNonQuery
            (
            "SP_Order_AdjustPayment",
            new SqlParameter[] {new SqlParameter { ParameterName="@OrderID",Value=orderID} ,
                                new SqlParameter{ParameterName="@OriginalAmount",Value=originalAmount},
                                new SqlParameter{ParameterName="@NewAmount",Value=newAmount}
                                },
            "@RowsAffected"
            );
        return RowsAffected.HasValue && RowsAffected.Value > 0;
    }
    public static bool RecordPayment(int orderID, decimal amount, DateTime paymentDate)
    {
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@OrderID", orderID),
            new SqlParameter("@Amount", amount),
            new SqlParameter("@PaymentDate", paymentDate),
        };
        int? RowsAffected = _ExecuteNonQuery("SP_Order_RecordPayment", parameters, "@RowsAffected");
        return RowsAffected.HasValue && RowsAffected.Value > 0;
    }
    public static List<clsOrderDTO> GetAllOrders()
    {
        return _ExecuteQueryToReadData("SP_Order_GetAll", null);
    }
    public static List<clsOrderDTO> GetByDate(DateTime orderDate)
    {
        return _ExecuteQueryToReadData("SP_Order_GetByDate", new SqlParameter[] { new SqlParameter("@OrderDate", orderDate) });
    }
    public static List<clsOrderDTO> GetByRequiredDate(DateTime requiredDate)
    {
        return _ExecuteQueryToReadData("SP_Order_GetByRequiredDate", new SqlParameter[] { new SqlParameter("@RequiredDate", requiredDate) });
    }
    public static List<clsOrderDTO> GetByStatus(byte status)
    {
        return _ExecuteQueryToReadData("SP_Order_GetByStatus", new SqlParameter[] { new SqlParameter("@Status", status) });
    }
    public static List<clsOrderDTO> GetByCustomerPhone(string customerPhone)
    {
        return _ExecuteQueryToReadData("SP_Order_GetByCustomerPhone", new SqlParameter[] { new SqlParameter("@Phone", customerPhone) });
    }
    public static List<clsOrderDTO> GetByCustomerName(string customerName)
    {
        return _ExecuteQueryToReadData("SP_Order_GetByCustomerName", new SqlParameter[] { new SqlParameter("@Name", customerName) });
    }
    public static List<clsOrderStatisticsDTO> GetOrdersStatisticsForEachMonthByYear(int year)
    {
        var OrderStatistics = new List<clsOrderStatisticsDTO>();
        try
        {
            using (SqlConnection conn = new SqlConnection(clsDatabaseSettings.DefaultConnection))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Order_GetTotalIncomesAndNumberOfOrdersForEachMonth", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Year", year));
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var MonthOrderStatistics = new clsOrderStatisticsDTO
                            (
                                reader.GetInt32(0),
                                 reader.GetDecimal(1),
                                reader.GetInt32(2)
                            );
                            OrderStatistics.Add(MonthOrderStatistics);
                        }
                    }
                }
            }
            return OrderStatistics;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    #endregion
}
