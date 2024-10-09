using MediatR;

namespace TrialsSystem.UsersService.Api.Application.Commands.UsersCommands
{
    public class DeleteUserCommand : IRequest<Unit> {

        public DeleteUserCommand(string id) {
            Id = id;
        }

        public string Id { get; } 
    }
}
