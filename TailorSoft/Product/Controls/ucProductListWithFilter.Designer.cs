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
            lblNumberOfProductItems = new Label();
            ucProductList1 = new ucProductList();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 32);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(47, 19);
            label1.TabIndex = 2;
            label1.Text = "Type:";
            // 
            // cbProductType
            // 
            cbProductType.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProductType.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbProductType.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbProductType.FormattingEnabled = true;
            cbProductType.Location = new Point(78, 29);
            cbProductType.Name = "cbProductType";
            cbProductType.RightToLeft = RightToLeft.No;
            cbProductType.Size = new Size(212, 25);
            cbProductType.TabIndex = 10;
            cbProductType.SelectedIndexChanged += cbProductType_SelectedIndexChanged;
            // 
            // cbFindBy
            // 
            cbFindBy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFindBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFindBy.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Location = new Point(149, 79);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.RightToLeft = RightToLeft.No;
            cbFindBy.Size = new Size(141, 25);
            cbFindBy.TabIndex = 12;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 82);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(118, 19);
            label2.TabIndex = 11;
            label2.Text = "Rechercher par:";
            // 
            // btnAddNewProduct
            // 
            btnAddNewProduct.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewProduct.BackColor = Color.WhiteSmoke;
            btnAddNewProduct.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            btnAddNewProduct.Image = Properties.Resources.add_icon_32;
            btnAddNewProduct.ImageAlign = ContentAlignment.TopCenter;
            btnAddNewProduct.Location = new Point(830, 29);
            btnAddNewProduct.Name = "btnAddNewProduct";
            btnAddNewProduct.RightToLeft = RightToLeft.No;
            btnAddNewProduct.Size = new Size(131, 89);
            btnAddNewProduct.TabIndex = 13;
            btnAddNewProduct.Text = "Ajouter un produit";
            btnAddNewProduct.TextAlign = ContentAlignment.BottomCenter;
            btnAddNewProduct.UseVisualStyleBackColor = false;
            btnAddNewProduct.Click += btnAddNewProduct_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI Light", 13.25F);
            txtSearch.Location = new Point(296, 76);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Rechercher ...";
            txtSearch.RightToLeft = RightToLeft.No;
            txtSearch.Size = new Size(330, 31);
            txtSearch.TabIndex = 14;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.VisibleChanged += txtSearch_VisibleChanged;
            // 
            // lblNumberOfProductItems
            // 
            lblNumberOfProductItems.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblNumberOfProductItems.AutoEllipsis = true;
            lblNumberOfProductItems.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblNumberOfProductItems.Location = new Point(25, 583);
            lblNumberOfProductItems.Name = "lblNumberOfProductItems";
            lblNumberOfProductItems.RightToLeft = RightToLeft.No;
            lblNumberOfProductItems.Size = new Size(276, 19);
            lblNumberOfProductItems.TabIndex = 16;
            lblNumberOfProductItems.Text = "Nombre de produits: 0";
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
            Controls.Add(txtSearch);
            Controls.Add(btnAddNewProduct);
            Controls.Add(cbFindBy);
            Controls.Add(label2);
            Controls.Add(cbProductType);
            Controls.Add(label1);
            Name = "ucProductListWithFilter";
            Size = new Size(995, 618);
            SizeChanged += ucProductListWithFilter_SizeChanged;
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
        private Label lblNumberOfProductItems;
        private ucProductList ucProductList1;
    }
}
