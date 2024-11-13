using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.CityDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.CityCommands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityResponse>
    {
        ICityRepository _repository;
        IMapper _mapper;

        public CreateCityCommandHandler(ICityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            City city = _mapper.Map<CreateCityCommand, City>(request);
            City added = _repository.Add(city);

            return _mapper.Map<City, CreateCityResponse>(added);
        }
    }
}