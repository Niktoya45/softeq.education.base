using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Api.Application.Queries.QueryParameters;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{
    public class DevicesQuery : IRequest<IEnumerable<GetDevicesResponse>>
    {
        public DevicesQuery(Pagination? pagination)
        {
            Pgn = pagination;
        }

        public Pagination? Pgn { get; }
    }
}
