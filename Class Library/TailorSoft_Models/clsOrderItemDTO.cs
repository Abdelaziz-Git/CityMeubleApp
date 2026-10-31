namespace TailorSoft_Models
{
    public class clsOrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Note { get; set; }
        public clsOrderItemDTO(int id, int orderId, int? productId, string productName, decimal quantity, decimal unitPrice, string? note = null)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Note = note;
        }
    }
}
