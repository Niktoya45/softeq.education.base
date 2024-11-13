using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;
using TrialsSystem.UserTaskService.Domain.AggregatesModel.UserTaskAggregate;
using AutoMapper;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UserTaskService.Api.Exceptions.UserTaskExceptions;

namespace TrialsSystem.UserTaskService.Api.Application.Queries.UserTaskQueries
{
    public class UserTasksQueryHandler : IRequestHandler<UserTasksQuery, IEnumerable<GetUserTaskResponse>>
    {
        IUserTaskRepository _repository;
        IMapper _mapper;
        public UserTasksQueryHandler(IUserTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetUserTaskResponse>> Handle(UserTasksQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<UserTask>? utasks = await _repository.GetByUserId(request.UserId, cancellationToken);

            if (utasks == null)
                throw new TrialUserTaskNotFoundException(request.UserId);

            return utasks.Select(ut => _mapper.Map<UserTask, GetUserTaskResponse>(ut)).ToList();
        }
    }

}