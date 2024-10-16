using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class CreateUserTaskCommand : IRequest<CreateUserTaskResponse>
    {
        public CreateUserTaskCommand(string userId, string name,
            Dictionary<string, string> additionalProperties)
        {
            UserId = userId;
            Name = name;
            AdditionalProperties = additionalProperties;
        }

        public string UserId { get; }
        public string Name { get; }

        public Dictionary<string, string> AdditionalProperties { get; }

    }
}