using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

using SystemZarzadzaniaPraktykami.Models.Firms;

namespace SystemZarzadzaniaPraktykami.Persistance.Firms.DatabaseMigrations.Iteration01
{

    [Migration(202311172050)]
    public class _202311172050_CreateTable_Firms : Migration
    {
        readonly string tableName = nameof(Models.Firms.Firms);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Firms.Firms.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Firms.Firms.name)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Firms.Firms.phone_contact)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Firms.Firms.mail)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Firms.Firms.nip)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Firms.Firms.regon)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Firms.Firms.krs)).AsString().NotNullable();
                    //.WithColumn(nameof(Models.Firms.Firms.mail)).AsString().NotNullable(); dodac klucz obcy
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

