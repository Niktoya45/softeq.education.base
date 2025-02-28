using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

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

    [HttpGet("test-protected")]
    [Authorize(AuthenticationSchemes=OpenIdConnectDefaults.AuthenticationScheme, Roles="Participant")]
    public IActionResult TestProtected() {

        var claims = HttpContext.User.Claims;

        return View("Message",new MessageViewModel { Message = "Success!"});
    }

}
