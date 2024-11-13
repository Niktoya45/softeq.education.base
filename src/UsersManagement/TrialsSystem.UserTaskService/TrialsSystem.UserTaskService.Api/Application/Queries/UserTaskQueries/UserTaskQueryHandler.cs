using AutoMapper;
using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions;

namespace TrialsSystem.UserTaskService.Api.Application.Queries.UserTaskQueries
{
    public class UserTaskQueryHandler : IRequestHandler<UserTaskQuery, GetUserTaskResponse>
    {
        IUserTaskRepository _repository;
        IMapper _mapper;
        public UserTaskQueryHandler(IUserTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetUserTaskResponse> Handle(UserTaskQuery request, CancellationToken cancellationToken)
        {
            UserTask? utask = await _repository.GetByName(request.Name, request.UserId, cancellationToken);

            if (utask == null)
                throw new TrialUserTaskNotFoundException(request.Name, request.UserId);

            return _mapper.Map<UserTask, GetUserTaskResponse>(utask);
        }
    }

}