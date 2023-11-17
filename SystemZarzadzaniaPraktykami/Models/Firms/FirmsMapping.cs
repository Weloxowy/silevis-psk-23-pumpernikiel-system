using FluentNHibernate.Mapping;
using SystemZarzadzaniaPraktykami.Models.Firms;
namespace SystemZarzadzaniaPraktykami.Models.Firms
{
        public class FirmsMapping : ClassMap<Firms>
        {
            readonly string tablename = nameof(Firms);
            public FirmsMapping()
            {
                Id(x => x.id).GeneratedBy.Guid();
                Map(x => x.name);
                Map(x => x.phone_contact);
                Map(x => x.mail);
                Map(x => x.nip);
                Map(x => x.regon);
                Map(x => x.krs);
                Map(x => x.address); 
                Table(tablename);
             }
        }
}


