using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;

namespace SystemZarzadzaniaPraktykami.Models.internship;

public class Internship
{
    public Internship() : base()
    {
        
    }

    public Internship(Guid id, DateTime start, DateTime endTime, string studentNumber, string studentLastName, string studentFirstName, string studentEmail, InternshipEnum intershipEnum, string feedBack, string telNumber, passEnum passEnum, Guid company)
    {
        this.id = id;
        this.start = start;
        this.endTime = endTime;
        this.studentNumber = studentNumber;
        this.studentLastName = studentLastName;
        this.studentFirstName = studentFirstName;
        this.studentEmail = studentEmail;
        IntershipEnum = intershipEnum;
        this.feedBack = feedBack;
        this.telNumber = telNumber;
        PassEnum = passEnum;
        this.company = company;
    }

    public virtual Guid id { get; set; }
    public virtual DateTime start { get; set; }
    public virtual DateTime endTime { get; set; }
    public virtual string studentNumber { get; set; }
    public virtual string studentLastName { get; set; }
    public virtual string studentFirstName { get; set; }
    public virtual string studentEmail { get; set; }
    public virtual InternshipEnum IntershipEnum { get; set; }
    public virtual string feedBack { get; set; }
    public virtual Guid company { get; set; }
    public virtual string telNumber { get; set; }
    public virtual passEnum PassEnum { get; set; }
}