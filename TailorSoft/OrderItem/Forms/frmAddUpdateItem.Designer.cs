namespace TailorSoft.OrderItem.Forms
{
    partial class frmAddUpdateItem
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
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblTotalPrice = new Label();
            txtNotes = new TextBox();
            txtUnitPrice = new TextBox();
            txtQuantity = new TextBox();
            txtProductName = new TextBox();
            txtProductID = new TextBox();
            groupBox1 = new GroupBox();
            btnClose = new Button();
            btnSave = new Button();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(2, 62, 138);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.No;
            lblTitle.Size = new Size(1076, 56);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Ajouter un nouvel article";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(661, 76);
            label8.Name = "label8";
            label8.Size = new Size(25, 25);
            label8.TabIndex = 28;
            label8.Text = "=";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(489, 79);
            label7.Name = "label7";
            label7.Size = new Size(18, 19);
            label7.TabIndex = 27;
            label7.Text = "X";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(926, 47);
            label6.Name = "label6";
            label6.Size = new Size(42, 19);
            label6.TabIndex = 26;
            label6.Text = "Note";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(746, 47);
            label5.Name = "label5";
            label5.Size = new Size(42, 19);
            label5.TabIndex = 25;
            label5.Text = "Total";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(527, 47);
            label4.Name = "label4";
            label4.Size = new Size(111, 19);
            label4.TabIndex = 24;
            label4.Text = "Prix unitaire (*)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(371, 47);
            label3.Name = "label3";
            label3.Size = new Size(86, 19);
            label3.TabIndex = 23;
            label3.Text = "Quantité (*)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(165, 47);
            label2.Name = "label2";
            label2.Size = new Size(137, 19);
            label2.TabIndex = 22;
            label2.Text = "Nom du produit (*)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 47);
            label1.Name = "label1";
            label1.Size = new Size(98, 19);
            label1.TabIndex = 21;
            label1.Text = "ID du produit";
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoEllipsis = true;
            lblTotalPrice.BackColor = Color.FromArgb(16, 24, 40);
            lblTotalPrice.BorderStyle = BorderStyle.FixedSingle;
            lblTotalPrice.Font = new Font("Segoe UI Semibold", 10.75F, FontStyle.Bold);
            lblTotalPrice.ForeColor = Color.FromArgb(102, 255, 178);
            lblTotalPrice.Location = new Point(685, 73);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(165, 30);
            lblTotalPrice.TabIndex = 20;
            lblTotalPrice.Text = "00 DH";
            lblTotalPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(858, 74);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(179, 29);
            txtNotes.TabIndex = 3;
            txtNotes.TextAlign = HorizontalAlignment.Center;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(510, 74);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(145, 29);
            txtUnitPrice.TabIndex = 2;
            txtUnitPrice.TextAlign = HorizontalAlignment.Center;
            txtUnitPrice.TextChanged += txtUnitPrice_TextChanged;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(345, 74);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(138, 29);
            txtQuantity.TabIndex = 1;
            txtQuantity.TextAlign = HorizontalAlignment.Center;
            txtQuantity.TextChanged += txtQuantity_TextChanged;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(144, 74);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(178, 29);
            txtProductName.TabIndex = 1;
            txtProductName.TextAlign = HorizontalAlignment.Center;
            txtProductName.TextChanged += txtProductName_TextChanged;
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(14, 74);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(114, 29);
            txtProductID.TabIndex = 15;
            txtProductID.TextAlign = HorizontalAlignment.Center;
            txtProductID.TextChanged += txtProductID_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(2, 62, 138);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtProductID);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtQuantity);
            groupBox1.Controls.Add(txtUnitPrice);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtNotes);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblTotalPrice);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 59);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.No;
            groupBox1.Size = new Size(1049, 147);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "Informations de l’article";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom;
            btnClose.BackColor = Color.FromArgb(200, 45, 55);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.Location = new Point(312, 226);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(0, 0, 5, 0);
            btnClose.RightToLeft = RightToLeft.No;
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 5;
            btnClose.Text = "Fermer";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom;
            btnSave.BackColor = Color.FromArgb(22, 140, 80);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.Location = new Point(630, 226);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(0, 0, 5, 0);
            btnSave.RightToLeft = RightToLeft.No;
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 4;
            btnSave.Text = "Enregistrer";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 244, 249);
            ClientSize = new Size(1076, 289);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddUpdateItem";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ajouter / Modifier un article";
            Load += frmAddUpdateItem_Load;
            SizeChanged += frmAddUpdateItem_SizeChanged;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblTotalPrice;
        private TextBox txtNotes;
        private TextBox txtUnitPrice;
        private TextBox txtQuantity;
        private TextBox txtProductName;
        private TextBox txtProductID;
        private GroupBox groupBox1;
        private Button btnClose;
        private Button btnSave;
        private ErrorProvider errorProvider1;
    }
}