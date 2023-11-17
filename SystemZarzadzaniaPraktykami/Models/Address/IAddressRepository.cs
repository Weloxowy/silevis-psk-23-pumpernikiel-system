namespace SystemZarzadzaniaPraktykami.Models.Address
{
    public interface IAddressRepository
    {
        public bool edit(Guid id, string Street, string HouseNumber, string FlatNumber, string City, string PostalCode, string Voivodeship, string Country);
    }
}
