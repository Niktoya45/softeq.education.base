using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Api.Exceptions.UserExceptions;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Commands.UsersCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = _mapper.Map<UpdateUserCommand, User>(request);

            User? updated = await _unitOfWork.Users.Update(user);

            if (updated == null)
            {
                throw new TrialUserNotFoundException(request.Id);
            }

            return _mapper.Map<User, UpdateUserResponse>(updated);
        }
    }
}
