using TailorSoft.Properties;
using TailorSoft.Store.Classes;

namespace TailorSoft.Store.Forms
{
    public partial class frmUpdateStoreInfo : Form
    {
        private clsStore _Store = clsStore.Load();
        public frmUpdateStoreInfo()
        {
            InitializeComponent();

        }
        private void LoadDataToForm()
        {
            if (_Store != null)
            {
                txtStoreName.Text = _Store.Name;
                txtPhone.Text = _Store.Phone;
                txtAddress.Text = _Store.Address;
                pbStoreLogo.ImageLocation = _Store.LogoImagePath;
            }
        }
        private void LoadImageToPictureBox(string filePath)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    pbStoreLogo.ImageLocation = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impossible de charger l’image : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Le fichier n’existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool LoadImageFromFile()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Sélectionner une image pour le logo du magasin";
                    openFileDialog.Filter = "Fichiers image|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    openFileDialog.Multiselect = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadImageToPictureBox(openFileDialog.FileName);
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement de l’image : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private void frmUpdateStoreInfo_Load(object sender, EventArgs e)
        {
            LoadDataToForm();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            if (!LoadImageFromFile())
            {
                pbStoreLogo.ImageLocation = "";
                pbStoreLogo.Image = Resources.empty_image_icon_512;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Store.Name = txtStoreName.Text ?? "";
            _Store.Phone = txtPhone.Text ?? "";
            _Store.Address = txtAddress.Text ?? "";
            _Store.LogoImagePath = pbStoreLogo.ImageLocation;
            try
            {
                _Store.Save();
                MessageBox.Show("Les informations du magasin ont été mises à jour avec succès.", "Magasin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Erreur lors de l’enregistrement des informations du magasin : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l’enregistrement des informations du magasin : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
