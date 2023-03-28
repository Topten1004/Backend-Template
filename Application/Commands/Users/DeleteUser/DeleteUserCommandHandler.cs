using Application.Commands.Users.UpdateUser;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            _userRepository.Delete(command.Id);
            _userRepository.SaveChanges();

            return command.Id;
        }
    }
}
