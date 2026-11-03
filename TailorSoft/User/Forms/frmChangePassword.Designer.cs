namespace TailorSoft.User.Forms
{
    partial class frmChangePassword
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
            label2 = new Label();
            txtCurrentPassword = new TextBox();
            label1 = new Label();
            txtNewPassword = new TextBox();
            label3 = new Label();
            txtConfirmPassword = new TextBox();
            label4 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label2.Location = new Point(48, 142);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(153, 19);
            label2.TabIndex = 35;
            label2.Text = "Mot de passe actuel :";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(260, 137);
            txtCurrentPassword.Margin = new Padding(4);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.RightToLeft = RightToLeft.No;
            txtCurrentPassword.Size = new Size(200, 29);
            txtCurrentPassword.TabIndex = 36;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label1.Location = new Point(48, 197);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(169, 19);
            label1.TabIndex = 37;
            label1.Text = "Nouveau mot de passe :";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(260, 192);
            txtNewPassword.Margin = new Padding(4);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.RightToLeft = RightToLeft.No;
            txtNewPassword.Size = new Size(200, 29);
            txtNewPassword.TabIndex = 38;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            label3.Location = new Point(48, 258);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(193, 19);
            label3.TabIndex = 39;
            label3.Text = "Confirmer le mot de passe :";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(260, 253);
            txtConfirmPassword.Margin = new Padding(4);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.RightToLeft = RightToLeft.No;
            txtConfirmPassword.Size = new Size(200, 29);
            txtConfirmPassword.TabIndex = 40;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.BackColor = Color.IndianRed;
            label4.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(113, 44);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(300, 31);
            label4.TabIndex = 41;
            label4.Text = "Modifier le mot de passe";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.Location = new Point(49, 354);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5);
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 42;
            btnClose.Text = "Fermer";
            btnClose.TextImageRelation = TextImageRelation.ImageBeforeText;
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
            btnSave.Location = new Point(292, 354);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 43;
            btnSave.Text = "Enregistrer";
            btnSave.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // frmChangePassword
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(507, 445);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtConfirmPassword);
            Controls.Add(label1);
            Controls.Add(txtNewPassword);
            Controls.Add(label2);
            Controls.Add(txtCurrentPassword);
            Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChangePassword";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtCurrentPassword;
        private Label label1;
        private TextBox txtNewPassword;
        private Label label3;
        private TextBox txtConfirmPassword;
        private Label label4;
        private Button btnClose;
        private Button btnSave;
    }
}