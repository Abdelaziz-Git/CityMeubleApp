namespace TailorSoft.OrderItem.Controls
{
    partial class ucOrderItemList
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvOrderItemsList = new WinFormsControlsLibrary.CustomDataGridView();
            btnAddItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrderItemsList).BeginInit();
            SuspendLayout();
            // 
            // dgvOrderItemsList
            // 
            dgvOrderItemsList.AllowUserToAddRows = false;
            dgvOrderItemsList.AllowUserToDeleteRows = false;
            dgvOrderItemsList.AllowUserToOrderColumns = true;
            dgvOrderItemsList.AlternateRowBackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dgvOrderItemsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrderItemsList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrderItemsList.BackgroundColor = Color.White;
            dgvOrderItemsList.BorderStyle = BorderStyle.None;
            dgvOrderItemsList.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOrderItemsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOrderItemsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(5, 2, 5, 2);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOrderItemsList.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOrderItemsList.EnableHeadersVisualStyles = false;
            dgvOrderItemsList.GridColor = Color.FromArgb(230, 230, 230);
            dgvOrderItemsList.HeaderBackColor = Color.FromArgb(52, 152, 219);
            dgvOrderItemsList.HeaderForeColor = Color.White;
            dgvOrderItemsList.Location = new Point(0, 54);
            dgvOrderItemsList.Name = "dgvOrderItemsList";
            dgvOrderItemsList.ReadOnly = true;
            dgvOrderItemsList.RowHeadersVisible = false;
            dgvOrderItemsList.SelectionBackColorCustom = Color.FromArgb(41, 128, 185);
            dgvOrderItemsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderItemsList.Size = new Size(916, 299);
            dgvOrderItemsList.TabIndex = 1;
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.Gainsboro;
            btnAddItem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddItem.Image = Properties.Resources.add_icon_32;
            btnAddItem.Location = new Point(0, 0);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.RightToLeft = RightToLeft.No;
            btnAddItem.Size = new Size(213, 45);
            btnAddItem.TabIndex = 2;
            btnAddItem.Text = "Ajouter un élément";
            btnAddItem.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // ucOrderItemList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnAddItem);
            Controls.Add(dgvOrderItemsList);
            Name = "ucOrderItemList";
            Size = new Size(916, 353);
            Load += ucOrderItemList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOrderItemsList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private WinFormsControlsLibrary.CustomDataGridView dgvOrderItemsList;
        private Button btnAddItem;
    }
}
