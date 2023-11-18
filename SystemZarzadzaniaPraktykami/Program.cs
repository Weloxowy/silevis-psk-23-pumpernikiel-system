using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using SystemZarzadzaniaPraktykami.Controllers.PDFParse;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Razor
builder.Services.AddRazorPages();
//Fluent migrator
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(c =>
    {
        c.AddSqlServer2016()
            .WithGlobalConnectionString("Server=localhost\\SQLEXPRESS;Database=Hackaton;Integrated Security=SSPI;Application Name=SystemZarzadzaniaPraktykami; TrustServerCertificate=true;")
            .ScanIn(Assembly.GetExecutingAssembly()).For.All();
    })
    .AddLogging(config => config.AddFluentMigratorConsole());
var app = builder.Build();


PDFGen pdfgen = new PDFGen();

pdfgen.AddTextToPdf(@"C:/Users/Pawel/Desktop/FileTEST.pdf", "Anna Musia³, 092137");


using var scope = app.Services.CreateScope();
// Configure the HTTP request pipeline.
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

app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
app.Run();
