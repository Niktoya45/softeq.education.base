using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Api.Exceptions.DeviceExceptions;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{

    public class DeviceQueryHandler : IRequestHandler<DeviceQuery, GetDeviceResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DeviceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetDeviceResponse> Handle(DeviceQuery request, CancellationToken cancellationToken)
        {
            Device? device = await _unitOfWork.Devices.GetById(request.Id);

            if (device == null)
                throw new TrialDeviceNotFoundException(request.Id);

            return _mapper.Map<Device, GetDeviceResponse>(device);
        }
    }
}
