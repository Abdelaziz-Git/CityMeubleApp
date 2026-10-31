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
            btnClose.BackColor = Color.Red;
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnClose.Image = Properties.Resources.Close_icon_32;
            btnClose.ImageAlign = ContentAlignment.MiddleLeft;
            btnClose.Location = new Point(79, 566);
            btnClose.Name = "btnClose";
            btnClose.Padding = new Padding(5);
            btnClose.Size = new Size(168, 51);
            btnClose.TabIndex = 20;
            btnClose.Text = "إغلاق";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.BackColor = Color.DarkGreen;
            btnSave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            btnSave.Image = Properties.Resources.Save_icon_32;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(338, 566);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(5);
            btnSave.Size = new Size(168, 51);
            btnSave.TabIndex = 21;
            btnSave.Text = "حفظ";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top;
            groupBox1.BackColor = Color.Black;
            groupBox1.Controls.Add(btnAddImage);
            groupBox1.Controls.Add(pbStoreLogo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtStoreName);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(12, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(572, 440);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            // 
            // btnAddImage
            // 
            btnAddImage.Anchor = AnchorStyles.Top;
            btnAddImage.BackColor = Color.White;
            btnAddImage.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddImage.ForeColor = Color.Black;
            btnAddImage.Image = Properties.Resources.add_icon_32;
            btnAddImage.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddImage.Location = new Point(198, 368);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Padding = new Padding(0, 0, 5, 0);
            btnAddImage.Size = new Size(174, 51);
            btnAddImage.TabIndex = 24;
            btnAddImage.Text = "إضافة شعار المحل";
            btnAddImage.TextAlign = ContentAlignment.MiddleRight;
            btnAddImage.UseVisualStyleBackColor = false;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // pbStoreLogo
            // 
            pbStoreLogo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbStoreLogo.Image = Properties.Resources.empty_image_icon_512;
            pbStoreLogo.InitialImage = Properties.Resources.empty_image_icon_512;
            pbStoreLogo.Location = new Point(15, 213);
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
            label6.Location = new Point(500, 151);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 15;
            label6.Text = "العنوان:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(15, 145);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(479, 34);
            txtAddress.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(474, 40);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 2;
            label2.Text = "اسم المحل:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(500, 92);
            label4.Name = "label4";
            label4.Size = new Size(56, 21);
            label4.TabIndex = 4;
            label4.Text = "الهاتف:";
            // 
            // txtStoreName
            // 
            txtStoreName.Location = new Point(15, 41);
            txtStoreName.Name = "txtStoreName";
            txtStoreName.Size = new Size(453, 23);
            txtStoreName.TabIndex = 8;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(15, 93);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(479, 23);
            txtPhone.TabIndex = 11;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(596, 77);
            lblTitle.TabIndex = 19;
            lblTitle.Text = "معلومات المحل التجاري";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // frmUpdateStoreInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
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
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
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