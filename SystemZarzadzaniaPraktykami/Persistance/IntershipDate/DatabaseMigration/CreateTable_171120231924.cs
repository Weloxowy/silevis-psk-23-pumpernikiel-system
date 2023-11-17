using FluentMigrator;

namespace SystemZarzadzaniaPraktykami.Persistance.IntershipDate.DatabaseMigration;
[Migration(202310182156)]
public class CreateTable_171120231924 : Migration
{
    readonly string tableName = nameof(Models.IntershipDate.IntershipDate);
    public override void Up()
    {
        if (!Schema.Table(tableName).Exists())
        {
            Create.Table(tableName)
                .WithColumn(nameof(Models.IntershipDate.IntershipDate.id)).AsGuid().NotNullable().PrimaryKey()
                .WithColumn(nameof(Models.IntershipDate.IntershipDate.name)).AsString().NotNullable()
                .WithColumn(nameof(Models.IntershipDate.IntershipDate.start)).AsDateTime().NotNullable()
                .WithColumn(nameof(Models.IntershipDate.IntershipDate.endTime)).AsDateTime().NotNullable();

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