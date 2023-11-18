using System;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using System.Text;

namespace SystemZarzadzaniaPraktykami.Controllers.PDF
{
    public class PDFGen
    {
        // Ustawienie czcionki i rozmiaru tekstu
        XFont font = new XFont("Arial", 30, XFontStyle.Regular);

        static PDFGen()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public void AddText(XGraphics gfx, string textToAdd, int x, int y)
        {
            // Set pos
            XPoint point = new XPoint(x, y);

            // Adding text
            gfx.DrawString(textToAdd, font, XBrushes.Black, point);
        }

        public void AddTextToPdf(string filePath, string textToAdd)
        {
            // Get existing PDF
            PdfDocument document = PdfReader.Open(filePath, PdfDocumentOpenMode.Modify);

            PdfPage page = document.Pages[0];

            // Creating a new object
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Adding text to PDF file
            AddText(gfx, textToAdd, 130, 80);
            AddText(gfx, "Informatyka, 3 rok", 130, 110);
            AddText(gfx, "Stacjonarne", 130, 180);
            AddText(gfx, "dr. xxxxxxxxxxxxxxxxx", 400, 250);
            AddText(gfx, "Informatyka, 3 rok", 350, 350);
            AddText(gfx, "23", 400, 350);
            AddText(gfx, "24", 400, 350);
            AddText(gfx, "posiadanej umowy o prace", 250, 390);

            // Saving PDF
            document.Save(filePath);
        }
    }
}

