namespace TailorSoft.User.Forms
{
    partial class frmUpdateUser
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
            ucUpdateUser1 = new TailorSoft.User.Controls.ucUpdateUser();
            SuspendLayout();
            // 
            // ucUpdateUser1
            // 
            ucUpdateUser1.BackColor = Color.White;
            ucUpdateUser1.Dock = DockStyle.Fill;
            ucUpdateUser1.Font = new Font("Times New Roman", 9F);
            ucUpdateUser1.Location = new Point(0, 0);
            ucUpdateUser1.Name = "ucUpdateUser1";
            ucUpdateUser1.RightToLeft = RightToLeft.Yes;
            ucUpdateUser1.Size = new Size(1044, 534);
            ucUpdateUser1.TabIndex = 0;
            // 
            // frmUpdateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1044, 534);
            Controls.Add(ucUpdateUser1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUpdateUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmUpdateUser";
            ResumeLayout(false);
        }

        #endregion

        private Controls.ucUpdateUser ucUpdateUser1;
    }
}