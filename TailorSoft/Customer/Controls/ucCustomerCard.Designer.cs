namespace TailorSoft.Customer.Controls
{
    partial class ucCustomerCard
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
            groupBox1 = new GroupBox();
            lblAdress = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblName = new Label();
            label3 = new Label();
            lblCreatedDate = new Label();
            label6 = new Label();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            lblCustomerID = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(lblAdress);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(lblPhone);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblCreatedDate);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblCustomerID);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.Brown;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.RightToLeft = RightToLeft.Yes;
            groupBox1.Size = new Size(734, 352);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            groupBox1.Text = "معلومات الزبون";
            // 
            // lblAdress
            // 
            lblAdress.Anchor = AnchorStyles.Top;
            lblAdress.AutoEllipsis = true;
            lblAdress.BackColor = Color.WhiteSmoke;
            lblAdress.BorderStyle = BorderStyle.Fixed3D;
            lblAdress.Font = new Font("Segoe UI Semibold", 11.75F, FontStyle.Bold);
            lblAdress.ForeColor = Color.Black;
            lblAdress.Location = new Point(57, 234);
            lblAdress.Name = "lblAdress";
            lblAdress.Size = new Size(578, 81);
            lblAdress.TabIndex = 21;
            lblAdress.Text = "[???]";
            lblAdress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Top;
            lblEmail.AutoEllipsis = true;
            lblEmail.BackColor = Color.WhiteSmoke;
            lblEmail.BorderStyle = BorderStyle.Fixed3D;
            lblEmail.Font = new Font("Segoe UI Semibold", 11.75F, FontStyle.Bold);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(57, 168);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(278, 24);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "[???]";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPhone
            // 
            lblPhone.Anchor = AnchorStyles.Top;
            lblPhone.AutoEllipsis = true;
            lblPhone.BackColor = Color.WhiteSmoke;
            lblPhone.BorderStyle = BorderStyle.Fixed3D;
            lblPhone.Font = new Font("Segoe UI Semibold", 11.75F, FontStyle.Bold);
            lblPhone.ForeColor = Color.Black;
            lblPhone.Location = new Point(396, 168);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(239, 24);
            lblPhone.TabIndex = 19;
            lblPhone.Text = "[???]";
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            lblName.Anchor = AnchorStyles.Top;
            lblName.AutoEllipsis = true;
            lblName.BackColor = Color.WhiteSmoke;
            lblName.BorderStyle = BorderStyle.Fixed3D;
            lblName.Font = new Font("Segoe UI Semibold", 11.75F, FontStyle.Bold);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(57, 103);
            lblName.Name = "lblName";
            lblName.Size = new Size(578, 24);
            lblName.TabIndex = 18;
            lblName.Text = "[???]";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Location = new Point(244, 50);
            label3.Name = "label3";
            label3.Size = new Size(101, 21);
            label3.TabIndex = 17;
            label3.Text = "تاريخ التسجيل:";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.Anchor = AnchorStyles.Top;
            lblCreatedDate.AutoEllipsis = true;
            lblCreatedDate.BackColor = Color.WhiteSmoke;
            lblCreatedDate.BorderStyle = BorderStyle.Fixed3D;
            lblCreatedDate.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreatedDate.ForeColor = Color.FromArgb(64, 64, 64);
            lblCreatedDate.Location = new Point(57, 48);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(181, 24);
            lblCreatedDate.TabIndex = 16;
            lblCreatedDate.Text = "?? / ?? / ????";
            lblCreatedDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(637, 264);
            label6.Name = "label6";
            label6.Size = new Size(60, 21);
            label6.TabIndex = 15;
            label6.Text = "العنوان:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(656, 50);
            label1.Name = "label1";
            label1.Size = new Size(41, 21);
            label1.TabIndex = 1;
            label1.Text = "رقم :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Location = new Point(644, 103);
            label2.Name = "label2";
            label2.Size = new Size(53, 21);
            label2.TabIndex = 2;
            label2.Text = "الاسم :";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label4.Location = new Point(641, 168);
            label4.Name = "label4";
            label4.Size = new Size(56, 21);
            label4.TabIndex = 4;
            label4.Text = "الهاتف:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(341, 168);
            label5.Name = "label5";
            label5.Size = new Size(49, 21);
            label5.TabIndex = 5;
            label5.Text = "البريد:";
            // 
            // lblCustomerID
            // 
            lblCustomerID.Anchor = AnchorStyles.Top;
            lblCustomerID.AutoEllipsis = true;
            lblCustomerID.BackColor = Color.WhiteSmoke;
            lblCustomerID.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerID.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold);
            lblCustomerID.ForeColor = Color.Black;
            lblCustomerID.Location = new Point(351, 47);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(284, 24);
            lblCustomerID.TabIndex = 10;
            lblCustomerID.Text = "[???]";
            lblCustomerID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucCustomerCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(groupBox1);
            Name = "ucCustomerCard";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(734, 352);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label6;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label lblCustomerID;
        private Label lblCreatedDate;
        private Label label3;
        private Label lblAdress;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblName;
    }
}
