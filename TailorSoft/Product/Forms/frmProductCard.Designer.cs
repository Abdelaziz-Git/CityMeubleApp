namespace TailorSoft.Product.Forms
{
    partial class frmProductCard
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
            ucProductItem1 = new HFS.Product.Controls.ucProductItem();
            SuspendLayout();
            // 
            // ucProductItem1
            // 
            ucProductItem1.BackColor = Color.WhiteSmoke;
            ucProductItem1.BorderStyle = BorderStyle.Fixed3D;
            ucProductItem1.Location = new Point(3, 3);
            ucProductItem1.Name = "ucProductItem1";
            ucProductItem1.Size = new Size(668, 334);
            ucProductItem1.TabIndex = 0;
            ucProductItem1.OnProductItemDeleted += ucProductItem1_OnProductItemDeleted;
            ucProductItem1.OnProductItemSaved += ucProductItem1_OnProductItemSaved;
            // 
            // frmProductCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(673, 339);
            Controls.Add(ucProductItem1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProductCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "معلومات المنتج";
            ResumeLayout(false);
        }

        #endregion

        private HFS.Product.Controls.ucProductItem ucProductItem1;
    }
}