using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommand, UpdateUserTaskResponse>
    {
        public async Task<UpdateUserTaskResponse> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
        {
            return new UpdateUserTaskResponse();
        }
    }

}