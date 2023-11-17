using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Nhibernate;

namespace SystemZarzadzaniaPraktykami.Controllers.Address
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Models.Address.Address>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var addressEntities = session.Query<Models.Address.Address>().ToList();
                return Ok(addressEntities);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Models.Address.Address> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var addressEntity = session.Get<Models.Address.Address>(id);

                if (addressEntity == null)
                {
                    return NotFound();
                }

                return Ok(addressEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.Address.Address> CreateAddressEntity([FromBody] Models.Address.Address address)
        {
            if (address == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(address);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = address.id }, address);
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
        public ActionResult DeletePolisy(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var address = session.Get<Models.Address.Address>(id);

                        if (address == null)
                        {
                            return NotFound();
                        }


                        session.Delete(address);


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
