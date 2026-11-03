namespace TailorSoft.Store.Forms
{
    partial class frmUpdateStoreInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateStoreInfo));
            btnClose = new Button();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            btnAddImage = new Button();
            pbStoreLogo = new PictureBox();
            label6 = new Label();
            txtAddress = new TextBox();
            label2 = new Label();
            label4 = new Label();
            txtStoreName = new TextBox();
            txtPhone = new TextBox();
            lblTitle = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStoreLogo).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClose.BackColor = Color.FromArgb(190, 62, 70);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(155, 45, 54);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(210, 78, 86);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(79, 566);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5);
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 20;
            btnClose.Text = "Fermer";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(37, 99, 170);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 78, 137);
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(49, 119, 195);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(338, 566);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 21;
            btnSave.Text = "Enregistrer";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(btnAddImage);
            groupBox1.Controls.Add(pbStoreLogo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtStoreName);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.ForeColor = Color.FromArgb(51, 65, 85);
            groupBox1.Location = new Point(12, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(572, 440);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            // 
            // btnAddImage
            // 
            btnAddImage.Anchor = AnchorStyles.Top;
            btnAddImage.BackColor = Color.FromArgb(239, 246, 255);
            btnAddImage.FlatAppearance.BorderColor = Color.FromArgb(191, 219, 254);
            btnAddImage.FlatAppearance.BorderSize = 1;
            btnAddImage.FlatAppearance.MouseDownBackColor = Color.FromArgb(219, 234, 254);
            btnAddImage.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 238, 255);
            btnAddImage.FlatStyle = FlatStyle.Flat;
            btnAddImage.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddImage.ForeColor = Color.FromArgb(30, 64, 112);
            btnAddImage.Image = Properties.Resources.add_icon_32;
            btnAddImage.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddImage.Location = new Point(162, 371);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Padding = new Padding(0, 0, 5, 0);
            btnAddImage.Size = new Size(246, 51);
            btnAddImage.TabIndex = 24;
            btnAddImage.Text = "Ajouter le logo du magasin";
            btnAddImage.TextAlign = ContentAlignment.MiddleRight;
            btnAddImage.UseVisualStyleBackColor = false;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // pbStoreLogo
            // 
            pbStoreLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbStoreLogo.BackColor = Color.FromArgb(245, 248, 252);
            pbStoreLogo.BorderStyle = BorderStyle.FixedSingle;
            pbStoreLogo.Image = Properties.Resources.empty_image_icon_512;
            pbStoreLogo.InitialImage = Properties.Resources.empty_image_icon_512;
            pbStoreLogo.Location = new Point(15, 214);
            pbStoreLogo.Name = "pbStoreLogo";
            pbStoreLogo.Size = new Size(541, 137);
            pbStoreLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbStoreLogo.TabIndex = 23;
            pbStoreLogo.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(51, 65, 85);
            label6.Location = new Point(15, 151);
            label6.Name = "label6";
            label6.Size = new Size(77, 21);
            label6.TabIndex = 15;
            label6.Text = "Adresse :";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(162, 145);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(394, 34);
            txtAddress.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(51, 65, 85);
            label2.Location = new Point(15, 40);
            label2.Name = "label2";
            label2.Size = new Size(141, 21);
            label2.TabIndex = 2;
            label2.Text = "Nom du magasin :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(51, 65, 85);
            label4.Location = new Point(15, 92);
            label4.Name = "label4";
            label4.Size = new Size(94, 21);
            label4.TabIndex = 4;
            label4.Text = "Téléphone :";
            // 
            // txtStoreName
            // 
            txtStoreName.BorderStyle = BorderStyle.FixedSingle;
            txtStoreName.Font = new Font("Segoe UI", 10F);
            txtStoreName.Location = new Point(162, 41);
            txtStoreName.Name = "txtStoreName";
            txtStoreName.Size = new Size(394, 23);
            txtStoreName.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(162, 93);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(394, 23);
            txtPhone.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(30, 45, 68);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(596, 77);
            lblTitle.TabIndex = 19;
            lblTitle.Text = "Informations du magasin";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // frmUpdateStoreInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 245, 249);
            ClientSize = new Size(596, 661);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(groupBox1);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUpdateStoreInfo";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modifier les informations du magasin";
            Load += frmUpdateStoreInfo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStoreLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private Button btnSave;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox txtAddress;
        private Label label2;
        private Label label4;
        private TextBox txtStoreName;
        private TextBox txtPhone;
        private Label lblTitle;
        private PictureBox pbStoreLogo;
        private Button btnAddImage;
    }
}