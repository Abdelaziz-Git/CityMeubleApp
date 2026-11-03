
using System.Media;
using TailorSoft.Order.Classes;
using TailorSoft.Order.Forms;
using TailorSoft.Store.Classes;
using WinFormsControlsLibrary;
using static clsOrder;

namespace TailorSoft.Order.Controls
{
    public partial class ucOrdersList : UserControl
    {
        int _IconSize = 28; // Size of the icons in the actions column
        int _Padding = 40; // Padding for icons in the actions column
        int _IconSpacing = 10; // Spacing between icons in the actions column

        // French translations for enum values
        Dictionary<clsOrder.enStatus, string> statusTranslations = new Dictionary<clsOrder.enStatus, string>
            {
                    { enStatus.Pending, "En attente" },
                    { enStatus.Measuring, "Mesure" },
                    { enStatus.InProgress, "En cours" },
                    { enStatus.ReadyforDelivery, "Prêt pour la livraison" },
                    { enStatus.Delivered, "Livré" },
                    { enStatus.DeliveredAndPaid, "Livré et payé" },
                    { enStatus.Cancelled, "Annulé" }
            };

        CustomDataGridView dgvOrdersLis = new CustomDataGridView();
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
            dgvOrdersLis.BackgroundColor = Color.White;
            dgvOrdersLis.BorderStyle = BorderStyle.None;
            dgvOrdersLis.GridColor = Color.LightGray;
            dgvOrdersLis.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Header style
            dgvOrdersLis.EnableHeadersVisualStyles = false;
            dgvOrdersLis.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 102, 204);
            dgvOrdersLis.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrdersLis.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvOrdersLis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOrdersLis.ColumnHeadersHeight = 60;

            // Row style
            dgvOrdersLis.DefaultCellStyle.BackColor = Color.White;
            dgvOrdersLis.DefaultCellStyle.ForeColor = Color.Black;
            dgvOrdersLis.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgvOrdersLis.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvOrdersLis.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            dgvOrdersLis.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdersLis.RowTemplate.Height = 55;


