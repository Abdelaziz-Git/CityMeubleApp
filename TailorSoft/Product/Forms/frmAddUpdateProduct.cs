using TailorSoft_Business_Layer;

namespace HFS.Product.Forms
{
    public partial class frmAddUpdateProduct : Form
    {
        // Enums
        enum enMode { AddNew, Update }
        enMode _Mode = enMode.AddNew;

        // Properties
        public event Action<clsProduct>? OnProductSavedSuccessfully;
        public event Action<clsProduct?>? OnProductAddedSuccessfully;
        public event Action<clsProduct?>? OnProductUpdatedSuccessfully;

        // Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddUpdateProduct"/> class 
        /// in "Add New Product" mode. Sets up the form controls and assigns the 
        /// close button event handler.
        /// </summary>
        public frmAddUpdateProduct()
        {
            InitializeComponent();
            InitializeTheFormInAddNewMode();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddUpdateProduct"/> class 
        /// in "Update Product" mode. Pre-fills the form fields with the specified 
        /// product's data and sets up the close button event handler.
        /// </summary>
        /// <param name="product">The product to be updated. Its data will populate the form.</param>
        public frmAddUpdateProduct(clsProduct product)
        {
            InitializeComponent();
            InitializeTheFormInUpdateMode(product);
        }

        // Methods
        private void InitializeTheFormInAddNewMode()
        {
            _Mode = enMode.AddNew;
            this.ucAddUpdateProduct1.AddNewProduct();
        }
        private void InitializeTheFormInUpdateMode(clsProduct product)
        {
            _Mode = enMode.Update;
            this.ucAddUpdateProduct1.LoadUpdateProduct(product);
        }



        private void ucAddUpdateProduct1_OnCloseButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucAddUpdateProduct1_OnSavedProductSuccessfully(clsProduct product)
        {
            this.OnProductSavedSuccessfully?.Invoke(product);
            this.Close();
        }

        private void ucAddUpdateProduct1_OnProductAddedSuccessfully(clsProduct obj)
        {
            this.OnProductAddedSuccessfully?.Invoke(obj);
        }

        private void ucAddUpdateProduct1_OnProductUpdatedSuccessfully(clsProduct obj)
        {
            this.OnProductUpdatedSuccessfully?.Invoke(obj);
        }
    }
}
