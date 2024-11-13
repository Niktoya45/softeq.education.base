namespace TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs
{
    public class UpdateUserTaskRequest
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public Dictionary<string, string> AdditionalProperties { get; set; }
    }
}