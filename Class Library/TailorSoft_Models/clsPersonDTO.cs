namespace TailorSoft_Models
{
    public class clsPersonDTO
    {
        // Prperties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }


        // Constructor
        public clsPersonDTO()
        {
            this.Id = -1;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Phone = string.Empty;
            this.Email = null;
            this.Address = null;
        }

    }
}
