using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Text;
using TailorSoft.Store.Classes;
using TailorSoft_Business_Layer;

namespace TailorSoft.Order.Classes
{
    public static class clsOrderHtmlPrinter
    {
        public static void Preview(clsOrder order)
        {
            ArgumentNullException.ThrowIfNull(order);

            var store = clsStore.Load();
            var customer = order.Customer?.Person;
            var items = order.Items ?? new List<clsOrderItem>();
            var culture = CultureInfo.GetCultureInfo("fr-FR");
            string Money(decimal amount) => $"{amount.ToString("N2", culture)} DH";
            string MoneyHtml(decimal amount)
            {
                var parts = amount.ToString("N2", culture).Split(culture.NumberFormat.NumberDecimalSeparator);
                return $"<span class=\"money-value\"><span class=\"money-integer\">{Encode(parts[0])}</span><span>,</span><span>{Encode(parts[1])}</span><span> DH</span></span>";
            }
            string Encode(string? value) => WebUtility.HtmlEncode(value ?? string.Empty);
            string logo = GetLogoDataUri(store.LogoImagePath);

            var html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang=\"fr\"><head><meta charset=\"utf-8\">");
            html.AppendLine($"<title>Commande {Encode(order.Id.ToString("D5", culture))}</title>");
            html.AppendLine("<style>");
            html.AppendLine("@page{size:A4;margin:14mm}*{box-sizing:border-box}body{position:relative;min-height:269mm;font-family:Arial,sans-serif;color:#171717;margin:0;font-size:12px}.header{display:grid;grid-template-columns:130px 1fr 180px;gap:12px;min-height:105px;align-items:center;margin-bottom:20px}.logo{max-width:125px;max-height:90px;object-fit:contain}.brand{text-align:center}.brand h1{color:#f28c28;font-size:50px;margin:0 0 8px}.brand .tagline{display:flex;align-items:center;justify-content:center;gap:12px;background:#171717;color:#f28c28;padding:7px 10px;font-size:13px;font-weight:bold;white-space:nowrap}.tagline-divider{height:20px;border-left:2px solid #f28c28}.tagline-arabic{direction:rtl}.signature{height:105px;border:1px solid #171717;text-align:center;padding:8px;font-weight:bold}.fields{display:grid;grid-template-columns:1fr 1fr;gap:12px 24px;margin-bottom:18px}.field{border-bottom:1px solid #555;min-height:24px}.field strong{margin-right:5px}.field.full{grid-column:1/-1}table{width:100%;border-collapse:collapse;table-layout:fixed}thead{display:table-header-group}th,td{border:1px solid #171717;padding:7px 5px;text-align:center;overflow-wrap:anywhere}th{background:#171717;color:#fff}th:first-child{background:#f28c28;color:#171717;width:9%}th:nth-child(2){width:48%}th:nth-child(3),th:nth-child(4){width:21.5%}td.product{text-align:left}.bottom{display:grid;grid-template-columns:1fr 285px;gap:16px;align-items:center;margin-top:18px}.contact{position:absolute;left:0;bottom:0;display:block;width:calc(100% - 301px);background:#f8f8f8;border:1px solid #999;padding:10px;line-height:1.8}.contact-icon{width:14px;height:14px;vertical-align:-2px;margin-right:5px}.whatsapp-icon{color:#f28c28}.amounts{grid-column:2;width:100%}.amounts td:first-child{background:#171717;color:#fff;text-align:left;font-weight:bold}.amounts td:last-child{text-align:center}.amounts tr:last-child{font-weight:bold}.no-break{break-inside:avoid;page-break-inside:avoid}@media print{body{print-color-adjust:exact;-webkit-print-color-adjust:exact}tr{break-inside:avoid;page-break-inside:avoid}}</style>");
            html.AppendLine("<style>.brand .tagline{border-radius:999px}.signature{border-radius:12px;background:#fff}.field{border:1px solid #ddd;border-radius:8px;padding:7px 10px;background:#fff}.field.full{border-color:#ccc}table{border-collapse:separate;border-spacing:0;overflow:hidden;border-radius:10px}th:first-child{border-top-left-radius:10px}th:last-child{border-top-right-radius:10px}.items-table tbody tr:last-child td:first-child{border-bottom-left-radius:10px}.items-table tbody tr:last-child td:last-child{border-bottom-right-radius:10px}.items-table .money-value,.amounts .money-value{display:grid;grid-template-columns:1fr auto auto auto;align-items:center}.items-table .money-integer,.amounts .money-integer{text-align:right}.contact{border-radius:10px;border-color:#ddd;background:#f7f8fa}.amounts td{padding:9px 10px}.amounts tr:first-child td:first-child{border-top-left-radius:8px}.amounts tr:first-child td:last-child{border-top-right-radius:8px}.amounts tr:last-child td:first-child{border-bottom-left-radius:8px}.amounts tr:last-child td:last-child{border-bottom-right-radius:8px}</style>");
            html.AppendLine("<style>.contact{width:100%}</style>");
            html.AppendLine("</head><body>");
            html.AppendLine("<header class=\"header\">");
            html.AppendLine(logo.Length == 0 ? "<div></div>" : $"<img class=\"logo\" src=\"{logo}\" alt=\"Logo\">");
            html.AppendLine($"<div class=\"brand\"><h1>{Encode(store.Name.ToUpperInvariant())}</h1><div class=\"tagline\"><span>Vente d’Ameublement</span><span class=\"tagline-divider\" aria-hidden=\"true\"></span><span class=\"tagline-arabic\" lang=\"ar\">بيع الأثاث المنزلية</span></div></div>");
            html.AppendLine("<div class=\"signature\">Signature / Cachet</div></header>");
            html.AppendLine("<section class=\"fields\">");
            html.AppendLine($"<div class=\"field\"><strong>Nom du client :</strong>{Encode(customer?.FullName)}</div>");
            html.AppendLine($"<div class=\"field\"><strong>Nador, le :</strong>{Encode(order.OrderDate.ToString("dd/MM/yyyy", culture))}</div>");
            html.AppendLine($"<div class=\"field\"><strong>Tél :</strong>{Encode(customer?.Phone)}</div>");
            html.AppendLine($"<div class=\"field\"><strong>N° de commande :</strong>{Encode(order.Id.ToString("D5", culture))}</div>");
            html.AppendLine($"<div class=\"field full\"><strong>Lieu de livraison :</strong>{Encode(customer?.Address)}</div>");
            html.AppendLine("</section>");
            html.AppendLine("<table class=\"items-table\"><thead><tr><th>QT</th><th>DÉSIGNATION</th><th>PRIX UNITÉ</th><th>TOTAL</th></tr></thead><tbody>");
            foreach (var item in items)
            {
                html.AppendLine($"<tr><td>{Encode(item.Quantity.ToString("0.##", culture))}</td><td class=\"product\">{Encode(item.ProductName)}</td><td>{MoneyHtml(item.UnitPrice)}</td><td>{MoneyHtml(item.TotalPrice)}</td></tr>");
            }
            html.AppendLine("</tbody></table>");
            html.AppendLine("<footer class=\"bottom no-break\">");
            html.AppendLine($"<div class=\"contact\"><svg class=\"contact-icon\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path fill=\"currentColor\" d=\"M12 2a8 8 0 0 0-8 8c0 5.5 8 12 8 12s8-6.5 8-12a8 8 0 0 0-8-8Zm0 11a3 3 0 1 1 0-6 3 3 0 0 1 0 6Z\"/></svg>{Encode(store.Address)}<br><svg class=\"contact-icon whatsapp-icon\" viewBox=\"0 0 24 24\" aria-hidden=\"true\"><path fill=\"currentColor\" d=\"M12 2a9.8 9.8 0 0 0-8.5 14.7L2 22l5.5-1.4A10 10 0 1 0 12 2Zm0 17.9a8 8 0 0 1-4.1-1.1l-.3-.2-3.2.8.9-3.1-.2-.3A8 8 0 1 1 12 19.9Zm4.4-6c-.2-.1-1.4-.7-1.6-.8s-.4-.1-.5.1-.6.8-.8.9-.3.2-.5.1a6.5 6.5 0 0 1-1.9-1.2 7.3 7.3 0 0 1-1.3-1.6c-.1-.2 0-.3.1-.4l.4-.5.2-.4v-.4c-.1-.1-.5-1.3-.7-1.7s-.4-.3-.5-.3h-.5c-.2 0-.4.1-.6.3a2.5 2.5 0 0 0-.8 1.8 4.4 4.4 0 0 0 .9 2.3 10 10 0 0 0 3.8 3.4c.5.2.9.4 1.2.5.5.2 1 .2 1.4.1.4-.1 1.4-.6 1.6-1.1s.2-1 .1-1.1-.2-.1-.4-.2Z\"/></svg>{Encode(store.Phone)}</div>");
            html.AppendLine("<table class=\"amounts\"><tbody>");
            html.AppendLine($"<tr><td>TOTAL À PAYER</td><td>{MoneyHtml(order.TotalAmount)}</td></tr>");
            html.AppendLine($"<tr><td>AVANCE</td><td>{MoneyHtml(order.InitialAmount)}</td></tr>");
            html.AppendLine($"<tr><td>RESTE À PAYER</td><td>{MoneyHtml(order.RemainingAmount)}</td></tr>");
            html.AppendLine("</tbody></table></footer>");
            html.AppendLine("<script>window.addEventListener('load',()=>window.print());</script></body></html>");

            string filePath = Path.Combine(Path.GetTempPath(), $"TailorSoft-Order-{order.Id}-{Guid.NewGuid():N}.html");
            File.WriteAllText(filePath, html.ToString(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
        }

        private static string GetLogoDataUri(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return string.Empty;

            string? mediaType = Path.GetExtension(path).ToLowerInvariant() switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".webp" => "image/webp",
                _ => null
            };

            return mediaType == null
                ? string.Empty
                : $"data:{mediaType};base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
        }
    }
}
