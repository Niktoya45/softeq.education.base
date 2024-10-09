using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityResponse>
    {
        public async Task<CreateCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            return new CreateCityResponse();
        }
    }
}