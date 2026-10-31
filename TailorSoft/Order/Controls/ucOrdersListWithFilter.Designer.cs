namespace TailorSoft.Order.Controls
{
    partial class ucOrdersListWithFilter
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
            lblNumberOfOrders = new Label();
            txtSearch = new TextBox();
            btnAddNewOrder = new Button();
            cbFindBy = new ComboBox();
            label2 = new Label();
            ucOrdersList1 = new ucOrdersList();
            cbOrderStatus = new ComboBox();
            dtpDate = new DateTimePicker();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // lblNumberOfOrders
            // 
            lblNumberOfOrders.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblNumberOfOrders.AutoEllipsis = true;
            lblNumberOfOrders.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            lblNumberOfOrders.Location = new Point(733, 517);
            lblNumberOfOrders.Name = "lblNumberOfOrders";
            lblNumberOfOrders.RightToLeft = RightToLeft.Yes;
            lblNumberOfOrders.Size = new Size(276, 19);
            lblNumberOfOrders.TabIndex = 17;
            lblNumberOfOrders.Text = "عدد الطلبات: 0";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI Light", 13.25F);
            txtSearch.Location = new Point(279, 51);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "ابحث ...";
            txtSearch.RightToLeft = RightToLeft.Yes;
            txtSearch.Size = new Size(381, 31);
            txtSearch.TabIndex = 23;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnAddNewOrder
            // 
            btnAddNewOrder.BackColor = Color.WhiteSmoke;
            btnAddNewOrder.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            btnAddNewOrder.Image = Properties.Resources.add_icon_32;
            btnAddNewOrder.ImageAlign = ContentAlignment.TopCenter;
            btnAddNewOrder.Location = new Point(26, 32);
            btnAddNewOrder.Name = "btnAddNewOrder";
            btnAddNewOrder.RightToLeft = RightToLeft.Yes;
            btnAddNewOrder.Size = new Size(131, 69);
            btnAddNewOrder.TabIndex = 22;
            btnAddNewOrder.Text = "إضافة طلب جديد";
            btnAddNewOrder.TextAlign = ContentAlignment.BottomCenter;
            btnAddNewOrder.UseVisualStyleBackColor = false;
            btnAddNewOrder.Click += btnAddNewOrder_Click;
            // 
            // cbFindBy
            // 
            cbFindBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbFindBy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFindBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFindBy.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Location = new Point(686, 52);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.RightToLeft = RightToLeft.Yes;
            cbFindBy.Size = new Size(173, 29);
            cbFindBy.TabIndex = 21;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(867, 57);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(58, 19);
            label2.TabIndex = 20;
            label2.Text = "البحث ب:";
            // 
            // ucOrdersList1
            // 
            ucOrdersList1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucOrdersList1.BackColor = Color.White;
            ucOrdersList1.Location = new Point(26, 105);
            ucOrdersList1.Name = "ucOrdersList1";
            ucOrdersList1.Size = new Size(983, 396);
            ucOrdersList1.TabIndex = 24;
            // 
            // cbOrderStatus
            // 
            cbOrderStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbOrderStatus.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbOrderStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbOrderStatus.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbOrderStatus.FormattingEnabled = true;
            cbOrderStatus.Location = new Point(487, 53);
            cbOrderStatus.Name = "cbOrderStatus";
            cbOrderStatus.RightToLeft = RightToLeft.Yes;
            cbOrderStatus.Size = new Size(173, 27);
            cbOrderStatus.TabIndex = 25;
            cbOrderStatus.SelectedIndexChanged += cbOrderStatus_SelectedIndexChanged;
            // 
            // dtpDate
            // 
            dtpDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDate.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(511, 52);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(149, 29);
            dtpDate.TabIndex = 26;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Image = Properties.Resources.Refresh_icon_32;
            btnRefresh.Location = new Point(951, 43);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(58, 46);
            btnRefresh.TabIndex = 27;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // ucOrdersListWithFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRefresh);
            Controls.Add(dtpDate);
            Controls.Add(cbOrderStatus);
            Controls.Add(ucOrdersList1);
            Controls.Add(txtSearch);
            Controls.Add(btnAddNewOrder);
            Controls.Add(cbFindBy);
            Controls.Add(label2);
            Controls.Add(lblNumberOfOrders);
            Name = "ucOrdersListWithFilter";
            Size = new Size(1042, 549);
            Load += ucOrdersListWithFilter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNumberOfOrders;
        private TextBox txtSearch;
        private Button btnAddNewOrder;
        private ComboBox cbFindBy;
        private Label label2;
        private ucOrdersList ucOrdersList1;
        private ComboBox cbOrderStatus;
        private DateTimePicker dtpDate;
        private Button btnRefresh;
    }
}
