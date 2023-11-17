using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using SystemZarzadzaniaPraktykami.Models.Student;
using SystemZarzadzaniaPraktykami.Models.Address;

namespace SystemZarzadzaniaPraktykami.Nhibernate;

 public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost\\SQLEXPRESS;Database=Hackaton;Integrated Security=SSPI;Application Name=SystemZarzadzaniaPraktykami;TrustServerCertificate=true;")
                        )
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<Student>()
                        )
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<Address>()
                        )
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
    }