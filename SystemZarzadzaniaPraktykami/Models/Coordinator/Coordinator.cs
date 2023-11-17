using System;
namespace SystemZarzadzaniaPraktykami.Models.Coordinator;

public class Coordinator
{
        public Coordinator() : base() { }

        public Coordinator(Guid id, string login, string password, string name, string surname, string company, string phone_number, string mail)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.company = company;
            this.phone_number = phone_number;
            this.mail = mail;
        }


    public virtual Guid id { get; set; }
    public virtual string login { get; set; }
    public virtual string password { get; set; }
    public virtual string name { get; set; }
    public virtual string surname { get; set; }
    public virtual string company { get; set; }
    public virtual string phone_number { get; set; }
    public virtual string mail { get; set; }
}
