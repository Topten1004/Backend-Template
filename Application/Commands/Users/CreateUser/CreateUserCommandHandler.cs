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

namespace Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var User = UserMapper.CommandToEntity(command);
            User.Created = DateTime.UtcNow;
            User.Updated = DateTime.UtcNow;
            _userRepository.Add(User);
            _userRepository.SaveChanges();

            return User;
        }
    }
}
