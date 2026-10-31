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
                    MessageBox.Show("Failed to load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool LoadImageFromFile()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select an Image for product";
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
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
                MessageBox.Show($"Error to load image: {ex.Message}");
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
                MessageBox.Show("تم تحديث معلومات المحل بنجاح");
                this.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
