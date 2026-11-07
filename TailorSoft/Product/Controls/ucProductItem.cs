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
                MessageBox.Show("Le numéro de produit est incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtProductID.Text = product?.Id.ToString();
            txtProductType.Text = product?.ProductType?.Name ?? "Unknown";
            txtProductCategory.Text = product?.Category ?? "N/A";
            txtProductColor.Text = product?.Color ?? "N/A";

            txtProductDimensions.Text = product?.Dimensions ?? "N/A";

            txtProductQuantity.Text = product?.Quantity.ToString() ?? "N/A";
            txtProductPrice.Text = product?.Price % 1 == 0 ?
                $"{product?.Price.GetValueOrDefault():F0} DH" : $"{product?.Price.GetValueOrDefault():F1} DH";

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
            txtProductDimensions.Text = "N/A";
            txtProductQuantity.Text = "N/A";
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
                ShowError("Veuillez sélectionner un produit correct");
                return;
            }
            SetProduct(product);
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (Product?.Id is null or <= 0)
            {
                ShowError("Veuillez sélectionner un produit correct à modifier");
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
                MessageBox.Show("Veuillez sélectionner un produit correct à supprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce produit ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = clsProduct.Delete(Product.Id.Value);
                    if (success)
                    {
                        MessageBox.Show("Produit supprimé avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnProductItemDeleted?.Invoke();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur s'est produite lors de la suppression du produit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Une erreur s'est produite lors de la suppression du produit : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion


        private void btnSell_Click(object sender, EventArgs e)
        {
            if (Product == null || Product.Id == null || Product.Id <= 0)
            {
                MessageBox.Show("Veuillez sélectionner un produit correct à vendre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
