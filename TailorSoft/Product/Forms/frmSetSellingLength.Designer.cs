namespace TailorSoft.Product.Forms
{
    partial class frmSetSellingLength
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
            nudSellingLength = new NumericUpDown();
            btnClose = new Button();
            btnSave = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)nudSellingLength).BeginInit();
            SuspendLayout();
            // 
            // nudSellingLength
            // 
            nudSellingLength.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nudSellingLength.DecimalPlaces = 1;
            nudSellingLength.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nudSellingLength.Location = new Point(132, 76);
            nudSellingLength.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudSellingLength.Name = "nudSellingLength";
            nudSellingLength.Size = new Size(224, 43);
            nudSellingLength.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(63, 171);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5);
            btnClose.Size = new Size(126, 51);
            btnClose.TabIndex = 19;
            btnClose.Text = "Fermer";
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
            btnSave.Location = new Point(277, 171);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(136, 51);
            btnSave.TabIndex = 20;
            btnSave.Text = "Confirmer";
            btnSave.TextAlign = ContentAlignment.MiddleRight;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Firebrick;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 178);
            lblTitle.ForeColor = Color.Transparent;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(492, 59);
            lblTitle.TabIndex = 21;
            lblTitle.Text = "Entrez la quantité que vous souhaitez vendre";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmSetSellingLength
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(492, 234);
            Controls.Add(lblTitle);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(nudSellingLength);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSetSellingLength";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmSetSellingLength_Load;
            ((System.ComponentModel.ISupportInitialize)nudSellingLength).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private NumericUpDown nudSellingLength;
        private Button btnClose;
        private Button btnSave;
        private Label lblTitle;
    }
}