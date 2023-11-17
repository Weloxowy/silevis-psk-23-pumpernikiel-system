using FluentMigrator;

namespace SystemZarzadzaniaPraktykami.Persistance.Student.Migrations;

[Migration(171120231806)]
public class CreateTable_171120231806 : Migration
{
    readonly string tableName = nameof(Student);
    public override void Up()
    {
        if (!Schema.Table(tableName).Exists())
        {
            //Create.Table(tableName)
                //.WithColumn("Id" )
        }
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}