using TailorSoft_Data_Layer;
using TailorSoft_Models;

namespace TailorSoft_Business_Layer
{
    public class clsUser
    {
        public enum enPermissions
        {
            All = 0,
            ViewHome = 1,
            ViewProducts = 2,
            ViewProductsDetail = 4,
            AddProducts = 8,
            EditProducts = 16,
            DeleteProducts = 32,
            SaleProducts = 64,
            ViewCustomers = 128,
            AddCustomers = 256,
            EditCustomers = 512,
            DeleteCustomers = 1024,
            ViewOrders = 2048,
            AddOrders = 4096,
            EditOrders = 8192,
            DeleteOrders = 16384,
            PaymentOrders = 32768,
            PrintOrders = 65536,
            ViewUsers = 131072,
            AddUsers = 262144,
            EditUsers = 524288,
            DeleteUsers = 1048576,
            EditStoreInfo = 2097152
        }
        public enum enPermissionsInArabic
        {
            الكل = 0,
            عرض_الصفحة_الرئيسية = 1,
            عرض_المنتجات = 2,
            عرض_تفاصيل_المنتجات = 4,
            إضافة_منتجات = 8,
            تعديل_منتجات = 16,
            حذف_منتجات = 32,
            بيع_منتجات = 64,
            عرض_العملاء = 128,
            إضافة_عملاء = 256,
            تعديل_عملاء = 512,
            حذف_عملاء = 1024,
            عرض_الطلبات = 2048,
            إضافة_طلبات = 4096,
            تعديل_طلبات = 8192,
            حذف_طلبات = 16384,
            دفع_طلبات = 32768,
            طباعة_طلبات = 65536,
            عرض_المستخدمين = 131072,
            إضافة_مستخدمين = 262144,
            تعديل_مستخدمين = 524288,
            حذف_مستخدمين = 1048576,
            تعديل_معلومات_المتجر = 2097152
        }
        enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;


        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public bool? Status { get; set; }
        public int? Permissions { get; set; }
        public string? Address { get; set; }

        public string? FullName => $"{FirstName} {LastName}".Trim();


        public clsUser()
        {
            Id = null;
            FirstName = null;
            LastName = null;
            Phone = null;
            Email = null;
            City = null;
            Username = null;
            PasswordHash = null;
            Status = null;
            Permissions = null;
            Address = null;
            _Mode = enMode.AddNew;
        }
        private clsUser(clsUserDTO userDTO)
        {
            Id = userDTO.Id;
            FirstName = userDTO.FirstName;
            LastName = userDTO.LastName;
            Phone = userDTO.Phone;
            Email = userDTO.Email;
            City = userDTO.City;
            Username = userDTO.Username;
            PasswordHash = userDTO.PasswordHash;
            Status = userDTO.Status;
            Permissions = userDTO.Permissions;
            Address = userDTO.Address;
            _Mode = enMode.Update;
        }
        public static clsUser? Find(int id)
        {
            if (id <= 0)
                return null;
            clsUserDTO? userDTO = clsUserData.GetUserById(id);
            return userDTO == null ? null : new clsUser(userDTO);
        }
        public static clsUser? Find(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            clsUserDTO? userDTO = clsUserData.GetUserByUsername(username);
            return userDTO == null ? null : new clsUser(userDTO);
        }
        public static bool IsExists(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            return clsUserData.IsUsernameExist(username);
        }
        public static List<clsUser> GetAllUsers()
        {
            List<clsUserDTO> userDTOs = clsUserData.GetAllUsers();
            return userDTOs.Select(dto => new clsUser(dto)).ToList();
        }
        public bool Save()
        {
            clsUserDTO userDTO = new clsUserDTO
            {
                Id = this.Id ?? -1,
                FirstName = this.FirstName ?? string.Empty,
                LastName = this.LastName ?? string.Empty,
                Phone = this.Phone ?? string.Empty,
                Email = string.IsNullOrWhiteSpace(this.Email) ? null : this.Email,
                City = this.City ?? string.Empty,
                Username = this.Username ?? string.Empty,
                PasswordHash = this.PasswordHash ?? string.Empty,
                Status = this.Status ?? false,
                Permissions = this.Permissions ?? 0,
                Address = this.Address ?? string.Empty
            };
            if (_Mode == enMode.AddNew)
            {
                int? newId = clsUserData.AddNewUser(userDTO);
                if (newId is not null && newId > 0)
                {
                    this.Id = newId;
                    _Mode = enMode.Update;
                    return true;
                }
                return false;
            }
            else if (_Mode == enMode.Update && this.Id.HasValue)
            {
                return clsUserData.UpdateUser(userDTO);
            }
            return false;
        }
        public bool Delete()
        {
            if (this.Id.HasValue && _Mode == enMode.Update)
            {
                bool isDeleted = clsUserData.DeleteUser(this.Id.Value);
                if (isDeleted)
                {
                    this.Clear();
                }
                return isDeleted;
            }
            return false;

        }
        public static bool Delete(int id)
        {
            if (id <= 0)
                return false;
            return clsUserData.DeleteUser(id);
        }
        public void Clear()
        {
            Id = null;
            FirstName = null;
            LastName = null;
            Phone = null;
            Email = null;
            City = null;
            Username = null;
            PasswordHash = null;
            Status = null;
            Permissions = null;
            Address = null;
            _Mode = enMode.AddNew;
        }
        public bool HasPermission(enPermissions permission)
        {
            if (Permissions.HasValue)
            {
                if (Permissions.Value == (int)enPermissions.All)
                    return true;

                return (Permissions.Value & (int)permission) == (int)permission;
            }
            return false;
        }
    }
}
