namespace HFS.Product.Controls
{
    partial class ucProductItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblProductDate = new Label();
            btnSell = new Button();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            pbProduct = new PictureBox();
            txtProductID = new Label();
            txtProductColor = new Label();
            txtProductInitialLength = new Label();
            txtProductStockLength = new Label();
            txtProductPrice = new Label();
            txtProductCategory = new Label();
            txtProductType = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProduct).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtProductType);
            splitContainer1.Panel1.Controls.Add(txtProductCategory);
            splitContainer1.Panel1.Controls.Add(txtProductPrice);
            splitContainer1.Panel1.Controls.Add(txtProductStockLength);
            splitContainer1.Panel1.Controls.Add(txtProductInitialLength);
            splitContainer1.Panel1.Controls.Add(txtProductColor);
            splitContainer1.Panel1.Controls.Add(txtProductID);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(lblProductDate);
            splitContainer1.Panel1.RightToLeft = RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnSell);
            splitContainer1.Panel2.Controls.Add(btnEditProduct);
            splitContainer1.Panel2.Controls.Add(btnDeleteProduct);
            splitContainer1.Panel2.Controls.Add(pbProduct);
            splitContainer1.Size = new Size(668, 334);
            splitContainer1.SplitterDistance = 278;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label1.ForeColor = Color.DarkGoldenrod;
            label1.Location = new Point(220, 281);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(46, 22);
            label1.TabIndex = 14;
            label1.Text = "الثمن:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(173, 235);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(93, 22);
            label2.TabIndex = 13;
            label2.Text = "الطول الحالي:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.WhiteSmoke;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label3.Location = new Point(168, 189);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(98, 22);
            label3.TabIndex = 12;
            label3.Text = "الطول الأولي: ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.WhiteSmoke;
            label4.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label4.Location = new Point(211, 146);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(51, 22);
            label4.TabIndex = 11;
            label4.Text = "اللون: ";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.WhiteSmoke;
            label5.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label5.Location = new Point(217, 101);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(47, 22);
            label5.TabIndex = 10;
            label5.Text = "الفئة: ";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.WhiteSmoke;
            label6.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(217, 56);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(47, 22);
            label6.TabIndex = 9;
            label6.Text = "النوع:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.WhiteSmoke;
            label7.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(225, 14);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(41, 22);
            label7.TabIndex = 8;
            label7.Text = "رقم: ";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblProductDate
            // 
            lblProductDate.AutoSize = true;
            lblProductDate.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProductDate.Location = new Point(3, 309);
            lblProductDate.Name = "lblProductDate";
            lblProductDate.RightToLeft = RightToLeft.Yes;
            lblProductDate.Size = new Size(85, 20);
            lblProductDate.TabIndex = 7;
            lblProductDate.Text = "25/07/2024";
            // 
            // btnSell
            // 
            btnSell.BackColor = Color.FromArgb(0, 192, 0);
            btnSell.Cursor = Cursors.Hand;
            btnSell.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            btnSell.Image = TailorSoft.Properties.Resources.sell_icon;
            btnSell.ImageAlign = ContentAlignment.MiddleRight;
            btnSell.Location = new Point(252, 277);
            btnSell.Name = "btnSell";
            btnSell.Padding = new Padding(20, 5, 5, 5);
            btnSell.Size = new Size(113, 52);
            btnSell.TabIndex = 0;
            btnSell.Text = "بيع";
            btnSell.TextAlign = ContentAlignment.MiddleLeft;
            btnSell.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnSell.UseVisualStyleBackColor = false;
            btnSell.Click += btnSell_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.BackColor = Color.DodgerBlue;
            btnEditProduct.Cursor = Cursors.Hand;
            btnEditProduct.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditProduct.Image = TailorSoft.Properties.Resources.edit_icon_32;
            btnEditProduct.ImageAlign = ContentAlignment.MiddleRight;
            btnEditProduct.Location = new Point(135, 277);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Padding = new Padding(5);
            btnEditProduct.Size = new Size(113, 52);
            btnEditProduct.TabIndex = 1;
            btnEditProduct.Text = "تعديل";
            btnEditProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnEditProduct.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnEditProduct.UseVisualStyleBackColor = false;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.BackColor = Color.Red;
            btnDeleteProduct.Cursor = Cursors.Hand;
            btnDeleteProduct.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteProduct.Image = TailorSoft.Properties.Resources.Delete_icon_32;
            btnDeleteProduct.ImageAlign = ContentAlignment.MiddleRight;
            btnDeleteProduct.Location = new Point(19, 277);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Padding = new Padding(5);
            btnDeleteProduct.Size = new Size(113, 52);
            btnDeleteProduct.TabIndex = 2;
            btnDeleteProduct.Text = "حذف";
            btnDeleteProduct.TextAlign = ContentAlignment.MiddleLeft;
            btnDeleteProduct.UseVisualStyleBackColor = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // pbProduct
            // 
            pbProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbProduct.Image = TailorSoft.Properties.Resources.empty_image_icon_512;
            pbProduct.Location = new Point(19, 14);
            pbProduct.Name = "pbProduct";
            pbProduct.Size = new Size(346, 256);
            pbProduct.SizeMode = PictureBoxSizeMode.Zoom;
            pbProduct.TabIndex = 0;
            pbProduct.TabStop = false;
            // 
            // txtProductID
            // 
            txtProductID.AutoEllipsis = true;
            txtProductID.BackColor = Color.White;
            txtProductID.BorderStyle = BorderStyle.Fixed3D;
            txtProductID.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductID.Location = new Point(21, 14);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(210, 23);
            txtProductID.TabIndex = 22;
            txtProductID.Text = "00";
            // 
            // txtProductColor
            // 
            txtProductColor.AutoEllipsis = true;
            txtProductColor.BackColor = Color.White;
            txtProductColor.BorderStyle = BorderStyle.Fixed3D;
            txtProductColor.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductColor.Location = new Point(21, 146);
            txtProductColor.Name = "txtProductColor";
            txtProductColor.Size = new Size(193, 23);
            txtProductColor.TabIndex = 23;
            txtProductColor.Text = "00";
            // 
            // txtProductInitialLength
            // 
            txtProductInitialLength.AutoEllipsis = true;
            txtProductInitialLength.BackColor = Color.White;
            txtProductInitialLength.BorderStyle = BorderStyle.Fixed3D;
            txtProductInitialLength.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductInitialLength.Location = new Point(21, 189);
            txtProductInitialLength.Name = "txtProductInitialLength";
            txtProductInitialLength.Size = new Size(150, 23);
            txtProductInitialLength.TabIndex = 24;
            txtProductInitialLength.Text = "00";
            // 
            // txtProductStockLength
            // 
            txtProductStockLength.AutoEllipsis = true;
            txtProductStockLength.BackColor = Color.White;
            txtProductStockLength.BorderStyle = BorderStyle.Fixed3D;
            txtProductStockLength.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductStockLength.Location = new Point(21, 235);
            txtProductStockLength.Name = "txtProductStockLength";
            txtProductStockLength.Size = new Size(150, 23);
            txtProductStockLength.TabIndex = 25;
            txtProductStockLength.Text = "00";
            // 
            // txtProductPrice
            // 
            txtProductPrice.AutoEllipsis = true;
            txtProductPrice.BackColor = Color.White;
            txtProductPrice.BorderStyle = BorderStyle.Fixed3D;
            txtProductPrice.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductPrice.Location = new Point(21, 281);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(198, 23);
            txtProductPrice.TabIndex = 26;
            txtProductPrice.Text = "00";
            // 
            // txtProductCategory
            // 
            txtProductCategory.AutoEllipsis = true;
            txtProductCategory.BackColor = Color.White;
            txtProductCategory.BorderStyle = BorderStyle.Fixed3D;
            txtProductCategory.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductCategory.Location = new Point(21, 101);
            txtProductCategory.Name = "txtProductCategory";
            txtProductCategory.Size = new Size(198, 23);
            txtProductCategory.TabIndex = 27;
            txtProductCategory.Text = "00";
            // 
            // txtProductType
            // 
            txtProductType.AutoEllipsis = true;
            txtProductType.BackColor = Color.White;
            txtProductType.BorderStyle = BorderStyle.Fixed3D;
            txtProductType.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductType.Location = new Point(21, 56);
            txtProductType.Name = "txtProductType";
            txtProductType.Size = new Size(198, 23);
            txtProductType.TabIndex = 28;
            txtProductType.Text = "00";
            // 
            // ucProductItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(splitContainer1);
            Name = "ucProductItem";
            Size = new Size(668, 334);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnDeleteProduct;
        private PictureBox pbProduct;
        private Button btnEditProduct;
        private Label lblProductDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnSell;
        private Label txtProductID;
        private Label txtProductType;
        private Label txtProductCategory;
        private Label txtProductPrice;
        private Label txtProductStockLength;
        private Label txtProductInitialLength;
        private Label txtProductColor;
    }
}
