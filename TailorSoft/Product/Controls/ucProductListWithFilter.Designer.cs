namespace TailorSoft.Product.Controls
{
    partial class ucProductListWithFilter
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
            label1 = new Label();
            cbProductType = new ComboBox();
            cbFindBy = new ComboBox();
            label2 = new Label();
            btnAddNewProduct = new Button();
            txtSearch = new TextBox();
            pbIconSearch = new PictureBox();
            lblNumberOfProductItems = new Label();
            ucProductList1 = new ucProductList();
            ((System.ComponentModel.ISupportInitialize)pbIconSearch).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(919, 32);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(42, 19);
            label1.TabIndex = 2;
            label1.Text = "النوع:";
            // 
            // cbProductType
            // 
            cbProductType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbProductType.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProductType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbProductType.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbProductType.FormattingEnabled = true;
            cbProductType.Location = new Point(722, 29);
            cbProductType.Name = "cbProductType";
            cbProductType.RightToLeft = RightToLeft.Yes;
            cbProductType.Size = new Size(191, 25);
            cbProductType.TabIndex = 10;
            cbProductType.SelectedIndexChanged += cbProductType_SelectedIndexChanged;
            // 
            // cbFindBy
            // 
            cbFindBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFindBy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFindBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFindBy.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Location = new Point(722, 73);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.RightToLeft = RightToLeft.Yes;
            cbFindBy.Size = new Size(173, 25);
            cbFindBy.TabIndex = 12;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(903, 76);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(58, 19);
            label2.TabIndex = 11;
            label2.Text = "البحث ب:";
            // 
            // btnAddNewProduct
            // 
            btnAddNewProduct.BackColor = Color.WhiteSmoke;
            btnAddNewProduct.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            btnAddNewProduct.Image = Properties.Resources.add_icon_32;
            btnAddNewProduct.ImageAlign = ContentAlignment.TopCenter;
            btnAddNewProduct.Location = new Point(25, 29);
            btnAddNewProduct.Name = "btnAddNewProduct";
            btnAddNewProduct.RightToLeft = RightToLeft.Yes;
            btnAddNewProduct.Size = new Size(131, 69);
            btnAddNewProduct.TabIndex = 13;
            btnAddNewProduct.Text = "إضافة منتج جديد";
            btnAddNewProduct.TextAlign = ContentAlignment.BottomCenter;
            btnAddNewProduct.UseVisualStyleBackColor = false;
            btnAddNewProduct.Click += btnAddNewProduct_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI Light", 13.25F);
            txtSearch.Location = new Point(208, 48);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث ...";
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Size = new Size(465, 31);
            txtSearch.TabIndex = 14;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.VisibleChanged += txtSearch_VisibleChanged;
            // 
            // pbIconSearch
            // 
            pbIconSearch.Image = Properties.Resources.icon_search_32;
            pbIconSearch.Location = new Point(217, 49);
            pbIconSearch.Name = "pbIconSearch";
            pbIconSearch.Size = new Size(41, 28);
            pbIconSearch.SizeMode = PictureBoxSizeMode.Zoom;
            pbIconSearch.TabIndex = 15;
            pbIconSearch.TabStop = false;
            // 
            // lblNumberOfProductItems
            // 
            lblNumberOfProductItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblNumberOfProductItems.AutoEllipsis = true;
            lblNumberOfProductItems.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblNumberOfProductItems.Location = new Point(685, 583);
            lblNumberOfProductItems.Name = "lblNumberOfProductItems";
            lblNumberOfProductItems.RightToLeft = RightToLeft.Yes;
            lblNumberOfProductItems.Size = new Size(276, 19);
            lblNumberOfProductItems.TabIndex = 16;
            lblNumberOfProductItems.Text = "عدد المنتجات: 0";
            // 
            // ucProductList1
            // 
            ucProductList1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucProductList1.BackColor = Color.White;
            ucProductList1.Location = new Point(25, 144);
            ucProductList1.Name = "ucProductList1";
            ucProductList1.Size = new Size(936, 413);
            ucProductList1.TabIndex = 17;
            ucProductList1.OnProductItemsCountChanged += ucProductList1_OnProductItemsCountChanged;
            // 
            // ucProductListWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ucProductList1);
            Controls.Add(lblNumberOfProductItems);
            Controls.Add(pbIconSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnAddNewProduct);
            Controls.Add(cbFindBy);
            Controls.Add(label2);
            Controls.Add(cbProductType);
            Controls.Add(label1);
            Name = "ucProductListWithFilter";
            Size = new Size(995, 618);
            SizeChanged += ucProductListWithFilter_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)pbIconSearch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbProductType;
        private ComboBox cbFindBy;
        private Label label2;
        private Button btnAddNewProduct;
        private TextBox txtSearch;
        private PictureBox pbIconSearch;
        private Label lblNumberOfProductItems;
        private ucProductList ucProductList1;
    }
}
