using FluentMigrator;

namespace SystemZarzadzaniaPraktykami.Persistance.Address.DatabaseMigration;
[Migration(171120232300)]
public class CreateTable_171120232300 : Migration
{
    readonly string tableName = nameof(Models.Address.Address);
    public override void Up()
    {
        if (!Schema.Table(tableName).Exists())
        {
            Create.Table(tableName)
                .WithColumn(nameof(Models.Address.Address.id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(Models.Address.Address.premises_number)).AsInt32()
                .WithColumn(nameof(Models.Address.Address.city)).AsString()
                .WithColumn(nameof(Models.Address.Address.postcode)).AsString()
                .WithColumn(nameof(Models.Address.Address.numeber_house)).AsInt32()
                .WithColumn(nameof(Models.Address.Address.street)).AsString();

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