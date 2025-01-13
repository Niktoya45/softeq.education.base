
namespace TrialsSystem.IdentityService.Infrastructure.Models.UserDTO
{
    public class CreateUserRequest
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public string CityId { get; set; }

        public string GenderId { get; set; }
    }
}
