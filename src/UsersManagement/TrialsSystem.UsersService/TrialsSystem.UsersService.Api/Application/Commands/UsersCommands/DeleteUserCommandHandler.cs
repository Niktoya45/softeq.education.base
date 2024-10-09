using MediatR;

namespace TrialsSystem.UsersService.Api.Application.Commands.UsersCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }

    }
}

