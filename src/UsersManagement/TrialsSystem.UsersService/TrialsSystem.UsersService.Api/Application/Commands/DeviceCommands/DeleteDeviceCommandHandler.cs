using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.DeviceExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, Unit>
    {
        IUnitOfWork _unitOfWork;

        public DeleteDeviceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            Device? deleted = await _unitOfWork.Devices.Delete(request.Id, cancellationToken);

            if (deleted == null)
            {
                throw new TrialDeviceNotFoundException(request.Id);
            }

            return Unit.Value;
        }
    }
}