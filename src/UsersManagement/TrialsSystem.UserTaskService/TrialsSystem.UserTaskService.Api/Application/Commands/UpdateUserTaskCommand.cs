using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class UpdateUserTaskCommand : IRequest<UpdateUserTaskResponse>
    {

        public UpdateUserTaskCommand(string id,
            string name, 
            string status, 
            DateTime createdDateTime,
            DateTime lastUpdatedDateTime,
            Dictionary<string, string> additionalProperties
            )
        {
            Id = id;
            Name = name;
            Status = status;
            CreatedDateTime = createdDateTime;
            LastUpdatedDateTime = lastUpdatedDateTime;
            AdditionalProperties = additionalProperties;
        }

        public string Id { get; }

        public string Name { get; }

        public string Status { get; }

        public DateTime CreatedDateTime { get; }

        public DateTime LastUpdatedDateTime { get; }

        public Dictionary<string, string> AdditionalProperties { get; }

    }
}