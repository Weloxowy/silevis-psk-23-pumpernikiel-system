using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using SystemZarzadzaniaPraktykami.Models.User;
using SystemZarzadzaniaPraktykami.Controllers.PDF;
using SystemZarzadzaniaPraktykami.Persistance.User;
using DinkToPdf.Contracts;
using DinkToPdf;

var builder = WebApplication.CreateBuilder(args);


PDFGen pdfGen = new PDFGen();
pdfGen.CopyFile(@"C:/Users/Pawel/Downloads/FileTEST.docx", @"C:/Users/Pawel/Desktop/FileNEW.docx");
pdfGen.MassReplacing(@"C:/Users/Pawel/Desktop/FileNEW.docx");
var converter = new BasicConverter(new PdfTools());
pdfGen.ConvertDocxToPdf(converter,@"C:/Users/Pawel/Desktop/FileNEW.docx",@"C:/Users/Pawel/Desktop/FileNEW.pdf");
//pdfgen.AddTextToPdf(@"C:/Users/Pawel/Desktop/FileTEST.pdf", "Anna Musia³, 092137");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserService, UserService>();
// Fluent Migrator
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(c =>
    {
        c.AddSqlServer2016()
            .WithGlobalConnectionString("Server=localhost\\SQLEXPRESS;Database=Hackaton;Integrated Security=SSPI;Application Name=SystemZarzadzaniaPraktykami; TrustServerCertificate=true;")
            .ScanIn(Assembly.GetExecutingAssembly()).For.All();
    })
    .AddLogging(config => config.AddFluentMigratorConsole());


var app = builder.Build();

using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
migrator.ListMigrations();
migrator.MigrateUp();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    //endpoints.MapDefaultControllerRoute();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
User user = new User();
app.Run();