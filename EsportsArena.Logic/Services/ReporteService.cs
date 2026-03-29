using ClosedXML.Excel;
using EsportsArena.Entities.Models;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace EsportsArena.Logic.Services
{
    public class ReporteService
    {
        public byte[] GenerarExcelUsuarios(IEnumerable<Usuario> usuarios)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Usuarios");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Username";
                worksheet.Cell(1, 3).Value = "Email";

                int row = 2;
                foreach (var u in usuarios)
                {
                    worksheet.Cell(row, 1).Value = u.Id;
                    worksheet.Cell(row, 2).Value = u.Username;
                    worksheet.Cell(row, 3).Value = u.Email;
                    row++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        public byte[] GenerarPdfUsuarios(IEnumerable<Usuario> usuarios)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Título del Reporte
                document.Add(new Paragraph("ESPORTS ARENA - REPORTE DE USUARIOS")
                    .SetFontSize(20)
                    .SetFontColor(ColorConstants.CYAN)
                    .SetTextAlignment(TextAlignment.CENTER));

                document.Add(new Paragraph($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}")
                    .SetFontSize(10)
                    .SimulateItalic()
                    .SetMarginBottom(20));

                // Crear Tabla (3 columnas: ID, Username, Email)
                Table table = new Table(3, true);
                table.SetWidth(UnitValue.CreatePercentValue(100));

                // Encabezados con estilo "Gamer"
                string[] headers = { "ID", "NOMBRE DE USUARIO", "CORREO ELECTRÓNICO" };
                foreach (var h in headers)
                {
                    table.AddHeaderCell(new Cell()
                        .Add(new Paragraph(h).SetFontColor(ColorConstants.WHITE).SetFontSize(12))
                        .SetBackgroundColor(ColorConstants.BLACK)
                        .SetTextAlignment(TextAlignment.CENTER));
                }

                // Llenado de datos
                foreach (var u in usuarios)
                {
                    table.AddCell(new Cell().Add(new Paragraph(u.Id.ToString())));
                    table.AddCell(new Cell().Add(new Paragraph(u.Username)));
                    table.AddCell(new Cell().Add(new Paragraph(u.Email)));
                }

                document.Add(table);
                document.Close();
                return stream.ToArray();
            }
        }
    }
}
