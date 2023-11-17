using FluentNHibernate.Mapping;
using SystemZarzadzaniaPraktykami.Models.Coordinator;

namespace SystemZarzadzaniaPraktykami.Models.Coordinator
{
    public class CoordinatorMapping : ClassMap<Coordinator>
    {
        readonly string tablename = nameof(Coordinator);
        public CoordinatorMapping()
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.login);
            Map(x => x.password);
            Map(x => x.name);
            Map(x => x.surname);
            Map(x => x.company);
            Map(x => x.phone_number);
            Map(x => x.mail);
            Table(tablename);
        }
    }
}
