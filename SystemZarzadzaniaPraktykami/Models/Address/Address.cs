using SystemZarzadzaniaPraktykami.Models.studentProgrammes;

namespace SystemZarzadzaniaPraktykami.Models.Address
{
    public class Address
    {

        public Address() : base() { }

        public Address(Guid id, string city, string street, string postcode, int number_house, int premises_number)
        {
            this.id = id;
            this.city = city;  
            this.street = street;
            this.postcode = postcode;
            this.premises_number = number_house;
            this.premises_number = premises_number;

            
        }

        public virtual Guid id { get; set; }
        public virtual string city { get; set; }
        public virtual string street { get; set; }
        public virtual string postcode { get; set; }
        public virtual int numeber_house { get; set; }
        public virtual int premises_number { get; set; }
       

    }
}
