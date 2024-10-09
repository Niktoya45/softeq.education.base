using TrialsSystem.UsersService.Api.Exceptions.Base;

namespace TrialsSystem.UsersService.Api.Exceptions.UserExceptions
{
    /// <summary>
    /// UserNotFoundException
    /// </summary>
    public class TrialUserNotFoundException : ServiceException
    {
        public string Id { get; }

        public TrialUserNotFoundException(string id):base($"User with Id {id} is not found")
        {
            Id = id;
        }
    }
}
