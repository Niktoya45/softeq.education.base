using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Api.Exceptions.CityExceptions;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;
using AutoMapper;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;

namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{

    public class CityQueryHandler : IRequestHandler<CityQuery, GetCityResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public CityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetCityResponse> Handle(CityQuery request, CancellationToken cancellationToken)
        {
            City? city = await _unitOfWork.Cities.GetById(request.Id, cancellationToken);

            if (city == null)
                throw new TrialCityNotFoundException(request.Id);

            return _mapper.Map<City, GetCityResponse>(city);
        }
    }
}
