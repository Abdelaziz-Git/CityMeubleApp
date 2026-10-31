namespace TailorSoft_Models
{
    public class clsProductDTO
    {
        public int Id { get; set; }
        public byte TypeID { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public double InitialLength { get; set; }
        public double StockLength { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsActive { get; set; } = true;
        public clsProductDTO(int id, byte typeId, string category, string color, double initialLength, double stockLength, double price, string imagePath, DateTime createdDate, DateTime lastUpdate, int createdByUserId, bool isActive)
        {
            this.Id = id;
            this.TypeID = typeId;
            this.Category = category;
            this.Color = color;
            this.InitialLength = initialLength;
            this.StockLength = stockLength;
            this.Price = price;
            this.ImagePath = imagePath;
            this.CreatedDate = createdDate;
            this.LastUpdate = lastUpdate;
            this.CreatedByUserID = createdByUserId;
            this.IsActive = true;
        }
    }
}
