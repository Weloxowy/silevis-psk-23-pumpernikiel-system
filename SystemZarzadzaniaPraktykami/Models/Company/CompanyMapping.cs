using FluentNHibernate.Mapping;
using NHibernate.Mapping;

namespace SystemZarzadzaniaPraktykami.Models.Company;

public class CompanyMapping : ClassMap<Company>
{
    readonly string tablename = nameof(Company);

    public CompanyMapping()
    {
        Id(x => x.id).GeneratedBy.Guid();
        Map(x => x.name);
        Map(x => x.address);
        Table(tablename);
    }
}