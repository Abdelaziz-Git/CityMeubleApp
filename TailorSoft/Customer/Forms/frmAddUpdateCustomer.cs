using TailorSoft.Customers.Controls;
using TailorSoft_Business_Layer;

namespace TailorSoft.Customer.Forms
{
    public partial class frmAddUpdateCustomer : Form
    {
        public event Action<clsCustomer>? OnCustomerSaved;
        public ucAddUpdateCustomer ucAddUpdateCustomer1 = new ucAddUpdateCustomer();
        public frmAddUpdateCustomer()
        {
            InitializeComponent();
            InitializeUcAddUpdateCustomer();
            ucAddUpdateCustomer1.AddNewCustomer();
        }
        public frmAddUpdateCustomer(clsCustomer obj)
        {
            InitializeComponent();
            InitializeUcAddUpdateCustomer();
            ucAddUpdateCustomer1.LoadCustomerData(obj);
        }
        private void InitializeUcAddUpdateCustomer()
        {
            this.ucAddUpdateCustomer1.Dock = DockStyle.Fill;
            this.Controls.Add(this.ucAddUpdateCustomer1);
            this.ucAddUpdateCustomer1.OnCloseButtonClicked += ucAddUpdateCustomer1_OnCloseButtonClicked;
            this.ucAddUpdateCustomer1.OnCustomerSaved += ucAddUpdateCustomer1_OnCustomerSaved;
        }
        private void ucAddUpdateCustomer1_OnCloseButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucAddUpdateCustomer1_OnCustomerSaved(clsCustomer obj)
        {
            OnCustomerSaved?.Invoke(obj);
            this.Close();
        }

    }
}
