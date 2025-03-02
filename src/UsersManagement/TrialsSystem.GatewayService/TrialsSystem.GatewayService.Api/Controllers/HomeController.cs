using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace TrialsSystem.GatewayService.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View("Message", new MessageViewModel { Message = "Welcome!" }); ;
    }

    [HttpGet("test-protected-page")]
    [Authorize(AuthenticationSchemes=OpenIdConnectDefaults.AuthenticationScheme, Roles="Participant", Policy="Authenticated")]
    public async Task<IActionResult> TestProtected() {

        var claims = HttpContext.User.Claims;
        var client = new HttpClient();

        var token = await HttpContext.GetTokenAsync("access_token");
        client.BaseAddress = new Uri("https://localhost:7080");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);

        var response = await client.GetStringAsync("/api/v1/Home/test-protected-data");
        JObject? result = JObject.Parse(response);

        return View("Message",new MessageViewModel { Message = (string)result["message"] });
    }

    [HttpGet("test-protected-data")]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> ProtectedData() {
        return new JsonResult(new { Message = "Api_Authorization_Succeeded" });
    }

}
