
using System.Media;
using TailorSoft.Order.Classes;
using TailorSoft.Order.Forms;
using TailorSoft.Store.Classes;
using TailorSoft_Business_Layer;
using WinFormsControlsLibrary;
using static clsOrder;

namespace TailorSoft.Order.Controls
{
    public partial class ucOrdersList : UserControl
    {
        int _IconSize = 28; // Size of the icons in the actions column
        int _Padding = 40; // Padding for icons in the actions column
        int _IconSpacing = 10; // Spacing between icons in the actions column
        private byte? _statusBeforeEdit; // Store the status before editing to revert if needed
        private bool _isStatusUpdateInProgress;

        // French translations for enum values
        private Dictionary<clsOrder.enStatus, string> statusTranslations = new Dictionary<clsOrder.enStatus, string>
            {
                    { enStatus.Pending, "En attente" },
                    { enStatus.DeliveredAndNotPaid, "Livré et non payé" },
                    { enStatus.DeliveredAndPartiallyPaid, "Livré et part payé" },
                    { enStatus.DeliveredAndPaid, "Livré et payé" },
                    { enStatus.Cancelled, "Annulé" }
            };

        CustomDataGridView dgvOrdersList = new CustomDataGridView();
        public event Action<int>? OnOrdersCountChanged;
        public ucOrdersList()
        {
            InitializeComponent();
            InitializeCustomDataGridView();
        }

        #region Methods
        private void InitializeCustomDataGridView()
        {
            // General style
            dgvOrdersList.BackgroundColor = Color.White;
            dgvOrdersList.BorderStyle = BorderStyle.None;
            dgvOrdersList.GridColor = Color.LightGray;
            dgvOrdersList.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Header style
            dgvOrdersList.EnableHeadersVisualStyles = false;
            dgvOrdersList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvOrdersList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrdersList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvOrdersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrdersList.ColumnHeadersHeight = 60;

            // Row style
            dgvOrdersList.DefaultCellStyle.BackColor = Color.White;
            dgvOrdersList.DefaultCellStyle.ForeColor = Color.Black;
            dgvOrdersList.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgvOrdersList.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvOrdersList.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            dgvOrdersList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersList.RowTemplate.Height = 55;


            // Alternating row style
            dgvOrdersList.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 255); // light beige

            // Remove row headers if not needed
            dgvOrdersList.RowHeadersVisible = false;

            dgvOrdersList.Dock = DockStyle.Fill;
            dgvOrdersList.RightToLeft = RightToLeft.No;
            dgvOrdersList.AllowUserToAddRows = false;
            dgvOrdersList.AllowUserToDeleteRows = false;
            dgvOrdersList.AllowUserToResizeRows = false;
            dgvOrdersList.AllowUserToResizeColumns = false;
            dgvOrdersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdersList.MultiSelect = false;
            dgvOrdersList.ReadOnly = false;
            dgvOrdersList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdersList.BorderStyle = BorderStyle.None;
            dgvOrdersList.CellPainting += CustomDataGridView_CellPainting;
            dgvOrdersList.CellClick += CustomDataGridView_CellClick;
            dgvOrdersList.CellValueChanged += CustomDataGridView_CellValueChanged;
            dgvOrdersList.CurrentCellDirtyStateChanged += CustomDataGridView_CurrentCellDirtyStateChanged;
            dgvOrdersList.CellBeginEdit += CustomDataGridView_CellBeginEdit;
            dgvOrdersList.CellFormatting += CustomDataGridView_CellFormatting;

