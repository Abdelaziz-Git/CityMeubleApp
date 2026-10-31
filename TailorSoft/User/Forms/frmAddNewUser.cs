namespace TailorSoft.User.Forms
{
    public partial class frmAddNewUser : Form
    {
        public Action? OnUserAddedSuccessfully;
        public frmAddNewUser()
        {
            InitializeComponent();
            ucAddUser1.OnButtonCloseClicked += UcAddUser1_OnButtonCloseClicked;
            ucAddUser1.OnUserAddedSuccessfully += UcAddUser1_OnUserAddedSuccessfully;
        }

        private void UcAddUser1_OnUserAddedSuccessfully(int? obj)
        {
            this.OnUserAddedSuccessfully?.Invoke();
            this.Close();
        }

        private void UcAddUser1_OnButtonCloseClicked()
        {
            this.Close();
        }
    }
}
