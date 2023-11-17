using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Nhibernate;
using SystemZarzadzaniaPraktykami.Persistance.Company;

namespace SystemZarzadzaniaPraktykami.Controllers;
[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService = new CompanyService();
    [HttpGet]
    public ActionResult<IEnumerable<Models.Company.Company>> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var company = session.Query<Models.Company.Company>().ToList();
            return Ok(company);
        }
    }
}