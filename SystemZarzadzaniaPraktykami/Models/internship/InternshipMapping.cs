using FluentNHibernate.Mapping;
using SystemZarzadzaniaPraktykami.Models.studentProgrammes;

namespace SystemZarzadzaniaPraktykami.Models.internship
{
    public class InternshipMapping : ClassMap<Internship>
    {

     
            readonly string tablename = nameof(User);
            public InternshipMapping()
            {
                Id(x => x.id).GeneratedBy.Guid();
                Map(x => x.start);
                Map(x => x.endTime);
                Map(x => x.studentNumber);
                Map(x => x.studentFirstName);
                Map(x => x.studentEmail);
                Map(x => x.studentNumber);
                Map(x => x.IntershipEnum).CustomType<InternshipEnum>();
                Map(x => x.feedBack);
                Map(x => x.company);
                Map(x => x.telNumber);
                Map(x => x.PassEnum).CustomType<passEnum>();
                Table(tablename);
        }


        }
    }

