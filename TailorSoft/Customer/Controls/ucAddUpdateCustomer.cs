using TailorSoft_Business_Layer;

namespace TailorSoft.Customers.Controls
{
    public partial class ucAddUpdateCustomer : UserControl
    {
        public event EventHandler? OnCloseButtonClicked;
        public event Action<clsCustomer>? OnCustomerSaved;

        private enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;
        public clsCustomer? Customer { get; private set; }

        public ucAddUpdateCustomer()
        {
            InitializeComponent();
        }

        public void AddNewCustomer()
        {
            _Mode = enMode.AddNew;
            Customer = null;
            lblTitle.Text = "إضافة عميل جديد";
            lblCustomerID.Text = "[???]";
            ResetFields();
        }

        public void LoadCustomerData(clsCustomer customer)
        {
            Customer = customer;
            if (Customer != null)
            {
                _Mode = enMode.Update;
                lblTitle.Text = "تحديث بيانات العميل";
                lblCustomerID.Text = Customer.Id?.ToString() ?? "[???]";
                txtFirstName.Text = Customer.Person?.FirstName;
                txtLastName.Text = Customer.Person?.LastName;
                txtPhone.Text = Customer.Person?.Phone;
                txtEmail.Text = Customer.Person?.Email;
                txtAddress.Text = Customer.Person?.Address;
            }
        }

        private void _UpdateCustomer()
        {
            if (Customer == null)
            {
                MessageBox.Show("لا يوجد عميل لتحرير بياناته", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Customer.PersonID.HasValue)
            {
                clsCustomer? UpdatedCustomer = clsCustomer.Update(
                PersonID: Customer.PersonID.Value,
                firstName: txtFirstName.Text.Trim(),
                lastName: txtLastName.Text.Trim(),
                phone: txtPhone.Text.Trim(),
                email: txtEmail.Text.Trim(),
                address: txtAddress.Text.Trim());
                if (UpdatedCustomer == null)
                {
                    MessageBox.Show("فشل في تحديث بيانات العميل", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadCustomerData(UpdatedCustomer);
                Customer = UpdatedCustomer;
                MessageBox.Show("تم تحديث بيانات العميل بنجاح", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnCustomerSaved?.Invoke(Customer);
            }
            else
            {
                MessageBox.Show("لا يمكن تحديث بيانات العميل بدون معرف شخصي", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ResetFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "الاسم الأول مطلوب");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "اسم العائلة مطلوب");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "الهاتف مطلوب");
                return false;
            }
            if (_Mode == enMode.AddNew)
            {
                if (clsCustomer.IsExistsByPhone(txtPhone.Text.Trim()))
                {
                    errorProvider1.SetError(txtPhone, "رقم الهاتف موجود بالفعل");
                    return false;
                }
            }

            return true;
        }

        private void SaveCustomer()
        {
            if (!ValidateData() || !this.ValidateChildren()) return;

            int userID = clsGlobal.CurrentUser?.Id ?? 0;
            clsCustomer? newCustomer = null;

            if (_Mode == enMode.AddNew)
            {
                newCustomer = clsCustomer.AddNew(
                    firstName: txtFirstName.Text.Trim(),
                    lastName: txtLastName.Text.Trim(),
                    phone: txtPhone.Text.Trim(),
                    email: txtEmail.Text.Trim(),
                    addres: txtAddress.Text.Trim(),
                    userID: userID
                );
                if (newCustomer == null)
                {
                    MessageBox.Show("فشل في إضافة العميل", "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblCustomerID.Text = newCustomer.Id?.ToString() ?? "[???]";
                MessageBox.Show("تم إضافة العميل بنجاح", "نجاح",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomerData(newCustomer);
                OnCustomerSaved?.Invoke(newCustomer);
            }
            else if (_Mode == enMode.Update && Customer != null)
            {
                _UpdateCustomer();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCustomer();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCloseButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                errorProvider1.SetError(txtPhone, string.Empty);
                return;
            }
            if (clsCustomer.IsExistsByPhone(txtPhone.Text.Trim()))
            {
                errorProvider1.SetError(txtPhone, "رقم الهاتف موجود بالفعل");
            }
            else
            {
                errorProvider1.SetError(txtPhone, string.Empty);
            }
        }
    }
}