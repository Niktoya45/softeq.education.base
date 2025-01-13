using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Repositories.QueryParameters;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Queries.UserTaskQueries
{
    public class UserTasksQuery : IRequest<IEnumerable<GetUserTaskResponse>>
    {
        public UserTasksQuery(string userId, string? name, Pagination? pg)
        {
            UserId = userId;
            Pg = pg??new Pagination();
            Name = name;
        }

        public string UserId { get; }

        public string? Name { get; }
        public Pagination Pg { get; }
    }

}