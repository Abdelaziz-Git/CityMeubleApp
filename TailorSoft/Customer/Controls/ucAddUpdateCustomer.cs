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
            lblTitle.Text = "Ajouter un nouveau client";
            lblCustomerID.Text = "[???]";
            ResetFields();
        }

        public void LoadCustomerData(clsCustomer customer)
        {
            Customer = customer;
            if (Customer != null)
            {
                _Mode = enMode.Update;
                lblTitle.Text = "Mettre à jour les données du client";
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
                MessageBox.Show("Échec de la mise à jour du client", "Erreur",
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
                    MessageBox.Show("Échec de la mise à jour des données du client", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadCustomerData(UpdatedCustomer);
                Customer = UpdatedCustomer;
                MessageBox.Show("Données du client mises à jour avec succès", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnCustomerSaved?.Invoke(Customer);
            }
            else
            {
                MessageBox.Show("Impossible de mettre à jour le client sans ID personnel", "Erreur",
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
                errorProvider1.SetError(txtFirstName, "Le prénom est obligatoire");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Le nom de famille est obligatoire");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Le téléphone est obligatoire");
                return false;
            }
            if (_Mode == enMode.AddNew)
            {
                if (clsCustomer.IsExistsByPhone(txtPhone.Text.Trim()))
                {
                    errorProvider1.SetError(txtPhone, "Ce numéro de téléphone existe déjà");
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
                    MessageBox.Show("Échec de l'ajout du client", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblCustomerID.Text = newCustomer.Id?.ToString() ?? "[???]";
                MessageBox.Show("Client ajouté avec succès", "Succès",
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
                errorProvider1.SetError(txtPhone, "Ce numéro de téléphone existe déjà");
            }
            else
            {
                errorProvider1.SetError(txtPhone, string.Empty);
            }
        }
    }
}