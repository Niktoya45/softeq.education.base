using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{
    public class CitiesQuery : IRequest<IEnumerable<GetCityResponse>>
    {

        public CitiesQuery(int? take, int? skip)
        {
            Take = take;

            Skip = skip;
        }

        public int? Take { get; }

        public int? Skip { get; } 
    }
}