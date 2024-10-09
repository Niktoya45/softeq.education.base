using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class DeleteDeviceCommand : IRequest<Unit>
    {

        public DeleteDeviceCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

    }
}