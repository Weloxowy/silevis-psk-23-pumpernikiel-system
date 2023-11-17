using FluentMigrator;
using SystemZarzadzaniaPraktykami.Models.Coordinator;


namespace SystemZarzadzaniaPraktykami.Persistence.Coordinator.DatabaseMigrations.Iteration01
{
    [Migration(202311171834)]
    public class _202311171834_CreateTable_Coordinator : Migration
    {
        readonly string tableName = nameof(Models.Coordinator.Coordinator);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(Models.Coordinator.Coordinator.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(Models.Coordinator.Coordinator.login)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Coordinator.Coordinator.password)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Coordinator.Coordinator.name)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Coordinator.Coordinator.surname)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Coordinator.Coordinator.company)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Coordinator.Coordinator.phone_number)).AsString().NotNullable()
                    .WithColumn(nameof(Models.Coordinator.Coordinator.mail)).AsString().NotNullable();

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
