using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;
using TrialsSystem.UsersService.Api.Exceptions.CityExceptions;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        ICityRepository _repository;

        public DeleteCityCommandHandler(ICityRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            City? deleted = await _repository.Delete(request.Id, cancellationToken);

            if (deleted == null)
            {
                throw new TrialCityNotFoundException(request.Id);
            }

            return Unit.Value;
        }
    }
}