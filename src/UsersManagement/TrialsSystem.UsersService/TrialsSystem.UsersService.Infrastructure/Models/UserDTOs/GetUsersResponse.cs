
using TrialsSystem.UsersService.Infrastructure.Models.BaseDTO;

namespace TrialsSystem.UsersService.Infrastructure.Models.UserDTOs
{
    public class GetUsersResponse
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public string CityName { get; set; }

        public string GenderName { get; set; }

    }
}
