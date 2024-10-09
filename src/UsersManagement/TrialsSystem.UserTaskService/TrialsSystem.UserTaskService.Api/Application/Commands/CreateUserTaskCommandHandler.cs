using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, CreateUserTaskResponse>
    {
        public async Task<CreateUserTaskResponse> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            return new CreateUserTaskResponse();
        }
    }

}