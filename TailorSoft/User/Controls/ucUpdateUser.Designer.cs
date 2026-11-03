namespace TailorSoft.User.Controls
{
    partial class ucUpdateUser
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
            label10 = new Label();
            flpPermissions = new FlowLayoutPanel();
            btnClose = new Button();
            btnSave = new Button();
            tabControl2 = new TabControl();
            tabPage2 = new TabPage();
            chkStatus = new CheckBox();
            label9 = new Label();
            txtUsername = new TextBox();
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
            lblTitle = new Label();
            tabControl2.SuspendLayout();
            tabPage2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.BackColor = Color.WhiteSmoke;
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Font = new Font("Times New Roman", 12.25F);
            label10.Location = new Point(696, 73);
            label10.Name = "label10";
            label10.Size = new Size(204, 21);
            label10.TabIndex = 43;
            label10.Text = "Autorisations de l'utilisateur";
            // 
            // flpPermissions
            // 
            flpPermissions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpPermissions.AutoScroll = true;
            flpPermissions.FlowDirection = FlowDirection.TopDown;
            flpPermissions.Font = new Font("Times New Roman", 14.25F);
            flpPermissions.Location = new Point(696, 102);
            flpPermissions.Name = "flpPermissions";
            flpPermissions.Size = new Size(318, 330);
            flpPermissions.TabIndex = 42;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Times New Roman", 14.25F);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(239, 464);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5);
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 40;
            btnClose.Text = "Fermer";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Font = new Font("Times New Roman", 14.25F);
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(592, 464);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 41;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Font = new Font("Times New Roman", 12.25F);
            tabControl2.Location = new Point(17, 237);
            tabControl2.Name = "tabControl2";
            tabControl2.RightToLeft = RightToLeft.No;
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(675, 198);
            tabControl2.TabIndex = 39;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(chkStatus);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(txtUsername);
            tabPage2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(667, 166);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "Informations de connexion";
            // 
            // chkStatus
            // 
            chkStatus.AutoSize = true;
            chkStatus.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkStatus.Location = new Point(255, 105);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(155, 26);
            chkStatus.TabIndex = 36;
            chkStatus.Text = "Utilisateur actif";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(120, 51);
            label9.Name = "label9";
            label9.Size = new Size(176, 22);
            label9.TabIndex = 30;
            label9.Text = "Nom d'utilisateur : *";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(302, 49);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(276, 27);
            txtUsername.TabIndex = 34;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Font = new Font("Times New Roman", 12.25F);
            tabControl1.Location = new Point(17, 73);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.No;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(671, 161);
            tabControl1.TabIndex = 38;
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
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(663, 129);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Informations personnelles";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(14, 78);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 40;
            label1.Text = "Ville : *";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(104, 75);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(192, 27);
            txtCity.TabIndex = 41;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(309, 78);
            label6.Name = "label6";
            label6.Size = new Size(77, 21);
            label6.TabIndex = 39;
            label6.Text = "Adresse :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(388, 75);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(265, 27);
            txtAddress.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(14, 14);
            label2.Name = "label2";
            label2.Size = new Size(86, 21);
            label2.TabIndex = 30;
            label2.Text = "Prénom : *";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(309, 13);
            label3.Name = "label3";
            label3.Size = new Size(65, 21);
            label3.TabIndex = 31;
            label3.Text = "Nom : *";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(14, 46);
            label4.Name = "label4";
            label4.Size = new Size(53, 21);
            label4.TabIndex = 32;
            label4.Text = "Tél. : *";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(309, 46);
            label5.Name = "label5";
            label5.Size = new Size(62, 21);
            label5.TabIndex = 33;
            label5.Text = "E-mail :";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(104, 12);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(192, 27);
            txtFirstName.TabIndex = 34;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(388, 12);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(265, 27);
            txtLastName.TabIndex = 35;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(104, 43);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(192, 27);
            txtPhone.TabIndex = 36;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(388, 43);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(265, 27);
            txtEmail.TabIndex = 37;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Red;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1031, 50);
            lblTitle.TabIndex = 37;
            lblTitle.Text = "Modifier les informations de l'utilisateur";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucUpdateUser
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
            Font = new Font("Times New Roman", 9F);
            Name = "ucUpdateUser";
            RightToLeft = RightToLeft.No;
            Size = new Size(1031, 536);
            tabControl2.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private FlowLayoutPanel flpPermissions;
        private Button btnClose;
        private Button btnSave;
        private TabControl tabControl2;
        private TabPage tabPage2;
        private Label label9;
        private TextBox txtUsername;
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
        private Label lblTitle;
        private CheckBox chkStatus;
    }
}
