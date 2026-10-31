namespace TailorSoft.Order.Forms
{
    partial class frmRecordPayment
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
            lblTitle = new Label();
            btnClose = new Button();
            btnSave = new Button();
            txtAmount = new TextBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Gainsboro;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 17.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(800, 87);
            lblTitle.TabIndex = 25;
            lblTitle.Text = "أكتب الطول الذي تريد بيعه من هذا الثوب:";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(164, 256);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5);
            btnClose.RightToLeft = RightToLeft.Yes;
            btnClose.Size = new Size(133, 51);
            btnClose.TabIndex = 23;
            btnClose.Text = "إغلاق";
            btnClose.TextAlign = ContentAlignment.MiddleRight;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(499, 256);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.RightToLeft = RightToLeft.Yes;
            btnSave.Size = new Size(133, 51);
            btnSave.TabIndex = 24;
            btnSave.Text = "تأكيد";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtAmount
            // 
            txtAmount.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAmount.Location = new Point(248, 147);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(294, 39);
            txtAmount.TabIndex = 1;
            // 
            // frmRecordPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 354);
            Controls.Add(txtAmount);
            Controls.Add(lblTitle);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRecordPayment";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnClose;
        private Button btnSave;
        private TextBox txtAmount;
    }
}