using System.ComponentModel;
using TailorSoft.Properties;
using TailorSoft_Business_Layer;

namespace HFS.Product.Controls
{
    public partial class ucAddUpdateProduct : UserControl
    {
        // Enums
        enum enMode
        {
            AddNew = 0,
            Update = 1
        }
        enum enPbProductImage
        {
            InitialImage = 0,
            ProductImage = 1
        }

        // Properties
        public event EventHandler? OnCloseButtonClicked;
        public event Action<clsProduct>? OnSavedProductSuccessfully;
        public event Action<clsProduct>? OnProductAddedSuccessfully;
        public event Action<clsProduct>? OnProductUpdatedSuccessfully;
        private enPbProductImage _pbProductImage = enPbProductImage.InitialImage;
        private enMode _Mode = enMode.AddNew;
        public clsProduct? Product { get; set; }


        // Constructor
        public ucAddUpdateProduct()
        {
            InitializeComponent();
            InitializeTextBoxProductCategory();
        }

        // Methodes
        private void InitializeTextBoxProductCategory()
        {
            // Your custom list
            string[] suggestions = { "متروز", "بروكار" };

            // Assign to AutoCompleteCustomSource
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(suggestions);

            txtProductCategory.AutoCompleteCustomSource = collection;
            txtProductCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProductCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void HandelLabelTitleLocation()
        {
            int X = (this.Size.Width / 2) - (this.lblTitle.Size.Width / 2);
            lblTitle.Location = new Point(X, lblTitle.Location.Y);
        }
        public void AddNewProduct()
        {
            Product = new clsProduct();
            _Mode = enMode.AddNew;
            lblTitle.Text = "إضافت منتج جديد";
            lblProductID.Text = "[???]";
            cbProductType.SelectedIndex = -1;
            txtProductCategory.Text = string.Empty;
            txtProductColor.Text = string.Empty;
            txtProductInitialLength.Text = string.Empty;
            txtProductStockLength.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            pbProductImage.Image = Resources.empty_image_icon_512;
            _pbProductImage = enPbProductImage.InitialImage;
            pbProductImage.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public void LoadUpdateProduct(clsProduct product)
        {
            Product = product;
            if (Product != null)
            {
                _Mode = enMode.Update;
                lblTitle.Text = "تحديث المنتج";
                lblProductID.Text = Product?.Id.ToString();
                cbProductType.SelectedIndex = int.Parse(Product?.TypeID?.ToString() ?? "0") - 1; // Assuming TypeID is 1-based index
                txtProductCategory.Text = Product?.Category;
                txtProductColor.Text = Product?.Color;
                txtProductInitialLength.Text = Product?.InitialLength?.ToString("0.00");
                txtProductStockLength.Text = Product?.StockLength?.ToString("0.00");
                txtProductPrice.Text = Product?.Price?.ToString("0.00");
                pbProductImage.ImageLocation = Product?.ImagePath != null && File.Exists(Product.ImagePath)
                    ? Product.ImagePath
                    : string.Empty;
                _pbProductImage = enPbProductImage.ProductImage;
                pbProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        private void LoadUserControl()
        {

        }
        private void LoadImageToPictureBox(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    //using (var imgTemp = Image.FromFile(filePath))
                    //{
                    //    pbProductImage.Image = new Bitmap(imgTemp);
                    //}
                    pbProductImage.ImageLocation = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool LoadImageFromFile()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select an Image for product";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    openFileDialog.Multiselect = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadImageToPictureBox(openFileDialog.FileName);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error to load image: {ex.Message}");
            }
            return false;
        }
        private void FillProductDataFromControls()
        {
            if (Product == null)
            {
                MessageBox.Show("لازم إنشاء منتج أولاً قبل الحفظ.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Product.TypeID = (byte)(cbProductType.SelectedIndex + 1);
            Product.Category = txtProductCategory.Text.Trim();
            Product.Color = txtProductColor.Text.Trim();
            Product.InitialLength = double.TryParse(txtProductInitialLength.Text, out double initialLength) ? initialLength : (double?)null;
            Product.StockLength = double.TryParse(txtProductStockLength.Text, out double stockLength) ? stockLength : (double?)null;
            Product.Price = double.TryParse(txtProductPrice.Text, out double price) ? price : (double?)null;
            if (_pbProductImage == enPbProductImage.ProductImage && pbProductImage.Image != null)
            {
                Product.ImagePath = pbProductImage.ImageLocation ?? string.Empty;
            }
            Product.CreatedByUserID = clsGlobal.CurrentUser?.Id;
            if (Product._Mode == clsProduct.enMode.AddNew)
                Product.CreatedDate = DateTime.Now;

            Product.LastUpdate = DateTime.Now;
        }
        private bool ValidateProductData()
        {
            if (cbProductType.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbProductType, "من فضلك, قم باختيار نوع المنتج");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductCategory.Text))
            {
                errorProvider1.SetError(txtProductCategory, "من فضلك, قم بإدخال فئة المنتج");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductColor.Text))
            {
                errorProvider1.SetError(txtProductColor, "من فضلك, قم بإدخال لون المنتج");
                return false;
            }
            if (!decimal.TryParse(txtProductInitialLength.Text, out decimal initialLength) || initialLength <= 0)
            {
                errorProvider1.SetError(txtProductInitialLength, "من فضلك, قم بإدخال طول المنتج الأولي بشكل صحيح");
                return false;
            }
            if (!decimal.TryParse(txtProductStockLength.Text, out decimal stockLength) || stockLength < 0)
            {
                errorProvider1.SetError(txtProductStockLength, "من فضلك, قم بإدخال طول المنتج المخزن بشكل صحيح");
                return false;
            }
            if (!decimal.TryParse(txtProductPrice.Text, out decimal price) || price < 0)
            {
                errorProvider1.SetError(txtProductPrice, "من فضلك, قم بإدخال سعر المنتج بشكل صحيح");
                return false;
            }
            if (pbProductImage.Image == null || _pbProductImage == enPbProductImage.InitialImage)
            {
                errorProvider1.SetError(pbProductImage, "من فضلك, قم بإضافة صورة للمنتج");
                return false;
            }
            return true;
        }
        private void SaveProductData()
        {
            if (!ValidateProductData())
            {
                return;
            }
            if (!this.ValidateChildren())
            {
                MessageBox.Show("من فضلك, قم بتصحيح الأخطاء قبل الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FillProductDataFromControls();
            if (Product != null && Product.Save())
            {
                MessageBox.Show($"تم حفظ المنتج بنجاح مع رقم المنتج: {Product.Id}", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_Mode == enMode.AddNew)
                {

                    this.OnProductAddedSuccessfully?.Invoke(Product);
                }
                else if (_Mode == enMode.Update)
                {
                    this.OnProductUpdatedSuccessfully?.Invoke(Product);
                }
                lblProductID.Text = Product.Id.ToString();
                LoadUpdateProduct(Product);
                this.OnSavedProductSuccessfully?.Invoke(Product);
            }
            else
            {
                MessageBox.Show("فشل في حفظ المنتج. يرجى المحاولة مرة أخرى", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        // Events
        private void lblTitle_TextChanged(object sender, EventArgs e)
        {
            HandelLabelTitleLocation();
        }
        private void ucAddProduct_Load(object sender, EventArgs e)
        {
            LoadUserControl();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (LoadImageFromFile())
            {
                _pbProductImage = enPbProductImage.ProductImage;
            }
            else
            {
                _pbProductImage = enPbProductImage.InitialImage;
                pbProductImage.Image = Resources.empty_image_icon_512;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProductData();
        }

        private void cbProductType_Validating(object sender, CancelEventArgs e)
        {
            if (cbProductType.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbProductType, "من فضلك, قم باختيار نوع المنتج");
            }
            else
            {
                errorProvider1.SetError(cbProductType, string.Empty);
            }
        }

        private void txtProductCategory_Validating(object sender, CancelEventArgs e)
        {
            if (txtProductCategory.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductCategory, "من فضلك, قم بإدخال فئة المنتج");
            }
            else
            {
                errorProvider1.SetError(txtProductCategory, string.Empty);
            }
        }

        private void txtProductColor_Validating(object sender, CancelEventArgs e)
        {
            if (txtProductColor.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductColor, "من فضلك, قم بإدخال لون المنتج");
            }
            else
            {
                errorProvider1.SetError(txtProductColor, string.Empty);
            }
        }

        private void txtProductInitialLength_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtProductInitialLength.Text, out decimal initialLength) || initialLength <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductInitialLength, "من فضلك, قم بإدخال طول المنتج الأولي بشكل صحيح");
            }
            else
            {
                errorProvider1.SetError(txtProductInitialLength, string.Empty);
            }
        }

        private void txtProductStockLength_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtProductStockLength.Text, out decimal stockLength) || stockLength < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductStockLength, "من فضلك, قم بإدخال طول المخزون للمنتج بشكل صحيح");
            }
            else
            {
                errorProvider1.SetError(txtProductStockLength, string.Empty);
            }
        }

        private void txtProductPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtProductPrice.Text, out decimal price) || price < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductPrice, "من فضلك, قم بإدخال سعر المنتج بشكل صحيح");
            }
            else
            {
                errorProvider1.SetError(txtProductPrice, string.Empty);
            }
        }

        private void pbProductImage_Validating(object sender, CancelEventArgs e)
        {
            if (pbProductImage.Image == null || _pbProductImage == enPbProductImage.InitialImage)
            {
                e.Cancel = true;
                errorProvider1.SetError(pbProductImage, "من فضلك, قم بإضافة صورة للمنتج");

            }
            else
            {
                errorProvider1.SetError(pbProductImage, string.Empty);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.OnCloseButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
