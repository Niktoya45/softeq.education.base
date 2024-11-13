using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, CreateDeviceResponse>
    {
        IDeviceRepository _repository;
        IMapper _mapper;

        public CreateDeviceCommandHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateDeviceResponse> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            Device device = _mapper.Map<CreateDeviceCommand, Device>(request);
            Device added = _repository.Add(device);

            return _mapper.Map<Device, CreateDeviceResponse>(added);
        }
    }
}