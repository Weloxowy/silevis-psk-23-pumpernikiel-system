namespace SystemZarzadzaniaPraktykami.Models.IntershipDate;

public class IntershipDate
{
    public IntershipDate() : base()
    {
        
    }

    public IntershipDate(Guid id, string name, DateTime start, DateTime endTime)
    {
        this.id = id;
        this.name = name;
        this.start = start;
        this.endTime = endTime;
    }
    public virtual Guid id { get; set; }
    public virtual string name { get; set; }
    public virtual DateTime start { get; set; }
    public virtual DateTime endTime { get; set; }
}