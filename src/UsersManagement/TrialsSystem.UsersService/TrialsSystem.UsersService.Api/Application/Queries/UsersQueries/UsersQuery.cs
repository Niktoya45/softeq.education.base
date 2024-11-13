using MediatR;
using TrialsSystem.UsersService.Infrastructure.Repositories.QueryParameters;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UsersQueries
{
    public class UsersQuery : IRequest<IEnumerable<GetUsersResponse>>
    {
        public Pagination Pg;
        public string? Email { get; }

        public UsersQuery(Pagination pagination, string email)
        {
            Pg = pagination;
            Email = email;
        }
    }
}
