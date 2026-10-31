namespace TailorSoft_Models
{
    public class clsCustomerDTO
    {
        // Properties
        public int Id { get; set; }
        public int PersonID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserID { get; set; }

        // Constructor
        public clsCustomerDTO()
        {
            this.Id = -1;
            this.PersonID = -1;
            this.CreatedDate = DateTime.MinValue;
            this.CreatedByUserID = -1;
        }
    }
}
