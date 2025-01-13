using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrialsSystem.IdentityService.Api.Controllers
{
    public class RegisterViewModel : RegisterInputModel
    {
        public IList<SelectListItem> CityList = new List<SelectListItem>();
        
        public IList<SelectListItem> GenderList = new List<SelectListItem>();
    }
}
