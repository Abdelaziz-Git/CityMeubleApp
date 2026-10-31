namespace HFS.Product.Forms
{
    partial class frmAddUpdateProduct
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
            TailorSoft_Business_Layer.clsProduct clsProduct1 = new TailorSoft_Business_Layer.clsProduct();
            ucAddUpdateProduct1 = new HFS.Product.Controls.ucAddUpdateProduct();
            SuspendLayout();
            // 
            // ucAddUpdateProduct1
            // 
            ucAddUpdateProduct1.AutoScroll = true;
            ucAddUpdateProduct1.BackColor = Color.White;
            ucAddUpdateProduct1.Dock = DockStyle.Fill;
            ucAddUpdateProduct1.Location = new Point(0, 0);
            ucAddUpdateProduct1.Name = "ucAddUpdateProduct1";
            clsProduct1.Category = null;
            clsProduct1.Color = null;
            clsProduct1.CreatedByUserID = null;
            clsProduct1.CreatedDate = new DateTime(2025, 7, 12, 17, 9, 8, 781);
            clsProduct1.ImagePath = null;
            clsProduct1.InitialLength = null;
            clsProduct1.IsActive = null;
            clsProduct1.LastUpdate = new DateTime(2025, 7, 12, 17, 9, 8, 795);
            clsProduct1.Price = null;
            clsProduct1.StockLength = null;
            clsProduct1.TypeID = null;
            ucAddUpdateProduct1.Product = clsProduct1;
            ucAddUpdateProduct1.RightToLeft = RightToLeft.Yes;
            ucAddUpdateProduct1.Size = new Size(848, 652);
            ucAddUpdateProduct1.TabIndex = 0;
            ucAddUpdateProduct1.OnCloseButtonClicked += ucAddUpdateProduct1_OnCloseButtonClicked;
            ucAddUpdateProduct1.OnSavedProductSuccessfully += ucAddUpdateProduct1_OnSavedProductSuccessfully;
            ucAddUpdateProduct1.OnProductAddedSuccessfully += ucAddUpdateProduct1_OnProductAddedSuccessfully;
            ucAddUpdateProduct1.OnProductUpdatedSuccessfully += ucAddUpdateProduct1_OnProductUpdatedSuccessfully;
            // 
            // frmAddUpdateProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(848, 652);
            Controls.Add(ucAddUpdateProduct1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddUpdateProduct";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        #endregion

        private Controls.ucAddUpdateProduct ucAddUpdateProduct1;
    }
}