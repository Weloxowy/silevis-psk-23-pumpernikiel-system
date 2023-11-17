using FluentMigrator;

namespace SystemZarzadzaniaPraktykami.Persistance.Lecturer.DatabaseMigrations.Iteration2
{
    [Migration(202311172102)]
    public class _202311172102_CreateTable_Lecturer : Migration
    {
        readonly string tableName = nameof(Models.Lecturer);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Lecturer.Lecturer.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Lecturer.Lecturer.Name)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Lecturer.Lecturer.Surname)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Lecturer.Lecturer.Login)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Lecturer.Lecturer.Password)).AsString().NotNullable();              

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
