using FluentNHibernate.Mapping;

namespace SystemZarzadzaniaPraktykami.Models.Company;

public class CompanyMapping : ClassMap<Company>
{
    public CompanyMapping() 
    {
        Id(x => x.id).GeneratedBy.Guid();
        Map(x => x.name);
        Map(x => x.address);
        Table(nameof(Company));
    }
}