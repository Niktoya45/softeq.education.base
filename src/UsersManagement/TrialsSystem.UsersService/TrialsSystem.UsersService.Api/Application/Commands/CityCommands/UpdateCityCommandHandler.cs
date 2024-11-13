using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.CityExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdateCityResponse>
    {
        ICityRepository _repository;
        IMapper _mapper;

        public UpdateCityCommandHandler(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateCityResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            City city = _mapper.Map<UpdateCityCommand, City>(request);

            City? updated = await _repository.Update(city);

            if (updated == null)
            {
                throw new TrialCityNotFoundException(request.Id);
            }

            return _mapper.Map<City, UpdateCityResponse>(updated);
        }
    }
}