namespace TailorSoft.Customers.Controls
{
    partial class ucAddUpdateCustomer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            btnSave = new Button();
            btnClose = new Button();
            errorProvider1 = new ErrorProvider(components);
            lblCustomerID = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold);
            lblTitle.Location = new Point(237, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(212, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "إضافة عميل جديد";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(627, 35);
            label1.Name = "label1";
            label1.Size = new Size(41, 21);
            label1.TabIndex = 1;
            label1.Text = "رقم :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(583, 86);
            label2.Name = "label2";
            label2.Size = new Size(85, 21);
            label2.TabIndex = 2;
            label2.Text = "الاسم الأول:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(279, 86);
            label3.Name = "label3";
            label3.Size = new Size(84, 21);
            label3.TabIndex = 3;
            label3.Text = "اسم العائلة:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(612, 150);
            label4.Name = "label4";
            label4.Size = new Size(56, 21);
            label4.TabIndex = 4;
            label4.Text = "الهاتف:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(312, 150);
            label5.Name = "label5";
            label5.Size = new Size(49, 21);
            label5.TabIndex = 5;
            label5.Text = "البريد:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(389, 85);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(191, 23);
            txtFirstName.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(28, 85);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(245, 23);
            txtLastName.TabIndex = 9;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(389, 149);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(217, 23);
            txtPhone.TabIndex = 11;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(28, 149);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(278, 23);
            txtEmail.TabIndex = 12;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(28, 202);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(578, 88);
            txtAddress.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(389, 385);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5, 5, 5, 5);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 18;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(145, 385);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5, 5, 5, 5);
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
            // lblCustomerID
            // 
            lblCustomerID.AutoSize = true;
            lblCustomerID.ForeColor = Color.Red;
            lblCustomerID.Location = new Point(591, 38);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(30, 15);
            lblCustomerID.TabIndex = 10;
            lblCustomerID.Text = "[???]";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblCustomerID);
            groupBox1.Controls.Add(txtFirstName);
            groupBox1.Controls.Add(txtLastName);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Location = new Point(6, 56);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(685, 302);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(608, 236);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 15;
            label6.Text = "العنوان:";
            // 
            // ucAddUpdateCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            Name = "ucAddUpdateCustomer";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(699, 459);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnClose;
        private ErrorProvider errorProvider1;
        private Label lblCustomerID;
        private GroupBox groupBox1;
        private Label label6;
    }
}