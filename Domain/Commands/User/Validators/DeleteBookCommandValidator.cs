using Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User.Validators
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandValidator(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;

            ValidateExists();
        }

        private void ValidateExists()
        {
            RuleFor(UserBaseCommand => UserBaseCommand.Id)
                .Must(id => _userRepository.GetById(id) != null)
                .WithSeverity(Severity.Error)
                .WithMessage("User not exists.");
        }
    }

}
