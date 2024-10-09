using TrialsSystem.UsersService.Api.Exceptions.Base;

namespace TrialsSystem.UsersService.Api.Exceptions
{
    /// <summary>
    /// The user with this email already exists
    /// </summary>
    public class TrialUserEmailExistsException : ServiceException
    {

        public string Email { get; }

        public TrialUserEmailExistsException(string email):base($"User with Email {email} already exists")
        {
            Email = email;
        }
    }
}