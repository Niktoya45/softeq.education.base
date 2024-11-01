
using System.ComponentModel.DataAnnotations.Schema;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity
    {
        public User(string email, string name, string surname, string cityId, string genderId, DateTime birthDate)
        {
            Email = email;
            Name = name;
            Surname = surname;
            CityId = cityId;
            BirthDate = birthDate;
            GenderId = genderId;
        }

        public string Email { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        private string CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; private set; }

        private string GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; private set; }

        public DateTime BirthDate { get; private set; }

        public decimal? Weight { get; private set; }

        public decimal? Height { get; private set; }

        public ICollection<Device> Devices { get; set; }

        public void SetWeight(decimal weight)
        {
            Weight = weight;
        }

        public void SetHeight(decimal height)
        {
            Height = height;
        }

    }
}
