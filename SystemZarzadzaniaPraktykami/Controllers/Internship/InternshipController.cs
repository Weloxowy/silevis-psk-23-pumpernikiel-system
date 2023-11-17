using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Nhibernate;
using SystemZarzadzaniaPraktykami.Persistance.Address;
using SystemZarzadzaniaPraktykami.Persistance.Internship;

namespace SystemZarzadzaniaPraktykami.Controllers.Intership
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternshipController : ControllerBase
    {
        readonly IntershipService intershipService = new IntershipService();
        [HttpGet]
        public ActionResult<IEnumerable<Models.internship.Internship>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var Adres = session.Query<Models.internship.Internship>().ToList();
                return Ok(Adres);
            }
        }

    }
}
