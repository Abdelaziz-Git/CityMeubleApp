namespace TailorSoft.Order.Forms
{
    public partial class frmRecordPayment : Form
    {
        private int _orderID;
        clsOrder? _Order;
        public frmRecordPayment(int orderID)
        {
            InitializeComponent();
            _orderID = orderID;
            _Order = clsOrder.Find(orderID);
            if (_Order == null)
            {
                MessageBox.Show("الطلب غير موجود.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                lblTitle.Text = $"تسجيل دفعة للطلب رقم {_Order.Id}";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                // Assuming clsOrder has a method to record payment
                bool success = clsOrder.RecordPayment(_orderID, amount);
                if (success)
                {
                    MessageBox.Show("تم تسجيل الدفعة بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشل تسجيل الدفعة. يرجى المحاولة مرة أخرى.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("يرجى إدخال مبلغ صحيح.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
