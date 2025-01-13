using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using System.ComponentModel.DataAnnotations.Schema;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    public class Device : Entity
    {
        public Device() { }

        public Device(string id)
        {
            Id = id;
        }
        public Device(string serialNumber, string deviceTypeId, string model, string firmwareVersion) {
            SerialNumber = serialNumber;
            DeviceTypeId = deviceTypeId;
            Model = model;
            FirmwareVersion = firmwareVersion;
        }

        public string SerialNumber { get; set; }

        public string Model { get; set; }
	
	    public string DeviceTypeId { get; set; }
	
        public virtual DeviceType Type { get; set; }

        public string FirmwareVersion { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
