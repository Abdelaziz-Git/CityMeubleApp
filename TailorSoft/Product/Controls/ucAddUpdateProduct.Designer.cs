namespace HFS.Product.Controls
{
    partial class ucAddUpdateProduct
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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtProductCategory = new TextBox();
            cbProductType = new ComboBox();
            lblProductID = new Label();
            txtProductColor = new TextBox();
            txtProductInitialLength = new TextBox();
            txtProductStockLength = new TextBox();
            txtProductPrice = new TextBox();
            pbProductImage = new PictureBox();
            btnAddImage = new Button();
            groupBox1 = new GroupBox();
            btnSave = new Button();
            btnClose = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)pbProductImage).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(332, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(203, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "إضافة منتج جديد";
            lblTitle.TextChanged += lblTitle_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(594, 35);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(41, 21);
            label1.TabIndex = 1;
            label1.Text = "رقم :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(595, 86);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(40, 21);
            label2.TabIndex = 2;
            label2.Text = "نوع :";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(341, 86);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(39, 21);
            label3.TabIndex = 3;
            label3.Text = "فئة :";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(584, 149);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(51, 21);
            label4.TabIndex = 4;
            label4.Text = "اللون :";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(239, 149);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(141, 21);
            label5.TabIndex = 5;
            label5.Text = "الطول الأولي بالمتر :";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(481, 205);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(154, 21);
            label6.TabIndex = 6;
            label6.Text = "الطول المخزون بالمتر :";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(179, 205);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.Yes;
            label7.Size = new Size(104, 21);
            label7.TabIndex = 7;
            label7.Text = "الثمن بالدرهم :";
            // 
            // txtProductCategory
            // 
            txtProductCategory.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductCategory.Location = new Point(28, 85);
            txtProductCategory.Name = "txtProductCategory";
            txtProductCategory.Size = new Size(307, 23);
            txtProductCategory.TabIndex = 8;
            txtProductCategory.Validating += txtProductCategory_Validating;
            // 
            // cbProductType
            // 
            cbProductType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbProductType.FormattingEnabled = true;
            cbProductType.Items.AddRange(new object[] { "طلامط", "وسادة", "ستائر", "سامبل", "أكسيسوار" });
            cbProductType.Location = new Point(403, 85);
            cbProductType.Name = "cbProductType";
            cbProductType.Size = new Size(191, 23);
            cbProductType.TabIndex = 9;
            cbProductType.Validating += cbProductType_Validating;
            // 
            // lblProductID
            // 
            lblProductID.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProductID.AutoSize = true;
            lblProductID.ForeColor = Color.Red;
            lblProductID.Location = new Point(564, 38);
            lblProductID.Name = "lblProductID";
            lblProductID.Size = new Size(30, 15);
            lblProductID.TabIndex = 10;
            lblProductID.Text = "[???]";
            // 
            // txtProductColor
            // 
            txtProductColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductColor.Location = new Point(401, 148);
            txtProductColor.Name = "txtProductColor";
            txtProductColor.Size = new Size(179, 23);
            txtProductColor.TabIndex = 11;
            txtProductColor.Validating += txtProductColor_Validating;
            // 
            // txtProductInitialLength
            // 
            txtProductInitialLength.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductInitialLength.Location = new Point(28, 148);
            txtProductInitialLength.Name = "txtProductInitialLength";
            txtProductInitialLength.Size = new Size(205, 23);
            txtProductInitialLength.TabIndex = 12;
            txtProductInitialLength.Validating += txtProductInitialLength_Validating;
            // 
            // txtProductStockLength
            // 
            txtProductStockLength.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductStockLength.Location = new Point(307, 207);
            txtProductStockLength.Name = "txtProductStockLength";
            txtProductStockLength.Size = new Size(168, 23);
            txtProductStockLength.TabIndex = 13;
            txtProductStockLength.Validating += txtProductStockLength_Validating;
            // 
            // txtProductPrice
            // 
            txtProductPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductPrice.Location = new Point(28, 207);
            txtProductPrice.Name = "txtProductPrice";
            txtProductPrice.Size = new Size(145, 23);
            txtProductPrice.TabIndex = 14;
            txtProductPrice.Validating += txtProductPrice_Validating;
            // 
            // pbProductImage
            // 
            pbProductImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbProductImage.Image = TailorSoft.Properties.Resources.empty_image_icon_512;
            pbProductImage.InitialImage = TailorSoft.Properties.Resources.empty_image_icon_512;
            pbProductImage.Location = new Point(28, 255);
            pbProductImage.Name = "pbProductImage";
            pbProductImage.Size = new Size(607, 137);
            pbProductImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbProductImage.TabIndex = 15;
            pbProductImage.TabStop = false;
            pbProductImage.Validating += pbProductImage_Validating;
            // 
            // btnAddImage
            // 
            btnAddImage.Anchor = AnchorStyles.Top;
            btnAddImage.BackColor = Color.RoyalBlue;
            btnAddImage.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddImage.Image = TailorSoft.Properties.Resources.add_icon_32;
            btnAddImage.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddImage.Location = new Point(244, 398);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Padding = new Padding(0, 0, 5, 0);
            btnAddImage.Size = new Size(174, 51);
            btnAddImage.TabIndex = 16;
            btnAddImage.Text = "إضافة صورة المنتج";
            btnAddImage.TextAlign = ContentAlignment.MiddleRight;
            btnAddImage.UseVisualStyleBackColor = false;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.Controls.Add(pbProductImage);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnAddImage);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtProductPrice);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtProductStockLength);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtProductInitialLength);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtProductColor);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblProductID);
            groupBox1.Controls.Add(txtProductCategory);
            groupBox1.Controls.Add(cbProductType);
            groupBox1.Location = new Point(110, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(667, 469);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = TailorSoft.Properties.Resources.Save_icon_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(519, 586);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(0, 0, 5, 0);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 18;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = TailorSoft.Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(201, 586);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(0, 0, 5, 0);
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 18;
            btnClose.Text = "إغلاق";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ucAddUpdateProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Name = "ucAddUpdateProduct";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(888, 675);
            Load += ucAddProduct_Load;
            ((System.ComponentModel.ISupportInitialize)pbProductImage).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtProductCategory;
        private ComboBox cbProductType;
        private Label lblProductID;
        private TextBox txtProductColor;
        private TextBox txtProductInitialLength;
        private TextBox txtProductStockLength;
        private TextBox txtProductPrice;
        private PictureBox pbProductImage;
        private Button btnAddImage;
        private GroupBox groupBox1;
        private Button btnSave;
        private Button btnClose;
        private ErrorProvider errorProvider1;
    }
}
