namespace TailorSoft.Order.Controls
{
    partial class ucAddUpdateOrder
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblOrderID = new Label();
            txtNotes = new TextBox();
            cbOrderStatus = new ComboBox();
            label8 = new Label();
            lblCustomerID = new Label();
            dtpRequiredDate = new DateTimePicker();
            pnlOrderInfo = new Panel();
            pnlAmounts = new Panel();
            lblInitialAmount = new Label();
            lblTotalAmount = new Label();
            lblRemainingAmount = new Label();
            label9 = new Label();
            label7 = new Label();
            label10 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            ucOrderItemList1 = new TailorSoft.OrderItem.Controls.ucOrderItemList();
            pnlOrderInfo.SuspendLayout();
            pnlAmounts.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F);
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(184, 21);
            label1.TabIndex = 15;
            label1.Text = "Numéro de commande:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F);
            label2.Location = new Point(18, 79);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(196, 21);
            label2.TabIndex = 16;
            label2.Text = "Date de livraison requise:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F);
            label3.Location = new Point(18, 145);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(170, 21);
            label3.TabIndex = 17;
            label3.Text = "État de la commande:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14.25F);
            label4.Location = new Point(412, 106);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(58, 21);
            label4.TabIndex = 18;
            label4.Text = "Notes:";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoEllipsis = true;
            lblOrderID.BorderStyle = BorderStyle.Fixed3D;
            lblOrderID.Font = new Font("Times New Roman", 14.25F);
            lblOrderID.ForeColor = Color.Red;
            lblOrderID.Location = new Point(208, 17);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(166, 27);
            lblOrderID.TabIndex = 24;
            lblOrderID.Text = "[???]";
            lblOrderID.TextAlign = ContentAlignment.MiddleLeft;
            lblOrderID.Click += lblOrderID_Click;
            // 
            // txtNotes
            // 
            txtNotes.Font = new Font("Times New Roman", 14.25F);
            txtNotes.Location = new Point(476, 103);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(205, 29);
            txtNotes.TabIndex = 22;
            // 
            // cbOrderStatus
            // 
            cbOrderStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrderStatus.Font = new Font("Times New Roman", 14.25F);
            cbOrderStatus.FormattingEnabled = true;
            cbOrderStatus.Location = new Point(194, 142);
            cbOrderStatus.Name = "cbOrderStatus";
            cbOrderStatus.Size = new Size(215, 29);
            cbOrderStatus.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 14.25F);
            label8.Location = new Point(412, 42);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.No;
            label8.Size = new Size(141, 21);
            label8.TabIndex = 29;
            label8.Text = "Numéro de client:";
            // 
            // lblCustomerID
            // 
            lblCustomerID.AutoEllipsis = true;
            lblCustomerID.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerID.Font = new Font("Times New Roman", 14.25F);
            lblCustomerID.ForeColor = Color.Red;
            lblCustomerID.Location = new Point(559, 39);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(122, 27);
            lblCustomerID.TabIndex = 31;
            lblCustomerID.Text = "[???]";
            lblCustomerID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpRequiredDate
            // 
            dtpRequiredDate.CalendarFont = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpRequiredDate.Cursor = Cursors.Hand;
            dtpRequiredDate.CustomFormat = "dd/MM/yyyy";
            dtpRequiredDate.Font = new Font("Times New Roman", 14.25F);
            dtpRequiredDate.Format = DateTimePickerFormat.Custom;
            dtpRequiredDate.Location = new Point(220, 73);
            dtpRequiredDate.Name = "dtpRequiredDate";
            dtpRequiredDate.RightToLeft = RightToLeft.No;
            dtpRequiredDate.Size = new Size(189, 29);
            dtpRequiredDate.TabIndex = 32;
            // 
            // pnlOrderInfo
            // 
            pnlOrderInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlOrderInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlOrderInfo.Controls.Add(pnlAmounts);
            pnlOrderInfo.Controls.Add(cbOrderStatus);
            pnlOrderInfo.Controls.Add(label4);
            pnlOrderInfo.Controls.Add(label8);
            pnlOrderInfo.Controls.Add(dtpRequiredDate);
            pnlOrderInfo.Controls.Add(label1);
            pnlOrderInfo.Controls.Add(txtNotes);
            pnlOrderInfo.Controls.Add(lblOrderID);
            pnlOrderInfo.Controls.Add(label2);
            pnlOrderInfo.Controls.Add(label3);
            pnlOrderInfo.Controls.Add(lblCustomerID);
            pnlOrderInfo.Location = new Point(3, 32);
            pnlOrderInfo.Name = "pnlOrderInfo";
            pnlOrderInfo.Size = new Size(1126, 192);
            pnlOrderInfo.TabIndex = 33;
            // 
            // pnlAmounts
            // 
            pnlAmounts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAmounts.BorderStyle = BorderStyle.FixedSingle;
            pnlAmounts.Controls.Add(lblInitialAmount);
            pnlAmounts.Controls.Add(lblTotalAmount);
            pnlAmounts.Controls.Add(lblRemainingAmount);
            pnlAmounts.Controls.Add(label9);
            pnlAmounts.Controls.Add(label7);
            pnlAmounts.Controls.Add(label10);
            pnlAmounts.Location = new Point(696, 14);
            pnlAmounts.Name = "pnlAmounts";
            pnlAmounts.Size = new Size(414, 152);
            pnlAmounts.TabIndex = 36;
            // 
            // lblInitialAmount
            // 
            lblInitialAmount.Anchor = AnchorStyles.Top;
            lblInitialAmount.AutoEllipsis = true;
            lblInitialAmount.BackColor = Color.White;
            lblInitialAmount.BorderStyle = BorderStyle.FixedSingle;
            lblInitialAmount.Font = new Font("Times New Roman", 18F);
            lblInitialAmount.ForeColor = Color.Black;
            lblInitialAmount.Location = new Point(203, 15);
            lblInitialAmount.Name = "lblInitialAmount";
            lblInitialAmount.Padding = new Padding(0, 0, 5, 0);
            lblInitialAmount.RightToLeft = RightToLeft.No;
            lblInitialAmount.Size = new Size(193, 31);
            lblInitialAmount.TabIndex = 36;
            lblInitialAmount.Text = "00 EUR";
            lblInitialAmount.TextAlign = ContentAlignment.MiddleLeft;
            lblInitialAmount.Click += lblInitialAmount_Click;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Anchor = AnchorStyles.Top;
            lblTotalAmount.AutoEllipsis = true;
            lblTotalAmount.BackColor = Color.White;
            lblTotalAmount.BorderStyle = BorderStyle.FixedSingle;
            lblTotalAmount.Font = new Font("Times New Roman", 18F);
            lblTotalAmount.Location = new Point(195, 105);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Padding = new Padding(0, 0, 5, 0);
            lblTotalAmount.RightToLeft = RightToLeft.No;
            lblTotalAmount.Size = new Size(201, 31);
            lblTotalAmount.TabIndex = 38;
            lblTotalAmount.Text = "00 EUR";
            lblTotalAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRemainingAmount
            // 
            lblRemainingAmount.Anchor = AnchorStyles.Top;
            lblRemainingAmount.AutoEllipsis = true;
            lblRemainingAmount.BackColor = Color.White;
            lblRemainingAmount.BorderStyle = BorderStyle.FixedSingle;
            lblRemainingAmount.Font = new Font("Times New Roman", 18F);
            lblRemainingAmount.Location = new Point(225, 59);
            lblRemainingAmount.Name = "lblRemainingAmount";
            lblRemainingAmount.Padding = new Padding(0, 0, 5, 0);
            lblRemainingAmount.RightToLeft = RightToLeft.No;
            lblRemainingAmount.Size = new Size(171, 31);
            lblRemainingAmount.TabIndex = 37;
            lblRemainingAmount.Text = "00 EUR";
            lblRemainingAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.BackColor = Color.DeepSkyBlue;
            label9.Font = new Font("Times New Roman", 20.25F);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(18, 15);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.No;
            label9.Size = new Size(179, 31);
            label9.TabIndex = 33;
            label9.Text = "Montant payé: ";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.BackColor = Color.Crimson;
            label7.Font = new Font("Times New Roman", 20.25F);
            label7.Location = new Point(18, 105);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.No;
            label7.Size = new Size(171, 31);
            label7.TabIndex = 35;
            label7.Text = "Montant total:";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.BackColor = Color.Lime;
            label10.Font = new Font("Times New Roman", 20.25F);
            label10.Location = new Point(18, 59);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.No;
            label10.Size = new Size(201, 31);
            label10.TabIndex = 34;
            label10.Text = "Montant restant: ";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.BackColor = Color.DarkGray;
            label5.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(5, 2);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(1122, 26);
            label5.TabIndex = 34;
            label5.Text = "Informations de la commande";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.BackColor = Color.DarkGray;
            label6.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 242);
            label6.Name = "label6";
            label6.Size = new Size(1124, 22);
            label6.TabIndex = 36;
            label6.Text = "Éléments de la commande";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.Location = new Point(290, 542);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(0, 0, 5, 0);
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 37;
            btnClose.Text = "Fermer";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.Location = new Point(681, 542);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(0, 0, 5, 0);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 38;
            btnSave.Text = "Enregistrer";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // ucOrderItemList1
            // 
            ucOrderItemList1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ucOrderItemList1.BackColor = Color.White;
            ucOrderItemList1.Location = new Point(5, 267);
            ucOrderItemList1.Name = "ucOrderItemList1";
            ucOrderItemList1.RightToLeft = RightToLeft.No;
            ucOrderItemList1.Size = new Size(1123, 251);
            ucOrderItemList1.TabIndex = 39;
            ucOrderItemList1.OnItemsChanged += UcOrderItemList1_OnItemsChanged;
            // 
            // ucAddUpdateOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(ucOrderItemList1);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(pnlOrderInfo);
            Name = "ucAddUpdateOrder";
            Size = new Size(1132, 605);
            pnlOrderInfo.ResumeLayout(false);
            pnlOrderInfo.PerformLayout();
            pnlAmounts.ResumeLayout(false);
            pnlAmounts.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtProductPrice;
        private Label label4;
        private TextBox txtProductStockLength;
        private TextBox txtProductInitialLength;
        private TextBox txtProductColor;
        private Label lblOrderID;
        private TextBox txtNotes;
        private ComboBox cbOrderStatus;
        private Label label8;
        private Label lblCustomerID;
        private DateTimePicker dtpRequiredDate;
        private Panel pnlOrderInfo;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label label10;
        private Panel pnlAmounts;
        private Label lblInitialAmount;
        private Label lblTotalAmount;
        private Label lblRemainingAmount;
        private Button btnClose;
        private Button btnSave;
        private OrderItem.Controls.ucOrderItemList ucOrderItemList1;
    }
}
