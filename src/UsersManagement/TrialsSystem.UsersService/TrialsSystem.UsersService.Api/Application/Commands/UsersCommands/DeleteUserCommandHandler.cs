using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.UserExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.UsersCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {

        IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? deleted = await _repository.Delete(request.Id, cancellationToken);

            if (deleted == null)
            {
                throw new TrialUserNotFoundException(request.Id);
            }

            return Unit.Value;
        }

    }
}

