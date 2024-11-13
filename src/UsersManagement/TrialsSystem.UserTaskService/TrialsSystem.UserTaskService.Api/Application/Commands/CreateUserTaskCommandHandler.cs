using MediatR;
using AutoMapper;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;
using TrialsSystem.UserTaskService.Infrastructure.Repositories;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;

namespace TrialsSystem.UserTaskService.Api.Application.Commands
{
    public class CreateUserTaskCommandHandler : IRequestHandler<CreateUserTaskCommand, CreateUserTaskResponse>
    {
        IUserTaskRepository _repository;
        IMapper _mapper;
        public CreateUserTaskCommandHandler(IUserTaskRepository repository, IMapper mapper) { 
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateUserTaskResponse> Handle(CreateUserTaskCommand request, CancellationToken cancellationToken)
        {
            UserTask utask = _mapper.Map<CreateUserTaskCommand, UserTask>(request);

            UserTask added = _repository.Add(utask);

            return _mapper.Map<UserTask, CreateUserTaskResponse>(added);
        }
    }

}