using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.DeviceExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, UpdateDeviceResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdateDeviceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateDeviceResponse> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            Device device = _mapper.Map<UpdateDeviceCommand, Device>(request);

            Device? updated = await _unitOfWork.Devices.Update(device);

            if (updated == null)
            {
                throw new TrialDeviceNotFoundException(request.Id);
            }

            return _mapper.Map<Device, UpdateDeviceResponse>(updated);
        }
    }
}