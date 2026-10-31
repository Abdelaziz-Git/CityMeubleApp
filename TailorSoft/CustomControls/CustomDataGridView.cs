using System.ComponentModel;

namespace WinFormsControlsLibrary
{
    public partial class CustomDataGridView : DataGridView
    {
        // Customizable properties
        [Category("Appearance"), Description("Background color for alternating rows.")]
        public Color AlternateRowBackColor { get; set; } = Color.FromArgb(240, 240, 240);

        [Category("Appearance"), Description("Background color for column headers.")]
        public Color HeaderBackColor { get; set; } = Color.FromArgb(52, 152, 219);

        [Category("Appearance"), Description("Fore color for column headers.")]
        public Color HeaderForeColor { get; set; } = Color.White;

        [Category("Appearance"), Description("Selection background color for cells.")]
        public Color SelectionBackColorCustom { get; set; } = Color.FromArgb(41, 128, 185);

        public CustomDataGridView()
        {
            // Double buffering to reduce flicker
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.EnableHeadersVisualStyles = false;

            // Base styles
            BorderStyle = BorderStyle.None;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            BackgroundColor = Color.White;
            GridColor = Color.FromArgb(230, 230, 230);

            // Header style
            ColumnHeadersHeight = 40;
            ColumnHeadersDefaultCellStyle.BackColor = HeaderBackColor;
            ColumnHeadersDefaultCellStyle.ForeColor = HeaderForeColor;
            ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Cell style
            DefaultCellStyle.SelectionBackColor = SelectionBackColorCustom;
            DefaultCellStyle.SelectionForeColor = Color.White;
            DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);

            // Alternating row style
            AlternatingRowsDefaultCellStyle.BackColor = AlternateRowBackColor;

            // Row header hidden
            RowHeadersVisible = false;

            // Enable full row select
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);

            // Custom header bottom border
            if (e.RowIndex == -1)
            {
                using (var pen = new Pen(Color.White, 2))
                {
                    e?.Graphics?.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                         e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Optionally: draw rounded corners or drop shadow here
        }
    }
}
