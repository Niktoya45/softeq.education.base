
namespace TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs
{
    public class UpdateDeviceRequest
    {

        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public string TypeId { get; set; }

        public string FirmwareVersion { get; set; }
    }
}