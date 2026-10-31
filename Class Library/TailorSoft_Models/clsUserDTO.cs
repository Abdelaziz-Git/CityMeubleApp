namespace TailorSoft_Models
{
    public class clsUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }
        public string City { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool Status { get; set; }
        public int Permissions { get; set; }
        public string? Address { get; set; }

        public clsUserDTO()
        {
            this.Id = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.City = string.Empty;
            this.Username = string.Empty;
            this.PasswordHash = string.Empty;
            this.Status = false;
            this.Permissions = 0;
            this.Address = string.Empty;
        }
        public clsUserDTO(clsUserDTO UserDTO)
        {
            Id = UserDTO.Id;
            FirstName = UserDTO.FirstName;
            LastName = UserDTO.LastName;
            Phone = UserDTO.Phone;
            Email = UserDTO.Email;
            City = UserDTO.City;
            Username = UserDTO.Username;
            PasswordHash = UserDTO.PasswordHash;
            Status = UserDTO.Status;
            Permissions = UserDTO.Permissions;
            Address = UserDTO.Address;

        }

    }
}
