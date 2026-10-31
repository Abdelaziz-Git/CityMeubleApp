using System.Data;
using TailorSoft.User.Forms;
using TailorSoft_Business_Layer;

namespace TailorSoft.User.Controls
{
    public partial class ucUsersList : UserControl
    {
        #region Constructors
        public ucUsersList()
        {
            InitializeComponent();
            InitializeCustomDataGridView();
            this.Load += UcUsersList_Load;
        }
        #endregion

        #region Methods
        private void InitializeCustomDataGridView()
        {
            // General style
            dgvUsersList.BackgroundColor = Color.White;
            dgvUsersList.GridColor = Color.LightGray;
            dgvUsersList.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Header style
            dgvUsersList.EnableHeadersVisualStyles = false;
            dgvUsersList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224);
            dgvUsersList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUsersList.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dgvUsersList.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvUsersList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsersList.ColumnHeadersHeight = 35;

            // Row style
            dgvUsersList.DefaultCellStyle.BackColor = Color.White;
            dgvUsersList.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsersList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 165, 32);
            dgvUsersList.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsersList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Alternating row style
            dgvUsersList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 240);

            // Grid configuration
            dgvUsersList.RowHeadersVisible = false;
            dgvUsersList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsersList.RightToLeft = RightToLeft.Yes;
            dgvUsersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsersList.AllowUserToAddRows = false;
            dgvUsersList.AllowUserToDeleteRows = false;
            dgvUsersList.AllowUserToResizeRows = false;
            dgvUsersList.AllowUserToResizeColumns = true;
            dgvUsersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsersList.MultiSelect = false;
            dgvUsersList.ReadOnly = true;
            dgvUsersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsersList.BorderStyle = BorderStyle.None;
            dgvUsersList.RowTemplate.Height = 40;

            dgvUsersList.Columns.AddRange(GetColumns());

            dgvUsersList.CellPainting += CustomDataGridView_CellPainting;
            dgvUsersList.CellClick += CustomDataGridView_CellClick;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            cbFindBy.SelectedIndexChanged += CbFindBy_SelectedIndexChanged;
            btnAddNewUser.Click += BtnAddNewUser_Click;
        }

        private DataGridViewColumn[] GetColumns()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[9];
            columns[0] = new DataGridViewTextBoxColumn { Name = "clmnID", HeaderText = "الرقم" };
            columns[1] = new DataGridViewTextBoxColumn { Name = "clmnFirstName", HeaderText = "الاسم الشخصي" };
            columns[2] = new DataGridViewTextBoxColumn { Name = "clmnLastName", HeaderText = "الاسم العائلي" };
            columns[3] = new DataGridViewTextBoxColumn { Name = "clmnPhone", HeaderText = "الهاتف" };
            columns[4] = new DataGridViewTextBoxColumn { Name = "clmnEmail", HeaderText = "البريد الإلكتروني" };
            columns[5] = new DataGridViewTextBoxColumn { Name = "clmnCity", HeaderText = "المدينة" };
            columns[6] = new DataGridViewTextBoxColumn { Name = "clmnUsername", HeaderText = "اسم المستخدم" };
            columns[7] = new DataGridViewTextBoxColumn
            {
                Name = "clmnStatus",
                HeaderText = "الحالة",
                ReadOnly = true
            };
            columns[8] = new DataGridViewTextBoxColumn
            {
                Name = "clmnActions",
                HeaderText = "الإجراءات",
                FillWeight = 50f,
                ReadOnly = true
            };
            return columns;
        }

        public void LoadAndRefreshData()
        {
            dgvUsersList?.Rows.Clear();
            List<clsUser> users = clsUser.GetAllUsers();

            foreach (var user in users)
            {
                string statusText = user.Status.HasValue ? (user.Status.Value ? "نشط" : "غير نشط") : "---";

                dgvUsersList?.Rows.Add(
                    user?.Id.HasValue == true ? user.Id.Value : "???",
                    user?.FirstName,
                    user?.LastName,
                    user?.Phone,
                    user?.Email,
                    user?.City,
                    user?.Username,
                    statusText,
                    "" // Placeholder for actions column
                );
            }
            if (dgvUsersList != null)
            {
                dgvUsersList.ClearSelection();
            }
        }

        private void LoadAndRefreshData(List<clsUser> users)
        {
            dgvUsersList?.Rows.Clear();

            foreach (var user in users)
            {
                string statusText = user.Status.HasValue ? (user.Status.Value ? "نشط" : "غير نشط") : "---";

                dgvUsersList?.Rows.Add(
                    user?.Id.HasValue == true ? user.Id.Value : "???",
                    user?.FirstName,
                    user?.LastName,
                    user?.Phone,
                    user?.Email,
                    user?.City,
                    user?.Username,
                    statusText,
                    "" // Placeholder for actions column
                );
            }
            if (dgvUsersList != null)
            {
                dgvUsersList.ClearSelection();
            }
        }
        #endregion

        #region Events
        private void UcUsersList_Load(object? sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0; // Default to "By Phone"
            LoadAndRefreshData();
            txtSearch.Focus();
        }

        private void BtnAddNewUser_Click(object? sender, EventArgs e)
        {
            using (var frm = new frmAddNewUser())
            {
                frm.OnUserAddedSuccessfully += OnUserSavedEvent;
                frm.ShowDialog();
            }
        }

        private void OnUserSavedEvent()
        {
            LoadAndRefreshData();
        }

        private void CustomDataGridView_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvUsersList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            e.PaintBackground(e.ClipBounds, true);
            e.Handled = true;

            // Icon size & position
            int iconSize = 26;
            int padding = 40;
            int spacing = 10;

            int x1 = e.CellBounds.Left + padding;
            int x2 = x1 + iconSize + spacing;
            int y = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

            Rectangle editIconRect = new Rectangle(x1, y, iconSize, iconSize);
            Rectangle deleteIconRect = new Rectangle(x2, y, iconSize, iconSize);

            e?.Graphics?.DrawImage(Properties.Resources.edit_icon_32, editIconRect);
            e?.Graphics?.DrawImage(Properties.Resources.Delete_icon_32, deleteIconRect);
        }

        private void CustomDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsersList == null || e.RowIndex < 0 || dgvUsersList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            Rectangle cellRect = dgvUsersList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            Point mouse = dgvUsersList.PointToClient(Cursor.Position);

            int iconSize = 26;
            int padding = 40;
            int spacing = 10;

            int x1 = cellRect.Left + padding;
            int x2 = x1 + iconSize + spacing;
            int y = cellRect.Top + (cellRect.Height - iconSize) / 2;

            Rectangle editRect = new Rectangle(x1, y, iconSize, iconSize);
            Rectangle deleteRect = new Rectangle(x2, y, iconSize, iconSize);

            if (editRect.Contains(mouse))
            {
                if (int.TryParse(dgvUsersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int userId))
                {
                    clsUser? user = clsUser.Find(userId);
                    if (user != null && user.Id is int UserID)
                    {
                        using (var frm = new frmUpdateUser(UserID))
                        {
                            frm.OnUserUpdatedSuccessfully += OnUserSavedEvent;
                            frm.ShowDialog();
                        }
                        if(userId==1&&user.Id==1)
                        {
                            user = clsUser.Find(userId);
                            if (user == null) return;
                            user.Status = true;
                            user.Permissions = (int)clsUser.enPermissions.All;
                            if(user.Save())
                            {
                                OnUserSavedEvent();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("المستخدم غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("خطأ في قراءة رقم المستخدم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (deleteRect.Contains(mouse))
            {
                if (dgvUsersList.Rows.Count == 0 || e.RowIndex < 0)
                {
                    MessageBox.Show("لا يوجد مستخدمين لحذفهم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("هل أنت متأكد من حذف هذا المستخدم؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                if (int.TryParse(dgvUsersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int userId))
                {
                    if (userId >= 1)
                    {
                        try
                        {
                            if(userId == 1)
                            {
                                MessageBox.Show("لا يمكن حذف المستخدم الرئيسي", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            if (clsUser.Delete(userId))
                            {
                                dgvUsersList.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("تم حذف المستخدم بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("فشل في حذف المستخدم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"حدث خطأ أثناء حذف المستخدم: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("المستخدم غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("خطأ في قراءة رقم المستخدم.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFindBy.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى اختيار طريقة البحث", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtSearch.Text = string.Empty;
            txtSearch.Visible = true;
            txtSearch.Focus();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadAndRefreshData();
                return;
            }

            switch (cbFindBy.SelectedIndex)
            {
                case 0: // By Phone
                    LoadAndRefreshData(
                        clsUser.GetAllUsers().Where(u => u?.Phone != null && u.Phone.Contains(searchText)).ToList()
                    );
                    break;
                case 1: // By First Name
                    LoadAndRefreshData(
                        clsUser.GetAllUsers().Where(u => u?.FirstName != null && u.FirstName.Contains(searchText)).ToList()
                    );
                    break;
                case 2: // By Last Name
                    LoadAndRefreshData(
                        clsUser.GetAllUsers().Where(u => u?.LastName != null && u.LastName.Contains(searchText)).ToList()
                    );
                    break;
            }
        }
        #endregion
    }
}
