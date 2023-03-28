using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;

namespace Application.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, User>
    {
        private IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetById(request.UserId);
        }
    }
}