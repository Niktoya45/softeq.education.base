using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class DeleteUserTaskCommand : IRequest<Unit>
    {
        public DeleteUserTaskCommand(string userId, string name)
        {
            UserId = userId;
            Name = name;
        }

        public string UserId { get; }

        public string Name { get; }
    }
}