using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Api.Exceptions.CityExceptions;
using System.Collections;


namespace TrialsSystem.UsersService.Api.Application.Queries.CityQueries
{

    public class CitiesQueryHandler : IRequestHandler<CitiesQuery, IEnumerable<GetCityResponse>>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public CitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCityResponse>> Handle(CitiesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<City>? cities = await _unitOfWork.Cities.GetAll(null, cancellationToken, request.Pg);

            if (cities == null)
                throw new TrialCityNotFoundException();

            return _mapper.Map<IEnumerable<City>, IEnumerable<GetCityResponse>>(cities);
        }
    }
}
