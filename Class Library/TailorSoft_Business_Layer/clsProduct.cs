using TailorSoft_Data_Layer;
using TailorSoft_Models;


namespace TailorSoft_Business_Layer
{
    public class clsProduct
    {
        #region Enums and Properties
        // Enums 
        public enum enMode { AddNew, Update }
        public enMode _Mode { get; private set; } = enMode.AddNew;

        // Properties
        public int? Id { get; private set; }
        public byte? TypeID { get; set; }
        public clsProductType? ProductType
        {
            get { return clsProductType.Find(TypeID ?? 0); }
        }
        public string? Category { get; set; }
        public string? Color { get; set; }
        public double? InitialLength { get; set; }
        public double? StockLength { get; set; }
        public double? Price { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public int? CreatedByUserID { get; set; }
        public bool? IsActive { get; set; }
        #endregion

        #region Constructors
        // Constructors
        public clsProduct()
        {
            Id = null;
            TypeID = null;
            Category = null;
            Color = null;
            InitialLength = null;
            StockLength = null;
            Price = null;
            ImagePath = null;
            CreatedDate = DateTime.Now;
            LastUpdate = DateTime.Now;
            CreatedByUserID = null;
            IsActive = null;
            _Mode = enMode.AddNew;
        }
        private clsProduct(clsProductDTO productDTO)
        {
            Id = productDTO.Id;
            TypeID = productDTO.TypeID;
            Category = productDTO.Category;
            Color = productDTO.Color;
            InitialLength = productDTO.InitialLength;
            StockLength = productDTO.StockLength;
            Price = productDTO.Price;
            ImagePath = productDTO.ImagePath;
            CreatedDate = productDTO.CreatedDate;
            LastUpdate = productDTO.LastUpdate;
            CreatedByUserID = productDTO.CreatedByUserID;
            IsActive = productDTO.IsActive;
            _Mode = enMode.Update;
        }
        #endregion

        // Methods
        public bool Sell(double sellingLength)
        {
            if (Id == null || Id <= 0)
                throw new InvalidOperationException("Cannot sell product without a valid Id.");
            if (sellingLength < 0)
                throw new ArgumentException("Selling length must be greater than zero.", nameof(sellingLength));
            if (StockLength == null || StockLength < sellingLength)
                throw new InvalidOperationException("Insufficient stock length for sale.");
            // Update stock length
            StockLength -= sellingLength;
            LastUpdate = DateTime.Now;
            // Save changes
            return Save();
        }
        private static clsProduct? _MapProductDTO_ToProduct(clsProductDTO? productDTO)
        {
            return productDTO == null ? null : new clsProduct(productDTO);
        }
        private static List<clsProduct> _MapProductsDTOsToProducts(List<clsProductDTO> productsDTOs)
        {
            var products = new List<clsProduct>();
            foreach (clsProductDTO productDTO in productsDTOs)
            {
                var product = _MapProductDTO_ToProduct(productDTO);
                if (product != null)
                    products.Add(product);
            }
            return products;
        }
        public static clsProduct? Find(int id)
        {
            return _MapProductDTO_ToProduct(clsProductData.GetProductByID(id));
        }
        public static bool Exist(int id)
        {
            return clsProductData.IsProductExistByID(id);
        }
        public static async Task<List<clsProduct>> GetAllActiveProductsAsync(CancellationToken token)
        {
            var productDTOs = await clsProductData.GetAllActiveProductsAsync(token);
            return _MapProductsDTOsToProducts(productDTOs);
        }

        public static async Task<List<clsProduct>> GetProductsByTypeAsync(
            clsProductType.enProductType type,
            CancellationToken token)
        {
            var productDTOs = await clsProductData.GetProductsByProductTypeIdAsync((byte)type, token);
            return _MapProductsDTOsToProducts(productDTOs);
        }

        public static int GetAllActiveProductsCount()
        {
            return clsProductData.GetAllActiveProductsCount();
        }
        public static int GetProductsByTypeCount(clsProductType.enProductType type)
        {
            return clsProductData.GetProductsByProductTypeIdCount((byte)type);
        }
        public static int GetProductsByTypeIdAndCategoryCount(clsProductType.enProductType type, string category)
        {
            return clsProductData.GetProductsByTypeIdAndCategoryCount((byte)type, category);
        }
        public static int GetProductsByTypeIdAndColorCount(clsProductType.enProductType type, string color)
        {
            return clsProductData.GetProductsByTypeIdAndColorCount((byte)type, color);
        }
        public static bool Delete(int id)
        {
            return clsProductData.DeleteProduct(id);
        }
        public bool Save()
        {

            var productDTO = new clsProductDTO(
                Id ?? 0,
                TypeID ?? 0,
                Category ?? string.Empty,
                Color ?? string.Empty,
                InitialLength ?? 0,
                StockLength ?? 0,
                Price ?? 0,
                ImagePath ?? string.Empty,
                CreatedDate ?? DateTime.Now,
                DateTime.Now,
                CreatedByUserID ?? 0,
                IsActive ?? true
            );

            if (_Mode == enMode.AddNew)
            {
                // Insert new product
                var newId = clsProductData.AddNewProduct(productDTO);
                if (newId == null)
                    return false;

                Id = newId;
                _Mode = enMode.Update;
                return true;
            }
            else // Update
            {
                // Ensure Id is present for update
                if (Id == null || Id == 0)
                    throw new InvalidOperationException("Cannot update product without a valid Id.");

                productDTO.Id = Id.Value; // Ensure DTO has correct Id
                return clsProductData.UpdateProduct(productDTO);
            }
        }

        #region Async CRUD Operations
        public static async Task<clsProduct?> FindAsync(int id)
        {
            var productDTO = await clsProductData.GetProductByIdAsync(id);
            return _MapProductDTO_ToProduct(productDTO);
        }
        public async Task<bool> SaveAsync()
        {
            var productDTO = new clsProductDTO(
                Id ?? 0,
                TypeID ?? 0,
                Category ?? string.Empty,
                Color ?? string.Empty,
                InitialLength ?? 0,
                StockLength ?? 0,
                Price ?? 0,
                ImagePath ?? string.Empty,
                CreatedDate ?? DateTime.Now,
                DateTime.Now,
                CreatedByUserID ?? 0,
                IsActive ?? true
            );

            if (_Mode == enMode.AddNew)
            {
                var newId = await clsProductData.AddNewProductAsync(productDTO);
                if (newId == null) return false;

                Id = newId;
                _Mode = enMode.Update;
                return true;
            }
            else
            {
                if (Id == null || Id == 0)
                    throw new InvalidOperationException("Cannot update product without a valid Id.");

                productDTO.Id = Id.Value;
                return await clsProductData.UpdateProductAsync(productDTO);
            }
        }
        public static async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            return await clsProductData.DeleteProductAsync(id, token);
        }
        #endregion

