using TailorSoft.Order.Forms;
using static clsOrder;

namespace TailorSoft.Order.Controls
{
    public partial class ucOrdersListWithFilter : UserControl
    {
        enum enControlsSearchVisibility { None, txtSearch, cbOrderStatus, dtpDate }
        public ucOrdersListWithFilter()
        {
            InitializeComponent();
            InitializeUcOrderList();
            InitializeComboBoxFindBy();
            InitializeComboBoxOrderStatus();
            InitializeDateTimePicker();
        }

        private void InitializeUcOrderList()
        {
            ucOrdersList1.OnOrdersCountChanged += UcOrdersList1_OnOrdersCountChanged;
            ucOrdersList1.SetOrders(clsOrder.GetAll());
        }
        private void InitializeComboBoxFindBy()
        {
            cbFindBy.Items.Clear();
            cbFindBy.Items.Add("Aucun");
            cbFindBy.Items.Add("Numéro de commande");
            cbFindBy.Items.Add("Statut de la commande");
            cbFindBy.Items.Add("Date de la commande");
            cbFindBy.Items.Add("Date de livraison");
            cbFindBy.Items.Add("Nom du client");
            cbFindBy.Items.Add("Tél du client");
            cbFindBy.SelectedIndex = 0;

        }
        private void InitializeComboBoxOrderStatus()
        {
            cbOrderStatus.Items.Clear();
            var statusTranslations = new Dictionary<clsOrder.enStatus, string>
            {
                    { enStatus.Pending, "En attente" },
                    { enStatus.DeliveredAndNotPaid, "Livré et non payé" },
                    { enStatus.DeliveredAndPartiallyPaid, "Livré et part payé" },
                    { enStatus.DeliveredAndPaid, "Livré et payé" },
                    { enStatus.Cancelled, "Annulé" }
            };

            // Fill ComboBox with enum values
            foreach (var kvp in statusTranslations)
            {
                cbOrderStatus.Items.Add(new { Value = (byte)kvp.Key, Text = kvp.Value });
            }

            cbOrderStatus.DisplayMember = "Text";
            cbOrderStatus.ValueMember = "Value";
            cbOrderStatus.SelectedIndex = 0;
            cbOrderStatus.Visible = false;
        }
        private void InitializeDateTimePicker()
        {
            dtpDate.RightToLeft = RightToLeft.No;
            dtpDate.Value = DateTime.Now;
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Visible = false;
        }

