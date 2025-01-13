using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Queries.UserTaskQueries
{
    public class UserTaskQuery : IRequest<GetUserTaskResponse>
    {
        public UserTaskQuery(string userId, string id)
        {
            UserId = userId;
            Id = id;

        }

        public string UserId { get; }
        public string Name { get;  }
        public string Id { get;  }

    }
}