using AutoMapper;
using MediatR;
using TrialsSystem.UsersService.Infrastructure.Models.UserDTOs;
using TrialsSystem.UsersService.Domain.AggregatesModel.UserAggregate;
using TrialsSystem.UsersService.Api.Exceptions.UserExceptions;
using TrialsSystem.UsersService.Infrastructure.Repositories.UnitOfWork;

namespace TrialsSystem.UsersService.Api.Application.Queries.UsersQueries
{
    public class UsersQueryHandler : IRequestHandler<UsersQuery, IEnumerable<GetUsersResponse>>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public UsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            IUnitOfWork _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUsersResponse>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<User>? users;
            if(request.Email != null)
                users = await _unitOfWork.Users.GetByEmail(request.Email, cancellationToken);
            else users = await _unitOfWork.Users.GetAll(null, cancellationToken, request.Pg);

            if (users == null)
                throw new TrialUserNotFoundException("No user was found", request.Email);

            return _mapper.Map<IEnumerable<User>, IEnumerable<GetUsersResponse>>(users);
        }
    }
}