        #region Async Get Methods
        public static async Task<List<clsProduct>> GetAllProductsAsync()
        {
            var productDTOs = await clsProductData.GetAllProductsAsync();
            return _MapProductsDTOsToProducts(productDTOs);
        }

        public static async Task<List<clsProduct>> GetAllActiveProductsAsync()
        {
            var productDTOs = await clsProductData.GetAllActiveProductsAsync();
            return _MapProductsDTOsToProducts(productDTOs);
        }

        public static async Task<List<clsProduct>> GetProductsByTypeAsync(
            clsProductType.enProductType type)
        {
            var productDTOs = await clsProductData.GetProductsByProductTypeIdAsync((byte)type);
            return _MapProductsDTOsToProducts(productDTOs);
        }

        public static async Task<List<clsProduct>> GetProductsByTypeIdAndCategoryAsync(
            clsProductType.enProductType type,
            string category)
        {
            var productDTOs = await clsProductData.GetProductsByTypeIdAndCategoryAsync((byte)type, category);
            return _MapProductsDTOsToProducts(productDTOs);
        }

        public static async Task<List<clsProduct>> GetProductsByTypeIdAndColorAsync(
            clsProductType.enProductType type,
            string color)
        {
            var productDTOs = await clsProductData.GetProductsByTypeIdAndColorAsync((byte)type, color);
            return _MapProductsDTOsToProducts(productDTOs);
        }

        #endregion

        #region Factory Methods
        public static clsProduct CreateInstanceForAddNew(
            clsProductType.enProductType productType,
            string category,
            string color,
            double initialLength,
            double stockLength,
            double price,
            string imagePath,
            int currentUserID)
        {
            return new clsProduct
            {
                TypeID = (byte)productType,
                Category = category,
                Color = color,
                InitialLength = initialLength,
                StockLength = stockLength,
                Price = price,
                ImagePath = imagePath,
                CreatedDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                CreatedByUserID = currentUserID,
                IsActive = true,
                _Mode = enMode.AddNew
            };
        }
        #endregion
    }
}
