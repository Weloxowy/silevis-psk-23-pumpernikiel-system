using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SystemZarzadzaniaPraktykami.Models.studentProgrammes;
using SystemZarzadzaniaPraktykami.Models.User;
using SystemZarzadzaniaPraktykami.Persistance.User;

namespace SystemZarzadzaniaPraktykami.wwwroot.WebControllers;

public class LoginController : Controller
{
    private readonly IUserService _userService;
    public LoginController(IUserService userService)
    {
        _userService = userService;
    }
    // GET: /Login/RedirectToExample
    [HttpGet]
    [HttpGet]
    public async Task<IActionResult> RedirectToExample(string identyfikator, string error = null)
    {
        string apiUrl = $"http://hackathon23-mockapi-env.eba-qfrnjqkt.eu-central-1.elasticbeanstalk.com/user/{identyfikator}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                User user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json);
                _userService.SetLoggedInUser(user);
                return Redirect("https://localhost:1001/StronaGlowna.html");
            }
        }

        return Redirect($"https://localhost:1001/Index.html?error=Object not found. Please try again.");
    }

}