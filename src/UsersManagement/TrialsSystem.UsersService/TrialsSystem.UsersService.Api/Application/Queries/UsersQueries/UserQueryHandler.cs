using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UsersQueries
{

    public class UserQueryHandler : IRequestHandler<UserQuery, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            return new GetUserResponse();
        }
    }
}
