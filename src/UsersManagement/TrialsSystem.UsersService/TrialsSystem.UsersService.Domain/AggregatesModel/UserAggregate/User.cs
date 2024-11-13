
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

        public string Email { get; set; }

        public string Name { get;  set; }

        public string Surname { get; set; }

        private string CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get;  set; }

        private string GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        public DateTime BirthDate { get;  set; }

        public decimal? Weight { get;  set; }

        public decimal? Height { get; set; }

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
