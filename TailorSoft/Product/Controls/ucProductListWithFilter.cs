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
            cbProductType.SelectedIndex = 1; // Default to "طلامط"
            cbProductType.EndUpdate();
        }

        private void LoadDataToComboBoxFindBy()
        {
            cbFindBy.BeginUpdate();
            cbFindBy.Items.Clear();
            cbFindBy.Items.Add("لا شيء");
            cbFindBy.Items.Add("رقم المنتج");
            cbFindBy.Items.Add("فئة المنتج");
            cbFindBy.Items.Add("لون المنتج");
            cbFindBy.SelectedIndex = 0; // Default to "لا None"
            cbFindBy.EndUpdate();
        }
        #endregion

        #region Async Loading Methods

        private async Task LoadProductsByTypeAsync(clsProductType.enProductType productType, CancellationToken token)
        {
            if (productType == clsProductType.enProductType.الكل)
            {
                cbFindBy.SelectedIndex = 0; // Reset to "لا None"
                cbFindBy.Enabled = false;

                await ucProductList1.SetProductsAsync(clsProduct.GetAllActiveProductsAsync(token), token);
            }
            else
            {
                cbFindBy.Enabled = true;
                if (cbFindBy.Items.Count > 0)
                    cbFindBy.SelectedIndex = 0; // Reset to "لا None"

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
            if (cbProductType.SelectedIndex < 0 || cbProductType.SelectedIndex > 5) return;

            // Cancel any previous operation
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
                // Ignore cancellation (user switched quickly)
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

            if (productType == clsProductType.enProductType.الكل)
            {
                cbFindBy.SelectedIndex = 0; // Reset to "لا None"
                cbFindBy.Enabled = false;
                try
                {
                    await ucProductList1.SetProductsAsync(clsProduct.GetAllActiveProductsAsync(token), token);
                }
                catch (OperationCanceledException)
                {
                    // Ignore cancellation (user switched quickly)
                }
            }
            else
            {
                cbFindBy.Enabled = true;

                switch (cbFindBy.SelectedIndex)
                {
                    case 1: // ID
                        if (int.TryParse(searchText, out int productId))
                        {
                            ucProductList1.SetProduct(clsProduct.Find(productId));
                        }
                        else
                        {
                            ucProductList1.ClearProducts();
                        }
                        break;

                    case 2: // Category
                        await ucProductList1.SetProductsAsync(
                            clsProduct.GetProductsByTypeIdAndCategoryAsync(productType, searchText), token);
                        break;

                    case 3: // Color
                        await ucProductList1.SetProductsAsync(
                            clsProduct.GetProductsByTypeIdAndColorAsync(productType, searchText), token);
                        break;

                    default: // Type only
                        await ucProductList1.SetProductsAsync(
                            clsProduct.GetProductsByTypeAsync(productType), token);
                        break;
                }
            }


        }
        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = cbFindBy.SelectedIndex != 0;
            pbIconSearch.Visible = txtSearch.Visible;

            if (txtSearch.Visible)
            {
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
            pbIconSearch.Visible = txtSearch.Visible;
        }
        private void ucProductList1_OnProductItemsCountChanged(int obj)
        {
            lblNumberOfProductItems.Text = $"عدد المنتجات: {obj}";
        }
        private void ucProductListWithFilter_SizeChanged(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
