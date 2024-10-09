using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Api.Application.Queries.QueryParameters;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{
    public class CitiesQuery : IRequest<IEnumerable<GetCityResponse>>
    {

        public CitiesQuery(Pagination? pagination)
        {
            Pgn = pagination;
        }

        public Pagination? Pgn { get; }

    }
}