namespace TailorSoft
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            txtUsername = new TextBox();
            pictureBox1 = new PictureBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnLogin = new Button();
            errorProvider1 = new ErrorProvider(components);
            chkRememberMe = new CheckBox();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(467, 178);
            txtUsername.Name = "txtUsername";
            txtUsername.RightToLeft = RightToLeft.Yes;
            txtUsername.Size = new Size(204, 23);
            txtUsername.TabIndex = 0;
            txtUsername.Validating += txtUsername_Validating;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = Properties.Resources.مفروشات_منزلية;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(407, 485);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(467, 252);
            txtPassword.Name = "txtPassword";
            txtPassword.RightToLeft = RightToLeft.Yes;
            txtPassword.Size = new Size(204, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Validating += txtPassword_Validating;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(242, 233, 225);
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(129, 66, 86);
            label1.Location = new Point(407, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(314, 93);
            label1.TabIndex = 3;
            label1.Text = "مرحبا بك";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.UseMnemonic = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(129, 66, 86);
            label2.Location = new Point(569, 150);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(106, 21);
            label2.TabIndex = 4;
            label2.Text = "اسم المستخدم:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(129, 66, 86);
            label3.Location = new Point(588, 227);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(87, 21);
            label3.TabIndex = 5;
            label3.Text = "كلمة المرور:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(129, 66, 86);
            btnLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(493, 356);
            btnLogin.Name = "btnLogin";
            btnLogin.RightToLeft = RightToLeft.Yes;
            btnLogin.Size = new Size(154, 46);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "تسجيل الدخول";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // chkRememberMe
            // 
            chkRememberMe.AutoSize = true;
            chkRememberMe.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkRememberMe.ForeColor = Color.FromArgb(129, 66, 86);
            chkRememberMe.Location = new Point(503, 286);
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.RightToLeft = RightToLeft.Yes;
            chkRememberMe.Size = new Size(132, 21);
            chkRememberMe.TabIndex = 7;
            chkRememberMe.Text = "تذكر تسجيل الدخول";
            chkRememberMe.UseVisualStyleBackColor = true;
            chkRememberMe.CheckedChanged += chkRememberMe_CheckedChanged;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(242, 233, 225);
            label4.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(129, 66, 86);
            label4.Location = new Point(0, 329);
            label4.Name = "label4";
            label4.Size = new Size(407, 45);
            label4.TabIndex = 8;
            label4.Text = "المفروشات المنزلية";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.user_icon_24;
            pictureBox2.Location = new Point(441, 177);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.Password_icon_24;
            pictureBox3.Location = new Point(441, 251);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 233, 225);
            ClientSize = new Size(721, 485);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(label4);
            Controls.Add(chkRememberMe);
            Controls.Add(btnLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox1);
            Controls.Add(txtUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تسجيل الدخول";
            FormClosed += frmLogin_FormClosed;
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private PictureBox pictureBox1;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnLogin;
        private ErrorProvider errorProvider1;
        private CheckBox chkRememberMe;
        private Label label4;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}
