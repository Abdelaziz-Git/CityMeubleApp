using TailorSoft.OrderItem.Forms;
using TailorSoft_Business_Layer;

namespace TailorSoft.OrderItem.Controls
{
    public partial class ucOrderItemList : UserControl
    {
        private int _OrderID = -1;
        public event Action<int>? OnItemsChanged;
        public ucOrderItemList()
        {
            InitializeComponent();
            InitializeCustomDataGridView();
        }
        #region Public Methods
        public void SetItems(int orderID)
        {
            dgvOrderItemsList.Rows.Clear();
            if (orderID <= 0)
            {
                MessageBox.Show($"Le numéro de commande est invalide {orderID}");
            }
            _OrderID = orderID;
            foreach (var item in clsOrderItem.GetItems(_OrderID))
            {
                dgvOrderItemsList.Rows.Add(
                    item.Id,
                    item.ProductID,
                    item.ProductName,
                    item.Quantity % 1 == 0 ? item.Quantity.ToString("0") : item.Quantity.ToString("0.0"),
                    item.UnitPrice % 1 == 0 ? item.UnitPrice.ToString("0") + " MAD" : item.UnitPrice.ToString("0.0") + " MAD",
                    item.TotalPrice % 1 == 0 ? item.TotalPrice.ToString("0") + " MAD" : item.TotalPrice.ToString("0.0") + " MAD",
                    item.Notes
                );
            }
        }
        #endregion
        #region Private Methods
        private void InitializeCustomDataGridView()
        {
            // General style
            dgvOrderItemsList.BackgroundColor = Color.White;
            dgvOrderItemsList.BorderStyle = BorderStyle.None;
            dgvOrderItemsList.GridColor = Color.LightGray;
            dgvOrderItemsList.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Header style
            dgvOrderItemsList.EnableHeadersVisualStyles = false;
            dgvOrderItemsList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvOrderItemsList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrderItemsList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvOrderItemsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Row style
            dgvOrderItemsList.DefaultCellStyle.BackColor = Color.White;
            dgvOrderItemsList.DefaultCellStyle.ForeColor = Color.Black;
            dgvOrderItemsList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgvOrderItemsList.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvOrderItemsList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Alternating row style
            dgvOrderItemsList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 255);