        private void FilterOrdersListByOrderID()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Focus();
                return;
            }
            if (int.TryParse(txtSearch.Text.Trim(), out int orderID))
            {
                ucOrdersList1.SetOrder(clsOrder.Find(orderID));
            }
            else
            {
                MessageBox.Show("Numéro de commande invalide");
            }
        }
        private void FilterOrdersListByStatus()
        {
            if (byte.TryParse(cbOrderStatus.SelectedIndex.ToString(), out byte status))
                ucOrdersList1.SetOrders(clsOrder.GetByStatus(status));
        }
        private void FilterOrdersListByDate()
        {
            ucOrdersList1.SetOrders(clsOrder.GetByOrderDate(dtpDate.Value));
        }
        private void FilterOrdersListByRequiredDate()
        {
            ucOrdersList1.SetOrders(clsOrder.GetByRequiredDate(dtpDate.Value));
        }
        private void FilterOrdersListCustomerName()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Focus();
                return;
            }
            ucOrdersList1.SetOrders(clsOrder.GetByCustomerName(txtSearch.Text.Trim()));
        }
        private void FilterOrdersListCustomerPhone()
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Focus();
                return;
            }
            ucOrdersList1.SetOrders(clsOrder.GetByCustomerPhone(txtSearch.Text.Trim()));
        }
        private void HandelControlsSearchVisibility(enControlsSearchVisibility enVisibility)
        {
            switch (enVisibility)
            {
                case enControlsSearchVisibility.None:
                    {
                        txtSearch.Visible = false;
                        cbOrderStatus.Visible = false;
                        dtpDate.Visible = false;
                        break;
                    }
                case enControlsSearchVisibility.txtSearch:
                    {
                        txtSearch.Visible = true;
                        cbOrderStatus.Visible = false;
                        dtpDate.Visible = false;
                        break;
                    }
                case enControlsSearchVisibility.cbOrderStatus:
                    {
                        txtSearch.Visible = false;
                        cbOrderStatus.Visible = true;
                        dtpDate.Visible = false;
                        break;
                    }
                case enControlsSearchVisibility.dtpDate:
                    {
                        txtSearch.Visible = false;
                        cbOrderStatus.Visible = false;
                        dtpDate.Visible = true;
                        break;
                    }
                default:
                    {
                        txtSearch.Visible = false;
                        cbOrderStatus.Visible = false;
                        dtpDate.Visible = false;
                        break;
                    }

            }

        }
        private void FilterOrdersListByComboBoxFindBySelectedIndex(int index)
        {
            switch (index)
            {
                case 0: // None
                    {
                        ucOrdersList1.SetOrders(clsOrder.GetAll());
                        HandelControlsSearchVisibility(enControlsSearchVisibility.None);
                        break;
                    }
                case 1: // OrderID
                    {
                        HandelControlsSearchVisibility(enControlsSearchVisibility.txtSearch);
                        FilterOrdersListByOrderID();
                        break;
                    }
                case 2: // Order Status
                    {
                        HandelControlsSearchVisibility(enControlsSearchVisibility.cbOrderStatus);
                        FilterOrdersListByStatus();
                        break;
                    }
                case 3: // Order Date
                    {
                        HandelControlsSearchVisibility(enControlsSearchVisibility.dtpDate);
                        FilterOrdersListByDate();
                        break;
                    }
                case 4: // Required Date
                    {
                        HandelControlsSearchVisibility(enControlsSearchVisibility.dtpDate);
                        FilterOrdersListByRequiredDate();
                        break;
                    }
                case 5: // Customer name
                    {
                        HandelControlsSearchVisibility(enControlsSearchVisibility.txtSearch);
                        FilterOrdersListCustomerName();
                        break;
                    }
                case 6: // Customer phone
                    {
                        HandelControlsSearchVisibility(enControlsSearchVisibility.txtSearch);
                        FilterOrdersListCustomerPhone();
                        break;
                    }

            }
        }
        private void ClearControlsSearch()
        {
            txtSearch.Clear();
            dtpDate.Value = DateTime.Now;
            if (cbOrderStatus.Items.Count > 0 && cbOrderStatus.SelectedIndex != 0)
                cbOrderStatus.SelectedIndex = 0;
        }
        private void UcOrdersList1_OnOrdersCountChanged(int obj)
        {
            lblNumberOfOrders.Text = $"Nombre de commandes: {obj}";
        }
        private void btnAddNewOrder_Click(object sender, EventArgs e)
        {
            using (frmAddOrder frm = new frmAddOrder())
            {
                frm.OnOrderSavedSuccessfully += (order) =>
                {
                    // Refresh the orders list after a new order is added
                    ucOrdersList1.SetOrders(clsOrder.GetAll());
                };
                frm.ShowDialog();
            }
        }
        private void ucOrdersListWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearControlsSearch();
            ucOrdersList1.ClearOrdres();
            FilterOrdersListByComboBoxFindBySelectedIndex(cbFindBy.SelectedIndex);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (cbFindBy.SelectedIndex == 3)
            {
                FilterOrdersListByDate();
            }
            else if (cbFindBy.SelectedIndex == 4)
            {
                FilterOrdersListByRequiredDate();
            }
        }

        private void cbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFindBy.SelectedIndex == 2)  // Order status
            {
                FilterOrdersListByStatus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ucOrdersList1.ClearOrdres();
                return;
            }

            if (cbFindBy.SelectedIndex == 1)  // OrderID
            {
                FilterOrdersListByOrderID();
                return;
            }
            if (cbFindBy.SelectedIndex == 5) // Customer Name
            {
                FilterOrdersListCustomerName();
                return;
            }
            if (cbFindBy.SelectedIndex == 6) // Customer phone
            {
                FilterOrdersListCustomerPhone();
                return;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbFindBy_SelectedIndexChanged(null, null);
        }
    }
}
