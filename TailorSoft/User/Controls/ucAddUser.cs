using System.Data;
using TailorSoft_Business_Layer;

namespace TailorSoft.User.Controls
{
    public partial class ucAddUser : UserControl
    {
        /// <summary>
        /// Occurs when the close button is clicked, allowing subscribers to handle the event.
        /// </summary>
        /// <remarks>This event can be used to perform cleanup actions or to prompt the user for
        /// confirmation before closing. It is important to ensure that any event handlers are properly unsubscribed to
        /// avoid memory leaks.</remarks>
        public event Action? OnButtonCloseClicked;

        /// <summary>
        /// Occurs when a user is added successfully, providing the user ID of the newly added user.
        /// </summary>
        /// <remarks>Subscribe to this event to perform actions after a user has been added, such as
        /// updating the user interface or logging the event. The event handler receives the user ID as an
        /// argument.</remarks>
        public event Action<int?>? OnUserAddedSuccessfully;

        private readonly int[] permissionValues = (int[])Enum.GetValues(typeof(clsUser.enPermissionsInArabic));
        private readonly List<CheckBox> permissionsCheckBoxes = new List<CheckBox>();

        public ucAddUser()
        {
            InitializeComponent();
            LoadPermissions();
            InitializeFlowLayoutPanelPermissions();
        }

        // Initialize the FlowLayoutPanel settings for displaying permissions
        private void InitializeFlowLayoutPanelPermissions()
        {
            flpPermissions.AutoScroll = true;
            flpPermissions.FlowDirection = FlowDirection.TopDown;
            flpPermissions.WrapContents = false;

        }

        // Dynamically create CheckBox controls for each permission and add them to the FlowLayoutPanel
        private void LoadPermissions()
        {
            foreach (int permissionValue in permissionValues)
            {
                var permission = (clsUser.enPermissions)permissionValue;
                CheckBox chk = new CheckBox
                {
                    Text = GetPermissionName(permission),
                    Tag = permissionValue,
                    AutoSize = false,
                    Width = flpPermissions.ClientSize.Width - 30,
                    Height = 25,
                    Margin = new Padding(3)

                };


                if (permission == clsUser.enPermissions.All)
                {
                    chk.Font = new Font(chk.Font.FontFamily, 12, FontStyle.Bold | FontStyle.Underline);
                    chk.CheckedChanged += ChkAll_CheckedChanged;
                }
                else
                {
                    chk.Font = new Font(chk.Font.FontFamily, 11, FontStyle.Regular);
                    chk.CheckedChanged += Chk_CheckedChanged;
                }

                permissionsCheckBoxes.Add(chk);
                flpPermissions.Controls.Add(chk);
            }
        }

        private string GetPermissionName(clsUser.enPermissions permission)
        {
            return permission switch
            {
                clsUser.enPermissions.All => "Toutes les autorisations",
                clsUser.enPermissions.ViewHome => "Accéder à l'accueil",
                clsUser.enPermissions.ViewProducts => "Voir les produits",
                clsUser.enPermissions.ViewProductsDetail => "Voir les détails des produits",
                clsUser.enPermissions.AddProducts => "Ajouter des produits",
                clsUser.enPermissions.EditProducts => "Modifier les produits",
                clsUser.enPermissions.DeleteProducts => "Supprimer des produits",
                clsUser.enPermissions.SaleProducts => "Vendre des produits",
                clsUser.enPermissions.ViewCustomers => "Voir les clients",
                clsUser.enPermissions.AddCustomers => "Ajouter des clients",
                clsUser.enPermissions.EditCustomers => "Modifier les clients",
                clsUser.enPermissions.DeleteCustomers => "Supprimer les clients",
                clsUser.enPermissions.ViewOrders => "Voir les commandes",
                clsUser.enPermissions.AddOrders => "Ajouter des commandes",
                clsUser.enPermissions.EditOrders => "Modifier les commandes",
                clsUser.enPermissions.DeleteOrders => "Supprimer les commandes",
                clsUser.enPermissions.PaymentOrders => "Gérer les paiements des commandes",
                clsUser.enPermissions.PrintOrders => "Imprimer les commandes",
                clsUser.enPermissions.ViewUsers => "Voir les utilisateurs",
                clsUser.enPermissions.AddUsers => "Ajouter des utilisateurs",
                clsUser.enPermissions.EditUsers => "Modifier les utilisateurs",
                clsUser.enPermissions.DeleteUsers => "Supprimer les utilisateurs",
                clsUser.enPermissions.EditStoreInfo => "Modifier les informations du magasin",
                _ => throw new ArgumentOutOfRangeException(nameof(permission), permission, null)
            };
        }

        // Event handler for the "All" checkbox to check/uncheck all permissions
        private void ChkAll_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not CheckBox changedChk) return;
            if (changedChk.Tag is not int tagValue) return;

