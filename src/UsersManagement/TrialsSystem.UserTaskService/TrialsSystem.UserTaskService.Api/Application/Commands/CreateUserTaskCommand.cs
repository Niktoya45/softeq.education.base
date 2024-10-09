using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class CreateUserTaskCommand : IRequest<CreateUserTaskResponse>
    {
        public CreateUserTaskCommand(string name,
            string status, 
            DateTime createdDateTime, 
            DateTime lastUpdatedDateTime,
            Dictionary<string, string> additionalProperties)
        {
            Status = status;
            Name = name;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            AdditionalProperties = additionalProperties;
        }

        public string Name { get; }

        public string Status { get; }

        public DateTime CreatedDateTime { get; }

        public DateTime LastUpdatedDateTime { get; }

        public Dictionary<string, string> AdditionalProperties { get; }

    }
}