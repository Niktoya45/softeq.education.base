using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Queries
{
    public class UserTasksQueryHandler : IRequestHandler<UserTasksQuery, IEnumerable<GetUserTaskResponse>>
    {
        public async Task<IEnumerable<GetUserTaskResponse>> Handle(UserTasksQuery request, CancellationToken cancellationToken)
        {
            return new List<GetUserTaskResponse>();
        }
    }

}