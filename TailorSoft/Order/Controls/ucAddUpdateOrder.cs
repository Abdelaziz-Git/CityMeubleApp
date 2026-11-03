using TailorSoft.OrderItem.Controls;
using static clsOrder;

namespace TailorSoft.Order.Controls
{
    public partial class ucAddUpdateOrder : UserControl
    {
        private clsOrder? _Order;
        public clsOrder? Order
        {
            get => _Order;
        }
        public event Action? OnButtonCloseClicked;
        public event Action<clsOrder>? OnOrderSavedSuccessfully;
        public ucAddUpdateOrder()
        {
            InitializeComponent();
            InitializeComboBoxOrderStatus();
            SetDeffaultValues();
            this.ucOrderItemList1.OnItemsChanged += UcOrderItemList1_OnItemsChanged;
        }

        private void SetDeffaultValues()
        {
            lblOrderID.Text = "Inconnu";
            lblCustomerID.Text = "Inconnu";
            dtpRequiredDate.Value = DateTime.Now;
            cbOrderStatus.SelectedIndex = 0; // Default to Pending
            txtNotes.Text = "Pas de notes";
            lblInitialAmount.Text = "0 DH";
            lblRemainingAmount.Text = "0 DH";
            lblTotalAmount.Text = "0 DH";
        }
        private void InitializeComboBoxOrderStatus()
        {
            cbOrderStatus.Items.Clear();
            var statusTranslations = new Dictionary<clsOrder.enStatus, string>
            {
                    { enStatus.Pending, "En attente" },
                    { enStatus.Measuring, "Mesure" },
                    { enStatus.InProgress, "En cours" },
                    { enStatus.ReadyforDelivery, "Prêt pour livraison" },
                    { enStatus.Delivered, "Livré" },
                    { enStatus.DeliveredAndPaid, "Livré et payé" },
                    { enStatus.Cancelled, "Annulé" }
            };

            // Fill ComboBox with enum values
            foreach (var kvp in statusTranslations)
            {
                cbOrderStatus.Items.Add(new { Value = (byte)kvp.Key, Text = kvp.Value });
            }

            cbOrderStatus.DisplayMember = "Text";
            cbOrderStatus.ValueMember = "Value";
        }
        private bool IsValidInputs()
        {
            if (dtpRequiredDate.Value < DateTime.Now.AddYears(-1))
            {
                MessageBox.Show("Veuillez sélectionner une date valide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbOrderStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner l'état de la commande", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void SetOrder(clsOrder order)
        {
            if (order == null || order.Id <= 0 || order.CustomerID <= 0)
            {
                SetDeffaultValues();
                MessageBox.Show("Numéro de commande invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Set Order Information
            _Order = order;
            lblOrderID.Text = _Order.Id.ToString();
            lblCustomerID.Text = _Order.CustomerID.ToString();
            dtpRequiredDate.Value = _Order.RequiredDate;
            cbOrderStatus.SelectedValue = _Order.Status;
            txtNotes.Text = _Order.Notes;
            lblInitialAmount.Text = $"{_Order.InitialAmount} DH";
            lblRemainingAmount.Text = $"{_Order.RemainingAmount} DH";
            lblTotalAmount.Text = $"{_Order.TotalAmount} DH";

            // Set Items list
            this.ucOrderItemList1.SetItems(_Order.Id);
        }
        public void ButtonSave_Click()
        {
            btnSave.PerformClick();
        }
        private void UcOrderItemList1_OnItemsChanged(int orderID)
        {
            _Order = clsOrder.Find(orderID);
            if (_Order == null)
            {
                MessageBox.Show("Une erreur s'est produite lors du rechargement de la commande après modification des articles", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Update Order Information
            SetOrder(_Order);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.OnButtonCloseClicked?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidInputs())
                return;

            if (_Order == null)
            {
                MessageBox.Show("Veuillez charger la commande avant d'enregistrer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Update Order Information
            _Order.RequiredDate = dtpRequiredDate.Value;
            _Order.Status = (byte)cbOrderStatus.SelectedIndex;
            _Order.Notes = txtNotes.Text.Trim();
            if (_Order.Save())
            {
                this.OnOrderSavedSuccessfully?.Invoke(_Order);
                MessageBox.Show("La commande a été mise à jour avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnButtonCloseClicked?.Invoke();
            }
            else
            {
                MessageBox.Show("Une erreur s'est produite lors de la mise à jour de la commande", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblOrderID_Click(object sender, EventArgs e)
        {

        }

        private void lblInitialAmount_Click(object sender, EventArgs e)
        {

        }
    }
}
