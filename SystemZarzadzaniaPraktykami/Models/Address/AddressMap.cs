using FluentNHibernate.Mapping;

namespace SystemZarzadzaniaPraktykami.Models.Address;

public class AddressMap : ClassMap<Address>
{
    public AddressMap()
    {
        Id(x => x.id).GeneratedBy.Guid();
        Map(x => x.numeber_house);
        Map(x => x.premises_number);
        Map(x => x.postcode);
        Map(x => x.street);
        Map(x => x.city);
        Table(nameof(Address));
    }
}