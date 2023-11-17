using FluentNHibernate.Mapping;

namespace SystemZarzadzaniaPraktykami.Models.Lecturer
{
    public class LecturerMapping : ClassMap<Lecturer>
    {
        readonly string tablename = nameof(Lecturer);
        public LecturerMapping()
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Login);
            Map(x => x.Password);

        }
    }
}
