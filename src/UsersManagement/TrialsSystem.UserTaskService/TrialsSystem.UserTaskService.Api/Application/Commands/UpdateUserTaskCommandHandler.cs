using AutoMapper;
using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class UpdateUserTaskCommandHandler : IRequestHandler<UpdateUserTaskCommand, UpdateUserTaskResponse>
    {
        IUserTaskRepository _repository;
        IMapper _mapper;
        public UpdateUserTaskCommandHandler(IUserTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateUserTaskResponse> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
        {
            UserTask utask = _mapper.Map<UpdateUserTaskCommand, UserTask>(request);

            utask.SetStatus(request.Status);

            UserTask? updated = await _repository.Update(utask, cancellationToken);

            if (updated == null)
                throw new TrialUserTaskNotFoundException(request.Name, request.UserId);           


            return _mapper.Map<UserTask, UpdateUserTaskResponse>(updated!);
        }
    }

}