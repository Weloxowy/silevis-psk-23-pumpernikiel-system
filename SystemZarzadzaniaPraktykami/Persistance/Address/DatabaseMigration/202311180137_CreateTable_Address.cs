using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SystemZarzadzaniaPraktykami.Persistance.Address.DatabaseMigration
{
    [Migration(202311180137)]
    public class _202311180137_CreateTable_Address : Migration
    {
        readonly string tableName = nameof(Models.Address.Address);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Address.Address.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Address.Address.city)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.street)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.postcode)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.numeber_house)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Address.Address.premises_number)).AsString().NotNullable();

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
