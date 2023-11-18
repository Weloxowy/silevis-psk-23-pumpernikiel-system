using Microsoft.AspNetCore.Mvc;
using SystemZarzadzaniaPraktykami.Controllers.PDF;
using SystemZarzadzaniaPraktykami.Models.User;

namespace SystemZarzadzaniaPraktykami.wwwroot.WebControllers;

public class LogoutController : Controller
{
    private readonly IUserService _userService;
    public LogoutController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        PDF pdf = new PDF(_userService);
        _userService.clear();
        Console.WriteLine("_userService.GetLoggedInUser().studentNumber");
        Console.WriteLine(_userService.GetLoggedInUser().studentNumber);
        Console.WriteLine(_userService.GetLoggedInUserName());
        return Redirect("https://localhost:1001/Index.html");
    }
}