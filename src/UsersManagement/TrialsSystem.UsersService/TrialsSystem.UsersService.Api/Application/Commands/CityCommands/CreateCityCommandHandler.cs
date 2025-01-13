using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            City city = _mapper.Map<CreateCityCommand, City>(request);
            City added = _unitOfWork.Cities.Add(city);

            return _mapper.Map<City, CreateCityResponse>(added);
        }
    }
}