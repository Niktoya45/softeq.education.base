using TrialsSystem.UserTaskService.Api.Exceptions.Base;


namespace TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions
{
    public class InvalidTaskStatusChangeException : ServiceException
    {
        public InvalidTaskStatusChangeException(string fromSt, string toSt):base($"Cannot change task status from {fromSt} to {toSt}")
        { 
        }
    }
}
