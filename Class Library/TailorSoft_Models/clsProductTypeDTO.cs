namespace TailorSoft_Models
{
    public class clsProductTypeDTO
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public clsProductTypeDTO()
        {
            this.Id = 0;
            this.Name = string.Empty;
        }
    }
}
