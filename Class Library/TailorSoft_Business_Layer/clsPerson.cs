using TailorSoft_Data_Layer;
using TailorSoft_Models;

namespace TailorSoft_Business_Layer
{
    public class clsPerson
    {
        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;
        public int? Id { get; private set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => FirstName + " " + LastName;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public clsPerson()
        {
            this.Id = null;
            this.FirstName = null;
            this.LastName = null;
            this.Phone = null;
            this.Email = null;
            this.Address = null;
            _Mode = enMode.AddNew;
        }
        private clsPerson(clsPersonDTO personDTO)
        {
            this.Id = personDTO.Id;
            this.FirstName = personDTO.FirstName;
            this.LastName = personDTO.LastName;
            this.Phone = personDTO.Phone;
            this.Email = personDTO.Email;
            this.Address = personDTO.Address;
            _Mode = enMode.Update;
        }
        public static bool IsExists(string phone)
        {
            return clsPersonData.IsPersonExists(phone);
        }
        public static clsPerson? Find(int id)
        {
            clsPersonDTO? personDTO = clsPersonData.GetPersonByID(id);
            return personDTO == null ? null : new clsPerson(personDTO);
        }
        public static clsPerson? Find(string phone)
        {
            clsPersonDTO? personDTO = clsPersonData.GetPersonByPhone(phone);
            return personDTO == null ? null : new clsPerson(personDTO);
        }
        private bool _AddNew()
        {
            if (this.FirstName == null || this.LastName == null || this.Phone == null)
                return false;
            clsPersonDTO personDTO = new clsPersonDTO
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                Phone = this.Phone,
                Email = string.IsNullOrWhiteSpace(this.Email) ? null : this.Email,
                Address = this.Address
            };
            this.Id = clsPersonData.AddNewPerson(personDTO);
            return this.Id == null ? false : true;
        }
        private bool _Update()
        {
            if (this.Id == null || this.FirstName == null || this.LastName == null || this.Phone == null)
                return false;
            clsPersonDTO personDTO = new clsPersonDTO
            {
                Id = (int)this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Phone = this.Phone,
                Email = string.IsNullOrWhiteSpace(Email) ? null : Email,
                Address = this.Address
            };
            return clsPersonData.UpdatePerson(personDTO);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _Update();
                default:
                    return false;
            }
        }
    }
}
