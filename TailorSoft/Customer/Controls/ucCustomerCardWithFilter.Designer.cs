namespace TailorSoft.Customer.Controls
{
    partial class ucCustomerCardWithFilter
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
            ucCustomerCard1 = new ucCustomerCard();
            txtSearch = new TextBox();
            cbFindBy = new ComboBox();
            label2 = new Label();
            gbFilter = new GroupBox();
            btnAddNewCustomer = new Button();
            btnSearch = new Button();
            gbFilter.SuspendLayout();
            SuspendLayout();
            // 
            // ucCustomerCard1
            // 
            ucCustomerCard1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucCustomerCard1.BackColor = Color.White;
            ucCustomerCard1.Location = new Point(0, 109);
            ucCustomerCard1.Name = "ucCustomerCard1";
            ucCustomerCard1.RightToLeft = RightToLeft.No;
            ucCustomerCard1.Size = new Size(778, 253);
            ucCustomerCard1.TabIndex = 0;
            ucCustomerCard1.Load += ucCustomerCard1_Load;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI Light", 12.25F);
            txtSearch.Location = new Point(280, 41);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Rechercher...";
            txtSearch.RightToLeft = RightToLeft.No;
            txtSearch.Size = new Size(214, 29);
            txtSearch.TabIndex = 0;
            // 
            // cbFindBy
            // 
            cbFindBy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFindBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFindBy.Font = new Font("Times New Roman", 11.25F);
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Items.AddRange(new object[] { "Numéro de téléphone", "Numéro de client" });
            cbFindBy.Location = new Point(134, 43);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.RightToLeft = RightToLeft.No;
            cbFindBy.Size = new Size(139, 25);
            cbFindBy.TabIndex = 16;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(122, 19);
            label2.TabIndex = 15;
            label2.Text = "Rechercher par :";
            // 
            // gbFilter
            // 
            gbFilter.Controls.Add(btnAddNewCustomer);
            gbFilter.Controls.Add(btnSearch);
            gbFilter.Controls.Add(txtSearch);
            gbFilter.Controls.Add(label2);
            gbFilter.Controls.Add(cbFindBy);
            gbFilter.Dock = DockStyle.Top;
            gbFilter.Location = new Point(0, 0);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(778, 103);
            gbFilter.TabIndex = 18;
            gbFilter.TabStop = false;
            // 
            // btnAddNewCustomer
            // 
            btnAddNewCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewCustomer.BackColor = Color.LightSkyBlue;
            btnAddNewCustomer.Font = new Font("Times New Roman", 13.25F);
            btnAddNewCustomer.ForeColor = Color.Black;
            btnAddNewCustomer.Image = Properties.Resources.add_icon_32;
            btnAddNewCustomer.Location = new Point(639, 21);
            btnAddNewCustomer.Name = "btnAddNewCustomer";
            btnAddNewCustomer.RightToLeft = RightToLeft.No;
            btnAddNewCustomer.Size = new Size(133, 69);
            btnAddNewCustomer.TabIndex = 19;
            btnAddNewCustomer.Text = "Ajouter Client";
            btnAddNewCustomer.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAddNewCustomer.UseVisualStyleBackColor = false;
            btnAddNewCustomer.Click += btnAddNewCustomer_Click_1;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.LightSkyBlue;
            btnSearch.Image = Properties.Resources.icon_search_32;
            btnSearch.Location = new Point(500, 33);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(61, 44);
            btnSearch.TabIndex = 19;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // ucCustomerCardWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(gbFilter);
            Controls.Add(ucCustomerCard1);
            Name = "ucCustomerCardWithFilter";
            RightToLeft = RightToLeft.No;
            Size = new Size(778, 364);
            Load += ucCustomerCardWithFilter_Load;
            gbFilter.ResumeLayout(false);
            gbFilter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ucCustomerCard ucCustomerCard1;
        private TextBox txtSearch;
        private ComboBox cbFindBy;
        private Label label2;
        private GroupBox gbFilter;
        private Button btnSearch;
        private Button btnAddNewCustomer;
    }
}
