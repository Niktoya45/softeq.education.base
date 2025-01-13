namespace TrialsSystem.UserTaskService.Domain.Exceptions
{
    /// <summary>
    /// Used when given instance has invalid task status
    /// </summary>
    public class InvalidUserTaskStatusException : DomainException
    {
        public InvalidUserTaskStatusException(string status) : base($"Invalid task status \"{status}\"")
        {
        }
    }
}
