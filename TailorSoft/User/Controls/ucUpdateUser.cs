using TailorSoft_Business_Layer;

namespace TailorSoft.User.Controls
{
    public partial class ucUpdateUser : UserControl
    {
        /// <summary>
        /// Occurs when the close button is clicked.
        /// </summary>
        public event Action? OnButtonCloseClicked;

        /// <summary>
        /// Occurs when a user is updated successfully, provides the updated user id.
        /// </summary>
        public event Action<int?>? OnUserUpdatedSuccessfully;

        // Permission values used to map checkboxes to user permission flags
        private readonly int[] permissionValues = (int[])Enum.GetValues(typeof(clsUser.enPermissionsInArabic));

        // Dynamically created checkboxes for permissions
        private readonly List<CheckBox> permissionsCheckBoxes = new List<CheckBox>();

        // Current loaded user id and original username (used for uniqueness check)
        private int? _userId;
        private string? _originalUsername;

        public ucUpdateUser()
        {
            InitializeComponent();
            InitializeFlowLayoutPanelPermissions();
            LoadPermissions();
        }

        // Initialize FlowLayoutPanel behavior
        private void InitializeFlowLayoutPanelPermissions()
        {
            flpPermissions.AutoScroll = true;
            flpPermissions.FlowDirection = FlowDirection.TopDown;
            flpPermissions.WrapContents = false;
        }

        // Create permission checkboxes dynamically (same structure as ucAddUser)
        private void LoadPermissions()
        {
            flpPermissions.Controls.Clear();
            permissionsCheckBoxes.Clear();

            for (int i = 0; i < permissionValues.Length; i++)
            {
                var permission = (clsUser.enPermissions)permissionValues[i];
                CheckBox chk = new CheckBox
                {
                    Text = GetPermissionName(permission),
                    Tag = permissionValues[i],
                    AutoSize = false,
                    Width = Math.Max(100, flpPermissions.ClientSize.Width - 30),
                    Height = 25,
                    Margin = new Padding(3)
                };

                if (chk.Tag is int tagValue && tagValue == (int)clsUser.enPermissions.All)
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

        private  string GetPermissionName(clsUser.enPermissions permission)
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

        // Handler for the "All" checkbox: check/uncheck all other permissions
        private void ChkAll_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not CheckBox changedChk) return;
            if (changedChk.Tag is not int tagValue) return;

            var perm = (clsUser.enPermissions)tagValue;

            if (perm == clsUser.enPermissions.All)
            {
                CheckAllPermissions(changedChk.Checked);
            }
        }

        // Handler for individual permission checkboxes: maintain "All" checkbox state
        private void Chk_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not CheckBox changedChk) return;
            if (changedChk.Tag is not int tagValue) return;

            var perm = (clsUser.enPermissions)tagValue;