            var perm = (clsUser.enPermissions)tagValue;

            // If "All" checkbox toggled, set/clear all checkboxes accordingly.
            if (perm == clsUser.enPermissions.All)
            {
                CheckAllPermissions(changedChk.Checked);

                return;
            }
        }

        // Event handler for individual permission checkboxes to manage the "All" checkbox state
        private void Chk_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not CheckBox changedChk) return;
            if (changedChk.Tag is not int tagValue) return;

            var perm = (clsUser.enPermissions)tagValue;


            if (perm != clsUser.enPermissions.All)
            {
                CheckBox? checkBoxAll = permissionsCheckBoxes.FirstOrDefault(chk => (int?)chk?.Tag == (int?)clsUser.enPermissions.All);

                if (permissionsCheckBoxes.Exists(chk => (int?)chk?.Tag != (int?)clsUser.enPermissions.All && chk?.Checked == false))
                {
                    // If any other checkbox is unchecked, uncheck "All"
                    if (checkBoxAll != null)
                    {
                        checkBoxAll.CheckedChanged -= ChkAll_CheckedChanged; // Temporarily detach event handler to prevent recursion
                        checkBoxAll.Checked = false;
                        checkBoxAll.CheckedChanged += ChkAll_CheckedChanged; // Reattach event handler
                    }
                }
                else
                {
                    if (checkBoxAll != null)
                    {
                        checkBoxAll.CheckedChanged -= ChkAll_CheckedChanged; // Temporarily detach event handler to prevent recursion
                        checkBoxAll.Checked = true;
                        checkBoxAll.CheckedChanged += ChkAll_CheckedChanged; // Reattach event handler
                    }
                }
            }

        }

        // Helper method to check or uncheck all permission checkboxes except "All"
        private void CheckAllPermissions(bool check)
        {
            foreach (var chk in permissionsCheckBoxes.Where(chk => chk.Tag is int tagValue && tagValue != (int)clsUser.enPermissions.All))
            {
                chk.CheckedChanged -= Chk_CheckedChanged; // Temporarily detach event handler to prevent recursion
                chk.Checked = check;
                chk.CheckedChanged += Chk_CheckedChanged; // Reattach event handler
            }
        }

        // Validate user input before adding a new user
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Veuillez saisir le prénom.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Veuillez saisir le nom.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Veuillez saisir le numéro de téléphone.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("Veuillez saisir la ville.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Veuillez saisir le nom d'utilisateur.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsUsernameUnique(txtUsername.Text.Trim()))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Veuillez saisir le mot de passe.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Veuillez confirmer le mot de passe.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!IsConfirmPasswordMatching())
            {
                return false;
            }
            if (permissionsCheckBoxes.Count(chk => chk.Checked) == 0)
            {
                MessageBox.Show("Veuillez sélectionner au moins une autorisation.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Calculate the combined permissions value based on the selected checkboxes
        private int CalculateSelectedPermissions()
        {
            CheckBox? checkBoxAll = permissionsCheckBoxes.FirstOrDefault(chk => chk.Tag is int tag && tag == (int)clsUser.enPermissions.All);
            if (checkBoxAll != null && checkBoxAll.Checked)
            {
                return (int)clsUser.enPermissions.All;
            }
            else
            {
                return permissionsCheckBoxes
                    .Where(chk => chk.Checked)
                    .Sum(chk => chk.Tag is int value ? value : 0);
            }

        }

        // Check if the username is unique before adding a new user
        private bool IsUsernameUnique(string username)
        {
            if (clsUser.IsExists(username))
            {
                MessageBox.Show("Ce nom d'utilisateur existe déjà. Veuillez en choisir un autre.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Check if the password and confirm password fields match
        private bool IsConfirmPasswordMatching()
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Le mot de passe et sa confirmation ne correspondent pas. Veuillez vérifier qu'ils sont identiques.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Add a new user to the system after validating the input and calculating permissions
        private void AddUser()
        {
            try
            {
                if (!ValidateInput()) return;
                // Create a new user object and populate it with the input data
                clsUser newUser = new clsUser
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
                    City = txtCity.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    PasswordHash = clsPasswordHelper.HashPassword(txtPassword.Text.Trim()), // Hash the password before storing
                    Status = true, // Assuming new users are active by default
                    Permissions = CalculateSelectedPermissions(),
                    Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text
                };
                if (newUser != null && newUser.Save())
                {
                    MessageBox.Show("L'utilisateur a été ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnUserAddedSuccessfully?.Invoke(newUser.Id); // Invoke the event with the new user's ID
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de l'ajout de l'utilisateur :\n{ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the close button click event to invoke the OnButtonCloseClicked event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.OnButtonCloseClicked?.Invoke();
        }

        // Event handler for the save button click event to add a new user
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddUser();
        }
    }
}