            // Add columns
            dgvOrdersList.Columns.AddRange(GetOrderColumns());
            this.Controls.Add(dgvOrdersList);
        }
        private DataGridViewColumn[] GetOrderColumns()
        {
            DataGridViewColumn[] columns = new DataGridViewColumn[12];

            columns[0] = new DataGridViewTextBoxColumn
            {
                Name = "clmnID",
                HeaderText = "N° de commande",
                DataPropertyName = "Id",
                ReadOnly = true
            };

            columns[1] = new DataGridViewTextBoxColumn
            {
                Name = "clmnCustomerName",
                HeaderText = "Nom du client",
                DataPropertyName = "CustomerName",
                ReadOnly = true
            };

            columns[2] = new DataGridViewTextBoxColumn
            {
                Name = "clmnOrderDate",
                HeaderText = "Date de la commande",
                DataPropertyName = "OrderDate",
                ReadOnly = true
            };

            columns[3] = new DataGridViewTextBoxColumn
            {
                Name = "clmnRequiredDate",
                HeaderText = "Date de livraison requise",
                DataPropertyName = "RequiredDate",
                ReadOnly = true
            };

            columns[4] = new DataGridViewTextBoxColumn
            {
                Name = "clmnDeliveryDate",
                HeaderText = "Date de livraison réelle",
                DataPropertyName = "DeliveryDate",
                ReadOnly = true
            };


            // ComboBox column for Status
            var statusColumn = new DataGridViewComboBoxColumn
            {
                Name = "clmnStatus",
                HeaderText = "Statut",
                DataPropertyName = "Status", // bound to TINYINT in DB
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox,
                FlatStyle = FlatStyle.Standard,
                ValueType = typeof(byte),
            };

            // Fill ComboBox with enum values
            foreach (var kvp in statusTranslations)
            {
                statusColumn.Items.Add(new { Value = (byte)kvp.Key, Text = kvp.Value });
            }

            statusColumn.DisplayMember = "Text";
            statusColumn.ValueMember = "Value";

            columns[5] = statusColumn;

            columns[6] = new DataGridViewTextBoxColumn
            {
                Name = "clmnTotalAmount",
                HeaderText = "Montant total",
                DataPropertyName = "TotalAmount",
                ReadOnly = true
            };

            columns[7] = new DataGridViewTextBoxColumn
            {
                Name = "clmnInitialAmount",
                HeaderText = "Montant payé",
                DataPropertyName = "InitialAmount",
                ReadOnly = true
            };

            columns[8] = new DataGridViewTextBoxColumn
            {
                Name = "clmnRemainingAmount",
                HeaderText = "Montant restant",
                DataPropertyName = "RemainingAmount",
                ReadOnly = true
            };

            columns[9] = new DataGridViewTextBoxColumn
            {
                Name = "clmnPaymentDate",
                HeaderText = "Date de paiement",
                DataPropertyName = "PaymentDate",
                ReadOnly = true
            };

            columns[10] = new DataGridViewTextBoxColumn
            {
                Name = "clmnNotes",
                HeaderText = "Remarques",
                DataPropertyName = "Notes",
                ReadOnly = true
            };
            columns[11] = new DataGridViewTextBoxColumn
            {
                Name = "clmnActions",
                HeaderText = "Actions",
                DataPropertyName = "Actions",
                FillWeight = 180f,
                ReadOnly = true
            };

            return columns;
        }

        private void RestoreStatusCell(int rowIndex)
        {
            if (_statusBeforeEdit.HasValue &&
                rowIndex >= 0 &&
                rowIndex < dgvOrdersList.Rows.Count)
            {
                dgvOrdersList.Rows[rowIndex].Cells["clmnStatus"].Value =
                    _statusBeforeEdit.Value;
            }
        }
        public void SetOrders(List<clsOrder> orders)
        {
            dgvOrdersList.Rows.Clear();
            foreach (var order in orders)
            {
                dgvOrdersList.Rows.Add(
                    order.Id,
                    order?.Customer?.Person?.FullName,
                    order?.OrderDate.ToString("dd-MM-yyyy"),
                    order?.RequiredDate.ToString("dd-MM-yyyy"),
                    order?.DeliveryDate?.ToString("dd-MM-yyyy") ?? "",
                    order?.Status,
                    (order?.TotalAmount % 1 == 0 ? order?.TotalAmount.ToString("F0") : order?.TotalAmount.ToString("F2")) + "DH",
                    (order?.InitialAmount % 1 == 0 ? order?.InitialAmount.ToString("F0") : order?.InitialAmount.ToString("F2")) + "DH",
                    (order?.RemainingAmount % 1 == 0 ? order?.RemainingAmount.ToString("F0") : order?.RemainingAmount.ToString("F2")) + "DH",
                    order?.PaymentDate?.ToString("dd-MM-yyyy") ?? "",
                    order?.Notes ?? "",
                    ""); // Actions column will be handled in CellPainting
            }
            this.OnOrdersCountChanged?.Invoke(dgvOrdersList.Rows.Count);

        }
        public void SetOrder(clsOrder? order)
        {
            dgvOrdersList.Rows.Clear();
            if (order != null)
            {
                dgvOrdersList.Rows.Add(
                    order.Id,
                    order?.Customer?.Person?.FullName,
                    order?.OrderDate.ToString("dd-MM-yyyy"),
                    order?.RequiredDate.ToString("dd-MM-yyyy"),
                    order?.DeliveryDate?.ToString("dd-MM-yyyy") ?? "",
                    order?.Status,
                    (order?.TotalAmount % 1 == 0 ? order?.TotalAmount.ToString("F0") : order?.TotalAmount.ToString("F2")) + "DH",
                    (order?.InitialAmount % 1 == 0 ? order?.InitialAmount.ToString("F0") : order?.InitialAmount.ToString("F2")) + "DH",
                    (order?.RemainingAmount % 1 == 0 ? order?.RemainingAmount.ToString("F0") : order?.RemainingAmount.ToString("F2")) + "DH",
                    order?.PaymentDate?.ToString("dd-MM-yyyy") ?? "",
                    order?.Notes ?? "",
                    ""); // Actions column will be handled in CellPainting
            }
            this.OnOrdersCountChanged?.Invoke(dgvOrdersList.Rows.Count);
        }
        public void ClearOrdres()
        {
            dgvOrdersList.Rows.Clear();
        }



