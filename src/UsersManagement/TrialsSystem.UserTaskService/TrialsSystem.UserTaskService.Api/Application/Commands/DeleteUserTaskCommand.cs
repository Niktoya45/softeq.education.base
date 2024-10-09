using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class DeleteUserTaskCommand : IRequest<Unit>
    {
        public DeleteUserTaskCommand(string id)
        {
            Id = id;
        }

        public string Id { get;}
    }
}