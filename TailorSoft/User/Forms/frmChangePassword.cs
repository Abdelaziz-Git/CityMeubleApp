using Microsoft.VisualBasic.ApplicationServices;
using TailorSoft_Business_Layer;

namespace TailorSoft.User.Forms
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show("الرجاء إدخال كلمة المرور الحالية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("الرجاء إدخال كلمة المرور الجديدة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("كلمة المرور الجديدة وتأكيد كلمة المرور غير متطابقين.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCurrentPassword.Text == txtNewPassword.Text)
            {
                MessageBox.Show("كلمة المرور الجديدة لا يمكن أن تكون نفس كلمة المرور الحالية.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (clsPasswordHelper.VerifyPassword(txtCurrentPassword.Text, clsGlobal.CurrentUser?.PasswordHash ?? "") == false)
            {
                MessageBox.Show("كلمة المرور الحالية غير صحيحة.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void ChangePassword()
        {
            if (ValidateInputs())
            {
                string newHashedPassword = clsPasswordHelper.HashPassword(txtNewPassword.Text);
                // Update the password in the database for the current user
                // This is a placeholder for your actual database update logic
                clsUser? CurrentUser = clsGlobal.CurrentUser;
                if (CurrentUser != null)
                {
                    CurrentUser.PasswordHash = newHashedPassword;
                    if (CurrentUser.Save())
                    {
                        MessageBox.Show("تم تغيير كلمة المرور بنجاح.", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("حدث خطأ أثناء حفظ كلمة المرور الجديدة. الرجاء المحاولة مرة أخرى.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("لم يتم العثور على المستخدم الحالي. الرجاء تسجيل الدخول مرة أخرى.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
