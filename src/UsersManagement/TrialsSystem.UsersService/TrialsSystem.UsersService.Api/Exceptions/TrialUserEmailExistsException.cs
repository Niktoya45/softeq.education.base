
namespace TrialsSystem.UsersService.Api.Exceptions
{
	/// <summary>
	/// The user with this email already exists
	/// </summary>
	public class TrialUserEmailExistsException : Exception
	{

		public string Email { get; }

		public TrialUserEmailExistsException(string email)
		{

			Email = email;

		}
	}
}