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
}