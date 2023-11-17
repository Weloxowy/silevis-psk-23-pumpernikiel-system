using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Nhibernate;

namespace SystemZarzadzaniaPraktykami.Controllers.IntershipDate;
[ApiController]
[Route("[controller]")]
public class IntershipDateController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Models.IntershipDate.IntershipDate>> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var IntershipDate = session.Query<Models.IntershipDate.IntershipDate>().ToList();
            return Ok(IntershipDate);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Models.IntershipDate.IntershipDate> GetById(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var IntershipDate = session.Get<Models.IntershipDate.IntershipDate>(id);

            if (IntershipDate == null)
            {
                return NotFound();
            }

            return Ok(IntershipDate);
        }

    }
    [HttpPost]
    public ActionResult<Models.IntershipDate.IntershipDate> CreateAdresEntity([FromBody] Models.IntershipDate.IntershipDate IntershipDate)
    {
        if (IntershipDate == null)
        {
            return BadRequest("Invalid data");
        }
        using (var session = NHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(IntershipDate);
                    transaction.Commit();
                    return CreatedAtAction(nameof(GetById), new { id = IntershipDate.id }, IntershipDate);
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
                    var IntershipDate = session.Get<Models.IntershipDate.IntershipDate>(id);

                    if (IntershipDate == null)
                    {
                        return NotFound();
                    }


                    session.Delete(IntershipDate);


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