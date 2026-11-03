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
                MessageBox.Show("Veuillez saisir le mot de passe actuel.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                MessageBox.Show("Veuillez saisir le nouveau mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Le nouveau mot de passe et sa confirmation ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCurrentPassword.Text == txtNewPassword.Text)
            {
                MessageBox.Show("Le nouveau mot de passe doit être différent du mot de passe actuel.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (clsPasswordHelper.VerifyPassword(txtCurrentPassword.Text, clsGlobal.CurrentUser?.PasswordHash ?? "") == false)
            {
                MessageBox.Show("Le mot de passe actuel est incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Votre mot de passe a été modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Une erreur est survenue lors de l'enregistrement du nouveau mot de passe. Veuillez réessayer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Utilisateur courant introuvable. Veuillez vous reconnecter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
