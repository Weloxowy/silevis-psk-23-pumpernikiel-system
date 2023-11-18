using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using SystemZarzadzaniaPraktykami.Models.User;
using SystemZarzadzaniaPraktykami.Persistance.User;

namespace SystemZarzadzaniaPraktykami.Controllers.PDF;

public class PDF
{
    private readonly IUserService userService;
    
    public string coordinator;
    public string boss;
    public string company;
    public string companyAddress;
    public string notes;
    public int hours;
    public PDF(IUserService userService)
    {
        
        this.userService = userService;
        string pdfFilePath = "Zalacznik_nr_4.pdf";
        using (FileStream fs = new FileStream(pdfFilePath, FileMode.Create))
        {
            using (PdfWriter writer = new PdfWriter(fs))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Add content to the PDF document
                    AddContent(document);

                    Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(pdfFilePath));
                }
            }
        }
    }
     void AddContent(Document document)
    {
        // Add your content to the document here
        document.Add(new Paragraph("Załącznik nr 4 do Zarządzenia Nr 54/19 Rektora Politechniki Świętokrzyskiej z dnia 20 września 2019 r."));
        document.Add(new Paragraph(userService.GetLoggedInUser().firstName + " " + userService.GetLoggedInUser().lastName));
        document.Add(new Paragraph("Imię i nazwisko studenta, nr albumu"));
        document.Add(new Paragraph("Informatyka stacjonarnie"));
        document.Add(new Paragraph("Kierunek i forma studiów"));
        int year = DateTime.Now.Year;
        document.Add(new Paragraph(year + "/" + year+1));
        document.Add(new Paragraph("Rok studiów"));
        document.Add(new Paragraph("Pani/Pan Prodziekan ds. Studenckich Wydziału"));
        document.Add(new Paragraph("Dr inz."));
        document.Add(new Paragraph("Barbara Lukawska"));
        document.Add(new Paragraph("Podanie o zaliczenie praktyki studenckiej"));
        document.Add(new Paragraph("Zwracam się z uprzejmą prośbą o zaliczenie mi praktyki na studiach stacjonarnych/niestacjonarnych"));
        document.Add(new Paragraph("na kierunku Informatyka w roku akademickim " + year +"/"+year+1));
        document.Add(new Paragraph("na podstawie (wpisać jedną z sytuacji określoną w § 6 ust. 10 Regulaminu praktyk zawodowych)"));
        document.Add(new Paragraph("nie wiem"));
        document.Add(new Paragraph("Jako potwierdzenie załączam (załącznik A) stosowne zaświadczenie."));
        document.Add(new Paragraph(userService.GetLoggedInUser().firstName + " " + userService.GetLoggedInUser().lastName));
        document.Add(new Paragraph("Podpis Studenta"));
        document.Add(new Paragraph("Opinie:"));
        document.Add(new Paragraph("1. Opiekun praktyki na kierunku Informatyka"));
        document.Add(new Paragraph("Wyrażam zgodę/nie wyrażam zgody1 na zaliczenie praktyki i przedstawiam sprawę do dalszego rozpatrzenia"));
        document.Add(new Paragraph("data, podpis " + coordinator));
        document.Add(new Paragraph("2. Wydziałowy kierownik praktyk "+boss));
        document.Add(new Paragraph("Wyrażam zgodę/nie wyrażam zgody1 na zaliczenie praktyki i przedstawiam sprawę do dalszego rozpatrzenia"));
        document.Add(new Paragraph("Podpis " + boss));
        document.Add(new Paragraph("3. Prodziekan ds. Studenckich Wydziału………………….."));
        document.Add(new Paragraph("Wyrażam zgodę/nie wyrażam zgody1 na zaliczenie praktyki"));
        document.Add(new Paragraph("Podpis…………………………………."));
        document.Add(new Paragraph("1 niepotrzebne skreślić"));
        document.Add(new Paragraph("Załącznik A"));
        document.Add(new Paragraph("ZAŚWIADCZENIE"));
        document.Add(new Paragraph("1. Cel wystawienia: zaliczenie praktyki studenckiej"));
        document.Add(new Paragraph("2. Imię i nazwisko studenta: "+userService.GetLoggedInUser().firstName + " " + userService.GetLoggedInUser().lastName));
        document.Add(new Paragraph("3. Nazwa instytucji/zakładu, w której pracuje/pracował student: "+company));
        document.Add(new Paragraph("……………………………………………………………………………………………………………."));
        document.Add(new Paragraph("4. Adres instytucji/zakładu " + companyAddress));
        document.Add(new Paragraph("5. Profil działalności"));
        document.Add(new Paragraph("……………………………………………………………………………………………………………."));
        document.Add(new Paragraph("6. Stanowisko studenta w czasie pracy"));
        document.Add(new Paragraph(""));
        document.Add(new Paragraph("7. Czas pracy " + hours));
        document.Add(new Paragraph("8. Zakres obowiązków studenta w czasie pracy w odniesieniu do kierunku jego studiów"));
        document.Add(new Paragraph("……………………………………………………………………………………………………………"));
        document.Add(new Paragraph("9. Dane osoby, która może poświadczyć prawdziwość powyższych danych (prezes, dyrektor, Koordynator Programu Badawczego/Erasmusa, itp.) wraz z podpisem"));
        document.Add(new Paragraph("……………………………………………………………………………………………………….."));
        document.Add(new Paragraph("10. Uwagi " + notes));
        document.Add(new Paragraph("11. Data i podpis studenta " + DateTime.Now + " " + userService.GetLoggedInUser().firstName + " " + userService.GetLoggedInUser().lastName));
    }
}