            if (perm != clsUser.enPermissions.All)
            {
                CheckBox? checkBoxAll = permissionsCheckBoxes.FirstOrDefault(chk => (int?)chk?.Tag == (int?)clsUser.enPermissions.All);

                bool anyUncheckedOther = permissionsCheckBoxes.Exists(chk => (int?)chk?.Tag != (int?)clsUser.enPermissions.All && chk?.Checked == false);

                if (checkBoxAll != null)
                {
                    checkBoxAll.CheckedChanged -= ChkAll_CheckedChanged;
                    checkBoxAll.Checked = !anyUncheckedOther;
                    checkBoxAll.CheckedChanged += ChkAll_CheckedChanged;
                }
            }
        }

        // Set or clear all checkboxes (except the "All" checkbox)
        private void CheckAllPermissions(bool check)
        {
            foreach (var chk in permissionsCheckBoxes.Where(chk => chk.Tag is int tagValue && tagValue != (int)clsUser.enPermissions.All))
            {
                chk.CheckedChanged -= Chk_CheckedChanged;
                chk.Checked = check;
                chk.CheckedChanged += Chk_CheckedChanged;
            }
        }

        // Public method to load user data into the control
        public void LoadUser(int userId)
        {
            _userId = userId;
            var user = clsUser.Find(userId);
            if (user == null)
            {
                MessageBox.Show("L'utilisateur que vous souhaitez modifier est introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Populate fields
            txtFirstName.Text = user.FirstName ?? string.Empty;
            txtLastName.Text = user.LastName ?? string.Empty;
            txtPhone.Text = user.Phone ?? string.Empty;
            txtEmail.Text = user.Email ?? string.Empty;
            txtCity.Text = user.City ?? string.Empty;
            txtAddress.Text = user.Address ?? string.Empty;
            txtUsername.Text = user.Username ?? string.Empty;
            chkStatus.Checked = user.Status ?? false;

            _originalUsername = user.Username;

            // Set permission checkboxes based on stored permissions.
            // If Permissions is null, treat it as no permissions (-1). If it's All, check all. Otherwise, check individual permissions.
            int userPerms = user.Permissions ?? -1;
            if (user.Permissions.HasValue && userPerms == (int)clsUser.enPermissions.All)
            {
                // Check the "All" checkbox and all others
                var chkAll = permissionsCheckBoxes.FirstOrDefault(chk => (int?)chk?.Tag == (int?)clsUser.enPermissions.All);
                if (chkAll != null)
                {
                    chkAll.CheckedChanged -= ChkAll_CheckedChanged;
                    chkAll.Checked = true;
                    chkAll.CheckedChanged += ChkAll_CheckedChanged;
                }

                foreach (var chk in permissionsCheckBoxes.Where(chk => (int?)chk?.Tag != (int?)clsUser.enPermissions.All))
                {
                    chk.CheckedChanged -= Chk_CheckedChanged;
                    chk.Checked = true;
                    chk.CheckedChanged += Chk_CheckedChanged;
                }
            }
            else
            {
                // Clear "All" and set individual permissions
                var chkAll = permissionsCheckBoxes.FirstOrDefault(chk => (int?)chk?.Tag == (int?)clsUser.enPermissions.All);
                if (chkAll != null)
                {
                    chkAll.CheckedChanged -= ChkAll_CheckedChanged;
                    chkAll.Checked = false;
                    chkAll.CheckedChanged += ChkAll_CheckedChanged;
                }

                foreach (var chk in permissionsCheckBoxes.Where(chk => (int?)chk?.Tag != (int?)clsUser.enPermissions.All))
                {
                    chk.CheckedChanged -= Chk_CheckedChanged;
                    if (chk.Tag is int tagValue)
                    {
                        chk.Checked = (user.Permissions.HasValue && (userPerms & tagValue) == tagValue);
                    }
                    else
                    {
                        chk.Checked = false;
                    }
                    chk.CheckedChanged += Chk_CheckedChanged;
                }
            }
        }

        // Validate input for update (no password fields in update form)
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

            if (!IsUsernameUniqueForUpdate(txtUsername.Text.Trim()))
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

        // Compute combined permissions value from checked checkboxes
        private int CalculateSelectedPermissions()
        {
            CheckBox? checkBoxAll = permissionsCheckBoxes.FirstOrDefault(chk => chk.Tag is int tag && tag == (int)clsUser.enPermissions.All);
            if (checkBoxAll != null && checkBoxAll.Checked)
            {
                return (int)clsUser.enPermissions.All;
            }

            return permissionsCheckBoxes
                .Where(chk => chk.Checked)
                .Sum(chk => chk.Tag is int value ? value : 0);
        }

        // Username uniqueness check for update: allow original username
        private bool IsUsernameUniqueForUpdate(string username)
        {
            if (string.Equals(username, _originalUsername, StringComparison.OrdinalIgnoreCase))
                return true;

            if (clsUser.IsExists(username))
            {
                MessageBox.Show("Ce nom d'utilisateur existe déjà. Veuillez en choisir un autre.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Update the user in the database
        private void UpdateUser()
        {
            try
            {
                if (!ValidateInput()) return;
                if (!_userId.HasValue)
                {
                    MessageBox.Show("Aucun utilisateur n'a été chargé pour modification.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = clsUser.Find(_userId.Value);
                if (user == null)
                {
                    MessageBox.Show("Utilisateur introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                user.FirstName = txtFirstName.Text.Trim();
                user.LastName = txtLastName.Text.Trim();
                user.Phone = txtPhone.Text.Trim();
                user.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                user.City = txtCity.Text.Trim();
                user.Username = txtUsername.Text.Trim();
                user.Status = chkStatus.Checked;
                user.Permissions = CalculateSelectedPermissions();
                user.Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();

                if (user.Save())
                {
                    MessageBox.Show("Les informations de l'utilisateur ont été mises à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnUserUpdatedSuccessfully?.Invoke(user.Id);
                }
                else
                {
                    MessageBox.Show("Échec de la mise à jour de l'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue lors de la mise à jour de l'utilisateur :\n{ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Close button handler
        private void btnClose_Click(object sender, EventArgs e)
        {
            OnButtonCloseClicked?.Invoke();
        }

        // Save button handler
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }
    }
}
