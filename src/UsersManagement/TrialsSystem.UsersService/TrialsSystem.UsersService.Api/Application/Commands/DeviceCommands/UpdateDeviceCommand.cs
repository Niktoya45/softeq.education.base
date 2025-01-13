using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class UpdateDeviceCommand : IRequest<UpdateDeviceResponse>
    {

        public UpdateDeviceCommand( string id,
            string serialNumber,
            string model,
            string typeId,
            string firmwareVersion,
            string[] userIds,
            string auserId
            )
        {
            Id = id;
            SerialNumber = serialNumber;
            Model = model;
            TypeId = typeId;
            FirmwareVersion = firmwareVersion;
            UserIds = userIds;
        }

        public string Id { get; set; }

        public string SerialNumber { get; set; }

        public string Model { get; set; }
        
        public string TypeId { get; set; }

        public string FirmwareVersion { get; set; }

        public string[] UserIds { get; set;}

    }
}