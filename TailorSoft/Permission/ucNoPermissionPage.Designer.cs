namespace TailorSoft.Permission
{
    partial class ucNoPermissionPage
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Image = Properties.Resources.no_entry_100;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(996, 562);
            button1.TabIndex = 0;
            button1.Text = "عذرا ليست لديك صلاحية الدخول";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = true;
            // 
            // ucNoPermissionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(button1);
            Name = "ucNoPermissionPage";
            RightToLeft = RightToLeft.Yes;
            Size = new Size(996, 562);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}
