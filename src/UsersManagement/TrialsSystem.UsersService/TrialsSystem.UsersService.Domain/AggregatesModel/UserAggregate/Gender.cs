using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public class Gender:ValueObject
    {
        public string Id { get; set; }
        public string Name { get; set; }

        protected override IEnumerable<object> GetEqualityComponents() {
            yield return Id;
            yield return Name;
        }
    }
}
