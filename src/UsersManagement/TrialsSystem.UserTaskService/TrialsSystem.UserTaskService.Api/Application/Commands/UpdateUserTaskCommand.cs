using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class UpdateUserTaskCommand : IRequest<UpdateUserTaskResponse>
    {

        public UpdateUserTaskCommand(
            string userId,
            string name, 
            string status, 
            Dictionary<string, string> additionalProperties
            )
        {
            UserId = userId;
            Name = name;
            Status = status;
            AdditionalProperties = additionalProperties;
        }

        public string UserId;

        public string Name { get; }

        public string Status { get; }

        public Dictionary<string, string> AdditionalProperties { get; }

    }
}