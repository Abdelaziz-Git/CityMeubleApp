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
                lblName.Text = "غير معروف";
                lblPhone.Text = "غير معروف";
                lblEmail.Text = "غير معروف";
                lblAdress.Text = "غير معروف";
                lblCreatedDate.Text = "غير معروف";
                MessageBox.Show("لا يوجد عميل لعرض بياناته", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.OnCustomerSelected?.Invoke(null);
            }
            else
            {
                lblCustomerID.Text = _Customer.Id?.ToString() ?? "[???]";
                lblName.Text = _Customer.Person?.FullName ?? "غير معروف";
                lblPhone.Text = _Customer.Person?.Phone ?? "غير معروف";
                lblEmail.Text = _Customer.Person?.Email ?? "غير معروف";
                lblAdress.Text = _Customer.Person?.Address ?? "غير معروف";
                lblCreatedDate.Text = _Customer.CreatedDate?.ToString("yyyy-MM-dd") ?? "غير معروف";
                this.OnCustomerSelected?.Invoke(_Customer);
            }
        }
        public void ClearCustomerData()
        {
            _Customer = null;
            lblCustomerID.Text = "[???]";
            lblName.Text = "غير معروف";
            lblPhone.Text = "غير معروف";
            lblEmail.Text = "غير معروف";
            lblAdress.Text = "غير معروف";
            lblCreatedDate.Text = "غير معروف";
            this.OnCustomerSelected?.Invoke(null);
        }
    }
}
