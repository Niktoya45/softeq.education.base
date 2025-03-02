using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrialsSystem.IdentityService.Api.Controllers
{
    public class RegisterViewModel : RegisterInputModel
    {
        public IList<SelectListItem> CityList = new List<SelectListItem>();
        
        public IList<SelectListItem> GenderList = new List<SelectListItem>();

        public bool AllowRememberLogin { get; set; } = true;
        public bool EnableLocalRegistration { get; set; } = true;

        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        public bool IsExternalRegistrationOnly => EnableLocalRegistration == false && ExternalProviders?.Count() == 1;
        public string? ExternalRegistrationScheme => IsExternalRegistrationOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
    }
}
