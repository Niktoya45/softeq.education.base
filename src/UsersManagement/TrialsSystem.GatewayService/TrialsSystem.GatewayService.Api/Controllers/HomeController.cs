using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme, Roles="Participant")]
    public IActionResult Index() {

        return View("Message",new MessageViewModel { Message = "Success!"});
    }

}
