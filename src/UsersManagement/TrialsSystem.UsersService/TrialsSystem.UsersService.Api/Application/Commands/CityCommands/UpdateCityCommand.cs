using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{

    public class UpdateCityCommand : IRequest<UpdateCityResponse>
    {

        public UpdateCityCommand(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }

        public string Name { get; }
    }
}