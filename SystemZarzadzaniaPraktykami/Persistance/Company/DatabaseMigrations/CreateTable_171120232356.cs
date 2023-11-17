using FluentMigrator;
using NHibernate.Proxy;

namespace SystemZarzadzaniaPraktykami.Persistance.Company.DatabaseMigrations;
[Migration(171120232356)]
public class CreateTable_171120232356 : Migration
{
    readonly string tableName = nameof(Models.Company.Company);
    public override void Up()
    {
        if (!Schema.Table(tableName).Exists())
        {
            Create.Table(tableName)
                .WithColumn(nameof(Models.Company.Company.id)).AsGuid().PrimaryKey()
                .WithColumn(nameof(Models.Company.Company.name)).AsString()
                .WithColumn(nameof(Models.Company.Company.address)).AsGuid().NotNullable();
                Create.ForeignKey("FK_Address").FromTable("Company").ForeignColumn("address").ToTable("Address")
                .PrimaryColumn("id");
        }
    }

    public override void Down()
    {
        if (Schema.Table(tableName).Exists())
        {
            Delete.ForeignKey("FK_Address").OnTable(tableName);
            Delete.Table(tableName);
        }
    }
}