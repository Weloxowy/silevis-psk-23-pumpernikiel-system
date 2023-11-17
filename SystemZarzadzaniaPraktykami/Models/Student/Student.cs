namespace SystemZarzadzaniaPraktykami.Models.Student;

public class Student
{
    public Student() : base() { }
    
    public Student(Guid Id,String StudentNumber, String Name, String MiddleNames, String Surname, DateOnly BirthDate, int StudentStatus)
    {
        this.Id = Id;
        this.StudentNumber = StudentNumber;
        this.Name = Name;   
        this.MiddleNames = MiddleNames;
        this.Surname = Surname;
        this.StudentStatus = StudentStatus;
        this.BirthDate = BirthDate;

    }

    public virtual Guid Id { get; set; }
    public virtual String StudentNumber { get; set;}
    public virtual String Name { get; set;}
    public virtual String MiddleNames { get; set;}
    public virtual String Surname { get; set;}
    public virtual DateOnly BirthDate { get; set;}
    public virtual int StudentStatus { get; set;}
       
}