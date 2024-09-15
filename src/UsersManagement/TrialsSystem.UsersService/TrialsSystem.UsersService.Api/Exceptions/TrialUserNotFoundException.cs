namespace TrialsSystem.UsersService.Api.Exceptions
{
    /// <summary>
    /// UserNotFoundException
    /// </summary>
    public class TrialUserNotFoundException : Exception
    {
        public string Id { get; }

        public TrialUserNotFoundException(string id)
        {
            Id = id;
        }
    }
}
