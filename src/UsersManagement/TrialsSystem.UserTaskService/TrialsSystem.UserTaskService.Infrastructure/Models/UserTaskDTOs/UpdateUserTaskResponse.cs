namespace TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs
{
    public class UpdateUserTaskResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdatedDateTime { get; set; }

        public Dictionary<string, string> AdditionalProperties { get; set; }

    }
}