using TrialsSystem.UserTaskService.Api.Exceptions.Base;

namespace TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions
{
    /// <summary>
    /// Used when given instance has invalid task status
    /// </summary>
    public class InvalidUserTaskStatusException : ServiceException
    {
        public InvalidUserTaskStatusException(string status):base($"Invalid task status \"{status}\"") 
        {
        }
    }
}
