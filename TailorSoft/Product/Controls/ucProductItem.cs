using HFS.Product.Forms;
using TailorSoft.Product.Forms;
using TailorSoft_Business_Layer;

namespace HFS.Product.Controls
{
    public partial class ucProductItem : UserControl
    {
        #region Properties and Events
        public clsProduct? Product { get; private set; }
        public event Action? OnProductItemDeleted;
        public event Action<clsProduct>? OnProductItemSaved;
        #endregion

        #region Constructor
        public ucProductItem()
        {
            InitializeComponent();
        }
        #endregion


        #region Public Methods
        public void SetProduct(clsProduct product)
        {
            if (product?.Id <= 0)
            {
                MessageBox.Show("رقم المنتج غير صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtProductID.Text = product?.Id.ToString();
            txtProductType.Text = product?.ProductType?.Name ?? "Unknown";
            txtProductCategory.Text = product?.Category ?? "N/A";
            txtProductColor.Text = product?.Color ?? "N/A";

            txtProductInitialLength.Text = product?.InitialLength % 1 == 0 ?
                $"{product?.InitialLength.GetValueOrDefault():F0} متر" : $"{product?.InitialLength.GetValueOrDefault():F1} متر";

            txtProductStockLength.Text = product?.StockLength % 1 == 0 ?
                $"{product?.StockLength.GetValueOrDefault():F0} متر" : $"{product?.StockLength.GetValueOrDefault():F1} متر";

            txtProductPrice.Text = product?.Price % 1 == 0 ?
                $"{product?.Price.GetValueOrDefault():F0} درهم" : $"{product?.Price.GetValueOrDefault():F1} درهم";

            lblProductDate.Text = product?.CreatedDate?.ToString("dd/MM/yyyy") ?? "N/A";

            pbProduct.Image = Image.FromFile(product?.ImagePath ?? string.Empty);
            Product = product;
        }

        public void ClearProduct()
        {
            Product = null;
            txtProductID.Text = "N/A";
            txtProductType.Text = "N/A";
            txtProductCategory.Text = "N/A";
            txtProductColor.Text = "N/A";
            txtProductInitialLength.Text = "N/A";
            txtProductStockLength.Text = "N/A";
            txtProductPrice.Text = "N/A";
            lblProductDate.Text = "N/A";
            pbProduct.Image = TailorSoft.Properties.Resources.empty_image_icon_512;

        }
        #endregion

        #region Private Methods



        private void ShowError(string message)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)(() => MessageBox.Show(message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error)));
                return;
            }
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Event Handlers
        private void OnProductSavedSuccessfullyEventHandler(clsProduct product)
        {
            this.OnProductItemSaved?.Invoke(product);
            if (product?.Id is null or <= 0)
            {
                ClearProduct();
                ShowError("يرجى تحديد منتج صحيح");
                return;
            }
            SetProduct(product);
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (Product?.Id is null or <= 0)
            {
                ShowError("يرجى تحديد منتج صحيح للتعديل");
                return;
            }

            using var frm = new frmAddUpdateProduct(Product);
            frm.OnProductSavedSuccessfully += OnProductSavedSuccessfullyEventHandler;
            frm.ShowDialog();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (Product == null || Product.Id == null || Product.Id <= 0)
            {
                MessageBox.Show("يرجى تحديد منتج صحيح للحذف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا المنتج؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = clsProduct.Delete(Product.Id.Value);
                    if (success)
                    {
                        MessageBox.Show("تم حذف المنتج بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnProductItemDeleted?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء حذف المنتج", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"حدث خطأ أثناء حذف المنتج: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion


        private void btnSell_Click(object sender, EventArgs e)
        {
            if (Product == null || Product.Id == null || Product.Id <= 0)
            {
                MessageBox.Show("يرجى تحديد منتج صحيح للبيع", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var frm = new frmSetSellingLength(Product))
            {
                frm.OnSellingCompletedSuccessfully += (soldProduct) =>
                {
                    SetProduct(soldProduct);
                };
                frm.ShowDialog();
            }

        }
    }
}
