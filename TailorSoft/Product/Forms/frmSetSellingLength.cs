using TailorSoft_Business_Layer;

namespace TailorSoft.Product.Forms
{
    public partial class frmSetSellingLength : Form
    {
        private clsProduct _productToSell;
        public event Action<clsProduct>? OnSellingCompletedSuccessfully;
        public frmSetSellingLength(clsProduct ProductToSell)
        {
            InitializeComponent();
            _productToSell = ProductToSell;
        }
        private void SubstrackSellingLength()
        {
            if (_productToSell == null || _productToSell.Id <= 0)
            {
                MessageBox.Show("رقم المنتج غير صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_productToSell.StockLength <= 0)
            {
                MessageBox.Show("لا يوجد طول متاح للبيع", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudSellingLength.ResetText();
                return;
            }
            if (_productToSell.StockLength < (double)nudSellingLength.Value)
            {
                MessageBox.Show("الطول المطلوب للبيع أكبر من الطول المتاح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudSellingLength.ResetText();
                return;
            }
            if (_productToSell.Sell((double)nudSellingLength.Value))
            {
                OnSellingCompletedSuccessfully?.Invoke(_productToSell);
                MessageBox.Show("تم خصم الطول بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("حدث خطأ أثناء خصم الطول", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nudSellingLength.ResetText();
            }
        }
        private void frmSetSellingLength_Load(object sender, EventArgs e)
        {
            if (_productToSell == null || _productToSell.Id <= 0)
            {
                MessageBox.Show("رقم المنتج غير صحيح", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblTitle.Text = $"أكتب الطول بالمتر الذي تريد بيعه من الثوب رقم {_productToSell.Id}";
            nudSellingLength.ResetText();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SubstrackSellingLength();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
