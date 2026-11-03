using Microsoft.Win32;
using TailorSoft_Business_Layer;

namespace TailorSoft
{
    public partial class frmLogin : Form
    {
        private readonly string KeyPath = @"HKEY_CURRENT_USER\Software\TailorSoft\Credentials";
        private string? SavedUsername = string.Empty;
        private string? SavedEncryptedPassword = string.Empty;
        private bool IsRemember = false;

        readonly string valueName1 = "Username";
        readonly string valueName2 = "Password";
        readonly string valueName3 = "IsRemember";

        private static (string PublicKeyXml, string PrivateKeyXml) RsaKeyPair;


        public frmLogin()
        {
            InitializeComponent();
            RsaKeyPair = LoadOrGenerateRsaKeyPair();  // Load existing or generate once
            ReadCredentialsFromRegistry();
        }

        private static (string PublicKeyXml, string PrivateKeyXml) LoadOrGenerateRsaKeyPair()
        {
            const string regPath = @"Software\TailorSoft\Security";
            using (RegistryKey? key = Registry.CurrentUser.OpenSubKey(regPath))
            {
                if (key != null)
                {
                    string? pubKey = key.GetValue("PublicKey") as string;
                    string? privKey = key.GetValue("PrivateKey") as string;
                    if (pubKey != null && privKey != null)
                        return (pubKey, privKey);
                }
            }

            // Generate new key pair and save it
            var newPair = clsCryptoHelper.GenerateRsaKeyPair();
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(regPath))
            {
                key.SetValue("PublicKey", newPair.PublicKeyXml);
                key.SetValue("PrivateKey", newPair.PrivateKeyXml);
            }
            return newPair;
        }

        private void ReadCredentialsFromRegistry()
        {
            try
            {
                // Normalize subkey path for Registry.CurrentUser (remove the HKEY prefix if present)
                string subKeyPath = KeyPath;
                const string prefix = @"HKEY_CURRENT_USER\";
                if (subKeyPath.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    subKeyPath = subKeyPath.Substring(prefix.Length);
                }

                // Create or open the subkey (CreateSubKey will create it if it doesn't exist)
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subKeyPath, writable: true))
                {
                    if (key != null)
                    {
                        // Ensure both values exist — if not, create them with empty string (no data)
                        if (key.GetValue(valueName1) == null)
                            key.SetValue(valueName1, string.Empty, RegistryValueKind.String);

                        if (key.GetValue(valueName2) == null)
                            key.SetValue(valueName2, string.Empty, RegistryValueKind.String);

                        if (key.GetValue(valueName3) == null)
                            key.SetValue(valueName3, "0", RegistryValueKind.String);

                        // Read values (fallback to empty string if null)
                        SavedUsername = key.GetValue(valueName1, string.Empty) as string;
                        SavedEncryptedPassword = key.GetValue(valueName2, string.Empty) as string;
                        string Value3 = key.GetValue(valueName3, "false").ToString() switch
                        {
                            "1" => "true",
                            "0" => "false",
                            _ => throw new FormatException("Invalid boolean string")
                        };
                        if (bool.TryParse(Value3, out IsRemember)) { }
                        else
                            IsRemember = false;

                    }
                    else
                    {
                        // Fallback (shouldn't normally happen)
                        SavedUsername = null;
                        SavedEncryptedPassword = null;
                        IsRemember = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error and keep SavedUsername / SavedPasswordHash as null so login fails safely
                MessageBox.Show($"Erreur lors de l'accès au registre : {ex.Message}");
                SavedUsername = null;
                SavedEncryptedPassword = null;
            }
        }
        private void SaveCredentialsToRegistry(string username, string EncryptedPassword, bool remember)
        {
            try
            {
                // Normalize subkey path for Registry.CurrentUser (remove the HKEY prefix if present)
                string subKeyPath = KeyPath;
                const string prefix = @"HKEY_CURRENT_USER\";
                if (subKeyPath.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    subKeyPath = subKeyPath.Substring(prefix.Length);
                }
                // Create or open the subkey (CreateSubKey will create it if it doesn't exist)
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subKeyPath, writable: true))
                {
                    if (key != null)
                    {
                        key.SetValue(valueName1, remember ? username : string.Empty, RegistryValueKind.String);
                        key.SetValue(valueName2, remember ? EncryptedPassword : string.Empty, RegistryValueKind.String);
                        key.SetValue(valueName3, remember ? "1" : "0", RegistryValueKind.String);
                    }
                    else
                    {
                        MessageBox.Show("Impossible d'accéder au registre pour enregistrer les données d'identification.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement des données d'identification dans le registre: {ex.Message}");
            }
        }

        // Events
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Veuillez corriger les erreurs avant de vous connecter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (!clsUser.IsExists(username))
            {
                MessageBox.Show("Le nom d'utilisateur est invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsUser? curentUser = clsUser.Find(username);
            if (curentUser == null || curentUser.Username == null || curentUser.PasswordHash == null)
            {
                MessageBox.Show("Une erreur inattendue s'est produite lors de la vérification des données utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsPasswordHelper.VerifyPassword(password, curentUser.PasswordHash) == false)
            {
                MessageBox.Show("Le mot de passe est incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsGlobal.CurrentUser = curentUser;

            using (frmMain frm = new frmMain())
            {
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "Le nom d'utilisateur ne peut pas être vide.");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
        }
        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "Le mot de passe ne peut pas être vide.");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (IsRemember)
            {
                txtUsername.Text = SavedUsername;
                var (publicKey, privateKey) = clsCryptoHelper.GenerateRsaKeyPair();
                txtPassword.Text = clsCryptoHelper.RsaDecrypt(SavedEncryptedPassword ?? string.Empty, RsaKeyPair.PrivateKeyXml);
                chkRememberMe.Checked = true;
                btnLogin.Select();
            }
            else
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                chkRememberMe.Checked = false;
                txtUsername.Select();
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            SavedEncryptedPassword = clsCryptoHelper.RsaEncrypt(txtPassword.Text.Trim(), RsaKeyPair.PublicKeyXml);
            SaveCredentialsToRegistry(txtUsername.Text.Trim(), SavedEncryptedPassword, chkRememberMe.Checked);
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                // Normalize subkey path for Registry.CurrentUser (remove the HKEY prefix if present)
                string subKeyPath = KeyPath;
                const string prefix = @"HKEY_CURRENT_USER\";
                if (subKeyPath.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    subKeyPath = subKeyPath.Substring(prefix.Length);
                }

                // Create or open the subkey (CreateSubKey will create it if it doesn't exist)
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(subKeyPath, writable: true))
                {
                    if (key != null)
                    {
                        if (key.GetValue(valueName3) == null)
                            key.SetValue(valueName3, "0", RegistryValueKind.String);

                        key?.SetValue(valueName3, chkRememberMe.Checked ? "1" : "0", RegistryValueKind.String);


                    }
                    else
                    {
                        IsRemember = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error and keep SavedUsername / SavedPasswordHash as null so login fails safely
                MessageBox.Show($"Erreur lors de l'accès au registre : {ex.Message}");
                IsRemember = false;
            }
        }
    }
}
