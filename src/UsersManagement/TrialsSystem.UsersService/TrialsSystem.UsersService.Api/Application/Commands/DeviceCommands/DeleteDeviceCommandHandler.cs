using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}