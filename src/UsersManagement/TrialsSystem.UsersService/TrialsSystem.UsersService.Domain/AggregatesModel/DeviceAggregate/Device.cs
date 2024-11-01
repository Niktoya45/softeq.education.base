using TrialsSystem.UsersService.Domain.AggregatesModel.Base;
using System.ComponentModel.DataAnnotations.Schema;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate
{
    public class Device : Entity
    {
        public Device(string id, string serialNumber, string deviceTypeId, string model, string firmwareVersion) {
            Id = id;
            SerialNumber = serialNumber;
            DeviceTypeId = deviceTypeId;
            Model = model;
            FirmwareVersion = firmwareVersion;
        }

        public string SerialNumber { get; private set; }

        public string Model { get; private set; }
	
	    private string DeviceTypeId { get; set; }
	
	    [ForeignKey("DeviceTypeId")]
        public virtual DeviceType Type { get; private set; }

        public string FirmwareVersion { get; private set; }

        public ICollection<User> Users { get; set; }

    }
}
