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

        // Permission names (Arabic) and their numeric values
        private readonly string[] permissionsNames = Enum.GetNames(typeof(clsUser.enPermissionsInArabic));
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

            for (int i = 0; i < permissionsNames.Length; i++)
            {
                CheckBox chk = new CheckBox
                {
                    Text = permissionsNames[i],
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
                MessageBox.Show("المستخدم الذي تحاول تعديله غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("يرجى إدخال الاسم الشخصي.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("يرجى إدخال الاسم العائلي.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("يرجى إدخال رقم الهاتف.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCity.Text))
            {
                MessageBox.Show("يرجى إدخال المدينة.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("يرجى إدخال اسم المستخدم.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsUsernameUniqueForUpdate(txtUsername.Text.Trim()))
            {
                return false;
            }

            if (permissionsCheckBoxes.Count(chk => chk.Checked) == 0)
            {
                MessageBox.Show("يرجى اختيار صلاحية واحدة على الأقل.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("اسم المستخدم هذا موجود بالفعل. يرجى اختيار اسم مستخدم آخر.", "خطأ في الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("لم يتم تحميل مستخدم للتعديل.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var user = clsUser.Find(_userId.Value);
                if (user == null)
                {
                    MessageBox.Show("المستخدم غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("تم تحديث بيانات المستخدم بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnUserUpdatedSuccessfully?.Invoke(user.Id);
                }
                else
                {
                    MessageBox.Show("فشل تحديث المستخدم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء تحديث المستخدم:\n {ex.Message}\n", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
