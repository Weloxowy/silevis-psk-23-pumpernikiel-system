using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Nhibernate;
using SystemZarzadzaniaPraktykami.Persistance.Address;
using SystemZarzadzaniaPraktykami.Persistance.Internship;

namespace SystemZarzadzaniaPraktykami.Controllers.Intership
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("{id}")]
        public ActionResult<Models.internship.Internship> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var Adres = session.Get<Models.internship.Internship>(id);

                if (Adres == null)
                {
                    return NotFound();
                }

                return Ok(Adres);
            }

        }
        [HttpPost]
        public ActionResult<Models.internship.Internship> CreateAdresEntity([FromBody] Models.internship.Internship Adres)
        {
            if (Adres == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(Adres);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = Adres.id }, Adres);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteKlientEntity(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var adres = session.Get<Models.internship.Internship>(id);

                        if (adres == null)
                        {
                            return NotFound();
                        }


                        session.Delete(adres);


                        transaction.Commit();

                        return NoContent();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
