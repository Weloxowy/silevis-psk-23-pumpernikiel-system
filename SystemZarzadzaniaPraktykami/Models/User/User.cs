using SystemZarzadzaniaPraktykami.Models.studentProgrammes;

namespace SystemZarzadzaniaPraktykami.Models.User;

public class User
{
    public User() : base() {}

    public User(string id, string firstName, string lastName, int staffStatus, int studentStatus, string email, string studentNumber, StudentProgrammes studentProgrammes)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.staffStatus = staffStatus;
        this.studentStatus = studentStatus;
        this.email = email;
        this.studentNumber = studentNumber;
        this.studentProgrammes = studentProgrammes;
    }

    public virtual string id { get; set; }
    public virtual string firstName{ get; set; }
    public virtual string lastName{ get; set; }
    public virtual int staffStatus{ get; set; }
    public virtual int studentStatus{ get; set; }
    public virtual string email{ get; set; }
    public virtual string studentNumber{ get; set; }
    public virtual StudentProgrammes studentProgrammes{ get; set; }
}