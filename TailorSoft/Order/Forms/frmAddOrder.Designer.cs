namespace TailorSoft.Order.Forms
{
    partial class frmAddOrder
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
            pnlSelectCustomer = new Panel();
            ucCustomerCardWithFilter1 = new TailorSoft.Customer.Controls.ucCustomerCardWithFilter();
            btnNext = new Button();
            lblTitle = new Label();
            pnlSelectCustomer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSelectCustomer
            // 
            pnlSelectCustomer.Controls.Add(ucCustomerCardWithFilter1);
            pnlSelectCustomer.Controls.Add(btnNext);
            pnlSelectCustomer.Controls.Add(lblTitle);
            pnlSelectCustomer.Dock = DockStyle.Fill;
            pnlSelectCustomer.Location = new Point(0, 0);
            pnlSelectCustomer.Margin = new Padding(4);
            pnlSelectCustomer.Name = "pnlSelectCustomer";
            pnlSelectCustomer.RightToLeft = RightToLeft.Yes;
            pnlSelectCustomer.Size = new Size(1195, 710);
            pnlSelectCustomer.TabIndex = 0;
            // 
            // ucCustomerCardWithFilter1
            // 
            ucCustomerCardWithFilter1.BackColor = Color.White;
            ucCustomerCardWithFilter1.Location = new Point(143, 99);
            ucCustomerCardWithFilter1.Margin = new Padding(4, 5, 4, 5);
            ucCustomerCardWithFilter1.Name = "ucCustomerCardWithFilter1";
            ucCustomerCardWithFilter1.RightToLeft = RightToLeft.Yes;
            ucCustomerCardWithFilter1.Size = new Size(908, 426);
            ucCustomerCardWithFilter1.TabIndex = 20;
            ucCustomerCardWithFilter1.OnCustomerSelected += ucCustomerCardWithFilter1_OnCustomerSelected;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom;
            btnNext.BackColor = Color.Gainsboro;
            btnNext.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            btnNext.Image = Properties.Resources.Next_Icon_White_32;
            btnNext.ImageAlign = ContentAlignment.MiddleRight;
            btnNext.Location = new Point(484, 552);
            btnNext.Margin = new Padding(4);
            btnNext.Name = "btnNext";
            btnNext.Padding = new Padding(15, 0, 30, 0);
            btnNext.Size = new Size(227, 53);
            btnNext.TabIndex = 19;
            btnNext.Text = "التالي";
            btnNext.TextAlign = ContentAlignment.MiddleLeft;
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1195, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "من فضلك, قم باختيار الزبون اولا.";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmAddOrder
            // 
            AcceptButton = btnNext;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1195, 710);
            Controls.Add(pnlSelectCustomer);
            Margin = new Padding(4);
            Name = "frmAddOrder";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += frmAddOrder_FormClosing;
            KeyPress += frmAddOrder_KeyPress;
            KeyUp += frmAddOrder_KeyUp;
            pnlSelectCustomer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSelectCustomer;
        private Label lblTitle;
        private Button btnNext;
        private Customer.Controls.ucCustomerCardWithFilter ucCustomerCardWithFilter1;
    }
}