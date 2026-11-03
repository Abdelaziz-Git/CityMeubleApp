using TailorSoft.Order.Controls;
using TailorSoft_Business_Layer;

namespace TailorSoft.Order.Forms
{
    public partial class frmAddOrder : Form
    {
        public event Action<clsOrder>? OnOrderSavedSuccessfully;
        private ucAddUpdateOrder _ucAddUpdateOrder1 = new ucAddUpdateOrder();
        private clsOrder? _Order = null;
        private clsCustomer? _Customer = null;
        private bool _IsUserSavingOrder = false;
        public clsOrder? Order
        {
            get { return _Order; }
        }
        public frmAddOrder()
        {
            InitializeComponent();
            InitializeUcAddUpdateOrder();
        }
        private void InitializeUcAddUpdateOrder()
        {
            _ucAddUpdateOrder1.Dock = DockStyle.Fill;
            _ucAddUpdateOrder1.Visible = false;
            // Subscribe to events
            // Handle the event when the user saves the order successfully
            _ucAddUpdateOrder1.OnOrderSavedSuccessfully += (order) =>
            {
                _IsUserSavingOrder = true;
                OnOrderSavedSuccessfully?.Invoke(order);
            };
            // Handle the Close button click event
            _ucAddUpdateOrder1.OnButtonCloseClicked += () =>
            {
                this.Close();
            };

            this.Controls.Add(_ucAddUpdateOrder1);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Customer == null || _Customer.Id.HasValue == false)
            {
                MessageBox.Show("Veuillez sélectionner le client avant de continuer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_ucAddUpdateOrder1 != null)
            {
                // Create a new order
                _Order = new clsOrder
                {
                    CustomerID = _Customer.Id.Value,
                    UserID = clsGlobal.CurrentUser?.Id ?? 0,
                    RequiredDate = DateTime.Now, // Default to 7 days from now
                    Status = (byte)clsOrder.enStatus.Pending,
                    InitialAmount = 0,
                    RemainingAmount = 0,
                    TotalAmount = 0
                };
                if (!_Order.Save())
                {
                    MessageBox.Show("Une erreur s'est produite lors de la création d'une nouvelle commande", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _ucAddUpdateOrder1.Visible = true;
                _ucAddUpdateOrder1.BringToFront();
                _ucAddUpdateOrder1.SetOrder(_Order);
            }

        }
        private void ucCustomerCardWithFilter1_OnCustomerSelected(TailorSoft_Business_Layer.clsCustomer? obj)
        {
            _Customer = obj;

        }
        private void frmAddOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_IsUserSavingOrder && _ucAddUpdateOrder1.Visible == true)
            {
                if (MessageBox.Show("Voulez-vous quitter sans enregistrer la commande?", "Avertissement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true; // Cancel the closing event
                    return;
                }
                if (clsOrder.Delete(_Order?.Id ?? 0))
                {
                    MessageBox.Show("La commande a été supprimée avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Une erreur s'est produite lors de la suppression de la commande", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void frmAddOrder_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmAddOrder_KeyUp(object sender, KeyEventArgs e)
        {

        }

    }
}
