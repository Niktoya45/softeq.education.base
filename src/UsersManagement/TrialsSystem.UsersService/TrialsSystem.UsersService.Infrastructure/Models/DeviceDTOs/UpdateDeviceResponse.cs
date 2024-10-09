namespace TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs
{
    public class UpdateDeviceResponse
    {

        public string Id { get; set; }

        public string SerialNumber { get; set; }

        public string Model { get; set; }

        public string TypeId { get; set; }

        public string FirmwareVersion { get; set; }
    }
}