using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DevicesQuery : IRequest<IEnumerable<GetDevicesResponse>>
    {
        public DevicesQuery(int? take, int? skip)
        {
            Take = take;

            Skip = skip;
        }

        public int? Take { get; }

        public int? Skip { get; }
    }
}
