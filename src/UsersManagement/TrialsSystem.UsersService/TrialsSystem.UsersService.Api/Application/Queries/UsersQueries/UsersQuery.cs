using MediatR;
using TrialsSystem.UsersService.Api.Application.Queries.QueryParameters;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;

namespace TrialsSystem.UsersService.Api.Application.Queries.UsersQueries
{
    public class UsersQuery : IRequest<IEnumerable<GetUsersResponse>>
    {
        public Pagination? Pgn;
        public string? Email { get; }

        public UsersQuery(Pagination? pagination, string email)
        {
            Pgn = pagination;
            Email = email;
        }
    }
}
