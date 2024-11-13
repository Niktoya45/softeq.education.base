using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.QueryParameters;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Queries.UserTaskQueries
{
    public class UserTasksQuery : IRequest<IEnumerable<GetUserTaskResponse>>
    {
        public UserTasksQuery(string userId, Pagination? pg)
        {
            UserId = userId;
            Pg = pg??new Pagination();
        }

        public string UserId { get; }

        Pagination Pg { get; }
    }

}