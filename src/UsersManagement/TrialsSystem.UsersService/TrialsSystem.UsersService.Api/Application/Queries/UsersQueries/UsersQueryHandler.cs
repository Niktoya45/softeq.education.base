using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UsersQueries
{
    public class UsersQueryHandler : IRequestHandler<UsersQuery, IEnumerable<GetUsersResponse>>
    {
        public UsersQueryHandler()
        {

        }

        public async Task<IEnumerable<GetUsersResponse>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            return new List<GetUsersResponse>();
        }
    }
}
