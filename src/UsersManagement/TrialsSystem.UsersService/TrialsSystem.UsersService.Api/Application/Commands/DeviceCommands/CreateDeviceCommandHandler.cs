using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Commands.DeviceCommands
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, CreateDeviceResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateDeviceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateDeviceResponse> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            Device device = _mapper.Map<CreateDeviceCommand, Device>(request);
            Device added = _unitOfWork.Devices.Add(device);

            return _mapper.Map<Device, CreateDeviceResponse>(added);
        }
    }
}