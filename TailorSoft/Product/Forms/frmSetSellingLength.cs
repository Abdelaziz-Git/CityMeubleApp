using TailorSoft_Business_Layer;

namespace TailorSoft.Product.Forms
{
    public partial class frmSetSellingLength : Form
    {
        private clsProduct _productToSell;
        public event Action<clsProduct>? OnSellingCompletedSuccessfully;
        public frmSetSellingLength(clsProduct ProductToSell)
        {
            InitializeComponent();
            _productToSell = ProductToSell;
        }
        private void SubstrackSellingLength()
        {
            if (_productToSell == null || _productToSell.Id <= 0)
            {
                MessageBox.Show("Le numéro du produit est incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_productToSell.Quantity <= 0)
            {
                MessageBox.Show("Aucune quantité disponible pour la vente", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudSellingLength.ResetText();
                return;
            }
            if (_productToSell.Quantity < (int)nudSellingLength.Value)
            {
                MessageBox.Show("Le nombre requise pour la vente est supérieure à la quantité disponible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudSellingLength.ResetText();
                return;
            }
            if (_productToSell.Sell((int)nudSellingLength.Value))
            {
                OnSellingCompletedSuccessfully?.Invoke(_productToSell);
                MessageBox.Show("Le quantité a été déduite avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Une erreur s'est produite lors de la déduction de la quantité", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudSellingLength.ResetText();
            }
        }
        private void frmSetSellingLength_Load(object sender, EventArgs e)
        {
            if (_productToSell == null || _productToSell.Id <= 0)
            {
                MessageBox.Show("Le numéro du produit est incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblTitle.Text = $"Entrez la quantité que vous souhaitez vendre du produit numéro {_productToSell.Id}";
            nudSellingLength.ResetText();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SubstrackSellingLength();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