            // Alternating row style
            dgvOrdersLis.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 255); // light beige

            // Remove row headers if not needed
            dgvOrdersLis.RowHeadersVisible = false;

            dgvOrdersLis.Dock = DockStyle.Fill;
            dgvOrdersLis.RightToLeft = RightToLeft.No;
            dgvOrdersLis.AllowUserToAddRows = false;
            dgvOrdersLis.AllowUserToDeleteRows = false;
            dgvOrdersLis.AllowUserToResizeRows = false;
            dgvOrdersLis.AllowUserToResizeColumns = false;
            dgvOrdersLis.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdersLis.MultiSelect = false;
            dgvOrdersLis.ReadOnly = false;
            dgvOrdersLis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdersLis.BorderStyle = BorderStyle.None;
            dgvOrdersLis.CellPainting += CustomDataGridView_CellPainting;
            dgvOrdersLis.CellClick += CustomDataGridView_CellClick;
            dgvOrdersLis.CellValueChanged += CustomDataGridView_CellValueChanged;
            dgvOrdersLis.CurrentCellDirtyStateChanged += CustomDataGridView_CurrentCellDirtyStateChanged;

            // Add columns
            dgvOrdersLis.Columns.AddRange(GetOrderColumns());
            this.Controls.Add(dgvOrdersLis);
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
                ValueType = typeof(byte)
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

        public void SetOrders(List<clsOrder> orders)
        {
            dgvOrdersLis.Rows.Clear();
            foreach (var order in orders)
            {
                dgvOrdersLis.Rows.Add(
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
            this.OnOrdersCountChanged?.Invoke(dgvOrdersLis.Rows.Count);

        }
        public void SetOrder(clsOrder? order)
        {
            dgvOrdersLis.Rows.Clear();
            if (order != null)
            {
                dgvOrdersLis.Rows.Add(
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
            this.OnOrdersCountChanged?.Invoke(dgvOrdersLis.Rows.Count);
        }
        public void ClearOrdres()
        {
            dgvOrdersLis.Rows.Clear();
        }

        #endregion

        #region Events
        private void CustomDataGridView_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvOrdersLis?.Columns[e.ColumnIndex].Name != "clmnActions")
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
        private void CustomDataGridView_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdersLis == null || e.RowIndex < 0 || dgvOrdersLis?.Columns[e.ColumnIndex].Name != "clmnActions")
                return;

            Rectangle cellRect = dgvOrdersLis.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            Point mouse = dgvOrdersLis.PointToClient(Cursor.Position);


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
                if (int.TryParse(dgvOrdersLis.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    clsOrder? order = clsOrder.Find(orderID);
                    if (order == null)
                    {
                        MessageBox.Show("La commande n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (dgvOrdersLis.Rows.Count == 0 || e.RowIndex < 0)
                {
                    MessageBox.Show("Aucune commande à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette commande?", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (int.TryParse(dgvOrdersLis.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    try
                    {
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
                if (int.TryParse(dgvOrdersLis.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    // Open cash payment form or perform cash payment action
                    clsOrder? order = clsOrder.Find(orderID);
                    if (order == null)
                    {
                        MessageBox.Show("La commande n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (dgvOrdersLis.Columns[e.ColumnIndex].Name == "clmnActions" && printIcon.Contains(mouse))
            {
                if (int.TryParse(dgvOrdersLis.Rows[e.RowIndex].Cells["clmnID"].Value?.ToString(), out int orderID))
                {
                    // Open print form or perform print action
                    clsOrder? order = clsOrder.Find(orderID);
                    if (order == null)
                    {
                        MessageBox.Show("La commande n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    clsOrderPrinter printer = new clsOrderPrinter
                        (logoPath: clsStore.Load().LogoImagePath);
                    printer.Preview(order); // Assuming 80mm paper width and no specific printer
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
            if (dgvOrdersLis.IsCurrentCellDirty && dgvOrdersLis.CurrentCell is DataGridViewComboBoxCell)
                dgvOrdersLis.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private async void CustomDataGridView_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if the changed column is Status
                if (dgvOrdersLis.Columns[e.ColumnIndex].Name == "clmnStatus")
                {
                    var orderIdValue = dgvOrdersLis.Rows[e.RowIndex].Cells["clmnID"].Value;
                    var newStatusValue = dgvOrdersLis.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (orderIdValue != null && newStatusValue != null &&
                        int.TryParse(orderIdValue.ToString(), out int orderId) &&
                        byte.TryParse(newStatusValue.ToString(), out byte statusByte))
                    {
                        clsOrder? order = clsOrder.Find(orderId);
                        if (order != null)
                        {
                            order.Status = statusByte;

                            bool saved = false;

                            try
                            {
                                // Run Save() in background thread to avoid blocking the UI
                                saved = await Task.Run(() => order.Save());
                            }
                            catch (Exception ex)
                            {
                                SystemSounds.Exclamation.Play(); // error beep
                                MessageBox.Show($"⚠ Erreur lors de la sauvegarde: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            if (saved)
                            {
                                SystemSounds.Asterisk.Play(); // success beep
                                MessageBox.Show($"✅ Le statut de la commande n°{orderId} a été mis à jour vers {statusTranslations[(enStatus)statusByte]}",
                                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Refresh the list again after save
                                var orders = await Task.Run(() => clsOrder.GetAll());
                                SetOrders(orders);
                            }
                            else
                            {
                                SystemSounds.Exclamation.Play(); // error beep
                                MessageBox.Show("⚠ Une erreur s'est produite lors de la mise à jour du statut", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            SystemSounds.Exclamation.Play(); // error beep
                            MessageBox.Show("⚠ La commande n'existe pas ou est invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        private void ucOrdersList_SizeChanged(object sender, EventArgs e)
        {
            // Minimum width to ensure proper display

            // Adjust padding based on the width of the control
            if (dgvOrdersLis != null)
            {
                _Padding = ((this.Width) - 1859 + 40) < 0 ? 0 : ((this.Width) - 1859 + 40); // Adjust padding based on control width
            }
        }
        #endregion
    }
}
