namespace TrialsSystem.UsersService.Api.Exceptions
{
    /// <summary>
    /// Device not found
    /// </summary>
    public class TrialDeviceNotFoundException
    {
        public TrialDeviceNotFoundException(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}