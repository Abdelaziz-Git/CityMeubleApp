
using TailorSoft.Properties;
namespace TailorSoft
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            msMain = new MenuStrip();
            tsmiDashbord = new ToolStripMenuItem();
            tsmiProducts = new ToolStripMenuItem();
            tsmiCustomers = new ToolStripMenuItem();
            tsmiOrders = new ToolStripMenuItem();
            tsmiUsers = new ToolStripMenuItem();
            tsmiSettings = new ToolStripMenuItem();
            tsmiEditStoreInfo = new ToolStripMenuItem();
            tsmiChangePassword = new ToolStripMenuItem();
            tsmiSignOut = new ToolStripMenuItem();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // msMain
            // 
            msMain.AutoSize = false;
            msMain.BackColor = Color.WhiteSmoke;
            msMain.ImageScalingSize = new Size(40, 40);
            msMain.Items.AddRange(new ToolStripItem[] { tsmiDashbord, tsmiProducts, tsmiCustomers, tsmiOrders, tsmiUsers, tsmiSettings, tsmiSignOut });
            msMain.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.Padding = new Padding(0);
            msMain.RenderMode = ToolStripRenderMode.Professional;
            msMain.RightToLeft = RightToLeft.No;
            msMain.Size = new Size(979, 79);
            msMain.TabIndex = 3;
            msMain.Text = "menuStrip1";
            msMain.SizeChanged += msMain_SizeChanged;
            // 
            // tsmiDashbord
            // 
            tsmiDashbord.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiDashbord.Image = Resources.dashboard_32;
            tsmiDashbord.ImageScaling = ToolStripItemImageScaling.None;
            tsmiDashbord.Margin = new Padding(0, 0, 20, 0);
            tsmiDashbord.Name = "tsmiDashbord";
            tsmiDashbord.ShortcutKeys = Keys.Control | Keys.D3;
            tsmiDashbord.Size = new Size(174, 79);
            tsmiDashbord.Text = "Tableau de bord";
            tsmiDashbord.TextImageRelation = TextImageRelation.ImageAboveText;
            tsmiDashbord.Click += tsmiDashbord_Click;
            // 
            // tsmiProducts
            // 
            tsmiProducts.Font = new Font("Segoe UI", 15.75F);
            tsmiProducts.Image = Resources.Products_icon_32;
            tsmiProducts.ImageScaling = ToolStripItemImageScaling.None;
            tsmiProducts.ImageTransparentColor = Color.Transparent;
            tsmiProducts.Margin = new Padding(0, 0, 20, 0);
            tsmiProducts.Name = "tsmiProducts";
            tsmiProducts.RightToLeft = RightToLeft.No;
            tsmiProducts.ShortcutKeys = Keys.Control | Keys.D1;
            tsmiProducts.Size = new Size(101, 79);
            tsmiProducts.Text = "Produits";
            tsmiProducts.TextImageRelation = TextImageRelation.ImageAboveText;
            tsmiProducts.Click += tsmiProducts_Click;
            // 
            // tsmiCustomers
            // 
            tsmiCustomers.Font = new Font("Segoe UI", 15.75F);
            tsmiCustomers.Image = Resources.Customers_32;
            tsmiCustomers.ImageScaling = ToolStripItemImageScaling.None;
            tsmiCustomers.ImageTransparentColor = Color.Transparent;
            tsmiCustomers.Margin = new Padding(0, 0, 20, 0);
            tsmiCustomers.Name = "tsmiCustomers";
            tsmiCustomers.RightToLeft = RightToLeft.No;
            tsmiCustomers.ShortcutKeys = Keys.Control | Keys.D2;
            tsmiCustomers.Size = new Size(87, 79);
            tsmiCustomers.Text = "Clients";
            tsmiCustomers.TextImageRelation = TextImageRelation.ImageAboveText;
            tsmiCustomers.Click += tsmiCustomers_Click;
            // 
            // tsmiOrders
            // 
            tsmiOrders.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiOrders.Image = Resources.order_32;
            tsmiOrders.ImageScaling = ToolStripItemImageScaling.None;
            tsmiOrders.Margin = new Padding(0, 0, 20, 0);
            tsmiOrders.Name = "tsmiOrders";
            tsmiOrders.ShortcutKeys = Keys.Control | Keys.D3;
            tsmiOrders.Size = new Size(141, 79);
            tsmiOrders.Text = "Commandes";
            tsmiOrders.TextImageRelation = TextImageRelation.ImageAboveText;
            tsmiOrders.Click += tsmiOrders_Click;
            // 
            // tsmiUsers
            // 
            tsmiUsers.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiUsers.Image = Resources.icons8_users_32;
            tsmiUsers.ImageScaling = ToolStripItemImageScaling.None;
            tsmiUsers.Margin = new Padding(0, 0, 20, 0);
            tsmiUsers.Name = "tsmiUsers";
            tsmiUsers.ShortcutKeys = Keys.Control | Keys.D3;
            tsmiUsers.Size = new Size(127, 79);
            tsmiUsers.Text = "Utilisateurs";
            tsmiUsers.TextImageRelation = TextImageRelation.ImageAboveText;
            tsmiUsers.Click += tsmiUsers_Click;
            // 
            // tsmiSettings
            // 
            tsmiSettings.BackColor = Color.Transparent;
            tsmiSettings.DropDownItems.AddRange(new ToolStripItem[] { tsmiEditStoreInfo, tsmiChangePassword });
            tsmiSettings.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiSettings.Image = Resources.icons8_settings_32__1_;
            tsmiSettings.ImageScaling = ToolStripItemImageScaling.None;
            tsmiSettings.ImageTransparentColor = Color.White;
            tsmiSettings.Margin = new Padding(0, 0, 20, 0);
            tsmiSettings.Name = "tsmiSettings";
            tsmiSettings.RightToLeft = RightToLeft.No;
            tsmiSettings.ShortcutKeys = Keys.Control | Keys.A;
            tsmiSettings.Size = new Size(128, 79);
            tsmiSettings.Text = "Paramètres";
            tsmiSettings.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsmiEditStoreInfo
            // 
            tsmiEditStoreInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiEditStoreInfo.Image = Resources.edit_icon_blue_32;
            tsmiEditStoreInfo.ImageScaling = ToolStripItemImageScaling.None;
            tsmiEditStoreInfo.Name = "tsmiEditStoreInfo";
            tsmiEditStoreInfo.Size = new Size(416, 38);
            tsmiEditStoreInfo.Text = "Modifier les informations du magasin";
            tsmiEditStoreInfo.Click += tsmiEditStoreInfo_Click;
            // 
            // tsmiChangePassword
            // 
            tsmiChangePassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiChangePassword.Image = (Image)resources.GetObject("tsmiChangePassword.Image");
            tsmiChangePassword.ImageScaling = ToolStripItemImageScaling.None;
            tsmiChangePassword.Name = "tsmiChangePassword";
            tsmiChangePassword.Size = new Size(416, 38);
            tsmiChangePassword.Text = "Changer le mot de passe";
            tsmiChangePassword.Click += tsmiChangePassword_Click;
            // 
            // tsmiSignOut
            // 
            tsmiSignOut.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsmiSignOut.Image = (Image)resources.GetObject("tsmiSignOut.Image");
            tsmiSignOut.ImageScaling = ToolStripItemImageScaling.None;
            tsmiSignOut.Margin = new Padding(0, 0, 20, 0);
            tsmiSignOut.Name = "tsmiSignOut";
            tsmiSignOut.ShortcutKeys = Keys.Control | Keys.D3;
            tsmiSignOut.Size = new Size(168, 79);
            tsmiSignOut.Text = "Se déconnecter";
            tsmiSignOut.TextImageRelation = TextImageRelation.ImageAboveText;
            tsmiSignOut.Click += tsmiSignOut_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(979, 191);
            Controls.Add(msMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = msMain;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMain_FormClosing;
            FormClosed += frmMain_FormClosed;
            SizeChanged += frmMain_SizeChanged;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip msMain;
        private ToolStripMenuItem tsmiProducts;
        private ToolStripMenuItem tsmiCustomers;
        private ToolStripMenuItem tsmiOrders;
        private ToolStripMenuItem tsmiSettings;
        private ToolStripMenuItem tsmiEditStoreInfo;
        private ToolStripMenuItem tsmiDashbord;
        private ToolStripMenuItem tsmiUsers;
        private ToolStripMenuItem tsmiChangePassword;
        private ToolStripMenuItem tsmiSignOut;
    }
}