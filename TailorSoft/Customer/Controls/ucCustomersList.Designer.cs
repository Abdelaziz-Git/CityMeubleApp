using WinFormsControlsLibrary;
namespace TailorSoft.Customer.Controls
{
    partial class ucCustomersList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvCustomersList = new CustomDataGridView();
            btnAddNewCustomer = new Button();
            txtSearch = new TextBox();
            cbFindBy = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomersList).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomersList
            // 
            dgvCustomersList.AllowUserToAddRows = false;
            dgvCustomersList.AllowUserToDeleteRows = false;
            dgvCustomersList.AllowUserToOrderColumns = true;
            dgvCustomersList.AlternateRowBackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dgvCustomersList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCustomersList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomersList.BackgroundColor = Color.White;
            dgvCustomersList.BorderStyle = BorderStyle.Fixed3D;
            dgvCustomersList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCustomersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCustomersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(5, 2, 5, 2);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvCustomersList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvCustomersList.EnableHeadersVisualStyles = false;
            dgvCustomersList.GridColor = Color.FromArgb(230, 230, 230);
            dgvCustomersList.HeaderBackColor = Color.FromArgb(52, 152, 219);
            dgvCustomersList.HeaderForeColor = Color.White;
            dgvCustomersList.Location = new Point(40, 114);
            dgvCustomersList.Name = "dgvCustomersList";
            dgvCustomersList.ReadOnly = true;
            dgvCustomersList.RowHeadersVisible = false;
            dgvCustomersList.SelectionBackColorCustom = Color.FromArgb(41, 128, 185);
            dgvCustomersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomersList.Size = new Size(1084, 518);
            dgvCustomersList.TabIndex = 0;
            // 
            // btnAddNewCustomer
            // 
            btnAddNewCustomer.BackColor = Color.WhiteSmoke;
            btnAddNewCustomer.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            btnAddNewCustomer.Image = Properties.Resources.add_icon_32;
            btnAddNewCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddNewCustomer.Location = new Point(40, 56);
            btnAddNewCustomer.Name = "btnAddNewCustomer";
            btnAddNewCustomer.Padding = new Padding(10);
            btnAddNewCustomer.RightToLeft = RightToLeft.Yes;
            btnAddNewCustomer.Size = new Size(175, 53);
            btnAddNewCustomer.TabIndex = 14;
            btnAddNewCustomer.Text = "إضافة زبون جديد";
            btnAddNewCustomer.TextAlign = ContentAlignment.MiddleRight;
            btnAddNewCustomer.UseVisualStyleBackColor = false;
            btnAddNewCustomer.Click += btnAddNewCustomer_Click;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(329, 65);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث ...";
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Size = new Size(535, 33);
            txtSearch.TabIndex = 17;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cbFindBy
            // 
            cbFindBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFindBy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFindBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFindBy.DropDownHeight = 120;
            cbFindBy.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFindBy.FormattingEnabled = true;
            cbFindBy.IntegralHeight = false;
            cbFindBy.Items.AddRange(new object[] { "رقم الهاتف", "الاسم الشخصي", "الاسم العائلي" });
            cbFindBy.Location = new Point(885, 69);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.RightToLeft = RightToLeft.Yes;
            cbFindBy.Size = new Size(173, 25);
            cbFindBy.TabIndex = 16;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1066, 72);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(58, 19);
            label2.TabIndex = 15;
            label2.Text = "البحث ب:";
            // 
            // ucCustomersList
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(txtSearch);
            Controls.Add(cbFindBy);
            Controls.Add(label2);
            Controls.Add(btnAddNewCustomer);
            Controls.Add(dgvCustomersList);
            Name = "ucCustomersList";
            Size = new Size(1166, 705);
            Load += ucCustomersList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomersList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomDataGridView dgvCustomersList;
        private Button btnAddNewCustomer;
        private TextBox txtSearch;
        private ComboBox cbFindBy;
        private Label label2;
    }
}
