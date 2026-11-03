using System.Data;
using TailorSoft.Customer.Forms;
using TailorSoft_Business_Layer;

namespace TailorSoft.Customer.Controls
{
    public partial class ucCustomersList : UserControl
    {
        #region Constructors
        public ucCustomersList()
        {
            InitializeComponent();
            InitializeCustomDataGridView();
            LoadAndRefreshData();
        }
        #endregion

        #region Methods
        private void InitializeCustomDataGridView()
        {
            // General style
            dgvCustomersList.BackgroundColor = Color.White;
            dgvCustomersList.GridColor = Color.LightGray;
            dgvCustomersList.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Header style
            dgvCustomersList.EnableHeadersVisualStyles = false;
            dgvCustomersList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224); // light warm gray
            dgvCustomersList.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCustomersList.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dgvCustomersList.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvCustomersList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvCustomersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomersList.ColumnHeadersHeight = 35;

            // Row style
            dgvCustomersList.DefaultCellStyle.BackColor = Color.White;
            dgvCustomersList.DefaultCellStyle.ForeColor = Color.Black;
            dgvCustomersList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 165, 32); // goldenrod
            dgvCustomersList.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCustomersList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Alternating row style
            dgvCustomersList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 240); // light beige

            // Remove row headers if not needed
            dgvCustomersList.RowHeadersVisible = false;

            dgvCustomersList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomersList.RightToLeft = RightToLeft.No;
            dgvCustomersList.ColumnHeadersHeight = 44;
            dgvCustomersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCustomersList.AllowUserToAddRows = false;
            dgvCustomersList.AllowUserToDeleteRows = false;
            dgvCustomersList.AllowUserToResizeRows = false;
            dgvCustomersList.AllowUserToResizeColumns = true;
            dgvCustomersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomersList.MultiSelect = false;
            dgvCustomersList.ReadOnly = true;
            dgvCustomersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomersList.BorderStyle = BorderStyle.None;
            dgvCustomersList.RowTemplate.Height = 40;

            dgvCustomersList.Columns.AddRange(GetColumns());

            dgvCustomersList.CellPainting += CustomDataGridView_CellPainting;
            dgvCustomersList.CellClick += CustomDataGridView_CellClick;
            this.Controls.Add(dgvCustomersList);
        }
        private DataGridViewColumn[] GetColumns()
        {
            DataGridViewColumn[] Columns = new DataGridViewColumn[7];
            Columns[0] = new DataGridViewTextBoxColumn { Name = "clmnID", HeaderText = "Numéro" };
            Columns[1] = new DataGridViewTextBoxColumn { Name = "clmnName", HeaderText = "Nom" };
            Columns[2] = new DataGridViewTextBoxColumn { Name = "clmnPhone", HeaderText = "Téléphone" };
            Columns[3] = new DataGridViewTextBoxColumn { Name = "clmnEmail", HeaderText = "E-mail" };
            Columns[4] = new DataGridViewTextBoxColumn { Name = "clmnAddress", HeaderText = "Adresse" };
            Columns[5] = new DataGridViewTextBoxColumn
            {
                Name = "CreatedDate",
                HeaderText = "Date d'inscription",
                ReadOnly = true
            };
            Columns[6] = new DataGridViewTextBoxColumn
            {
                Name = "clmnActions",
                HeaderText = "Actions",
                FillWeight = 50f,
                ReadOnly = true
            };
            return Columns;
        }
        public void LoadAndRefreshData()
        {
            dgvCustomersList?.Rows.Clear();
            foreach (var customer in clsCustomer.GetAll())
            {
                dgvCustomersList?.Rows.Add(
                    customer?.Id.HasValue == true ? customer.Id.Value : "???",
                    customer?.Person?.FullName,
                    customer?.Person?.Phone,
                    customer?.Person?.Email,
                    customer?.Person?.Address,
                    customer?.CreatedDate.HasValue == true ? customer.CreatedDate.Value.ToString("yyyy-MM-dd") : string.Empty,
                    ""// Placeholder for actions column
                   );
            }
            if (dgvCustomersList != null)
            {
                dgvCustomersList.ClearSelection();
            }
        }
        private void LoadAndRefreshData(List<clsCustomer> customers)
        {
            dgvCustomersList?.Rows.Clear();
            foreach (var customer in customers)
            {
                dgvCustomersList?.Rows.Add(
                   customer?.Id.HasValue == true ? customer.Id.Value : "???",
                   customer?.Person?.FullName,
                   customer?.Person?.Phone,
                   customer?.Person?.Email,
                   customer?.Person?.Address,
                   customer?.CreatedDate.HasValue == true ? customer.CreatedDate.Value.ToString("yyyy-MM-dd") : string.Empty,
                   ""// Placeholder for actions column
                  );
            }
            if (dgvCustomersList != null)
            {
                dgvCustomersList.ClearSelection();
            }
        }
        #endregion

        #region Events
        private void ucCustomersList_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0; // Default to "Par téléphone"
            txtSearch.Focus();
        }
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            using (frmAddUpdateCustomer frm = new frmAddUpdateCustomer())
            {
                frm.OnCustomerSaved += OnCustomerSavedEvent;
                frm.ShowDialog();
            }
        }
        private void OnCustomerSavedEvent(clsCustomer? obj)
        {
            LoadAndRefreshData();
        }
        private void CustomDataGridView_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCustomersList?.Columns[e.ColumnIndex].Name != "clmnActions")
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
            if (dgvCustomersList == null || e.RowIndex < 0 || dgvCustomersList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            Rectangle cellRect = dgvCustomersList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            Point mouse = dgvCustomersList.PointToClient(Cursor.Position);

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
                if (int.TryParse(dgvCustomersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int customerId))
                {
                    clsCustomer? customer = clsCustomer.Find(customerId);
                    if (customer != null)
                    {
                        using (frmAddUpdateCustomer frm = new frmAddUpdateCustomer(customer))
                        {
                            frm.OnCustomerSaved += OnCustomerSavedEvent;
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le client n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la lecture du numéro client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (deleteRect.Contains(mouse))
            {
                if (dgvCustomersList.Rows.Count == 0 || e.RowIndex < 0)
                {
                    MessageBox.Show("Il n'y a pas de clients à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce client ?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (int.TryParse(dgvCustomersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int customerId))
                {
                    if (customerId >= 1)
                    {
                        try
                        {
                            if (clsCustomer.Delete(customerId))
                            {
                                dgvCustomersList.Rows.RemoveAt(e.RowIndex);
                                MessageBox.Show("Le client a été supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Échec de la suppression du client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Une erreur s'est produite lors de la suppression du client :\n\n\n {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le client n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la lecture du numéro client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFindBy.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez choisir une méthode de recherche", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (cbFindBy.SelectedIndex == 0) // Par téléphone
            {
                txtSearch.Text = string.Empty;
                txtSearch.Visible = true;
                txtSearch.Focus();
            }
            else if (cbFindBy.SelectedIndex == 1) // Par prénom
            {
                txtSearch.Text = string.Empty;
                txtSearch.Visible = true;
                txtSearch.Focus();
            }
            else if (cbFindBy.SelectedIndex == 2) // Par nom de famille
            {
                txtSearch.Text = string.Empty;
                txtSearch.Visible = true;
                txtSearch.Focus();
            }
            else
            {
                txtSearch.Visible = false;
                txtSearch.PlaceholderText = string.Empty;
            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            switch (cbFindBy.SelectedIndex)
            {
                case 0: // Par téléphone
                    LoadAndRefreshData(
                        clsCustomer.GetAll().Select(c => c).Where(c => c?.Person?.Phone != null && c.Person.Phone.Contains(txtSearch.Text.Trim())).ToList()
                        );
                    break;
                case 1: // Par prénom
                    LoadAndRefreshData(
                        clsCustomer.GetAll().Select(c => c).Where(c => c?.Person?.FirstName != null && c.Person.FirstName.Contains(txtSearch.Text.Trim())).ToList()
                        );
                    break;
                case 2: // Par nom de famille
                    LoadAndRefreshData(
                        clsCustomer.GetAll().Select(c => c).Where(c => c?.Person?.LastName != null && c.Person.LastName.Contains(txtSearch.Text.Trim())).ToList()
                        );
                    break;
            }
        }
        #endregion
    }
}
