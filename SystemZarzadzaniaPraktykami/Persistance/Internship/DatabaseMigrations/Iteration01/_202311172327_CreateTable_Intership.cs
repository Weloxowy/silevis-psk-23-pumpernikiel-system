using FluentMigrator;
using System.Security.Cryptography;
using SystemZarzadzaniaPraktykami.Models.Company;
using SystemZarzadzaniaPraktykami.Models.internship;


namespace SystemZarzadzaniaPraktykami.Persistance.User.DatabaseMigrations.Iteration01
{
    [Migration(202311172327)]
    public class _202311172327_CreateTable_Intership : Migration
    {
        readonly string tableName = nameof(Models.internship.Internship);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.internship.Internship.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.internship.Internship.start)).AsString().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.studentNumber)).AsString().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.studentLastName)).AsString().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.studentEmail)).AsString().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.IntershipEnum)).AsInt32().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.feedBack)).AsString().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.company)).AsString().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.telNumber)).AsString().NotNullable()
                    .WithColumn(nameof(Models.internship.Internship.PassEnum)).AsInt32().NotNullable()
                    .WithColumn("FK_company").AsGuid().NotNullable();
               
                Create.ForeignKey("FK_company").FromTable("Internship").ForeignColumn("company").ToTable("Company").PrimaryColumn("id");

            }
        }
        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Table(tableName);
            }



        }
    }
}