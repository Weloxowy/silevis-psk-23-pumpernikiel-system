namespace SystemZarzadzaniaPraktykami.Models.Student;

public class Student
{
    public Student() : base() { }
    
    public Student(Guid id,String StudentNumber, String Name, String MiddleNames, String Surname, DateOnly BirthDate, int StudentStatus, String login, String password)
    {
        this.id = id;
        this.StudentNumber = StudentNumber;
        this.Name = Name;   
        this.MiddleNames = MiddleNames;
        this.Surname = Surname;
        this.StudentStatus = StudentStatus;
        this.BirthDate = BirthDate;
        this.Login = Login;
        this.Password = Password;

    }

    public virtual Guid id { get; set; }
    public virtual String StudentNumber { get; set;}
    public virtual String Name { get; set;}
    public virtual String MiddleNames { get; set;}
    public virtual String Surname { get; set;}
    public virtual DateOnly BirthDate { get; set;}
    public virtual int StudentStatus { get; set;}
    public virtual String Login { get; set;}
    public virtual String Password { get; set;}
       
}