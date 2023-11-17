namespace SystemZarzadzaniaPraktykami.Models.Company;

public class Company
{
    public Company() : base()
    {
       
    }

    public Company(Guid id, string name, Address.Address address)
    {
        this.id = id;
        this.name = name;
        this.address = address;
    }

    public virtual Guid id { get; set; }
    public virtual string name { get; set; }
    public virtual Address.Address address { get; set; }
}