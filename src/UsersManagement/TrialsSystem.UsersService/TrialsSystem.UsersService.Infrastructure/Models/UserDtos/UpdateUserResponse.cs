using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialsSystem.UsersService.Infrastructure.Models.UserDTOs
{
    public class UpdateUserResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime BirthDate { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public string CityId { get; set; }

        public string[] DevicesSN { get; set; }
    }
}
