namespace TailorSoft.Dashbord.Controls
{
    partial class ucStatisticsCards
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
            pnlAnnualIncome = new Panel();
            lblAnnualIncome = new Label();
            lblPanelIncomeTitle = new Label();
            pnlCustomers = new Panel();
            lblTotalCustomers = new Label();
            lblPanelCustomersTitle = new Label();
            pnlProducts = new Panel();
            lblTotalProducts = new Label();
            lblPanelProductsTitle = new Label();
            pnlOrders = new Panel();
            lblTotalOrders = new Label();
            lblPanelOrdersTitle = new Label();
            pnlAnnualIncome.SuspendLayout();
            pnlCustomers.SuspendLayout();
            pnlProducts.SuspendLayout();
            pnlOrders.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAnnualIncome
            // 
            pnlAnnualIncome.Anchor = AnchorStyles.Top;
            pnlAnnualIncome.BackColor = Color.Orange;
            pnlAnnualIncome.BorderStyle = BorderStyle.Fixed3D;
            pnlAnnualIncome.Controls.Add(lblAnnualIncome);
            pnlAnnualIncome.Controls.Add(lblPanelIncomeTitle);
            pnlAnnualIncome.Font = new Font("Arial", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlAnnualIncome.Location = new Point(946, 3);
            pnlAnnualIncome.Name = "pnlAnnualIncome";
            pnlAnnualIncome.Size = new Size(297, 127);
            pnlAnnualIncome.TabIndex = 9;
            // 
            // lblAnnualIncome
            // 
            lblAnnualIncome.AutoEllipsis = true;
            lblAnnualIncome.Dock = DockStyle.Fill;
            lblAnnualIncome.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAnnualIncome.ForeColor = Color.White;
            lblAnnualIncome.Location = new Point(0, 64);
            lblAnnualIncome.Name = "lblAnnualIncome";
            lblAnnualIncome.Size = new Size(293, 59);
            lblAnnualIncome.TabIndex = 2;
            lblAnnualIncome.Text = "1967386 د.م";
            lblAnnualIncome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPanelIncomeTitle
            // 
            lblPanelIncomeTitle.AutoEllipsis = true;
            lblPanelIncomeTitle.Dock = DockStyle.Top;
            lblPanelIncomeTitle.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanelIncomeTitle.ForeColor = Color.White;
            lblPanelIncomeTitle.Image = Properties.Resources.Incom_64;
            lblPanelIncomeTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblPanelIncomeTitle.Location = new Point(0, 0);
            lblPanelIncomeTitle.Name = "lblPanelIncomeTitle";
            lblPanelIncomeTitle.Padding = new Padding(0, 0, 5, 0);
            lblPanelIncomeTitle.Size = new Size(293, 64);
            lblPanelIncomeTitle.TabIndex = 1;
            lblPanelIncomeTitle.Text = "الدخل السنوي";
            lblPanelIncomeTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlCustomers
            // 
            pnlCustomers.Anchor = AnchorStyles.Top;
            pnlCustomers.BackColor = Color.Crimson;
            pnlCustomers.BorderStyle = BorderStyle.Fixed3D;
            pnlCustomers.Controls.Add(lblTotalCustomers);
            pnlCustomers.Controls.Add(lblPanelCustomersTitle);
            pnlCustomers.Font = new Font("Arial", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlCustomers.Location = new Point(327, 3);
            pnlCustomers.Name = "pnlCustomers";
            pnlCustomers.Size = new Size(297, 127);
            pnlCustomers.TabIndex = 8;
            // 
            // lblTotalCustomers
            // 
            lblTotalCustomers.AutoEllipsis = true;
            lblTotalCustomers.Dock = DockStyle.Fill;
            lblTotalCustomers.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalCustomers.ForeColor = Color.White;
            lblTotalCustomers.Location = new Point(0, 64);
            lblTotalCustomers.Name = "lblTotalCustomers";
            lblTotalCustomers.Size = new Size(293, 59);
            lblTotalCustomers.TabIndex = 2;
            lblTotalCustomers.Text = "13";
            lblTotalCustomers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPanelCustomersTitle
            // 
            lblPanelCustomersTitle.AutoEllipsis = true;
            lblPanelCustomersTitle.Dock = DockStyle.Top;
            lblPanelCustomersTitle.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanelCustomersTitle.ForeColor = Color.White;
            lblPanelCustomersTitle.Image = Properties.Resources.customers_64;
            lblPanelCustomersTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblPanelCustomersTitle.Location = new Point(0, 0);
            lblPanelCustomersTitle.Name = "lblPanelCustomersTitle";
            lblPanelCustomersTitle.Padding = new Padding(0, 0, 20, 0);
            lblPanelCustomersTitle.Size = new Size(293, 64);
            lblPanelCustomersTitle.TabIndex = 1;
            lblPanelCustomersTitle.Text = "الزبائن";
            lblPanelCustomersTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlProducts
            // 
            pnlProducts.Anchor = AnchorStyles.Top;
            pnlProducts.BackColor = Color.Lime;
            pnlProducts.BorderStyle = BorderStyle.Fixed3D;
            pnlProducts.Controls.Add(lblTotalProducts);
            pnlProducts.Controls.Add(lblPanelProductsTitle);
            pnlProducts.Font = new Font("Arial", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlProducts.Location = new Point(634, 3);
            pnlProducts.Name = "pnlProducts";
            pnlProducts.Size = new Size(297, 127);
            pnlProducts.TabIndex = 7;
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoEllipsis = true;
            lblTotalProducts.Dock = DockStyle.Fill;
            lblTotalProducts.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalProducts.ForeColor = Color.White;
            lblTotalProducts.Location = new Point(0, 64);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(293, 59);
            lblTotalProducts.TabIndex = 2;
            lblTotalProducts.Text = "356";
            lblTotalProducts.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPanelProductsTitle
            // 
            lblPanelProductsTitle.AutoEllipsis = true;
            lblPanelProductsTitle.Dock = DockStyle.Top;
            lblPanelProductsTitle.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanelProductsTitle.ForeColor = Color.White;
            lblPanelProductsTitle.Image = Properties.Resources.stock_64;
            lblPanelProductsTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblPanelProductsTitle.Location = new Point(0, 0);
            lblPanelProductsTitle.Name = "lblPanelProductsTitle";
            lblPanelProductsTitle.Padding = new Padding(0, 0, 20, 0);
            lblPanelProductsTitle.Size = new Size(293, 64);
            lblPanelProductsTitle.TabIndex = 1;
            lblPanelProductsTitle.Text = "المنتجات";
            lblPanelProductsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlOrders
            // 
            pnlOrders.Anchor = AnchorStyles.Top;
            pnlOrders.BackColor = SystemColors.HotTrack;
            pnlOrders.BorderStyle = BorderStyle.Fixed3D;
            pnlOrders.Controls.Add(lblTotalOrders);
            pnlOrders.Controls.Add(lblPanelOrdersTitle);
            pnlOrders.Font = new Font("Arial", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlOrders.Location = new Point(15, 3);
            pnlOrders.Name = "pnlOrders";
            pnlOrders.Size = new Size(297, 127);
            pnlOrders.TabIndex = 6;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoEllipsis = true;
            lblTotalOrders.BackColor = Color.Transparent;
            lblTotalOrders.Dock = DockStyle.Fill;
            lblTotalOrders.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(0, 66);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(293, 57);
            lblTotalOrders.TabIndex = 2;
            lblTotalOrders.Text = "194";
            lblTotalOrders.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPanelOrdersTitle
            // 
            lblPanelOrdersTitle.AutoEllipsis = true;
            lblPanelOrdersTitle.BackColor = Color.Transparent;
            lblPanelOrdersTitle.Dock = DockStyle.Top;
            lblPanelOrdersTitle.Font = new Font("Arial", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPanelOrdersTitle.ForeColor = Color.White;
            lblPanelOrdersTitle.Image = Properties.Resources.sales_64;
            lblPanelOrdersTitle.ImageAlign = ContentAlignment.MiddleRight;
            lblPanelOrdersTitle.Location = new Point(0, 0);
            lblPanelOrdersTitle.Name = "lblPanelOrdersTitle";
            lblPanelOrdersTitle.Padding = new Padding(0, 0, 20, 0);
            lblPanelOrdersTitle.Size = new Size(293, 66);
            lblPanelOrdersTitle.TabIndex = 1;
            lblPanelOrdersTitle.Text = "الطلبات";
            lblPanelOrdersTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucStatisticsCards
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlAnnualIncome);
            Controls.Add(pnlCustomers);
            Controls.Add(pnlProducts);
            Controls.Add(pnlOrders);
            Name = "ucStatisticsCards";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(1255, 135);
            pnlAnnualIncome.ResumeLayout(false);
            pnlCustomers.ResumeLayout(false);
            pnlProducts.ResumeLayout(false);
            pnlOrders.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAnnualIncome;
        private Label lblPanelIncomeTitle;
        private Panel pnlCustomers;
        private Label lblPanelCustomersTitle;
        private Panel pnlProducts;
        private Label lblPanelProductsTitle;
        private Panel pnlOrders;
        private Label lblPanelOrdersTitle;
        private Label lblAnnualIncome;
        private Label lblTotalCustomers;
        private Label lblTotalProducts;
        private Label lblTotalOrders;
    }
}
