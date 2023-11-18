using System.Text;
using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Models.User;
using SystemZarzadzaniaPraktykami.Persistance.User;

namespace SystemZarzadzaniaPraktykami.wwwroot.WebControllers;

[Controller]
public class HomeController : Controller
{
    
    private readonly IUserService _userService;

    public HomeController(IUserService userService)
    {
        _userService = userService;
    }
    [Route("StronaGlowna.html")]
    public IActionResult Index()
    {
        string filePath = Path.Combine( "wwwroot/mainPage.html");
        Console.WriteLine(_userService.GetLoggedInUserName());
        
        ViewBag.Message = _userService.GetLoggedInUserName();

        string fileContent = System.IO.File.ReadAllText(filePath);

        fileContent = fileContent.Replace("@ViewBag.Message", ViewBag.Message);

        return Content(fileContent, "text/html");
        
    }
}