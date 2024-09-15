using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DeviceQuery : IRequest<GetDeviceResponse>
    {
        public DeviceQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
