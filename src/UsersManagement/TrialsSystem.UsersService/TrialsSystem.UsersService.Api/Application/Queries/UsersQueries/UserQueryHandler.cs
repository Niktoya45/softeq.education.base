using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Api.Exceptions.UserExceptions;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Queries.UsersQueries
{

    public class UserQueryHandler : IRequestHandler<UserQuery, GetUserResponse>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public UserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetUserResponse> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            User? user = await _unitOfWork.Users.GetById(request.Id, cancellationToken);

            if (user == null)
                throw new TrialUserNotFoundException(request.Id);


            return _mapper.Map<GetUserResponse>(user);
        }
    }
}
