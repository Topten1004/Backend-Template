using Application.Commands;
using Domain.Commands.User;
using Domain.Core.Interfaces;
using Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class DeleteUserCommandHandler : CommandHandlerBase, ICommandHandler<DeleteUserCommand>
    {
        private readonly IValidator<DeleteUserCommand> _deleteUserCommandValidator;
        private readonly IUserRepository _UserRepository;

        public DeleteUserCommandHandler(
            IValidator<DeleteUserCommand> deleteUserCommandValidator,
            IUserRepository UserRepository)
        {
            _deleteUserCommandValidator = deleteUserCommandValidator;
            _UserRepository = UserRepository;
        }

        public async Task<Result> HandleAsync(DeleteUserCommand command)
        {
            var validationResult = await ValidateAsync(command, _deleteUserCommandValidator);

            if (validationResult.IsValid)
            {
                _UserRepository.Delete(command.Id);
                _UserRepository.SaveChanges();
            }

            return Return();
        }
    }
}
