using TailorSoft.Customer.Forms;
using TailorSoft_Business_Layer;

namespace TailorSoft.Customer.Controls
{
    public partial class ucCustomerCardWithFilter : UserControl
    {
        public event Action<clsCustomer?>? OnCustomerSelected;
        public ucCustomerCardWithFilter()
        {
            InitializeComponent();
            ucCustomerCard1.OnCustomerSelected += UcCustomerCard1_OnCustomerSelected;
            cbFindBy.SelectedIndex = 0; // Default to "رقم الهاتف"  
        }
        private void FinnByCustomerID()
        {
            if (int.TryParse(txtSearch.Text.Trim(), out int customerId))
            {
                var customer = clsCustomer.Find(customerId);
                if (customer != null)
                {
                    ucCustomerCard1.SetCustomerData(customer);
                }
                else
                {
                    MessageBox.Show("لا يوجد عميل بهذا الرقم", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ucCustomerCard1.ClearCustomerData();
                }

            }
            else
            {
                MessageBox.Show("الرجاء إدخال رقم العميل بشكل صحيح", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucCustomerCard1.ClearCustomerData();
            }

        }
        private void FinnByPhone()
        {
            var customer = clsCustomer.FindByPhone(txtSearch.Text.Trim());
            if (customer != null)
            {
                ucCustomerCard1.SetCustomerData(customer);
            }
            else
            {
                MessageBox.Show("لا يوجد عميل بهذا الهاتف", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UcCustomerCard1_OnCustomerSelected(clsCustomer? obj)
        {
            this.OnCustomerSelected?.Invoke(obj);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                MessageBox.Show("الرجاء إدخال قيمة للبحث", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucCustomerCard1.ClearCustomerData();
                return;
            }
            if (cbFindBy.SelectedIndex == 0) // "رقم الهاتف"
            {
                FinnByPhone();
            }
            else if (cbFindBy.SelectedIndex == 1) // "رقم الزبون"
            {
                FinnByCustomerID();
            }
            else
            {
                MessageBox.Show("الرجاء اختيار طريقة البحث", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ucCustomerCard1.ClearCustomerData();
            }
        }
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddUpdateCustomer())
            {
                frm.OnCustomerSaved += (newCustomer) =>
                {
                    cbFindBy.SelectedIndex = 0;// Reset to "رقم الهاتف"
                    txtSearch.Text = newCustomer.Person?.Phone ?? string.Empty;
                    btnSearch.PerformClick();
                };
            }
        }
        public void ButtonSearchClick()
        {
            btnSearch.PerformClick();
        }
        public void GroupBoxFilterEnable(bool enable)
        {
            gbFilter.Enabled = enable;
        }
        public void txtSearchFocus()
        {
            txtSearch.Focus();
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty; // Clear search text when changing filter type
        }

        private void ucCustomerCardWithFilter_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnAddNewCustomer_Click_1(object sender, EventArgs e)
        {
            using (var frm = new frmAddUpdateCustomer())
            {
                frm.OnCustomerSaved += (newCustomer) =>
                {
                    cbFindBy.SelectedIndex = 0; // Reset to "رقم الهاتف"
                    txtSearch.Text = newCustomer.Person?.Phone ?? string.Empty;
                    btnSearch.PerformClick();
                };
                frm.ShowDialog();
            }
        }

        private void ucCustomerCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
