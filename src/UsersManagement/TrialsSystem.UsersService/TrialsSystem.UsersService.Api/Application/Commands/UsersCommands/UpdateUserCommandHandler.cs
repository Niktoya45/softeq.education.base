using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.UserExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.Abstractions;

namespace TrialsSystem.UsersService.Api.Application.Commands.UsersCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        IUserRepository _repository;
        IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<UpdateUserCommand, User>(request);

            User? updated = await _repository.Update(user);

            if (updated == null)
            {
                throw new TrialUserNotFoundException(request.Id);
            }

            return _mapper.Map<User, UpdateUserResponse>(updated);
        }
    }
}
