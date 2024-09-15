using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{

    public class DeviceQueryHandler : IRequestHandler<DeviceQuery, GetDeviceResponse>
    {
        public async Task<GetDeviceResponse> Handle(DeviceQuery request, CancellationToken cancellationToken)
        {
            return new GetDeviceResponse();
        }
    }
}
