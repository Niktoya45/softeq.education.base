
using System.ComponentModel.DataAnnotations.Schema;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity
    {

        public User() { }

        public User(string id)
        {
            Id = id;
        }

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

        public string CityId { get; set; }

        public virtual City City { get;  set; }

        public string GenderId { get; set; }

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
