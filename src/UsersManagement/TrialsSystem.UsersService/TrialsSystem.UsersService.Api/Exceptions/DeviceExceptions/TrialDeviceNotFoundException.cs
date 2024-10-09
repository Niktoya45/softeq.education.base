using TrialsSystem.UsersService.Api.Exceptions.Base;

namespace TrialsSystem.UsersService.Api.Exceptions
{
    /// <summary>
    /// Device not found
    /// </summary>
    public class TrialDeviceNotFoundException : ServiceException
    {
        public TrialDeviceNotFoundException(string id):base($"Device with Id {id} is not found")
        {
            Id = id;
        }

        public string Id { get; }
    }
}