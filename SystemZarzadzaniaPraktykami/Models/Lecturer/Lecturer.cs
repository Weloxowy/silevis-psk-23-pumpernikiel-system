using FluentNHibernate.Utils;

namespace SystemZarzadzaniaPraktykami.Models.Lecturer
{
    public class Lecturer
    {
        public Lecturer() : base() { }

        public Lecturer(Guid id, string Name, string Surname, string Login, string Password)
        {
            this.id = id;
            this.Name = Name;
            this.Surname = Surname;
            this.Login = Login;
            this.Password = Password;

        }
        public virtual Guid id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Login { get; set; }   
        public virtual string Password { get; set; }

    }
}
