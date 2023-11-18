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
        string filePath = Path.Combine( "wwwroot/StronaGlowna.html");
        Console.WriteLine(_userService.GetLoggedInUserName());
        // Set a message in ViewBag
        ViewBag.Message = _userService.GetLoggedInUserName();

        // Read the HTML file
        string fileContent = System.IO.File.ReadAllText(filePath);

        // Replace a placeholder in the HTML file with dynamic content
        fileContent = fileContent.Replace("@ViewBag.Message", ViewBag.Message);

        // Return the HTML file as content
        return Content(fileContent, "text/html");
        
    }
}