namespace TrialsSystem.UserTaskService.Api.Exceptions {

    /// <summary>
    /// User task not found
    /// </summary>
    public class TrialUserTaskNotFoundException : Exception
    {
        public TrialUserTaskNotFoundException(string id)
        {
            Id  = id;
        }

        public string Id {get;}
    }
}