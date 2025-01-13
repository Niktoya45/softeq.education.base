using TrialsSystem.UserTaskService.Api.Exceptions.Base;

namespace TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions {

    /// <summary>
    /// User task not found
    /// </summary>
    public class TrialUserTaskNotFoundException : ServiceException
    {
        public TrialUserTaskNotFoundException(string uid):base($"UserTasks of user: {uid} are not found")
        {
        }

        public TrialUserTaskNotFoundException(string name, string uid) : base($"UserTask: {name} of given user is not found")
        {
        }
    }
}