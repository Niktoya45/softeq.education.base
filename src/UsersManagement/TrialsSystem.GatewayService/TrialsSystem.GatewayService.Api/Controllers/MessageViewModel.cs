using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TrialsSystem.GatewayService.Api.Controllers
{
    public class MessageViewModel:PageModel
    {
        public string Message { get; set; } = "";
    }
}
