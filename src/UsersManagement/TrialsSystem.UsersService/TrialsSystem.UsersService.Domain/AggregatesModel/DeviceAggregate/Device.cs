using System;
using TrialsSystem.UsersService.Domain.AggregatesModel.Base;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    public class Device : Entity
    {
        public Device(string id, string serialNumber, string model, string firmwareVersion) {
            this.Id = id;
        }

        public string SerialNumber { get; private set; }

        public string Model { get; private set; }

        public DeviceType Type { get; set; }

        public string FirmwareVersion { get; private set; }

    }
}
