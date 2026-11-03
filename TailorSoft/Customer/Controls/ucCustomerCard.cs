using TailorSoft_Business_Layer;

namespace TailorSoft.Customer.Controls
{
    public partial class ucCustomerCard : UserControl
    {
        private clsCustomer? _Customer;
        public clsCustomer? Customer
        {
            get { return _Customer; }
        }
        public event Action<clsCustomer?>? OnCustomerSelected;
        public ucCustomerCard()
        {
            InitializeComponent();
            ClearCustomerData();

        }
        public void SetCustomerData(clsCustomer customer)
        {
            _Customer = customer;
            if (customer == null)
            {
                lblCustomerID.Text = "[???]";
                lblName.Text = "Inconnu";
                lblPhone.Text = "Inconnu";
                lblEmail.Text = "Inconnu";
                lblAdress.Text = "Inconnu";
                lblCreatedDate.Text = "Inconnu";
                MessageBox.Show("Aucun client à afficher", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OnCustomerSelected?.Invoke(null);
            }
            else
            {
                lblCustomerID.Text = _Customer.Id?.ToString() ?? "[???]";
                lblName.Text = _Customer.Person?.FullName ?? "Inconnu";
                lblPhone.Text = _Customer.Person?.Phone ?? "Inconnu";
                lblEmail.Text = _Customer.Person?.Email ?? "Inconnu";
                lblAdress.Text = _Customer.Person?.Address ?? "Inconnu";
                lblCreatedDate.Text = _Customer.CreatedDate?.ToString("yyyy-MM-dd") ?? "Inconnu";
                this.OnCustomerSelected?.Invoke(_Customer);
            }
        }
        public void ClearCustomerData()
        {
            _Customer = null;
            lblCustomerID.Text = "[???]";
            lblName.Text = "Inconnu";
            lblPhone.Text = "Inconnu";
            lblEmail.Text = "Inconnu";
            lblAdress.Text = "Inconnu";
            lblCreatedDate.Text = "Inconnu";
            this.OnCustomerSelected?.Invoke(null);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
