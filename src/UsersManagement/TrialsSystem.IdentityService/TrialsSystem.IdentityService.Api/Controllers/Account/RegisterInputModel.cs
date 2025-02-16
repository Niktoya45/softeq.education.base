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

        //[Required]
        public string? CityId { get; set; }

        //[Required]
        public string? GenderId { get; set; }

        public string ReturnUrl { get; set; }
    }
}