        #endregion

        #region Events
        private void CustomDataGridView_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvOrdersList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            e.PaintBackground(e.ClipBounds, true);
            e.Handled = true;

            int x1 = e.CellBounds.Left + _Padding;
            int x2 = x1 + _IconSize + _IconSpacing;
            int x3 = x2 + _IconSize + _IconSpacing;
            int x4 = x3 + _IconSize + _IconSpacing;
            int y = e.CellBounds.Top + (e.CellBounds.Height - _IconSize) / 2;

            Rectangle editIconRect = new Rectangle(x3, y, _IconSize, _IconSize);
            Rectangle deleteIconRect = new Rectangle(x4, y, _IconSize, _IconSize);
            Rectangle cashPaymentIcon = new Rectangle(x1, y, _IconSize, _IconSize);
            Rectangle printIcon = new Rectangle(x2, y, _IconSize, _IconSize);

            e?.Graphics?.DrawImage(Properties.Resources.edit_icon_blue_32, editIconRect);
            e?.Graphics?.DrawImage(Properties.Resources.delete_icon_red_32, deleteIconRect);
            e?.Graphics?.DrawImage(Properties.Resources.cash_payment_icon_32, cashPaymentIcon);
            e?.Graphics?.DrawImage(Properties.Resources.printer_icon_32, printIcon);
        }
        private async void CustomDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdersList == null || e.RowIndex < 0 || dgvOrdersList?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            Rectangle cellRect = dgvOrdersList.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            Point mouse = dgvOrdersList.PointToClient(Cursor.Position);


            int x1 = cellRect.Left + _Padding;
            int x2 = x1 + _IconSize + _IconSpacing;
            int x3 = x2 + _IconSize + _IconSpacing;
            int x4 = x3 + _IconSize + _IconSpacing; // For print icon
            int y = cellRect.Top + (cellRect.Height - _IconSize) / 2;

            Rectangle editRect = new Rectangle(x3, y, _IconSize, _IconSize);
            Rectangle deleteRect = new Rectangle(x4, y, _IconSize, _IconSize);
            Rectangle cashPaymentIcon = new Rectangle(x1, y, _IconSize, _IconSize);
            Rectangle printIcon = new Rectangle(x2, y, _IconSize, _IconSize);

            if (editRect.Contains(mouse))
            {
                if (int.TryParse(dgvOrdersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    clsOrder? order = clsOrder.Find(orderID);
                    if (order == null)
                    {
                        MessageBox.Show("La commande n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (order.Status == (byte)clsOrder.enStatus.Cancelled) 
                    {
                        MessageBox.Show("⚠ Impossible de modifier une commande annulée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    using (frmUpdateOrder frm = new frmUpdateOrder(order))
                    {
                        frm.OnOrderSavedSuccessfully += (updatedOrder) =>
                        {
                            if (updatedOrder != null)
                            {
                                // Update the DataGridView row with the updated order details
                                SetOrders(clsOrder.GetAll());

                            }
                        };
                        frm.ShowDialog();
                        SetOrders(clsOrder.GetAll());

                    }

                }
                else
                {
                    MessageBox.Show("Erreur lors de la lecture du numéro de commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (deleteRect.Contains(mouse))
            {
                if (dgvOrdersList.Rows.Count == 0 || e.RowIndex < 0)
                {
                    MessageBox.Show("Aucune commande à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette commande?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (int.TryParse(dgvOrdersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    try
                    {
                        var order = await clsOrder.FindAsync(orderID);
                        if(order!=null && order.Status!=(byte)clsOrder.enStatus.Cancelled)
                        {
                             MessageBox.Show("⚠ Impossible de supprimer une commande n'est annulée\aAnnulez d'abord la commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                             return;
                        }
                        if (clsOrder.Delete(orderID))
                        {
                            SetOrders(clsOrder.GetAll());
                            MessageBox.Show("La commande a été supprimée avec succès", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Échec de la suppression de la commande", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Erreur lors de la lecture du numéro de commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cashPaymentIcon.Contains(mouse))
            {
                if (int.TryParse(dgvOrdersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    // Open cash payment form or perform cash payment action
                    clsOrder? order = clsOrder.Find(orderID);
                    if (order == null)
                    {
                        MessageBox.Show("La commande n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (order.Status == (byte)clsOrder.enStatus.Cancelled)
                    {
                        MessageBox.Show("⚠ Impossible d'enregistrer le paiement d'une commande annulée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    using (frmRecordPayment frm = new frmRecordPayment(orderID))
                    {
                        frm.ShowDialog();
                        // Optionally refresh the order list after payment
                        SetOrders(clsOrder.GetAll());
                    }
                }
                else
                {
                    MessageBox.Show("Erreur lors de la lecture du numéro de commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dgvOrdersList.Columns[e.ColumnIndex].Name == "clmnActions" && printIcon.Contains(mouse))
            {
                if (int.TryParse(dgvOrdersList.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    // Open print form or perform print action
                    clsOrder? order = clsOrder.Find(orderID);
                    if (order == null)
                    {
                        MessageBox.Show("La commande n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (order.Status == (byte)clsOrder.enStatus.Cancelled)
                    {
                        MessageBox.Show("⚠ Impossible d'imprimer une commande annulée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    clsOrderHtmlPrinter.Preview(order);
                }
                else
                {
                    MessageBox.Show("Erreur lors de la lecture du numéro de commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CustomDataGridView_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            // Commit edit immediately when a ComboBox cell is changed
            if (dgvOrdersList.IsCurrentCellDirty && dgvOrdersList.CurrentCell is DataGridViewComboBoxCell)
                dgvOrdersList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private async void CustomDataGridView_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (_isStatusUpdateInProgress || e.RowIndex < 0 || e.ColumnIndex < 0 || dgvOrdersList.Columns[e.ColumnIndex].Name != "clmnStatus")
                return;

            _isStatusUpdateInProgress = true;
            bool gridWasEnabled = dgvOrdersList.Enabled;
            byte? previousStatus = null;

            try
            {
                dgvOrdersList.Enabled = false;

                var row = dgvOrdersList.Rows[e.RowIndex];
                var statusCell = row.Cells[e.ColumnIndex];

                if (!int.TryParse(row.Cells["clmnID"].Value?.ToString(), out int orderId) ||
                    !byte.TryParse(statusCell.Value?.ToString(), out byte statusByte))
                {
                    RestoreStatusCell(e.RowIndex);
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("⚠ Erreur lors de la lecture du numéro de commande ou du statut",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!statusTranslations.TryGetValue((enStatus)statusByte, out string? statusText))
                {
                    RestoreStatusCell(e.RowIndex);
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("⚠ Le statut sélectionné est invalide",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clsOrder? order = await clsOrder.FindAsync(orderId);

                if (order is null)
                {
                    RestoreStatusCell(e.RowIndex);
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("⚠ La commande n'existe pas ou est invalide",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (statusByte == order.Status)
                    return;

                previousStatus = order.Status;

                if (statusByte == (byte)clsOrder.enStatus.Cancelled &&
                    MessageBox.Show("⚠ Êtes-vous sûr de vouloir annuler cette commande?",
                        "Confirmer l'annulation", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    statusCell.Value = previousStatus.Value;
                    return;
                }

                if (order.Status == (byte)clsOrder.enStatus.Cancelled &&
                    statusByte != (byte)clsOrder.enStatus.Cancelled)
                {
                    statusCell.Value = previousStatus.Value;
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("⚠ Impossible de changer le statut d'une commande annulée",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                order.Status = statusByte;
                if(statusByte == (byte)clsOrder.enStatus.DeliveredAndNotPaid ||
                    statusByte == (byte)clsOrder.enStatus.DeliveredAndPartiallyPaid ||
                    statusByte == (byte)clsOrder.enStatus.DeliveredAndPaid)
                {
                    order.DeliveryDate = DateTime.Now;
                }
                if(statusByte == (byte)clsOrder.enStatus.Cancelled)
                {
                    order.Items?.ForEach(item => clsOrderItem.Delete(item.Id));
                    order.InitialAmount = 0;
                    order.Notes += $"\n⚠ La commande a été annulée le {DateTime.Now:dd-MM-yyyy HH:mm:ss}";
                }
                bool saved = await order.SaveAsync();

                if (saved)
                {
                    SystemSounds.Asterisk.Play();
                    MessageBox.Show(
                        $"✅ Le statut de la commande n°{orderId} a été mis à jour vers {statusText}",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    statusCell.Value = previousStatus.Value;
                    SystemSounds.Exclamation.Play();
                    MessageBox.Show("⚠ Une erreur s'est produite lors de la mise à jour du statut",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (previousStatus.HasValue)
                    dgvOrdersList.Rows[e.RowIndex].Cells["clmnStatus"].Value = previousStatus.Value;
                else
                    RestoreStatusCell(e.RowIndex);

                SystemSounds.Exclamation.Play();
                MessageBox.Show($"⚠ Erreur lors de la mise à jour: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dgvOrdersList.Enabled = gridWasEnabled;
                _isStatusUpdateInProgress = false;
            }
        }
        private void CustomDataGridView_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvOrdersList.Columns[e.ColumnIndex].Name == "clmnStatus" &&
                byte.TryParse(
                    dgvOrdersList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(),
                    out byte oldStatus))
            {
                if(oldStatus == (byte)clsOrder.enStatus.Cancelled)
                {
                    SystemSounds.Exclamation.Play(); // error beep
                    MessageBox.Show("⚠ Impossible de changer le statut d'une commande annulée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // Cancel the edit
                }
                else
                {
                    _statusBeforeEdit = oldStatus;
                }
            }
        }
        private void CustomDataGridView_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                dgvOrdersList.Columns[e.ColumnIndex].Name != "clmnStatus")
            {
                return;
            }

            Color? color = (clsOrder.enStatus)statusTranslations.FirstOrDefault(kvp => kvp.Value == e.Value?.ToString()).Key switch
            {
                clsOrder.enStatus.Pending => Color.FromArgb(0, 0, 255),
                clsOrder.enStatus.DeliveredAndNotPaid => Color.FromArgb(255, 0, 0),
                clsOrder.enStatus.DeliveredAndPartiallyPaid => Color.FromArgb(255, 255, 0),
                clsOrder.enStatus.DeliveredAndPaid => Color.FromArgb(0, 255, 0),
                clsOrder.enStatus.Cancelled => Color.FromArgb(128, 128, 128),
                _ => null
            };

            if (color.HasValue)
            {
                e.CellStyle.BackColor = color.Value;
                e.CellStyle.SelectionBackColor = color.Value;
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.SelectionForeColor = Color.Black;
            }
        }
        private void ucOrdersList_SizeChanged(object sender, EventArgs e)
        {
            // Minimum width to ensure proper display

            // Adjust padding based on the width of the control
            if (dgvOrdersList != null)
            {
                _Padding = ((this.Width) - 1859 + 40) < 0 ? 0 : ((this.Width) - 1859 + 40); // Adjust padding based on control width
            }
        }
        #endregion
    }
}
