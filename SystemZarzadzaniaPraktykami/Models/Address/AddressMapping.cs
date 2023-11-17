using FluentNHibernate.Mapping;

namespace SystemZarzadzaniaPraktykami.Models.Address
{
    public class AddressMapping : ClassMap<Address>
    {
        readonly string tablename = nameof(Address);
        public AddressMapping() 
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.Street);
            Map(x => x.HouseNumber);
            Map(x => x.FlatNumber);
            Map(x => x.City);
            Map(x => x.PostalCode);
            Map(x => x.Voivodeship);
            Map(x => x.Country);

            Table(tablename);
        }
    }
}
