using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TrialsSystem.IdentityService.Api.Controllers.Account
{
    public class RegisterInputModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string CityId { get; set; }

        [Required]
        public string GenderId { get; set; }

        public string ReturnUrl { get; set; }
    }
}
