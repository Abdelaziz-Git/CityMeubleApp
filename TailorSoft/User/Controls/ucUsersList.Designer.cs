namespace TailorSoft.User.Controls
{
    partial class ucUsersList
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            txtSearch = new TextBox();
            cbFindBy = new ComboBox();
            label2 = new Label();
            dgvUsersList = new WinFormsControlsLibrary.CustomDataGridView();
            btnAddNewUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsersList).BeginInit();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(343, 73);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Rechercher ...";
            txtSearch.RightToLeft = RightToLeft.No;
            txtSearch.Size = new Size(481, 33);
            txtSearch.TabIndex = 22;
            // 
            // cbFindBy
            // 
            cbFindBy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFindBy.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFindBy.DropDownHeight = 120;
            cbFindBy.Font = new Font("Times New Roman", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbFindBy.FormattingEnabled = true;
            cbFindBy.IntegralHeight = false;
            cbFindBy.Items.AddRange(new object[] { "Téléphone", "Prénom", "Nom" });
            cbFindBy.Location = new Point(155, 77);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.RightToLeft = RightToLeft.No;
            cbFindBy.Size = new Size(173, 25);
            cbFindBy.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 80);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(122, 19);
            label2.TabIndex = 20;
            label2.Text = "Rechercher par :";
            // 
            // dgvUsersList
            // 
            dgvUsersList.AllowUserToAddRows = false;
            dgvUsersList.AllowUserToDeleteRows = false;
            dgvUsersList.AllowUserToOrderColumns = true;
            dgvUsersList.AlternateRowBackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle4.BackColor = Color.FromArgb(240, 240, 240);
            dgvUsersList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvUsersList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsersList.BackgroundColor = Color.White;
            dgvUsersList.BorderStyle = BorderStyle.Fixed3D;
            dgvUsersList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvUsersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvUsersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new Padding(5, 2, 5, 2);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle6.SelectionForeColor = Color.White;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvUsersList.DefaultCellStyle = dataGridViewCellStyle6;
            dgvUsersList.EnableHeadersVisualStyles = false;
            dgvUsersList.GridColor = Color.FromArgb(230, 230, 230);
            dgvUsersList.HeaderBackColor = Color.FromArgb(52, 152, 219);
            dgvUsersList.HeaderForeColor = Color.White;
            dgvUsersList.Location = new Point(27, 122);
            dgvUsersList.Name = "dgvUsersList";
            dgvUsersList.ReadOnly = true;
            dgvUsersList.RowHeadersVisible = false;
            dgvUsersList.SelectionBackColorCustom = Color.FromArgb(41, 128, 185);
            dgvUsersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsersList.Size = new Size(1111, 509);
            dgvUsersList.TabIndex = 18;
            // 
            // btnAddNewUser
            // 
            btnAddNewUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddNewUser.BackColor = Color.WhiteSmoke;
            btnAddNewUser.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 178);
            btnAddNewUser.Image = Properties.Resources.add_icon_32;
            btnAddNewUser.ImageAlign = ContentAlignment.BottomCenter;
            btnAddNewUser.Location = new Point(987, 35);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.RightToLeft = RightToLeft.No;
            btnAddNewUser.Size = new Size(151, 81);
            btnAddNewUser.TabIndex = 23;
            btnAddNewUser.Text = "Ajouter utilisateur";
            btnAddNewUser.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAddNewUser.UseVisualStyleBackColor = false;
            // 
            // ucUsersList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnAddNewUser);
            Controls.Add(txtSearch);
            Controls.Add(cbFindBy);
            Controls.Add(label2);
            Controls.Add(dgvUsersList);
            Name = "ucUsersList";
            RightToLeft = RightToLeft.No;
            Size = new Size(1166, 696);
            ((System.ComponentModel.ISupportInitialize)dgvUsersList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private ComboBox cbFindBy;
        private Label label2;
        private WinFormsControlsLibrary.CustomDataGridView dgvUsersList;
        private Button btnAddNewUser;
    }
}
