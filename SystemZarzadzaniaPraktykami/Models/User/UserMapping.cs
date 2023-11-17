using FluentNHibernate.Mapping;
using SystemZarzadzaniaPraktykami.Models.studentProgrammes;

namespace SystemZarzadzaniaPraktykami.Models.User
{
    public class UserMapping : ClassMap<User>
    {
        readonly string tablename = nameof(User);
        public UserMapping()
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.firstName);
            Map(x => x.lastName);
            Map(x => x.staffStatus);
            Map(x => x.studentStatus);
            Map(x => x.email);
            Map(x => x.studentNumber);
            Map(x => x.studentProgrammes).CustomType<StudentProgrammes>();
            Table(tablename);
        }

    }
}
