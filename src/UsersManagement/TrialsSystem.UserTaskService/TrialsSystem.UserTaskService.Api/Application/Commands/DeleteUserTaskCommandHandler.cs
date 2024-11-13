using AutoMapper;
using MediatR;
using TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class DeleteUserTaskCommandHandler : IRequestHandler<DeleteUserTaskCommand, Unit>
    {
        IUserTaskRepository _repository;
        public DeleteUserTaskCommandHandler(IUserTaskRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteUserTaskCommand request, CancellationToken cancellationToken)
        {
            UserTask? deleted = await _repository.DeleteByName(request.Name, request.UserId, cancellationToken);

            if (deleted == null)
                throw new TrialUserTaskNotFoundException(request.Name, request.UserId);
  

            return Unit.Value;
        }
    }
}