using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TrialsSystem.IdentityService.Api.Controllers
{
    public class RegisterInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; } = DateTime.Now;

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="passwords_do_not_match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string CityId { get; set; }

        [Required]
        public string GenderId { get; set; }

        public string ReturnUrl { get; set; }

        public bool AllowRememberLogin { get; set; } = true;
        public bool EnableLocalRegistration { get; set; } = true;

        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        public bool IsExternalRegistrationOnly => EnableLocalRegistration == false && ExternalProviders?.Count() == 1;
        public string ExternalRegistrationScheme => IsExternalRegistrationOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
    }
}
