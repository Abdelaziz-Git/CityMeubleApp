using TailorSoft_Data_Layer;
using TailorSoft_Models;

namespace TailorSoft_Business_Layer
{
    public class clsCustomer
    {
        enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;

        public int? Id { get; private set; }
        public int? PersonID { get; set; }
        public clsPerson? Person
        {
            get
            {
                if (PersonID.HasValue)
                    return clsPerson.Find(PersonID.Value);
                return null;
            }
        }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedByUserID { get; set; }

        public clsCustomer()
        {
            this.Id = null;
            this.PersonID = null;
            this.CreatedDate = null;
            this.CreatedByUserID = null;
            _Mode = enMode.AddNew;
        }

        private clsCustomer(clsCustomerDTO customerDTO)
        {
            this.Id = customerDTO.Id;
            this.PersonID = customerDTO.PersonID;
            this.CreatedDate = customerDTO.CreatedDate;
            this.CreatedByUserID = customerDTO.CreatedByUserID;
            _Mode = enMode.Update;
        }

        public static bool IsExistsByPhone(string Phone)
        {
            return clsCustomer.FindByPhone(Phone) != null;
        }
        public static clsCustomer? FindByPhone(string phone)
        {
            if (clsPerson.IsExists(phone))
            {
                clsPerson? person = clsPerson.Find(phone);
                if (person != null)
                {
                    return clsCustomer.FindByPersonID(person.Id.HasValue ? (int)person.Id : -1); ;
                }
                return null;
            }
            return null;
        }
        public static clsCustomer? Find(int id)
        {
            clsCustomerDTO? dto = clsCustomerData.GetCustomerByID(id);
            return dto == null ? null : new clsCustomer(dto);
        }

        public static clsCustomer? FindByPersonID(int personID)
        {
            clsCustomerDTO? dto = clsCustomerData.GetCustomerByPersonID(personID);
            return dto == null ? null : new clsCustomer(dto);
        }

        public static List<clsCustomer> GetAll()
        {
            List<clsCustomer> customers = new List<clsCustomer>();
            List<clsCustomerDTO> customerDTOs = clsCustomerData.GetAllCustomers();

            foreach (var dto in customerDTOs)
            {
                customers.Add(new clsCustomer(dto));
            }

            return customers;
        }
        private bool _AddNew()
        {
            if (!PersonID.HasValue || !CreatedDate.HasValue || !CreatedByUserID.HasValue)
                return false;

            clsCustomerDTO dto = new clsCustomerDTO
            {
                PersonID = PersonID.Value,
                CreatedDate = CreatedDate.Value,
                CreatedByUserID = CreatedByUserID.Value
            };

            this.Id = clsCustomerData.AddNewCustomer(dto);
            return this.Id.HasValue;
        }

        private bool _Update()
        {
            if (!Id.HasValue || !PersonID.HasValue || !CreatedDate.HasValue || !CreatedByUserID.HasValue)
                return false;

            clsCustomerDTO dto = new clsCustomerDTO
            {
                Id = Id.Value,
                PersonID = PersonID.Value,
                CreatedDate = CreatedDate.Value,
                CreatedByUserID = CreatedByUserID.Value
            };

            return clsCustomerData.UpdateCustomer(dto);
        }

        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                if (this._AddNew())
                {
                    _Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.Update)
            {
                return this._Update();
            }
            return false;
        }

        public static bool Delete(int customerID)
        {
            return clsCustomerData.DeleteCustomer(customerID);
        }


        /// <summary>
        /// If the customer is added successfully, it returns the new customer object.
        /// else, it returns null.
        /// </summary>
        public static clsCustomer? AddNew(string firstName, string lastName, string phone, string? email, string? addres, int userID)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName)
                || string.IsNullOrWhiteSpace(phone) || userID < 0)
                return null;
            clsPerson person = new clsPerson
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = string.IsNullOrWhiteSpace(email) ? null : email,
                Address = addres
            };
            if (!person.Save())
                return null;
            clsCustomer customer = new clsCustomer
            {
                PersonID = person.Id,
                CreatedDate = DateTime.Now,
                CreatedByUserID = userID
            };
            if (!customer.Save())
                return null;

            return customer;
        }
        public static clsCustomer? Update(int PersonID, string firstName, string lastName, string phone, string? email, string? address)
        {
            if (PersonID < 0 || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName)
                || string.IsNullOrWhiteSpace(phone))
                return null;

            clsPerson? person = clsPerson.Find(PersonID);
            if (person == null)
                return null;
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Phone = phone;
            person.Email = string.IsNullOrWhiteSpace(email) ? null : email;
            person.Address = address;
            if (person.Save())
            {
                clsCustomer? customer = clsCustomer.FindByPersonID(PersonID);
                return customer is not null ? customer : null;
            }
            return null;
        }
    }
}