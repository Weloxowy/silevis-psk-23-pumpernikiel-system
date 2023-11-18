using System;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DinkToPdf.Contracts;
using DinkToPdf;
using SystemZarzadzaniaPraktykami.Models.User;
using SystemZarzadzaniaPraktykami.Persistance.User;

namespace SystemZarzadzaniaPraktykami.Controllers.PDF
{
    
    public class PDFGen
    {
        private readonly UserService userService;

        public PDFGen(UserService userService)
        {
            this.userService = userService;
        }
        DateOnly donly = DateOnly.FromDateTime(DateTime.Today);
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
            Dictionary<String,String> dic = new Dictionary<String,String>();

            List<string> into = new List<string>();
            into.Add("[NAME]");
            into.Add("[SNUM]");
            into.Add("[FACULTY]");
            into.Add("[TYPE OF STUDIES]");
            into.Add("[YEAR]");
            into.Add("[RECIEVER]");
            into.Add("[ARGUMENT]");
            into.Add("[NAME1]");
            into.Add("[NAME2]");
            into.Add("[NAME3]");
            into.Add("[FR]");
            into.Add("[SR]");
            into.Add("[WORKPLACE]");
            into.Add("[WORKPLACE ADDRESS]");
            into.Add("[PROFILE]");
            into.Add("[POSITION]");
            into.Add("[WORKTIME]");
            into.Add("[DUTIES]");
            into.Add("[COORDINATOR]");
            into.Add("[NOTES]");
            into.Add("[DATE]");
            List<string> outo = new List<string>();
            string text = userService.GetLoggedInUser().firstName + " " + userService.GetLoggedInUser().lastName;
            outo.Add(text);
            outo.Add(userService.GetLoggedInUser().studentNumber);
            outo.Add("Informatyka");
            outo.Add("Stacjonarne");
            outo.Add("3 rok");
            outo.Add("dr. AAA BBBBBBB");
            outo.Add("umowy o pracę");
            outo.Add("AAAAAAAAAAAA");
            outo.Add("BBBBBBBBBBBB");
            outo.Add("CCCCCCCCCCCC");
            outo.Add("23");
            outo.Add("24");
            outo.Add("FIRMA");
            outo.Add("Zawlazła 21/37, 25-311 Kielce");
            outo.Add("Wymuszenia, Stręczycielstwo");
            outo.Add("Konsultant ds. IT");
            outo.Add("160 h.");
            outo.Add("Zarządzanie infrastrukturą sieciową firmy. Praca na helpdesku.");
            outo.Add("Artur Kawalec");
            outo.Add("");
            outo.Add(donly.ToString());
            for (int i = 0;i< 20; i++)
            {
                ReplaceTextInWord(filePath, into[i], outo[i]);
            }
            
        }
        public void CopyFile(string sourceFilePath, string destinationFilePath)
        {
            File.Copy(sourceFilePath, destinationFilePath, true);
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

        public void initCOnversion(string sourceFilePath, string destinationFilePath)
        {
            // Inicjalizacja konwertera
            var converter = new BasicConverter(new PdfTools());

            // Ścieżka do pliku .docx wejściowego
            string docxFilePath = "ścieżka_do_pliku.docx";

            // Ścieżka do pliku .pdf wynikowego
            string pdfFilePath = "ścieżka_do_pliku.pdf";

            // Konwersja .docx do .pdf
            ConvertDocxToPdf(converter, sourceFilePath, destinationFilePath);

            Console.WriteLine("Konwersja zakończona pomyślnie.");
        }
        public void ConvertDocxToPdf(IConverter converter, string inputFilePath, string outputFilePath)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                PaperSize = PaperKind.A4,
                Orientation = Orientation.Portrait
            },
                Objects = {
                new ObjectSettings() {
                    PagesCount = true,
                    HtmlContent = File.ReadAllText(inputFilePath),
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            byte[] pdfBytes = converter.Convert(doc);

            File.WriteAllBytes(outputFilePath, pdfBytes);
        }
    }
}

