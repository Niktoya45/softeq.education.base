using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class DeleteCityCommand : IRequest<Unit>
    {

        public DeleteCityCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}