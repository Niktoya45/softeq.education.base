using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, CreateDeviceResponse>
    {
        public async Task<CreateDeviceResponse> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            return new CreateDeviceResponse();
        }
    }
}