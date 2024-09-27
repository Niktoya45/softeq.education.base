namespace TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs
{
	public class GetUserTaskResponse
	{
		public string Name { get; set; }

		public string Status { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public DateTime LastUpdatedDateTime { get; set; }

		public Dictionary<string, string> AdditionalProperties { get; set; }

	}
}