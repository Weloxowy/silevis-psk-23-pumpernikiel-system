using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Nhibernate;

namespace SystemZarzadzaniaPraktykami.Controllers.Address;
[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    
    [HttpGet]
    public ActionResult<IEnumerable<Models.Address.Address>> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var address = session.Query<Models.Address.Address>().ToList();
            return Ok(address);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Models.Address.Address> GetById(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var Adres = session.Get<Models.Address.Address>(id);

            if (Adres == null)
            {
                return NotFound();
            }

            return Ok(Adres);
        }

    }
    [HttpPost]
    public ActionResult<Models.Address.Address> CreateAdresEntity([FromBody] Models.Address.Address Adres)
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
                    var adres = session.Get<Models.Address.Address>(id);

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