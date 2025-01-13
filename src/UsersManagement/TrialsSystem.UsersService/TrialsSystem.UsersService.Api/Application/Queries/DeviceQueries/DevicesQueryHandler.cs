using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.DeviceDTOs;
using TrialsSystem.UsersService.Domain.AggregatesModel.DeviceAggregate;
using TrialsSystem.UsersService.Api.Exceptions.DeviceExceptions;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Queries.DeviceQueries
{

    public class DevicesQueryHandler : IRequestHandler<DevicesQuery, IEnumerable<GetDevicesResponse>>
    {

        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DevicesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDevicesResponse>> Handle(DevicesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Device>? devices = await _unitOfWork.Devices.GetAll(null, cancellationToken, request.Pg);

            if(devices == null)
                throw new TrialDeviceNotFoundException();

            return _mapper.Map<IEnumerable<Device>, IEnumerable<GetDevicesResponse>>(devices);
        }
    }
}
