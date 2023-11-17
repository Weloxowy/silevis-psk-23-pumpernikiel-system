using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode.Impl;

namespace SystemZarzadzaniaPraktykami.Models.Student
{
    public class StudentMapping : ClassMap<Student>
    {
        readonly String tablename = nameof(Student);

        public StudentMapping()
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.StudentNumber);
            Map(x => x.Name);
            Map(x => x.MiddleNames);
            Map(x => x.Surname);
            Map(x => x.BirthDate);
            Map(x => x.StudentStatus);
            Map(x => x.Login);
            Map(x => x.Password);
            Map(x => x.Address);

            Table(tablename);
        }
    }
}
