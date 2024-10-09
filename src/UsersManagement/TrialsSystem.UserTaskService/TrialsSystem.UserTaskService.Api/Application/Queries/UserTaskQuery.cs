using MediatR;
using TrialsSystem.UserTaskService.Infrastructure.Models.UserTaskDTOs;

namespace TrialsSystem.UserTaskService.Api.Application.Queries
{
    public class UserTaskQuery : IRequest<GetUserTaskResponse>
    {
        public UserTaskQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}