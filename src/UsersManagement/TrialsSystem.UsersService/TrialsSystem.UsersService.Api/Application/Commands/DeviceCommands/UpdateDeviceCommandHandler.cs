using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, UpdateDeviceResponse>
    {
        public async Task<UpdateDeviceResponse> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            return new UpdateDeviceResponse();
        }
    }
}