using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.QueryParameters;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{
    public class CitiesQuery : IRequest<IEnumerable<GetCityResponse>>
    {

        public CitiesQuery(Pagination? pagination)
        {
            Pg = pagination ?? new Pagination();
        }

        public Pagination Pg { get; }

    }
}