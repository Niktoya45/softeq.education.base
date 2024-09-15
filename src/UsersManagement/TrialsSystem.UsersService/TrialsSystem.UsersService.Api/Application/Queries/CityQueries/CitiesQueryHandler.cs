using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{

    public class CitiesQueryHandler : IRequestHandler<CitiesQuery, IEnumerable<GetCityResponse>>
    {
        public async Task<IEnumerable<GetCityResponse>> Handle(CitiesQuery request, CancellationToken cancellationToken)
        {
            return new List<GetCityResponse>();
        }
    }
}
