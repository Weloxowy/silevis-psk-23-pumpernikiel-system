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
        XFont font = new XFont("Times New Roman", 12, XFontStyle.Regular);

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

            // Adding text to PDF file - page 0
            AddText(gfx, textToAdd, 130, 110);
            AddText(gfx, "Informatyka, 3 rok", 130, 140);
            AddText(gfx, "Stacjonarne", 130, 170);
            AddText(gfx, "dr. Barbara Łukawska", 400, 265);
            AddText(gfx, "Informatyka", 130, 350);
            AddText(gfx, "23", 400, 360);
            AddText(gfx, "24", 420, 360);
            AddText(gfx, "posiadanej umowy o prace", 250, 405);
            page = document.Pages[1];
            XGraphics gfx2 = XGraphics.FromPdfPage(page);
            AddText(gfx2, textToAdd, 101, 170);
            AddText(gfx2, "Firma", 430, 220);
            AddText(gfx2, "Ul. Zawlazła 21/37, 12-345 Wadowice", 220, 250);
            AddText(gfx2, "Szachrajstwa, Malwersacje", 110, 300);
            AddText(gfx2, "Nosiwoda", 101, 380);
            // Saving PDF
            document.Save(filePath);
        }
    }
}

