using TailorSoft_Data_Layer;
using TailorSoft_Models;

namespace TailorSoft_Business_Layer
{
    public class clsProductType
    {
        public enum enProductType
        {
            Toute = 0,
            Armoire = 1,
            Bardage = 2,
            Bibliothèque = 3,
            Buffet = 4,
            Bureautique = 5,
            CACA = 6,
            CACE = 7,
            Chaise = 8,
            Commode_Chevêt = 9,
            Cuisine = 10,
            Décor_Accessoire = 11,
            Groupe = 12,
            Lit_Tapesier_A = 13,
            Lit_Tapesier_E = 14,
            Lustre = 15,
            Matelas = 16,
            Meuble_Chaussure = 17,
            Meuble_Tv = 18,
            SAM = 19,
            Salon_Bureau = 20,
            Salon_classique = 21,
            Salon_Moderne = 22,
            Salon_SR = 23,
            Table_Basse = 24,
            Vitrine = 25,
            Autres_Produits = 26
        }

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
        public static List<clsProductTypeDTO> GetAll()
        {
            List<clsProductTypeDTO> productTypesDTO = clsProductTypeData.GetAllProductTypes();
            return productTypesDTO;
        }
    }
}
