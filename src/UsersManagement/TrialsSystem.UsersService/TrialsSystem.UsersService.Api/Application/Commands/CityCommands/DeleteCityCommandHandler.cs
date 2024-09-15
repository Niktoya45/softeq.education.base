using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}