using TailorSoft_Data_Layer;
using TailorSoft_Models;

namespace TailorSoft_Business_Layer
{
    public class clsProductType
    {
        public enum enProductType { الكل = 0, طلامط = 1, وسادة, ستائر, سامبل, أكسيسوار }

        public byte? Id { get; set; }
        public string? Name { get; set; }

        private clsProductType(clsProductTypeDTO productTypeDTO)
        {
            this.Id = productTypeDTO.Id;
            this.Name = productTypeDTO.Name;
        }
        public static clsProductType? Find(byte id)
        {
            clsProductTypeDTO? productTypeDTO = clsProductTypeData.GetProductTypeByID(id);
            return productTypeDTO != null ? new clsProductType(productTypeDTO) : null;
        }
        public static List<clsProductType> GetAll()
        {
            List<clsProductTypeDTO> productTypesDTO = clsProductTypeData.GetAllProductTypes();
            return productTypesDTO.Select(pt => new clsProductType(pt)).ToList();
        }
    }
}
