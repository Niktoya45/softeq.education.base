using System;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    public class Device : Entity
    {
        public Device(string id, string serialNumber, string deviceId, string model, string firmwareVersion) {
            Id = id;
            SerialNumber = serialNumber;
            DeviceId = deviceId;
            Model = model;
            FirmwareVersion = firmwareVersion;
        }

        public string SerialNumber { get; private set; }

        public string Model { get; private set; }
	
	private string DeviceId { get; set; }
	
	[ForeignKey("DeviceId")]
        public virtual DeviceType Type { get; private set; }

        public string FirmwareVersion { get; private set; }

    }
}
