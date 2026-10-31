using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TailorSoft.Activation
{
    public partial class ActivationForm : Form
    {
        public bool IsActivated { get; private set; } = false;

        private string licensePath = @"C:\ProgramData\TailorSoft\license.json";

        public ActivationForm()
        {
            InitializeComponent();
            this.txtMachineId.Text = MachineIdProvider.GetMachineId();
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtMachineId.Text);
            lblStatus.Text = "Machine ID copied!";
        }

        private void btnLoadLicense_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "License File (*.json)|*.json";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Directory.CreateDirectory(@"C:\ProgramData\TailorSoft");
                    File.Copy(ofd.FileName, licensePath, true);

                    if (LicenseValidator.Validate(licensePath))
                    {
                        lblStatus.Text = "✅ Activation successful!";
                        lblStatus.ForeColor = Color.Green;

                        IsActivated = true;

                        MessageBox.Show("Activation successful!", "Success");
                        this.Close();
                    }
                    else
                    {
                        lblStatus.Text = "❌ Invalid license file";
                        lblStatus.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error: " + ex.Message;
                    lblStatus.ForeColor = Color.Red;
                }
            }
        }
    }
}
