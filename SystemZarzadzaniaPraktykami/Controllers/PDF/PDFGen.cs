using System;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Linq;
using DocumentFormat.OpenXml;

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

        public void MassReplacing(string filePath)
        {
            List<string> into = new List<string>();
            into.Add("[NAME]");
            into.Add("[SNUM]");
            into.Add("[FACULTY]");
            into.Add("[TYPE OF STUDIES]");
            into.Add("[YEAR]");
            into.Add("[RECIEVER]");
            //into.Add("[FACULTY]");
            List<string> outo = new List<string>();
            outo.Add("Anna Słoma");
            outo.Add("092137");
            outo.Add("Informatyka");
            outo.Add("Stacjonarne");
            outo.Add("3 rok");
            outo.Add("dr. AAA BBBBBBB");
            //outo.Add("Informatyka");
            for(int i = 0;i< 5; i++)
            {
                ReplaceTextInWord(@"C:/Users/Pawel/Desktop/FileTEST.docx", into[i], outo[i]);
            }
            
        }
        public void CopyWordDocument(string sourceFilePath, string destinationFilePath)
        {
            using (WordprocessingDocument sourceDoc = WordprocessingDocument.Open(sourceFilePath, false))
            using (WordprocessingDocument destDoc = WordprocessingDocument.Create(destinationFilePath, WordprocessingDocumentType.Document))
            {
                // Klonowanie struktury dokumentu
                destDoc.AddMainDocumentPart().Document = new Document(sourceDoc.MainDocumentPart.Document.OuterXml);

                // Kopiowanie zawartości
                var paragraphs = destDoc.MainDocumentPart.Document.Body.Elements<Paragraph>().ToList();
                foreach (var paragraph in sourceDoc.MainDocumentPart.Document.Body.Elements<Paragraph>())
                {
                    paragraphs.Add(new Paragraph(paragraph.OuterXml));
                }

                // Zapisanie zmian w nowym dokumencie
                destDoc.MainDocumentPart.Document.Body.RemoveAllChildren<Paragraph>();
                destDoc.MainDocumentPart.Document.Body.Append(paragraphs);

                destDoc.MainDocumentPart.Document.Save();
            }
        }

        public void ReplaceTextInWord(string filePath, string searchText, string replaceText)
        {
            
            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                // Pobranie wszystkich paragrafów w dokumencie
                var paragraphs = doc.MainDocumentPart.Document.Body.Elements<Paragraph>().ToList();

                // Przeszukanie i zamiana tekstu w każdym paragrafie
                foreach (var paragraph in paragraphs)
                {
                    foreach (var run in paragraph.Elements<Run>())
                    {
                        foreach (var text in run.Elements<Text>())
                        {
                            if (text.Text.Contains(searchText))
                            {
                                text.Text = text.Text.Replace(searchText, replaceText);
                            }
                        }
                    }
                }

                // Zapisanie zmian w dokumencie
                doc.MainDocumentPart.Document.Save();
            }
        }
    }
}

