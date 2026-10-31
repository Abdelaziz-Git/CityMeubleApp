namespace TailorSoft.Product.Forms
{
    partial class frmProductsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ucProductListWithFilter1 = new TailorSoft.Product.Controls.ucProductListWithFilter();
            SuspendLayout();
            // 
            // ucProductListWithFilter1
            // 
            ucProductListWithFilter1.BackColor = Color.White;
            ucProductListWithFilter1.Dock = DockStyle.Fill;
            ucProductListWithFilter1.Location = new Point(0, 0);
            ucProductListWithFilter1.Name = "ucProductListWithFilter1";
            ucProductListWithFilter1.Size = new Size(948, 515);
            ucProductListWithFilter1.TabIndex = 0;
            // 
            // frmProductsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(948, 515);
            Controls.Add(ucProductListWithFilter1);
            Name = "frmProductsList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProductsList";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private Controls.ucProductListWithFilter ucProductListWithFilter1;
    }
}