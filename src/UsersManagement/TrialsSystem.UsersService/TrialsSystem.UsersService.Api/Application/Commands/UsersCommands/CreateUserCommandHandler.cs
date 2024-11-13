using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.UsersCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        IUserRepository _repository;
        IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<CreateUserCommand, User>(request);
            User added = _repository.Add(user);

            return _mapper.Map<User, CreateUserResponse>(added);
        }
    }
}
