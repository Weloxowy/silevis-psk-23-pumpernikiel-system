using System.Runtime.InteropServices.JavaScript;

namespace SystemZarzadzaniaPraktykami.Models.internship;

public class Intership
{
    public Intership() : base()
    {
        
    }

    public Intership(DateTime start, DateTime endTime, string studentNumber, string studentLastName, string studentFirstName, string studentEmail, IntershipEnum intershipEnum, string feedBack, Company.Company company, string telNumber)
    {
        this.start = start;
        this.endTime = endTime;
        this.studentNumber = studentNumber;
        this.studentLastName = studentLastName;
        this.studentFirstName = studentFirstName;
        this.studentEmail = studentEmail;
        IntershipEnum = intershipEnum;
        this.feedBack = feedBack;
        this.company = company;
        this.telNumber = telNumber;
    }

    public virtual DateTime start { get; set; }
    public virtual DateTime endTime { get; set; }
    public virtual string studentNumber { get; set; }
    public virtual string studentLastName { get; set; }
    public virtual string studentFirstName { get; set; }
    public virtual string studentEmail { get; set; }
    public virtual IntershipEnum IntershipEnum { get; set; }
    public virtual string feedBack { get; set; }
    public virtual Company.Company company { get; set; }
    public virtual string telNumber { get; set; }
    public virtual passEnum PassEnum { get; set; }
}