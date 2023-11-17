using FluentMigrator;
using static NHibernate.Engine.Query.CallableParser;
using SystemZarzadzaniaPraktykami.Models.studentProgrammes;

namespace SystemZarzadzaniaPraktykami.Persistance.User.DatabaseMigrations.Iteration01
{
    [Migration(202311172241)]
    public class _202311172241_CreateTable_User : Migration
    {
        readonly string tableName = nameof(Models.User.User);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.User.User.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.User.User.firstName)).AsString().NotNullable()
                    .WithColumn(nameof(Models.User.User.lastName)).AsString().NotNullable()
                    .WithColumn(nameof(Models.User.User.staffStatus)).AsString().NotNullable()
                    .WithColumn(nameof(Models.User.User.studentStatus)).AsString().NotNullable()
                    .WithColumn(nameof(Models.User.User.email)).AsString().NotNullable()
                    .WithColumn(nameof(Models.User.User.studentNumber)).AsString().NotNullable()
                    .WithColumn(nameof(Models.User.User.studentProgrammes)).AsInt32().NotNullable();

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
