using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SystemZarzadzaniaPraktykami.Persistance.Address.DatabaseMigrations
{
    [Migration(202311171905)]
    public class _202311171905_CreateTable_Address : Migration
    {
        readonly string tableName = nameof(Models.Address.Address);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Address.Address.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Address.Address.Street)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.HouseNumber)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.FlatNumber)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.City)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.PostalCode)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.Voivodeship)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.Country)).AsString().NotNullable();
                    
            }

        }
        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Table(tableName);
            };
        }
    }
}
