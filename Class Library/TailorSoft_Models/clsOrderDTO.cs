public class clsOrderDTO
{
    public int Id { get; set; }
    public int CustomerID { get; set; }
    public int UserID { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public byte Status { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal InitialAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? Notes { get; set; }

    public clsOrderDTO(int id, int customerID, int userID, DateTime orderDate, DateTime requiredDate, DateTime? deliveryDate, byte status, decimal totalAmount, decimal initialAmount, decimal remainingAmount, DateTime? paymentDate, string? notes = null)
    {
        Id = id;
        CustomerID = customerID;
        UserID = userID;
        OrderDate = orderDate;
        RequiredDate = requiredDate;
        DeliveryDate = deliveryDate;
        Status = status;
        TotalAmount = totalAmount;
        InitialAmount = initialAmount;
        RemainingAmount = remainingAmount;
        PaymentDate = paymentDate;
        Notes = notes;
    }
}