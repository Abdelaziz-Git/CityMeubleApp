namespace TailorSoft.Order.Forms
{
    public partial class frmUpdateOrder : Form
    {
        private clsOrder _order;
        public event Action<clsOrder>? OnOrderSavedSuccessfully;
        public frmUpdateOrder(clsOrder order)
        {
            InitializeComponent();
            _order = order;
            ucAddUpdateOrder1.SetOrder(order);
        }

        private void ucAddUpdateOrder1_OnButtonCloseClicked()
        {
            this.Close();
        }

        private void ucAddUpdateOrder1_OnOrderSavedSuccessfully(clsOrder obj)
        {
            this.OnOrderSavedSuccessfully?.Invoke(obj);
        }
    }
}
