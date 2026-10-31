using TailorSoft.OrderItem.Controls;
using static clsOrder;

namespace TailorSoft.Order.Controls
{
    public partial class ucAddUpdateOrder : UserControl
    {
        private clsOrder? _Order;
        public clsOrder? Order
        {
            get => _Order;
        }
        public event Action? OnButtonCloseClicked;
        public event Action<clsOrder>? OnOrderSavedSuccessfully;
        public ucAddUpdateOrder()
        {
            InitializeComponent();
            InitializeComboBoxOrderStatus();
            SetDeffaultValues();
            this.ucOrderItemList1.OnItemsChanged += UcOrderItemList1_OnItemsChanged;
        }

        private void SetDeffaultValues()
        {
            lblOrderID.Text = "غير معروف";
            lblCustomerID.Text = "غير معروف";
            dtpRequiredDate.Value = DateTime.Now;
            cbOrderStatus.SelectedIndex = 0; // Default to Pending
            txtNotes.Text = "لا توجذد ملاحضات";
            lblInitialAmount.Text = "0 درهم";
            lblRemainingAmount.Text = "0 درهم";
            lblTotalAmount.Text = "0 درهم";
        }
        private void InitializeComboBoxOrderStatus()
        {
            cbOrderStatus.Items.Clear();
            var statusTranslations = new Dictionary<clsOrder.enStatus, string>
            {
                    { enStatus.Pending, "قيد الانتظار" },
                    { enStatus.Measuring, "قياس" },
                    { enStatus.InProgress, "قيد التنفيذ" },
                    { enStatus.ReadyforDelivery, "جاهز للتسليم" },
                    { enStatus.Delivered, "تم التسليم" },
                    { enStatus.DeliveredAndPaid, "تم التسليم والدفع" },
                    { enStatus.Cancelled, "ملغى" }
            };

            // Fill ComboBox with enum values
            foreach (var kvp in statusTranslations)
            {
                cbOrderStatus.Items.Add(new { Value = (byte)kvp.Key, Text = kvp.Value });
            }

            cbOrderStatus.DisplayMember = "Text";
            cbOrderStatus.ValueMember = "Value";
        }
        private bool IsValidInputs()
        {
            if (dtpRequiredDate.Value < DateTime.Now.AddYears(-1))
            {
                MessageBox.Show("الرجاء اختيار تاريخ صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbOrderStatus.SelectedIndex == -1)
            {
                MessageBox.Show("الرجاء اختيار حالة الطلب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void SetOrder(clsOrder order)
        {
            if (order == null || order.Id <= 0 || order.CustomerID <= 0)
            {
                SetDeffaultValues();
                MessageBox.Show("رقم طلب غير صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Set Order Information
            _Order = order;
            lblOrderID.Text = _Order.Id.ToString();
            lblCustomerID.Text = _Order.CustomerID.ToString();
            dtpRequiredDate.Value = _Order.RequiredDate;
            cbOrderStatus.SelectedValue = _Order.Status;
            txtNotes.Text = _Order.Notes;
            lblInitialAmount.Text = $"{_Order.InitialAmount} درهم";
            lblRemainingAmount.Text = $"{_Order.RemainingAmount} درهم";
            lblTotalAmount.Text = $"{_Order.TotalAmount} درهم";

            // Set Items list
            this.ucOrderItemList1.SetItems(_Order.Id);
        }
        public void ButtonSave_Click()
        {
            btnSave.PerformClick();
        }
        private void UcOrderItemList1_OnItemsChanged(int orderID)
        {
            _Order = clsOrder.Find(orderID);
            if (_Order == null)
            {
                MessageBox.Show("حدث خطأ أثناء تحميل الطلب من جديد بعد تغيير عناصر الطلب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Update Order Information
            SetOrder(_Order);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.OnButtonCloseClicked?.Invoke();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsValidInputs())
                return;

            if (_Order == null)
            {
                MessageBox.Show("الرجاء تحميل الطلب قبل الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Update Order Information
            _Order.RequiredDate = dtpRequiredDate.Value;
            _Order.Status = (byte)cbOrderStatus.SelectedIndex;
            _Order.Notes = txtNotes.Text.Trim();
            if (_Order.Save())
            {
                this.OnOrderSavedSuccessfully?.Invoke(_Order);
                MessageBox.Show("تم تحديث الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnButtonCloseClicked?.Invoke();
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء تحديث الطلب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
