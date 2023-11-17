using FluentMigrator;
namespace SystemZarzadzaniaPraktykami.Persistance.Student.DatabaseMigrations.Iteration1
{
    [Migration(202311171921)]
    public class _202311171921_CreateTable_Student : Migration
    {
        readonly string tableName = nameof(Models.Student.Student);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Student.Student.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Student.Student.StudentNumber)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Student.Student.Name)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Student.Student.MiddleNames)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Student.Student.Surname)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Student.Student.BirthDate)).AsDateTime().NotNullable()
                    .WithColumn(nameof(Models.Student.Student.Login)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Student.Student.Password)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Student.Student.StudentStatus)).AsInt32().NotNullable()
                    .WithColumn("Address").AsGuid().NotNullable();

                Create.ForeignKey("FK_Address").FromTable(tableName).ForeignColumn("Address").ToTable("Address").PrimaryColumn("id");
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
