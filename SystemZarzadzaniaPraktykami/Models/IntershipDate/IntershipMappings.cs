using FluentNHibernate.Mapping;

namespace SystemZarzadzaniaPraktykami.Models.IntershipDate;

public class IntershipMappings : ClassMap<IntershipDate>
{
    private readonly string tablename = nameof(IntershipDate);

    public IntershipMappings()
    {
        Id(x => x.id).GeneratedBy.Guid();
        Map(x => x.name);
        Map(x => x.start);
        Map(x => x.endTime);
        Table(tablename);
    }
}