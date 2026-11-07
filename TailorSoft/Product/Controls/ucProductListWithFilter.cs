using HFS.Product.Forms;
using TailorSoft_Business_Layer;

namespace TailorSoft.Product.Controls
{
    public partial class ucProductListWithFilter : UserControl
    {

        public CancellationTokenSource? _cts;

        #region Constructor
        public ucProductListWithFilter()
        {
            InitializeComponent();
            LoadDataToComboBoxProductType();
            LoadDataToComboBoxFindBy();

        }

        #endregion

        #region Initialization Methods
        private void LoadDataToComboBoxProductType()
        {
            cbProductType.BeginUpdate();
            cbProductType.Items.Clear();
            cbProductType.Items.AddRange(Enum.GetNames(typeof(clsProductType.enProductType)));
            cbProductType.SelectedIndex = 1; // Default to "Armoire"
            cbProductType.EndUpdate();
        }

        private void LoadDataToComboBoxFindBy()
        {
            cbFindBy.BeginUpdate();
            cbFindBy.Items.Clear();
            cbFindBy.Items.Add("Rien");
            cbFindBy.Items.Add("Numéro");
            cbFindBy.Items.Add("Catégorie");
            cbFindBy.Items.Add("Couleur");
            cbFindBy.Items.Add("Dimensions");
            cbFindBy.SelectedIndex = 0; // Default to "Rien"
            cbFindBy.EndUpdate();
        }
        #endregion

        #region Async Loading Methods

        private async Task LoadProductsByTypeAsync(clsProductType.enProductType productType, CancellationToken token)
        {
            if (productType == clsProductType.enProductType.Toute)
            {
                cbFindBy.SelectedIndex = 0; // Reset to "Rien"
                cbFindBy.Enabled = false;

                await ucProductList1.SetProductsAsync(clsProduct.GetAllActiveProductsAsync(token), token);
            }
            else
            {
                cbFindBy.Enabled = true;
                if (cbFindBy.Items.Count > 0)
                    cbFindBy.SelectedIndex = 0; // Reset to "Rien"

                await ucProductList1.SetProductsAsync(clsProduct.GetProductsByTypeAsync(productType, token), token);
            }
        }

        #endregion

        #region UI Helpers


        private void ResetFilter()
        {
            txtSearch.Text = string.Empty;
            if (cbFindBy.Items.Count > 0)
                cbFindBy.SelectedIndex = 0;
        }
        #endregion

        #region Event Handlers

        private async void cbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductType.SelectedIndex < 0) return;

            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            ResetFilter();

            try
            {
                await LoadProductsByTypeAsync((clsProductType.enProductType)cbProductType.SelectedIndex, token);
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors du chargement des produits : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = txtSearch.Text.Trim();
            var productType = (clsProductType.enProductType)cbProductType.SelectedIndex;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                ucProductList1.ClearProducts();
                return;
            }

            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            try
            {
                if (productType == clsProductType.enProductType.Toute)
                {
                    cbFindBy.SelectedIndex = 0;
                    cbFindBy.Enabled = false;
                    await ucProductList1.SetProductsAsync(clsProduct.GetAllActiveProductsAsync(token), token);
                }
                else
                {
                    cbFindBy.Enabled = true;

                    switch (cbFindBy.SelectedIndex)
                    {
                        case 1:
                            if (int.TryParse(searchText, out int productId))
                            {
                                ucProductList1.SetProduct(clsProduct.Find(productId));
                            }
                            else
                            {
                                ucProductList1.ClearProducts();
                            }
                            break;

                        case 2:
                            await ucProductList1.SetProductsAsync(
                                clsProduct.GetProductsByTypeIdAndCategoryAsync(productType, searchText), token);
                            break;

                        case 3:
                            await ucProductList1.SetProductsAsync(
                                clsProduct.GetProductsByTypeIdAndColorAsync(productType, searchText), token);
                            break;

                        case 4:
                            await ucProductList1.SetProductsAsync(
                                clsProduct.GetProductsByTypeIdAndDimensionsAsync(productType, searchText), token);
                            break;

                        default:
                            await ucProductList1.SetProductsAsync(
                                clsProduct.GetProductsByTypeAsync(productType), token);
                            break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la recherche des produits : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            if (cbFindBy.SelectedIndex < 0) return;

            try
            {
                if (cbFindBy.SelectedIndex == 0)
                {
                    await ucProductList1.SetProductsAsync(clsProduct.GetProductsByTypeAsync((clsProductType.enProductType)cbProductType.SelectedIndex, token), token);
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de l'application du filtre : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtSearch.Visible = cbFindBy.SelectedIndex != 0;

            if (txtSearch.Visible)
            {
                txtSearch.Text = string.Empty;
                txtSearch.Focus();
            }
            else
            {
                txtSearch.Text = string.Empty;
            }
        }
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddUpdateProduct())
            {
                frm.OnProductAddedSuccessfully += OnProductAddedSuccessfully;

                frm.ShowDialog();
            }
        }
        private void OnProductAddedSuccessfully(clsProduct? obj)
        {
            cbProductType_SelectedIndexChanged(null, null);
        }
        private void txtSearch_VisibleChanged(object sender, EventArgs e)
        {
        }
        private void ucProductList1_OnProductItemsCountChanged(int obj)
        {
            lblNumberOfProductItems.Text = $"Nombre de produits: {obj}";
        }
        private void ucProductListWithFilter_SizeChanged(object sender, EventArgs e)
        {

        }
        #endregion

        public void UpdateProductList()
        {
            cbProductType_SelectedIndexChanged(null, null);
        }
    }
}
