namespace TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs
{
	public class CreateUserTaskRequest
	{
		public string Name { get; set; }

		public string UserId { get; set; }

		public Dictionary<string, string> AdditionalProperties { get; set; }

	}
}