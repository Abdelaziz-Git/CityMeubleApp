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
            btnSearch = new Button();
            btnAddNewCustomer = new Button();
            gbFilter.SuspendLayout();
            SuspendLayout();
            // 
            // ucCustomerCard1
            // 
            ucCustomerCard1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ucCustomerCard1.BackColor = Color.White;
            ucCustomerCard1.Location = new Point(7, 92);
            ucCustomerCard1.Name = "ucCustomerCard1";
            ucCustomerCard1.RightToLeft = RightToLeft.Yes;
            ucCustomerCard1.Size = new Size(697, 321);
            ucCustomerCard1.TabIndex = 0;
            ucCustomerCard1.Load += ucCustomerCard1_Load;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI Light", 12.25F);
            txtSearch.Location = new Point(96, 33);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث ...";
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Size = new Size(273, 29);
            txtSearch.TabIndex = 0;
            // 
            // cbFindBy
            // 
            cbFindBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFindBy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFindBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFindBy.Font = new Font("Times New Roman", 11.25F);
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Items.AddRange(new object[] { "رقم الهاتف", "رقم الزبون" });
            cbFindBy.Location = new Point(375, 35);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.RightToLeft = RightToLeft.Yes;
            cbFindBy.Size = new Size(153, 25);
            cbFindBy.TabIndex = 16;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(534, 38);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(58, 19);
            label2.TabIndex = 15;
            label2.Text = "البحث ب:";
            // 
            // gbFilter
            // 
            gbFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbFilter.Controls.Add(btnSearch);
            gbFilter.Controls.Add(txtSearch);
            gbFilter.Controls.Add(label2);
            gbFilter.Controls.Add(cbFindBy);
            gbFilter.Location = new Point(112, -1);
            gbFilter.Name = "gbFilter";
            gbFilter.Size = new Size(598, 90);
            gbFilter.TabIndex = 18;
            gbFilter.TabStop = false;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.LightSkyBlue;
            btnSearch.Image = Properties.Resources.icon_search_32;
            btnSearch.Location = new Point(12, 16);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 62);
            btnSearch.TabIndex = 19;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnAddNewCustomer
            // 
            btnAddNewCustomer.BackColor = Color.LightSkyBlue;
            btnAddNewCustomer.Font = new Font("Times New Roman", 13.25F);
            btnAddNewCustomer.ForeColor = Color.Black;
            btnAddNewCustomer.Image = Properties.Resources.add_icon_32;
            btnAddNewCustomer.ImageAlign = ContentAlignment.TopCenter;
            btnAddNewCustomer.Location = new Point(7, 5);
            btnAddNewCustomer.Name = "btnAddNewCustomer";
            btnAddNewCustomer.RightToLeft = RightToLeft.Yes;
            btnAddNewCustomer.Size = new Size(99, 85);
            btnAddNewCustomer.TabIndex = 19;
            btnAddNewCustomer.Text = "إضافة زبون جديد";
            btnAddNewCustomer.TextAlign = ContentAlignment.BottomCenter;
            btnAddNewCustomer.UseVisualStyleBackColor = false;
            btnAddNewCustomer.Click += btnAddNewCustomer_Click_1;
            // 
            // ucCustomerCardWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnAddNewCustomer);
            Controls.Add(gbFilter);
            Controls.Add(ucCustomerCard1);
            Name = "ucCustomerCardWithFilter";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(713, 415);
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
