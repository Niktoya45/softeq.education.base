using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.DeviceExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, Unit>
    {
        IDeviceRepository _repository;

        public DeleteDeviceCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            Device? deleted = await _repository.Delete(request.Id, cancellationToken);

            if (deleted == null)
            {
                throw new TrialDeviceNotFoundException(request.Id);
            }

            return Unit.Value;
        }
    }
}