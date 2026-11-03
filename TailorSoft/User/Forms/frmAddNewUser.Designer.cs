namespace TailorSoft.User.Forms
{
    partial class frmAddNewUser
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
            ucAddUser1 = new TailorSoft.User.Controls.ucAddUser();
            SuspendLayout();
            // 
            // ucAddUser1
            // 
            ucAddUser1.BackColor = Color.White;
            ucAddUser1.Dock = DockStyle.Fill;
            ucAddUser1.Location = new Point(0, 0);
            ucAddUser1.Name = "ucAddUser1";
            ucAddUser1.Size = new Size(1084, 549);
            ucAddUser1.TabIndex = 0;
            // 
            // frmAddNewUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1084, 549);
            Controls.Add(ucAddUser1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAddNewUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAddNewUser";
            ResumeLayout(false);
        }

        #endregion

        private Controls.ucAddUser ucAddUser1;
    }
}