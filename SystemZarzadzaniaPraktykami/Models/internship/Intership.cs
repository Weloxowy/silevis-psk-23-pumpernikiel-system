namespace SystemZarzadzaniaPraktykami.Models.internship;

public class Intership
{
    public Intership() : base()
    {
        
    }

    public virtual DateTime start { get; set; }
    public virtual DateTime end { get; set; }
    public virtual string studentNumber { get; set; }
    public virtual string studentLastName { get; set; }
    public virtual string studentFirstName { get; set; }
    public virtual string studentEmail { get; set; }
    public virtual IntershipEnum IntershipEnum { get; set; }
    public virtual string feedBack { get; set; }
}