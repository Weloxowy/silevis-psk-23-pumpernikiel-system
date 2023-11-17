using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Models.Coordinator;
using SystemZarzadzaniaPraktykami.Nhibernate;

namespace SystemZarzadzaniaPraktykami.Controllers.Lecturer
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Models.Lecturer.Lecturer>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var coordinator = session.Query<Models.Lecturer.Lecturer>().ToList();
                return Ok(coordinator);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Lecturer.Lecturer> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var lecturer = session.Get<Models.Lecturer.Lecturer>(id);

                if (lecturer == null)
                {
                    return NotFound();
                }
                return Ok(lecturer);
            }

        }

        [HttpPost]
        public ActionResult<Models.Coordinator.Coordinator> CreateAdresEntity([FromBody] Models.Lecturer.Lecturer lecturer)
        {
            if (lecturer == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(lecturer);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = lecturer.id }, lecturer);
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
                        var lecturer = session.Get<Models.Lecturer.Lecturer>(id);

                        if (lecturer == null)
                        {
                            return NotFound();
                        }


                        session.Delete(lecturer);


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
