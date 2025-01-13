using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;
using TrialsSystem.UsersService.Api.Exceptions.CityExceptions;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            City? deleted = await _unitOfWork.Cities.Delete(request.Id, cancellationToken);

            if (deleted == null)
            {
                throw new TrialCityNotFoundException(request.Id);
            }

            return Unit.Value;
        }
    }
}