            dgvOrderItemsList.RowHeadersVisible = false;
            // Default
            dgvOrderItemsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrderItemsList.RightToLeft = RightToLeft.No;
            dgvOrderItemsList.ColumnHeadersHeight = 50;
            dgvOrderItemsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrderItemsList.Columns.AddRange(GetColumns());
            dgvOrderItemsList.AllowUserToAddRows = false;
            dgvOrderItemsList.AllowUserToDeleteRows = false;
            dgvOrderItemsList.AllowUserToResizeRows = false;
            dgvOrderItemsList.AllowUserToResizeColumns = true;
            dgvOrderItemsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItemsList.MultiSelect = false;
            dgvOrderItemsList.ReadOnly = true;
            dgvOrderItemsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderItemsList.BorderStyle = BorderStyle.None;
            dgvOrderItemsList.RowTemplate.Height = 30;
            dgvOrderItemsList.CellPainting += CustomDataGridView_CellPainting;
            dgvOrderItemsList.CellClick += CustomDataGridView_CellClick;
            this.Controls.Add(dgvOrderItemsList);
        }
        private DataGridViewColumn[] GetColumns()
        {
            DataGridViewColumn[] Columns = new DataGridViewColumn[8];
            Columns[0] = new DataGridViewTextBoxColumn { Name = "clmnID", HeaderText = "Numéro d'article" };
            Columns[1] = new DataGridViewTextBoxColumn { Name = "clmnProductID", HeaderText = "Numéro du produit" };
            Columns[2] = new DataGridViewTextBoxColumn { Name = "clmnProductName", HeaderText = "Nom du produit" };
            Columns[3] = new DataGridViewTextBoxColumn { Name = "clmnQuantity", HeaderText = "Quantité" };
            Columns[4] = new DataGridViewTextBoxColumn { Name = "clmnUnitPrice", HeaderText = "Prix unitaire" };
            Columns[5] = new DataGridViewTextBoxColumn { Name = "clmnTotalPrice", HeaderText = "Total" };
            Columns[6] = new DataGridViewTextBoxColumn { Name = "clmnNotes", HeaderText = "Notes" };
            Columns[7] = new DataGridViewTextBoxColumn
            {
                Name = "clmnActions",
                HeaderText = "Actions",
            };
            return Columns;
        }
        private void CustomDataGridView_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvOrderItemsList?.Columns[e.ColumnIndex].Name != "clmnActions")
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

            e?.Graphics?.DrawImage(Properties.Resources.edit_icon_blue_32, editIconRect);
            e?.Graphics?.DrawImage(Properties.Resources.delete_icon_red_32, deleteIconRect);
        }
        private void CustomDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrderItemsList == null || e.RowIndex < 0 || dgvOrderItemsList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            Rectangle cellRect = dgvOrderItemsList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            Point mouse = dgvOrderItemsList.PointToClient(Cursor.Position);

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
                if (int.TryParse(dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnID"].Value.ToString(), out int itemID))
                {
                    clsOrderItem? item = clsOrderItem.Find(itemID);
                    if (item != null)
                    {
                        using (frmAddUpdateItem frmItem = new frmAddUpdateItem(item))
                        {
                            frmItem.OnItemAddedOrUpdatedSuccessfully += (UpdatedItem) =>
                            {
                                this.OnItemsChanged?.Invoke(this._OrderID);
                                if (UpdatedItem != null)
                                {
                                    // Update the DataGridView row with the updated item details
                                    dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnProductID"].Value = UpdatedItem.ProductID;
                                    dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnProductName"].Value = UpdatedItem.ProductName;
                                    dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnQuantity"].Value = UpdatedItem.Quantity;
                                    dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnUnitPrice"].Value = UpdatedItem.UnitPrice;
                                    dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnTotalPrice"].Value = UpdatedItem.TotalPrice;
                                    dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnNotes"].Value = UpdatedItem.Notes;
                                }
                            };
                            frmItem.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("L'article n'existe pas.");
                    }
                }
                else
                {
                    MessageBox.Show("رقم العنصر غير صحيح.");
                }
            }
            else if (deleteRect.Contains(mouse))
            {
                if (int.TryParse(dgvOrderItemsList.Rows[e.RowIndex].Cells["clmnID"].Value.ToString(), out int itemID))
                {
                    if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer l'article numéro {itemID}?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    if (clsOrderItem.Delete(itemID))
                    {
                        // Remove the row from the DataGridView
                        dgvOrderItemsList.Rows.RemoveAt(e.RowIndex);
                        this.OnItemsChanged?.Invoke(this._OrderID);
                        MessageBox.Show("L'article a été supprimé avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("Échec de la suppression de l'article.");
                    }
                }
                else
                {
                    MessageBox.Show("Le numéro d'article est invalide.");
                }
            }
        }
        #endregion

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (_OrderID <= 0)
            {
                MessageBox.Show("Veuillez sélectionner une commande avant d'ajouter un article.");
                return;
            }
            using (frmAddUpdateItem frmItem = new frmAddUpdateItem(_OrderID))
            {
                frmItem.OnItemAddedOrUpdatedSuccessfully += (NewItem) =>
                {
                    if (NewItem != null)
                    {
                        // Refresh the DataGridView with the new item
                        SetItems(_OrderID);
                    }
                    this.OnItemsChanged?.Invoke(this._OrderID);
                };
                frmItem.ShowDialog();
            }
        }

        private void ucOrderItemList_Load(object sender, EventArgs e)
        {

        }
    }
}
