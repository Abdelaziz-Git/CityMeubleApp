using System.Drawing.Printing;
using System.Globalization;
using TailorSoft.Store.Classes;
using TailorSoft_Business_Layer;

namespace TailorSoft.Order.Classes
{
    public class clsOrderPrinter : IDisposable
    {
        private clsOrder _order = null!;
        private Image? _logo;
        private List<clsOrderItem> _items = new();
        private int _currentItemIndex;
        private readonly string _fontFamily;
        private readonly float _fontSize;

        public clsOrderPrinter(string fontFamily = "Arial", float fontSize = 10f, string? logoPath = null)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;

            string configuredLogoPath = string.IsNullOrWhiteSpace(logoPath)
                ? clsStore.Load().LogoImagePath
                : logoPath;
            if (!string.IsNullOrWhiteSpace(configuredLogoPath) && File.Exists(configuredLogoPath))
            {
                using var sourceImage = Image.FromFile(configuredLogoPath);
                _logo = new Bitmap(sourceImage);
            }
        }

        public void Preview(clsOrder order, string? printerName = null)
            => Print(order, printerName, preview: true);

        public void PrintDirect(clsOrder order, string? printerName = null)
            => Print(order, printerName, preview: false);

        private void Print(clsOrder order, string? printerName, bool preview)
        {
            _order = order ?? throw new ArgumentNullException(nameof(order));
            _items = _order.Items ?? new List<clsOrderItem>();
            _currentItemIndex = 0;

            using var doc = new PrintDocument
            {
                OriginAtMargins = false
            };

            if (!string.IsNullOrWhiteSpace(printerName))
                doc.PrinterSettings.PrinterName = printerName;

            doc.DefaultPageSettings.Margins = new Margins(35, 35, 35, 35);
            doc.DefaultPageSettings.Landscape = false;
            doc.DefaultPageSettings.PaperSize = GetA4PaperSize(doc.PrinterSettings);

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
            var bounds = e.MarginBounds;
            var store = clsStore.Load();
            var customer = _order.Customer?.Person;
            var culture = CultureInfo.GetCultureInfo("fr-FR");
            string Money(decimal amount) => $"{amount.ToString("N2", culture)} DH";
            bool isFirstPage = _currentItemIndex == 0;
            int left = bounds.Left;
            int top = bounds.Top;
            int width = bounds.Width;
            int y = top;
            int signatureWidth = Math.Min(205, width / 3);
            int headerHeight = 115;
            int rowHeight = 31;
            int quantityWidth = 65;
            int unitPriceWidth = 125;
            int totalWidth = 125;
            int nameWidth = width - quantityWidth - unitPriceWidth - totalWidth;

            using var titleFont = new Font(_fontFamily, _fontSize * 2.5f, FontStyle.Bold);
            using var subtitleFont = new Font(_fontFamily, _fontSize + 1, FontStyle.Bold);
            using var labelFont = new Font(_fontFamily, _fontSize, FontStyle.Bold);
            using var bodyFont = new Font(_fontFamily, Math.Max(8f, _fontSize - 0.5f), FontStyle.Regular);
            using var tableFont = new Font(_fontFamily, _fontSize, FontStyle.Bold);
            using var borderPen = new Pen(Color.Black, 1.5f);
            using var goldBrush = new SolidBrush(Color.FromArgb(245, 196, 0));
            using var blackBrush = new SolidBrush(Color.Black);
            using var whiteBrush = new SolidBrush(Color.White);
            using var textBrush = new SolidBrush(Color.Black);
            using var whatsAppBrush = new SolidBrush(Color.FromArgb(37, 145, 92));
            using var footerBackgroundBrush = new SolidBrush(Color.FromArgb(248, 248, 248));
            using var footerBorderPen = new Pen(Color.FromArgb(190, 190, 190), 1f);
            using var contactBorderPen = new Pen(Color.FromArgb(155, 155, 155), 1f);
            using var centeredFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            using var leftFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };
            using var rightFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter };

            void DrawCell(string text, RectangleF rect, Font font, Brush brush, StringFormat format)
            {
                g.DrawString(text ?? string.Empty, font, brush, rect, format);
            }

            void DrawField(string label, string value, float x, float fieldY, float fieldWidth)
            {
                float labelWidth = g.MeasureString(label, labelFont).Width + 4;
                DrawCell(label, new RectangleF(x, fieldY, labelWidth, 24), labelFont, textBrush, leftFormat);
                float valueX = x + labelWidth;
                g.DrawLine(borderPen, valueX, fieldY + 22, x + fieldWidth, fieldY + 22);
                DrawCell(value, new RectangleF(valueX + 3, fieldY, Math.Max(0, fieldWidth - labelWidth - 6), 22), bodyFont, textBrush, leftFormat);
            }

            void DrawLocationIcon(Rectangle bounds)
            {
                float centerX = bounds.X + bounds.Width / 2f;
                using var pinPath = new System.Drawing.Drawing2D.GraphicsPath();
                pinPath.AddBezier(centerX, bounds.Bottom, bounds.X + bounds.Width * 0.12f, bounds.Y + bounds.Height * 0.54f, bounds.X + bounds.Width * 0.12f, bounds.Y, centerX, bounds.Y);
                pinPath.AddBezier(centerX, bounds.Y, bounds.Right - bounds.Width * 0.12f, bounds.Y, bounds.Right - bounds.Width * 0.12f, bounds.Y + bounds.Height * 0.54f, centerX, bounds.Bottom);
                pinPath.CloseFigure();
                g.FillPath(goldBrush, pinPath);
                float holeSize = bounds.Width * 0.28f;
                g.FillEllipse(whiteBrush, centerX - holeSize / 2f, bounds.Y + bounds.Height * 0.24f, holeSize, holeSize);
            }

            void DrawPhoneIcon(Rectangle bounds)
            {
                g.FillEllipse(whatsAppBrush, bounds);
                using var phonePath = new System.Drawing.Drawing2D.GraphicsPath();
                phonePath.AddBezier(
                    bounds.X + bounds.Width * 0.28f, bounds.Y + bounds.Height * 0.24f,
                    bounds.X + bounds.Width * 0.12f, bounds.Y + bounds.Height * 0.42f,
                    bounds.X + bounds.Width * 0.58f, bounds.Y + bounds.Height * 0.88f,
                    bounds.X + bounds.Width * 0.76f, bounds.Y + bounds.Height * 0.72f);
                using var phonePen = new Pen(Color.White, Math.Max(2f, bounds.Width * 0.14f))
                {
                    StartCap = System.Drawing.Drawing2D.LineCap.Round,
                    EndCap = System.Drawing.Drawing2D.LineCap.Round,
                    LineJoin = System.Drawing.Drawing2D.LineJoin.Round
                };
                g.DrawPath(phonePen, phonePath);
            }

            int signatureX = left + width - signatureWidth;
            g.DrawRectangle(borderPen, signatureX, y, signatureWidth, headerHeight);
            DrawCell("Signature / Cachet", new RectangleF(signatureX + 4, y + 3, signatureWidth - 8, 24), labelFont, textBrush, centeredFormat);

            int logoAreaWidth = width - signatureWidth - 20;
            if (_logo != null)
            {
                var logoBounds = new RectangleF(left, y + 6, Math.Min(145, logoAreaWidth / 3), headerHeight - 12);
                float scale = Math.Min(logoBounds.Width / _logo.Width, logoBounds.Height / _logo.Height);
                float logoWidth = _logo.Width * scale;
                float logoHeight = _logo.Height * scale;
                g.DrawImage(_logo, logoBounds.X, logoBounds.Y + (logoBounds.Height - logoHeight) / 2, logoWidth, logoHeight);
            }

            int titleX = left + 150;
            int titleWidth = Math.Max(100, signatureX - titleX - 10);
            DrawCell(store.Name.ToUpperInvariant(), new RectangleF(titleX, y + 15, titleWidth, 43), titleFont, goldBrush, centeredFormat);
            g.FillRectangle(blackBrush, titleX, y + 61, titleWidth, 29);
            DrawCell("Vente d’ameublement", new RectangleF(titleX, y + 62, titleWidth, 27), subtitleFont, whiteBrush, centeredFormat);

            y += headerHeight + 14;
            if (isFirstPage)
            {
                int halfWidth = (width - 20) / 2;
                DrawField("Nom du client :", customer?.FullName ?? string.Empty, left, y, halfWidth);
                DrawField("Nador, le :", _order.OrderDate.ToString("dd/MM/yyyy", culture), left + halfWidth + 20, y, halfWidth);
                y += 38;
                DrawField("Tél. :", customer?.Phone ?? string.Empty, left, y, halfWidth);
                DrawField("N° de commande :", _order.Id.ToString("D5", culture), left + halfWidth + 20, y, halfWidth);
                y += 38;
                DrawField("Lieu de livraison :", customer?.Address ?? string.Empty, left, y, width);
                y += 44;
            }

            int x = left;
            int tableWidth = width;
            int[] columnWidths = [quantityWidth, nameWidth, unitPriceWidth, totalWidth];
            string[] headings = ["QT", "DÉSIGNATION", "PRIX UNITÉ", "TOTAL"];
            for (int i = 0; i < columnWidths.Length; i++)
            {
                var cell = new Rectangle(x, y, columnWidths[i], rowHeight);
                g.FillRectangle(i == 0 ? goldBrush : blackBrush, cell);
                DrawCell(headings[i], cell, tableFont, i == 0 ? blackBrush : whiteBrush, centeredFormat);
                g.DrawRectangle(borderPen, cell);
                x += columnWidths[i];
            }
            y += rowHeight;

            int totalBoxWidth = Math.Min(285, tableWidth / 2);
            int footerY = bounds.Bottom - 98;
            int tableBottom = footerY - 8;
            int rowsPerPage = Math.Max(1, (tableBottom - y) / rowHeight);
            int rowsToDraw = Math.Min(rowsPerPage, _items.Count - _currentItemIndex);
            for (int rowIndex = 0; rowIndex < rowsToDraw; rowIndex++)
            {
                var item = _items[_currentItemIndex++];
                int[] widths = [quantityWidth, nameWidth, unitPriceWidth, totalWidth];
                string[] values =
                [
                    item.Quantity.ToString("0.##", culture),
                    item.ProductName,
                    Money(item.UnitPrice),
                    Money(item.TotalPrice)
                ];
                x = left;
                for (int i = 0; i < widths.Length; i++)
                {
                    var cell = new Rectangle(x, y, widths[i], rowHeight);
                    g.DrawRectangle(borderPen, cell);
                    DrawCell(values[i], new RectangleF(cell.X + 4, cell.Y, cell.Width - 8, cell.Height), bodyFont, textBrush, i == 1 ? leftFormat : centeredFormat);
                    x += widths[i];
                }
                y += rowHeight;
            }

            bool hasMorePages = _currentItemIndex < _items.Count;
            if (!hasMorePages)
            {
                while (y < tableBottom)
                {
                    int emptyRowHeight = Math.Min(rowHeight, tableBottom - y);
                    x = left;
                    foreach (int columnWidth in columnWidths)
                    {
                        g.DrawRectangle(borderPen, x, y, columnWidth, emptyRowHeight);
                        x += columnWidth;
                    }
                    y += emptyRowHeight;
                }

                int totalX = left + tableWidth - totalBoxWidth;
                int amountRowHeight = 26;
                int contactRowHeight = amountRowHeight + 6;
                int footerGap = 14;
                int iconColumnWidth = 38;
                int contactPadding = 10;
                int iconSize = 20;
                string[] amountLabels = ["TOTAL À PAYER", "ACOMPTE VERSÉ", "RESTE À PAYER"];
                decimal[] amounts = [_order.TotalAmount, _order.InitialAmount, _order.RemainingAmount];
                int amountLabelWidth = (int)(totalBoxWidth * 0.56f);
                for (int i = 0; i < amountLabels.Length; i++)
                {
                    var row = new Rectangle(totalX, footerY + i * amountRowHeight, totalBoxWidth, amountRowHeight);
                    var labelBounds = new RectangleF(row.X + 10, row.Y, amountLabelWidth - 14, row.Height);
                    var amountBounds = new RectangleF(row.X + amountLabelWidth + 2, row.Y, totalBoxWidth - amountLabelWidth - 12, row.Height);
                    g.FillRectangle(blackBrush, row);
                    g.FillRectangle(whiteBrush, row.X + amountLabelWidth, row.Y, totalBoxWidth - amountLabelWidth, row.Height);
                    DrawCell(amountLabels[i], labelBounds, tableFont, whiteBrush, leftFormat);
                    DrawCell(Money(amounts[i]), amountBounds, i == 0 || i == amountLabels.Length - 1 ? tableFont : bodyFont, textBrush, rightFormat);
                }
                var amountsBounds = new Rectangle(totalX, footerY, totalBoxWidth, amountRowHeight * amountLabels.Length);
                g.DrawRectangle(contactBorderPen, amountsBounds);
                for (int i = 1; i < amountLabels.Length; i++)
                    g.DrawLine(footerBorderPen, totalX, footerY + i * amountRowHeight, totalX + totalBoxWidth, footerY + i * amountRowHeight);

                int contactWidth = Math.Max(170, totalX - left - footerGap);
                int contactTextX = left + iconColumnWidth + contactPadding;
                int contactTextWidth = Math.Max(0, contactWidth - iconColumnWidth - (contactPadding * 2));
                int contactBlockHeight = contactRowHeight * 2;
                int contactTop = footerY + (amountLabels.Length * amountRowHeight - contactBlockHeight) / 2;
                var contactBounds = new Rectangle(left, contactTop, contactWidth, contactBlockHeight);
                int firstIconY = contactTop + (contactRowHeight - iconSize) / 2;
                int secondIconY = contactTop + contactRowHeight + (contactRowHeight - iconSize) / 2;
                g.FillRectangle(footerBackgroundBrush, contactBounds);
                g.DrawRectangle(contactBorderPen, contactBounds);
                g.DrawLine(footerBorderPen, contactTextX, contactTop + contactRowHeight, left + contactWidth - contactPadding, contactTop + contactRowHeight);
                g.FillRectangle(goldBrush, left, contactTop, 4, contactBlockHeight);

                DrawLocationIcon(new Rectangle(left + 9, firstIconY, iconSize, iconSize));
                DrawCell(store.Address, new RectangleF(contactTextX, contactTop, contactTextWidth, contactRowHeight), bodyFont, textBrush, leftFormat);
                DrawPhoneIcon(new Rectangle(left + 9, secondIconY, iconSize, iconSize));
                DrawCell(store.Phone, new RectangleF(contactTextX, contactTop + contactRowHeight, contactTextWidth, contactRowHeight), bodyFont, textBrush, leftFormat);
            }

            e.HasMorePages = hasMorePages;
        }

        private static PaperSize GetA4PaperSize(PrinterSettings printerSettings)
        {
            var a4 = printerSettings.PaperSizes
                .Cast<PaperSize>()
                .FirstOrDefault(paper => paper.Kind == PaperKind.A4);

            return a4 ?? new PaperSize("A4", 827, 1169);
        }

        public void Dispose()
        {
            _logo?.Dispose();
            _logo = null;
        }
    }
}
