using System.Drawing.Printing;
using TailorSoft.Store.Classes;
using TailorSoft_Business_Layer;

namespace TailorSoft.Order.Classes
{
    public class clsOrderPrinter
    {
        private clsOrder _order = null!;
        private Font _font;
        private int _lineH;
        private StringFormat _rtlFormat;
        // Add a field for the logo image
        private Image? _logo;

        public clsOrderPrinter(string fontFamily = "Arial", float fontSize = 10f)
        {
            // خط يدعم العربية
            _font = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point);

            using var bmp = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bmp);
            _lineH = (int)Math.Ceiling(g.MeasureString("A", _font).Height);
            if (_lineH < 14)
                _lineH = 14;

            // إعداد المحاذاة RTL
            _rtlFormat = new StringFormat
            {
                Alignment = StringAlignment.Near, // من اليمين
                LineAlignment = StringAlignment.Near,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };
        }

        public void Preview(clsOrder order, int paperWidthMm = 80, string? printerName = null)
            => Print(order, paperWidthMm, printerName, preview: true);

        public void PrintDirect(clsOrder order, int paperWidthMm = 80, string? printerName = null)
            => Print(order, paperWidthMm, printerName, preview: false);

        private void Print(clsOrder order, int paperWidthMm, string? printerName, bool preview)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));

            var doc = new PrintDocument
            {
                OriginAtMargins = true
            };

            if (!string.IsNullOrWhiteSpace(printerName))
                doc.PrinterSettings.PrinterName = printerName;

            doc.DefaultPageSettings.Margins = new Margins(1, 1, 5, 5);

            int targetWidth = MmToHundredthInch(paperWidthMm);
            int targetHeight = 2000;
            doc.DefaultPageSettings.PaperSize = GetSupportedPaperSize(doc.PrinterSettings, targetWidth, targetHeight);

            doc.PrintPage += OnPrintPage;

            if (preview)
            {
                using var dlg = new PrintPreviewDialog { Document = doc, Width = 1000, Height = 600 };
                dlg.Text = "معاينة الطباعة";
                dlg.PrintPreviewControl.AutoZoom = false;
                dlg.PrintPreviewControl.Zoom = 1.7;

                dlg.ShowDialog();
            }
            else
            {
                doc.Print();
            }
        }

        private void OnPrintPage(object? sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var left = e.MarginBounds.Left - 35;
            var right = e.MarginBounds.Right - 35;
            var width = e.MarginBounds.Width;
            int y = e.MarginBounds.Top;

            void Line()
            {
                g.DrawString(new string('-', Math.Max(20, width / 4)), new Font("Arial", 9), Brushes.Black,
                    new RectangleF(left, y, width, _lineH), _rtlFormat);
                y += _lineH;
            }

            void Center(string text, bool bold = false)
            {
                using var font = bold ? new Font(new Font("Arial", 9), FontStyle.Bold) : new Font("Arial", 9);
                var fmt = (StringFormat)_rtlFormat.Clone();
                fmt.Alignment = StringAlignment.Center;
                g.DrawString(text ?? "", font, Brushes.Black,
                    new RectangleF(left + 20, y, width, _lineH), fmt);
                y += _lineH;
            }

            void R(string text) // الكتابة من اليمين
            {
                g.DrawString(text ?? "", new Font("Arial", 9), Brushes.Black,
                    new RectangleF(left, y, width, _lineH), _rtlFormat);
                y += _lineH;
            }

            string Nm(string s, int max) => string.IsNullOrEmpty(s) ? "" : (s.Length <= max ? s : s[..max]);

            clsStore? StoreInfo = clsStore.Load();

            // Draw logo at the top center before the header
            if (_logo != null)
            {
                // Set desired logo height (e.g., 60px) and maintain aspect ratio
                int logoHeight = 60;
                int logoWidth = _logo.Width * logoHeight / _logo.Height;
                int logoX = left + (width - logoWidth) / 2;
                g.DrawImage(_logo, logoX + 20, y, logoWidth, logoHeight);
                y += logoHeight + 8; // Add some space after the logo
            }

            // ======= الهيدر =======
            Center(StoreInfo?.Name ?? "", true);
            Center(StoreInfo?.Address ?? "", true);
            Center(StoreInfo?.Phone ?? "", true);
            Center(DateTime.Now.ToString("hh-mm dd-MM-yyyy"));

            y += _lineH;
            y += _lineH;


            R($"رقم الطلب: {_order.Id}");
            R($"اسم الزبون: {(_order.Customer?.Person?.FullName ?? "غير محدد")}");
            R($"تاريخ الطلب: {_order.OrderDate:mm-hh yyyy-MM-dd}");
            R($"تاريخ التسليم: {_order.RequiredDate:yyyy-MM-dd}");
            Line();

            // Define column widths (in pixels)
            int colNameWidth = 100;
            int colQtyWidth = 30;
            int colXWidth = 15;
            int colPriceWidth = 40;
            int colTotalWidth = 200;

            // Calculate rightmost position (start from right for RTL)
            int xName = right - colNameWidth;
            int xQty = xName - colQtyWidth;
            int xX = xQty - colXWidth;
            int xPrice = xX - colPriceWidth;
            int xTotal = xPrice - colTotalWidth;
            // Draw each field at its position
            var rtlFormat = (StringFormat)_rtlFormat.Clone();
            rtlFormat.Alignment = StringAlignment.Near; // محاذاة من اليمين
            rtlFormat.LineAlignment = StringAlignment.Far;

            // ======= العناوين =======
            //R("اسم المنتج           الكمية               السعر           المجموع");


            g.DrawString("اسم المنتج", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new RectangleF(xName, y, colNameWidth, _lineH), rtlFormat);
            g.DrawString("الكمية", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new RectangleF(xQty, y, colQtyWidth, _lineH), rtlFormat);
            g.DrawString(" ", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new RectangleF(xX, y, colXWidth, _lineH), rtlFormat);
            g.DrawString("السعر", new Font("Arial", 9, FontStyle.Bold), Brushes.Black, new RectangleF(xPrice, y, colPriceWidth, _lineH), rtlFormat);
            g.DrawString("المجموع", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new RectangleF(xTotal, y, colTotalWidth, _lineH), rtlFormat);
            y += _lineH;

            Line();

            var items = _order.Items ?? new List<clsOrderItem>();
            foreach (var it in items)
            {
                string name = Nm(it.ProductName ?? "", 25);
                string qty = it.Quantity % 1 == 0
                    ? it.Quantity.ToString("0")
                    : it.Quantity.ToString("0.0");
                qty = Nm(qty, 6);
                string X = "X";
                string price = it.UnitPrice % 1 == 0
                    ? it.UnitPrice.ToString("0")
                    : it.UnitPrice.ToString("0.0");
                price = Nm(price, 6);
                string total = it.TotalPrice % 1 == 0 ? it.TotalPrice.ToString("0") + " د.م" : it.TotalPrice.ToString("0.0") + " د.م";

                // Draw the strings in their respective positions
                g.DrawString(name, new Font("Arial", 7, FontStyle.Bold), Brushes.Black, new RectangleF(xName, y, colNameWidth, _lineH), rtlFormat);
                g.DrawString(qty, new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new RectangleF(xQty, y, colQtyWidth, _lineH), rtlFormat);

                g.DrawString(X, new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new RectangleF(xX, y, colXWidth, _lineH), rtlFormat);
                g.DrawString(price, new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new RectangleF(xPrice, y, colPriceWidth, _lineH), rtlFormat);
                g.DrawString(total, new Font("Arial", 7, FontStyle.Regular), Brushes.Black, new RectangleF(xTotal, y, colTotalWidth, _lineH), rtlFormat);


                y += _lineH;
            }

            Line();

            // ======= المجاميع =======
            string TotalAmount = _order.TotalAmount % 1 == 0
                ? _order.TotalAmount.ToString("0") + " درهم"
                : _order.TotalAmount.ToString("0.00") + " درهم";
            string InitialAmount = _order.InitialAmount % 1 == 0 ?
                _order.InitialAmount.ToString("0") + " درهم"
                : _order.InitialAmount.ToString("0.00") + " درهم";
            string RemainingAmount = _order.RemainingAmount % 1 == 0 ?
                _order.RemainingAmount.ToString("0") + " درهم"
                : _order.RemainingAmount.ToString("0.00") + " درهم";

            g.DrawString($"المبلغ الإجمالي: {TotalAmount}", new Font("Arial", 9, FontStyle.Bold), Brushes.Black,
                   new RectangleF(left, y, width, _lineH), _rtlFormat);
            y += _lineH;
            g.DrawString($"المبلغ المدفوع: {InitialAmount}", new Font("Arial", 9, FontStyle.Regular), Brushes.Black,
                    new RectangleF(left, y, width, _lineH), _rtlFormat);
            y += _lineH;
            g.DrawString($"المبلغ المتبقي: {RemainingAmount}", new Font("Arial", 9, FontStyle.Bold), Brushes.Black,
                    new RectangleF(left, y, width, _lineH), _rtlFormat);
            y += _lineH;

            Line();
            Center("شكرا لتعاملكم معنا", true);
            Center((StoreInfo?.Name ?? "") + " ترحب بكم", true);

            e.HasMorePages = false;
        }

        private static PaperSize GetSupportedPaperSize(PrinterSettings ps, int targetWidth, int targetHeight)
        {
            var all = ps.PaperSizes.Cast<PaperSize>().ToList();
            var match = all.OrderBy(p => Math.Abs(p.Width - targetWidth)).FirstOrDefault();

            if (match != null)
                return new PaperSize(match.PaperName, match.Width, targetHeight);

            return new PaperSize("Custom", targetWidth, targetHeight);
        }

        private static int MmToHundredthInch(int mm)
            => (int)Math.Round(mm * 100.0 / 25.4);

        // Optionally, add a constructor overload to accept a logo path
        public clsOrderPrinter(string fontFamily = "Arial", float fontSize = 10f, string? logoPath = null)
        {
            _font = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point);

            using var bmp = new Bitmap(1, 1);
            using var g = Graphics.FromImage(bmp);
            _lineH = (int)Math.Ceiling(g.MeasureString("A", _font).Height);
            if (_lineH < 14)
                _lineH = 14;

            _rtlFormat = new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Near,
                FormatFlags = StringFormatFlags.DirectionRightToLeft
            };

            if (!string.IsNullOrWhiteSpace(logoPath) && System.IO.File.Exists(logoPath))
            {
                _logo = Image.FromFile(logoPath);
            }
        }
    }
}
