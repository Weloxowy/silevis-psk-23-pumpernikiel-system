using Microsoft.AspNetCore.Mvc;

using SystemZarzadzaniaPraktykami.Models;
using SystemZarzadzaniaPraktykami.Models.Coordinator;
using SystemZarzadzaniaPraktykami.Persistence.Coordinator;
using System.Reflection;
using SystemZarzadzaniaPraktykami.Nhibernate;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SystemZarzadzaniaPraktykami.Models.Firms;

namespace SystemZarzadzaniaPraktykami.Controllers.CoordinatorController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmsController : ControllerBase
    {
        readonly Firms coordinatorService = new Firms();

        [HttpGet]
        public ActionResult<IEnumerable<Models.Firms.Firms>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var coordinator = session.Query<Models.Firms.Firms>().ToList();
                return Ok(coordinator);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Firms.Firms> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var coordinator = session.Get<Models.Firms.Firms>(id);

                if (coordinator == null)
                {
                    return NotFound();
                }
                return Ok(coordinator);
            }

        }

        [HttpPost]
        public ActionResult<Models.Firms.Firms> CreateAdresEntity([FromBody] Models.Firms.Firms firms)
        {
            if (firms == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(firms);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = firms.id }, firms);
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
                        var firms = session.Get<Models.Firms.Firms>(id);

                        if (firms == null)
                        {
                            return NotFound();
                        }


                        session.Delete(firms);


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
