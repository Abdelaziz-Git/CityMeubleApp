namespace TailorSoft.User.Forms
{
    public partial class frmUpdateUser : Form
    {
        public Action? OnUserUpdatedSuccessfully;
        public frmUpdateUser(int userId)
        {
            InitializeComponent();
            ucUpdateUser1.LoadUser(userId);
            ucUpdateUser1.OnUserUpdatedSuccessfully += UcUpdateUser1_OnUserUpdatedSuccessfully;
            ucUpdateUser1.OnButtonCloseClicked += UcUpdateUser1_OnButtonCloseClicked;
        }

        private void UcUpdateUser1_OnButtonCloseClicked()
        {
            this.Close();
        }

        private void UcUpdateUser1_OnUserUpdatedSuccessfully(int? obj)
        {
            this.OnUserUpdatedSuccessfully?.Invoke();
            this.Close();
        }
    }
}
