using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{
    public class CityQuery : IRequest<GetCityResponse>
    {

        public CityQuery(string id)
        {
            Id = id; 
        }

        public string Id { get; }
    }
}