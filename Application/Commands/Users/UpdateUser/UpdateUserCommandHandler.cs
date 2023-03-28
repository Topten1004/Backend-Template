using Application.Commands;
using Application.Interfaces;
using Application.Mapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {

            var User = UserMapper.CommandToEntity(command);
            _userRepository.Update(User);
            _userRepository.SaveChanges();

            return User;
        }
    }
}
