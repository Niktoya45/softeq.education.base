using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate
{
    public record Gender
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
