using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdateCityResponse>
    {
        public async Task<UpdateCityResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            return new UpdateCityResponse();
        }
    }
}