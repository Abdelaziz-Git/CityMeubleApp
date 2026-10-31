namespace TailorSoft.User.Controls
{
    partial class ucAddUser
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
            lblTitle = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            txtCity = new TextBox();
            label6 = new Label();
            txtAddress = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            tabControl2 = new TabControl();
            tabPage2 = new TabPage();
            txtConfirmPassword = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtPassword = new TextBox();
            label9 = new Label();
            txtUsername = new TextBox();
            btnClose = new Button();
            btnSave = new Button();
            flpPermissions = new FlowLayoutPanel();
            label10 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Red;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1005, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "إضافة مستخدم جديد";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(326, 63);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(675, 161);
            tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(txtCity);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(txtAddress);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(txtFirstName);
            tabPage1.Controls.Add(txtLastName);
            tabPage1.Controls.Add(txtPhone);
            tabPage1.Controls.Add(txtEmail);
            tabPage1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(667, 128);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "معلومات المستخدم";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(581, 78);
            label1.Name = "label1";
            label1.Size = new Size(72, 21);
            label1.TabIndex = 40;
            label1.Text = "المدينة:**";
            // 
            // txtCity
            // 
            txtCity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCity.Location = new Point(371, 75);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(192, 27);
            txtCity.TabIndex = 41;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(298, 78);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 39;
            label6.Text = "العنوان:";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAddress.Location = new Point(14, 75);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(278, 27);
            txtAddress.TabIndex = 38;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(529, 14);
            label2.Name = "label2";
            label2.Size = new Size(124, 21);
            label2.TabIndex = 30;
            label2.Text = "الاسم الشخصي:**";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(260, 13);
            label3.Name = "label3";
            label3.Size = new Size(98, 21);
            label3.TabIndex = 31;
            label3.Text = "اسم العائلة:**";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(583, 46);
            label4.Name = "label4";
            label4.Size = new Size(70, 21);
            label4.TabIndex = 32;
            label4.Text = "الهاتف:**";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(309, 46);
            label5.Name = "label5";
            label5.Size = new Size(49, 21);
            label5.TabIndex = 33;
            label5.Text = "البريد:";
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtFirstName.Location = new Point(371, 12);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(158, 27);
            txtFirstName.TabIndex = 34;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtLastName.Location = new Point(14, 12);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(245, 27);
            txtLastName.TabIndex = 35;
            // 
            // txtPhone
            // 
            txtPhone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPhone.Location = new Point(371, 43);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(192, 27);
            txtPhone.TabIndex = 36;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtEmail.Location = new Point(14, 43);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(278, 27);
            txtEmail.TabIndex = 37;
            // 
            // tabControl2
            // 
            tabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl2.Location = new Point(322, 227);
            tabControl2.Name = "tabControl2";
            tabControl2.RightToLeftLayout = true;
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(675, 198);
            tabControl2.TabIndex = 31;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(txtConfirmPassword);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(txtPassword);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(txtUsername);
            tabPage2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(667, 165);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "معلومات تسجيل الدخول";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtConfirmPassword.Location = new Point(218, 115);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(188, 27);
            txtConfirmPassword.TabIndex = 38;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label8.Location = new Point(412, 117);
            label8.Name = "label8";
            label8.Size = new Size(139, 21);
            label8.TabIndex = 37;
            label8.Text = "تأكيد كلمة المرور: **";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label7.Location = new Point(446, 72);
            label7.Name = "label7";
            label7.Size = new Size(105, 21);
            label7.TabIndex = 35;
            label7.Text = "كلمة المرور: **";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPassword.Location = new Point(218, 71);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(222, 27);
            txtPassword.TabIndex = 36;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label9.Location = new Point(427, 26);
            label9.Name = "label9";
            label9.Size = new Size(124, 21);
            label9.TabIndex = 30;
            label9.Text = "اسم المستخدم: **";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtUsername.Location = new Point(218, 25);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(203, 27);
            txtUsername.TabIndex = 34;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(311, 454);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5);
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 33;
            btnClose.Text = "إغلاق";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(554, 454);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 34;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // flpPermissions
            // 
            flpPermissions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpPermissions.AutoScroll = true;
            flpPermissions.FlowDirection = FlowDirection.TopDown;
            flpPermissions.Location = new Point(25, 92);
            flpPermissions.Name = "flpPermissions";
            flpPermissions.Size = new Size(292, 330);
            flpPermissions.TabIndex = 35;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.BackColor = Color.WhiteSmoke;
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Font = new Font("Segoe UI", 11F);
            label10.Location = new Point(184, 63);
            label10.Name = "label10";
            label10.Size = new Size(133, 22);
            label10.TabIndex = 36;
            label10.Text = "صلاحيات المستخدم";
            // 
            // ucAddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label10);
            Controls.Add(flpPermissions);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(tabControl2);
            Controls.Add(tabControl1);
            Controls.Add(lblTitle);
            Name = "ucAddUser";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1005, 524);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private TextBox txtCity;
        private Label label6;
        private TextBox txtAddress;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TabControl tabControl2;
        private TabPage tabPage2;
        private Label label9;
        private TextBox txtUsername;
        private Label label8;
        private TextBox textBox2;
        private Label label7;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnClose;
        private Button btnSave;
        private FlowLayoutPanel flpPermissions;
        private Label label10;
    }
}
