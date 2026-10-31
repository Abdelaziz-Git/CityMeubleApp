using TailorSoft_Business_Layer;

namespace TailorSoft.OrderItem.Forms
{
    public partial class frmAddUpdateItem : Form
    {
        enum enMode { AddNew, Update }
        private enMode _Mode = enMode.AddNew;
        private int _OrderID = -1;
        private clsOrderItem? _OrderItem;
        public event Action<clsOrderItem>? OnItemAddedOrUpdatedSuccessfully;
        public clsOrderItem? OrderItem
        {
            get { return _OrderItem; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddUpdateItem"/> form for adding a new order item.
        /// </summary>
        /// <param name="orderID">The ID of the order to which the item will be added.</param>
        public frmAddUpdateItem(int orderID)
        {
            _Mode = enMode.AddNew;
            _OrderID = orderID;
            InitializeComponent();

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddUpdateItem"/> form for updating an existing order item.
        /// </summary>
        /// <param name="orderItem">The <see cref="clsOrderItem"/> to update.</param>
        public frmAddUpdateItem(clsOrderItem orderItem)
        {
            _Mode = enMode.Update;
            _OrderItem = orderItem;
            InitializeComponent();

        }

        private bool CalculateTotalPrice()
        {
            if (decimal.TryParse(txtQuantity.Text, out decimal quantity) && decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
            {
                decimal TotalPrice = quantity * unitPrice;
                lblTotalPrice.Text = TotalPrice % 1 == 0 ? TotalPrice.ToString("0") + " درهم" : TotalPrice.ToString("0.0") + " درهم";
                errorProvider1.SetError(txtQuantity, string.Empty);
                errorProvider1.SetError(txtUnitPrice, string.Empty);
                return true;
            }
            else
            {
                lblTotalPrice.Text = "0" + " درهم";
                return false;
            }
        }
        private void InAddNewMode()
        {
            lblTitle.Text = "إضافة عنصر طلب جديد";
        }
        private void InUpdateMode()
        {
            lblTitle.Text = "تحديث عنصر الطلب";
            if (_OrderItem != null)
            {
                txtProductID.Text = _OrderItem?.ProductID?.ToString();
                txtProductName.Text = _OrderItem?.ProductName;
                txtQuantity.Text = _OrderItem?.Quantity % 1 == 0 ? _OrderItem?.Quantity.ToString("0") : _OrderItem?.Quantity.ToString("0.0");
                txtUnitPrice.Text = _OrderItem?.UnitPrice % 1 == 0 ? _OrderItem?.UnitPrice.ToString("0") : _OrderItem?.UnitPrice.ToString("0.0");
                CalculateTotalPrice();
            }
        }
        private void SaveData()
        {
            int? productId = null;
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                productId = null;
            }
            else if (!int.TryParse(txtProductID.Text.Trim(), out int ProductId))
            {
                MessageBox.Show("رقم المنتج غير صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                productId = ProductId;
            }
            if (_Mode == enMode.AddNew && _OrderID >= 1 && IsValideInputs() && this.ValidateChildren())
            {

                // Create a new order item and set its properties
                clsOrderItem newOrderItem = new clsOrderItem
                {
                    OrderId = _OrderID,
                    ProductID = productId,
                    ProductName = txtProductName.Text.Trim(),
                    Quantity = decimal.Parse(txtQuantity.Text),
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Notes = txtNotes.Text.Trim()
                };
                if (newOrderItem.Save())
                {
                    _OrderItem = newOrderItem;
                    this._Mode = enMode.Update;
                    this.OnItemAddedOrUpdatedSuccessfully?.Invoke(_OrderItem);
                    MessageBox.Show("تم إضافة العنصر الى الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("فشل في إضافة عنصر الطلب، يرجى المحاولة مرة أخرى", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_Mode == enMode.Update)
            {
                if (_OrderItem != null && IsValideInputs() && this.ValidateChildren())
                {
                    _OrderItem.ProductID = productId;
                    _OrderItem.ProductName = txtProductName.Text.Trim();
                    _OrderItem.Quantity = decimal.Parse(txtQuantity.Text);
                    _OrderItem.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                    _OrderItem.Notes = txtNotes.Text.Trim();
                    if (_OrderItem.Save())
                    {
                        this.OnItemAddedOrUpdatedSuccessfully?.Invoke(_OrderItem);
                        MessageBox.Show("تم تحديث عنصر الطلب بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("فشل في تحديث عنصر الطلب، يرجى المحاولة مرة أخرى", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
        private void frmAddUpdateItem_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
            {
                InAddNewMode();
                if (_OrderID <= 0)
                {
                    MessageBox.Show("رقم الطلب غير صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                txtProductName.Select();
            }
            else if (_Mode == enMode.Update)
            {
                if (_OrderItem != null)
                {
                    InUpdateMode();
                }
                else
                {
                    MessageBox.Show("لا يمكن تحديث عنصر الطلب، العنصر غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
        }
        public bool IsValideInputs()
        {
            if (!string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                if (!int.TryParse(txtProductID.Text.Trim(), out int ProductId))
                {
                    MessageBox.Show("رقم المنتج غير صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!clsProduct.Exist(ProductId))
                {
                    MessageBox.Show("رقم المنتج غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }

            if (_Mode == enMode.AddNew)
            {
                if (_OrderID <= 0)
                {
                    MessageBox.Show("رقم الطلب غير صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (_Mode == enMode.Update && _OrderItem == null)
            {
                MessageBox.Show("لا يمكن تحديث عنصر الطلب، العنصر غير موجود", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtProductName.Text) || txtProductName.Text.Length < 3)
            {
                MessageBox.Show("اسم المنتج مطلوب و يجب أن يكون أكثر من 3 أحرف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtProductName, "اسم المنتج مطلوب و يجب أن يكون أكثر من 3 أحرف");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text) || !decimal.TryParse(txtQuantity.Text, out decimal quantity) || quantity <= 0)
            {
                MessageBox.Show("الكمية او الطول مطلوبة و يجب أن تكون رقم صحيح و أكبر من صفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtQuantity, "الكمية او الطول مطلوبة و يجب أن تكون رقم صحيح و أكبر من صفر");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUnitPrice.Text) || !decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) || unitPrice < 0)
            {
                MessageBox.Show("ثمن الوحدة مطلوب و يجب أن يكون رقم صحيح و أكبر من صفر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtUnitPrice, "ثمن الوحدة مطلوب و يجب أن يكون رقم صحيح و أكبر من صفر");
                return false;
            }

            return true;
        }
        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                errorProvider1.SetError(txtProductID, string.Empty);
                return;
            }
            if (int.TryParse(txtProductID.Text, out int productId))
            {
                if (clsProduct.Exist(productId))
                {
                    errorProvider1.SetError(txtProductID, string.Empty);
                }
                else
                {
                    errorProvider1.SetError(txtProductID, "رقم المنتج غير موجود");
                }
            }
            else
            {
                errorProvider1.SetError(txtProductID, "رقم المنتج غير صحيح");
            }
        }
        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "اسم المنتج مطلوب");
            }
            else
            {
                errorProvider1.SetError(txtProductName, string.Empty);
            }
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                errorProvider1.SetError(txtQuantity, "الكمية او الطول مطلوبة");
            }
            else if (decimal.TryParse(txtQuantity.Text, out decimal quantity) && quantity >= 0)
            {
                errorProvider1.SetError(txtQuantity, string.Empty);
            }
            else
            {
                errorProvider1.SetError(txtQuantity, "الكمية يجب أن تكون رقم صحيح و أكبر من صفر");
            }
        }
        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
            if (string.IsNullOrWhiteSpace(txtUnitPrice.Text))
            {
                errorProvider1.SetError(txtUnitPrice, "ثمن الوحدة مطلوب");
            }
            else if (decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice) && unitPrice >= 0)
            {
                errorProvider1.SetError(txtUnitPrice, string.Empty);
            }
            else
            {
                errorProvider1.SetError(txtUnitPrice, "ثمن الوحدة يجب أن يكون رقم صحيح و أكبر من صفر");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAddUpdateItem_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 1092)
            { this.Width = 1092; }
        }

    }
}
