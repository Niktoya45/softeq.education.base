namespace TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs
{
    public class GetDevicesResponse
    {

        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public string DeviceTypeId { get; set; }

        public string FirmwareVersion { get; set; }

        public string[] UserNames { get; set; }
    }
}