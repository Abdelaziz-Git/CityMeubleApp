namespace TailorSoft.Activation
{
    partial class ActivationForm
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
            label1 = new Label();
            txtMachineId = new TextBox();
            label2 = new Label();
            btnCopy = new Button();
            listeBoxInstructions = new ListBox();
            label3 = new Label();
            btnLoadLicense = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(800, 48);
            label1.TabIndex = 0;
            label1.Text = "تفعيل البرنامج";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMachineId
            // 
            txtMachineId.Location = new Point(166, 197);
            txtMachineId.Multiline = true;
            txtMachineId.Name = "txtMachineId";
            txtMachineId.ReadOnly = true;
            txtMachineId.Size = new Size(484, 101);
            txtMachineId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(656, 237);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(123, 21);
            label2.TabIndex = 2;
            label2.Text = "رقم تعريف الجهاز:";
            // 
            // btnCopy
            // 
            btnCopy.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCopy.ForeColor = SystemColors.ButtonShadow;
            btnCopy.Location = new Point(76, 222);
            btnCopy.Name = "btnCopy";
            btnCopy.RightToLeft = RightToLeft.Yes;
            btnCopy.Size = new Size(75, 50);
            btnCopy.TabIndex = 3;
            btnCopy.Text = "نسخ";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // listeBoxInstructions
            // 
            listeBoxInstructions.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listeBoxInstructions.FormattingEnabled = true;
            listeBoxInstructions.ItemHeight = 19;
            listeBoxInstructions.Items.AddRange(new object[] { "1. انسخ مُعرّف جهازك", "2. أرسله إلى مزوّد الخدمة", "3. حمّل ملف الترخيص الذي استلمته" });
            listeBoxInstructions.Location = new Point(432, 84);
            listeBoxInstructions.Name = "listeBoxInstructions";
            listeBoxInstructions.RightToLeft = RightToLeft.Yes;
            listeBoxInstructions.Size = new Size(218, 80);
            listeBoxInstructions.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(590, 60);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(60, 21);
            label3.TabIndex = 5;
            label3.Text = "تعليمات:";
            // 
            // btnLoadLicense
            // 
            btnLoadLicense.BackColor = Color.FromArgb(0, 192, 0);
            btnLoadLicense.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLoadLicense.ForeColor = Color.Transparent;
            btnLoadLicense.Location = new Point(283, 319);
            btnLoadLicense.Name = "btnLoadLicense";
            btnLoadLicense.RightToLeft = RightToLeft.Yes;
            btnLoadLicense.Size = new Size(297, 67);
            btnLoadLicense.TabIndex = 6;
            btnLoadLicense.Text = "اضغط هنا لتحميل ملف الترخيص الذي استلمته";
            btnLoadLicense.UseVisualStyleBackColor = false;
            btnLoadLicense.Click += btnLoadLicense_Click;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = SystemColors.ActiveCaptionText;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Font = new Font("Times New Roman", 20.25F);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(0, 402);
            lblStatus.Name = "lblStatus";
            lblStatus.RightToLeft = RightToLeft.Yes;
            lblStatus.Size = new Size(800, 48);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "جهازك غير مفعل";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ActivationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(btnLoadLicense);
            Controls.Add(label3);
            Controls.Add(listeBoxInstructions);
            Controls.Add(btnCopy);
            Controls.Add(label2);
            Controls.Add(txtMachineId);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ActivationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ActivationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMachineId;
        private Label label2;
        private Button btnCopy;
        private ListBox listeBoxInstructions;
        private Label label3;
        private Button btnLoadLicense;
        private Label lblStatus;
    }
}