using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrialsSystem.IdentityService.Api.Controllers.Test
{
    [ApiController]
    [Route("test")]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
