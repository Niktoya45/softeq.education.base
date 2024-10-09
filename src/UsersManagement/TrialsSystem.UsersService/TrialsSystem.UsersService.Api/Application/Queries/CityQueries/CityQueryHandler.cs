using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{

    public class CityQueryHandler : IRequestHandler<CityQuery, GetCityResponse>
    {
        public async Task<GetCityResponse> Handle(CityQuery request, CancellationToken cancellationToken)
        {
            return new GetCityResponse();
        }
    }
}
