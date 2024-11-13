using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.QueryParameters;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DevicesQuery : IRequest<IEnumerable<GetDevicesResponse>>
    {
        public DevicesQuery(Pagination pagination)
        {
            Pg = pagination;
        }

        public Pagination Pg { get; }
    }
}
