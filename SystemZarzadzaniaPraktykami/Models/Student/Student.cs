namespace SystemZarzadzaniaPraktykami.Models.Student;

public class Student
{
    public Student() : base() { }

    public Student(Guid id, string StudentNumber, string Name, string MiddleNames, string Surname, DateTime BirthDate, int StudentStatus, string Login, string Password, Guid Address)
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
        this.Address = Address;

    }

    public virtual Guid id { get; set; }
    public virtual string StudentNumber { get; set; }
    public virtual string Name { get; set; }
    public virtual string MiddleNames { get; set; }
    public virtual string Surname { get; set; }
    public virtual DateTime BirthDate { get; set; }
    public virtual int StudentStatus { get; set; }
    public virtual string Login { get; set; }
    public virtual string Password { get; set; }
    public virtual Guid Address { get; set; }
}