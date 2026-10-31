using TailorSoft_Business_Layer;

namespace TailorSoft.Product.Forms
{
    public partial class frmProductCard : Form
    {
        public event Action<clsProduct>? OnProductSavedSuccessfully;
        public event Action? OnProductDeleted;
        public frmProductCard(clsProduct product)
        {
            InitializeComponent();
            ucProductItem1.SetProduct(product);
        }

        private void ucProductItem1_OnProductItemDeleted()
        {
            this.OnProductDeleted?.Invoke();
        }

        private void ucProductItem1_OnProductItemSaved(clsProduct obj)
        {
            this.OnProductSavedSuccessfully?.Invoke(obj);
        }
    }
}
