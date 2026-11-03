namespace TailorSoft.Order.Forms
{
    public partial class frmRecordPayment : Form
    {
        private int _orderID;
        clsOrder? _Order;
        public frmRecordPayment(int orderID)
        {
            InitializeComponent();
            _orderID = orderID;
            _Order = clsOrder.Find(orderID);
            if (_Order == null)
            {
                MessageBox.Show("La commande n'a pas été trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                lblTitle.Text = $"Enregistrement du paiement pour la commande n° {_Order.Id}";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                // Assuming clsOrder has a method to record payment
                bool success = clsOrder.RecordPayment(_orderID, amount);
                if (success)
                {
                    MessageBox.Show("Le paiement a été enregistré avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Échec de l'enregistrement du paiement. Veuillez réessayer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un montant correct.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
