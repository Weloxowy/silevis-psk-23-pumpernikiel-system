using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using SystemZarzadzaniaPraktykami.Models.User;
using SystemZarzadzaniaPraktykami.Controllers.PDF;
using SystemZarzadzaniaPraktykami.Persistance.User;
using SystemZarzadzaniaPraktykami.wwwroot.WebControllers;
using DinkToPdf;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserService, UserService>();
//PDFGen pdfGen = new PDFGen();//PDFGen pdfGen = new PDFGen();
//pdfGen.CopyFile(@"C:\Users\Marlena\Desktop\Hakaton\silevis-psk-23-pumpernikiel-system\SystemZarzadzaniaPraktykami\PDF'y\FileTEST.docx", @"C:\Users\Marlena\Desktop\Hakaton\silevis-psk-23-pumpernikiel-system\SystemZarzadzaniaPraktykami\PDF'y\FileTEST2.docx");
//pdfGen.MassReplacing(@"C:\Users\Marlena\Desktop\Hakaton\silevis-psk-23-pumpernikiel-system\SystemZarzadzaniaPraktykami\PDF'y\FileTEST2.docx");
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
//migrator.ListMigrations();
//migrator.MigrateUp();

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
app.Run();