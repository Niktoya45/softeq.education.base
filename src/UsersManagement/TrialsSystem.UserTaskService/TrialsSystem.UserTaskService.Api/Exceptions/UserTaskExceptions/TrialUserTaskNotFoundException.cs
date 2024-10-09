using TrialsSystem.UserTaskService.Api.Exceptions.Base;

namespace TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions {

    /// <summary>
    /// User task not found
    /// </summary>
    public class TrialUserTaskNotFoundException : ServiceException
    {
        public TrialUserTaskNotFoundException(string id):base($"UserTask with id: {id} is not found")
        {
            Id  = id;
        }
    }
}