
namespace TrialsSystem.UserTaskService.Domain.Exceptions
{
    /// <summary>
    /// Used when current task status cannot be changed 
    /// from current to the given valid status
    /// </summary>
    public class InvalidTaskStatusChangeException : DomainException
    {
        public InvalidTaskStatusChangeException(string st1, string st2) : base($"Cannot change task status from {st1} to {st2}")
        {
        }
    }
}
