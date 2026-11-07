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

        // Enums
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
            LoadUserControl();
            InitializeTextBoxProductCategory();
        }

        // Méthodes
        private void InitializeTextBoxProductCategory()
        {
            // Votre liste personnalisée
            string[] suggestions = { "Velours", "Brocart" };

            // Affecter à AutoCompleteCustomSource
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
            lblTitle.Text = "Ajouter un nouveau produit";
            lblProductID.Text = "[???]";
            cbProductType.SelectedIndex = -1;
            txtProductCategory.Text = string.Empty;
            txtProductColor.Text = string.Empty;
            txtProductDimensions.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;
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
                lblTitle.Text = "Mettre à jour le produit";
                lblProductID.Text = Product?.Id.ToString();
                cbProductType.SelectedIndex = int.Parse(Product?.TypeID?.ToString() ?? "0") - 1; // Assuming TypeID is 1-based index
                txtProductCategory.Text = Product?.Category;
                txtProductColor.Text = Product?.Color;
                txtProductDimensions.Text = Product?.Dimensions;
                txtProductQuantity.Text = Product?.Quantity?.ToString();
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
            cbProductType.Items.Clear();
            cbProductType.Items.AddRange(clsProductType.GetAll().Select(pt => pt.Name).ToArray());
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
                    MessageBox.Show("Échec du chargement de l'image: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Le fichier n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool LoadImageFromFile()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Sélectionner une image pour le produit";
                    openFileDialog.Filter = "Fichiers image|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
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
                MessageBox.Show($"Erreur lors du chargement de l'image: {ex.Message}");
            }
            return false;
        }
        private void FillProductDataFromControls()
        {
            if (Product == null)
            {
                MessageBox.Show("Vous devez créer un produit d'abord avant d'enregistrer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Product.TypeID = (byte)(cbProductType.SelectedIndex + 1);
            Product.Category = txtProductCategory.Text.Trim();
            Product.Color = txtProductColor.Text.Trim();
            Product.Dimensions = txtProductDimensions.Text.Trim();
            Product.Quantity = int.TryParse(txtProductQuantity.Text, out int quantity) ? quantity : (int?)null;
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
                errorProvider1.SetError(cbProductType, "S'il vous plaît, sélectionnez le type de produit");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductCategory.Text))
            {
                errorProvider1.SetError(txtProductCategory, "S'il vous plaît, entrez la catégorie du produit");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductColor.Text))
            {
                errorProvider1.SetError(txtProductColor, "S'il vous plaît, entrez la couleur du produit");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProductDimensions.Text))
            {
                errorProvider1.SetError(txtProductDimensions, "S'il vous plaît, entrez les dimensions du produit correctement\n" +
                    "Si nécessaire, utilisez le format LxWxH\n" +
                    "si le produit est de forme irrégulière, tapez N/A");
                return false;
            }
            if (!int.TryParse(txtProductQuantity.Text, out int stockLength) || stockLength < 0)
            {
                errorProvider1.SetError(txtProductQuantity, "S'il vous plaît, entrez la quantité du stock du produit correctement");
                return false;
            }
            if (!decimal.TryParse(txtProductPrice.Text, out decimal price) || price < 0)
            {
                errorProvider1.SetError(txtProductPrice, "S'il vous plaît, entrez le prix du produit correctement");
                return false;
            }
            if (pbProductImage.Image == null || _pbProductImage == enPbProductImage.InitialImage)
            {
                errorProvider1.SetError(pbProductImage, "S'il vous plaît, ajoutez une image pour le produit");
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
                MessageBox.Show("S'il vous plaît, corrigez les erreurs avant d'enregistrer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FillProductDataFromControls();
            if (Product != null && Product.Save())
            {
                MessageBox.Show($"Le produit a été enregistré avec succès avec le numéro de produit: {Product.Id}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Échec de l'enregistrement du produit. Veuillez réessayer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        // Events
        private void lblTitle_TextChanged(object sender, EventArgs e)
        {
            HandelLabelTitleLocation();
        }
        private void ucAddProduct_Load(object sender, EventArgs e)
        {
            
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
                errorProvider1.SetError(cbProductType, "S'il vous plaît, sélectionnez le type de produit");
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
                errorProvider1.SetError(txtProductCategory, "S'il vous plaît, entrez la catégorie du produit");
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
                errorProvider1.SetError(txtProductColor, "S'il vous plaît, entrez la couleur du produit");
            }
            else
            {
                errorProvider1.SetError(txtProductColor, string.Empty);
            }
        }

        private void txtProductDimensions_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductDimensions.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductDimensions, "S'il vous plaît, entrez les dimensions du produit correctement\n" +
                    "Si nécessaire, utilisez le format LxWxH\n" +
                    "si le produit est de forme irrégulière, tapez N/A");
            }
            else
            {
                errorProvider1.SetError(txtProductDimensions, string.Empty);
            }
        }

        private void txtProductStockLength_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtProductQuantity.Text, out int stockLength) || stockLength < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductQuantity, "S'il vous plaît, entrez la quantité du stock du produit correctement");
            }
            else
            {
                errorProvider1.SetError(txtProductQuantity, string.Empty);
            }
        }

        private void txtProductPrice_Validating(object sender, CancelEventArgs e)
        {
            if (!decimal.TryParse(txtProductPrice.Text, out decimal price) || price < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtProductPrice, "S'il vous plaît, entrez le prix du produit correctement");
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
                errorProvider1.SetError(pbProductImage, "S'il vous plaît, ajoutez une image pour le produit");

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

        private void txtProductDimensions_TextChanged(object sender, EventArgs e)
        {
            //errorProvider1.SetError(txtProductDimensions, string.Empty);
        }
    }
}
