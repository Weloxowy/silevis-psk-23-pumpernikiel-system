using Microsoft.AspNetCore.Mvc;

using SystemZarzadzaniaPraktykami.Models;
using SystemZarzadzaniaPraktykami.Models.Coordinator;
using SystemZarzadzaniaPraktykami.Persistence.Coordinator;
using System.Reflection;
using SystemZarzadzaniaPraktykami.Nhibernate;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SystemZarzadzaniaPraktykami.Controllers.CoordinatorController
{
    [Route("api/[controller]")]
    [ApiController] 
    public class CoordinatorController : ControllerBase
    {
        readonly Coordinator coordinatorService = new Coordinator();

        [HttpGet]
        public ActionResult<IEnumerable<Models.Coordinator.Coordinator>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var coordinator = session.Query<Models.Coordinator.Coordinator>().ToList();
                return Ok(coordinator);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Coordinator.Coordinator> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var coordinator = session.Get<Models.Coordinator.Coordinator>(id);

                if (coordinator == null)
                {
                    return NotFound();
                }
                return Ok(coordinator);
            }

        }
    
        [HttpPost]
           public ActionResult<Models.Coordinator.Coordinator> CreateAdresEntity([FromBody] Models.Coordinator.Coordinator coordinator)
           {
               if (coordinator == null)
               {
                   return BadRequest("Invalid data");
               }
               using (var session = NHibernateHelper.OpenSession())
               {
                   using (var transaction = session.BeginTransaction())
                   {
                       try
                       {
                           session.Save(coordinator);
                           transaction.Commit();
                           return CreatedAtAction(nameof(GetById), new { id = coordinator.id }, coordinator);
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
                           var coordinator = session.Get<Models.Coordinator.Coordinator>(id);

                           if (coordinator == null)
                           {
                               return NotFound();
                           }


                           session.Delete(coordinator);


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
