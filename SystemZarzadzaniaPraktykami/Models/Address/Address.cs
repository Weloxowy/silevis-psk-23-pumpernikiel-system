namespace SystemZarzadzaniaPraktykami.Models.Address
{
    public class Address
    {
        public Address() : base() { }

        public Address (Guid id, String Street, String HouseNumber, String FlatNumber, String City, String PostalCode, String Voivodeship, String Country)
        {
            this.id = id;
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.FlatNumber = FlatNumber;
            this.City = City;
            this.PostalCode = PostalCode;
            this.Voivodeship = Voivodeship;
            this.Country = Country;
        }

        public virtual Guid id { get; set; } 
        public virtual String Street { get; set; }
        public virtual String HouseNumber { get; set; }
        public virtual String FlatNumber { get; set; }
        public virtual String City { get; set; }
        public virtual String PostalCode { get; set; }
        public virtual String Voivodeship { get; set; }
        public virtual String Country { get; set; }

    }
}
