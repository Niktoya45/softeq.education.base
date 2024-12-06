using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.CityExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdateCityResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateCityResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            City city = _mapper.Map<UpdateCityCommand, City>(request);

            City? updated = await _unitOfWork.Cities.Update(city);

            if (updated == null)
            {
                throw new TrialCityNotFoundException(request.Id);
            }

            return _mapper.Map<City, UpdateCityResponse>(updated);
        }
    }
}