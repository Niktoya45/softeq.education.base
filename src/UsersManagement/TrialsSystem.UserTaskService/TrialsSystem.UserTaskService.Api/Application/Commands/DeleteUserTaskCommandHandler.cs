using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class DeleteUserTaskCommandHandler : IRequestHandler<DeleteUserTaskCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}