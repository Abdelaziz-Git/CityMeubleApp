namespace TailorSoft_Models
{
    public class clsProductDTO
    {
        public int Id { get; set; }
        public byte TypeID { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Dimensions { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; } = true;
        public clsProductDTO(int id, byte typeId, string category, string color, string dimensions, int quantity, double price, string imagePath, DateTime createdDate, DateTime lastUpdate, int createdByUserId, bool isActive)
        {
            this.Id = id;
            this.TypeID = typeId;
            this.Category = category;
            this.Color = color;
            this.Dimensions = dimensions;
            this.Quantity = quantity;
            this.Price = price;
            this.ImagePath = imagePath;
            this.CreatedDate = createdDate;
            this.LastUpdate = lastUpdate;
            this.CreatedByUserID = createdByUserId;
            this.IsActive = isActive;
        }
    }
}
