using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.DeviceExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, UpdateDeviceResponse>
    {
        IDeviceRepository _repository;
        IMapper _mapper;

        public UpdateDeviceCommandHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateDeviceResponse> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            Device device = _mapper.Map<UpdateDeviceCommand, Device>(request);

            Device? updated = await _repository.Update(device);

            if (updated == null)
            {
                throw new TrialDeviceNotFoundException(request.Id);
            }

            return _mapper.Map<Device, UpdateDeviceResponse>(updated);
        }
    }
}