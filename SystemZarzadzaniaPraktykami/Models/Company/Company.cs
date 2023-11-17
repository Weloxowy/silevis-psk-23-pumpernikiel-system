namespace SystemZarzadzaniaPraktykami.Models.Company;

public class Company
{
    public Company() : base()
    {
       
    }

    public Company(string name)
    {
        this.name = name;
    }

    public virtual Guid id { get; set; }
    public virtual string name { get; set; }
}