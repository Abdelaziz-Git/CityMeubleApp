namespace TailorSoft.Order.Forms
{
    partial class frmUpdateOrder
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
            ucAddUpdateOrder1 = new TailorSoft.Order.Controls.ucAddUpdateOrder();
            SuspendLayout();
            // 
            // ucAddUpdateOrder1
            // 
            ucAddUpdateOrder1.BackColor = Color.White;
            ucAddUpdateOrder1.Dock = DockStyle.Fill;
            ucAddUpdateOrder1.Location = new Point(0, 0);
            ucAddUpdateOrder1.Name = "ucAddUpdateOrder1";
            ucAddUpdateOrder1.RightToLeft = RightToLeft.Yes;
            ucAddUpdateOrder1.Size = new Size(1069, 705);
            ucAddUpdateOrder1.TabIndex = 0;
            ucAddUpdateOrder1.OnButtonCloseClicked += ucAddUpdateOrder1_OnButtonCloseClicked;
            ucAddUpdateOrder1.OnOrderSavedSuccessfully += ucAddUpdateOrder1_OnOrderSavedSuccessfully;
            // 
            // frmUpdateOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 705);
            Controls.Add(ucAddUpdateOrder1);
            Name = "frmUpdateOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmUpdateOrder";
            ResumeLayout(false);
        }

        #endregion

        private Controls.ucAddUpdateOrder ucAddUpdateOrder1;
    }
}