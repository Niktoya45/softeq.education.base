using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    public record DeviceType
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}