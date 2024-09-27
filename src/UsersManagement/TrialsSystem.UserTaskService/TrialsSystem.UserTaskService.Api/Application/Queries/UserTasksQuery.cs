using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Queries
{
    public class UserTasksQuery : IRequest<IEnumerable<GetUserTaskResponse>>
    {
        public UserTasksQuery(int? take, int? skip)
        { 
            Take = take;
            Skip = skip;
        }

        public int? Skip { get; }

        public int? Take { get; }
    }

}