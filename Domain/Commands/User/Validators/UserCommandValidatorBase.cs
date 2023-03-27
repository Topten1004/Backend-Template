using Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User.Validators
{
    public abstract class UserCommandValidatorBase<T> : AbstractValidator<T> where T : UserCommandBase
    {
        private readonly IUserRepository _UserRepository;

        protected UserCommandValidatorBase(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

            ValidateFirstName();
            ValidateLastName();
        }

        protected void ValidateNameIsUniqueOnCreate()
        {
            RuleFor(UserBaseCommand => UserBaseCommand.Email)
                .MustAsync(async (email, cancellationToken) => !(await _UserRepository.ExistsAsync(email)))
                .WithSeverity(Severity.Error)
                .WithMessage("An Email with this name already exists.");
        }

        private void ValidateFirstName()
        {
            RuleFor(UserBaseCommand => UserBaseCommand.FirstName)
                .Must(firstName => !string.IsNullOrWhiteSpace(firstName))
                .WithSeverity(Severity.Error)
                .WithMessage("FirstName can't be empty");
        }

        private void ValidateLastName()
        {
            RuleFor(UserBaseCommand => UserBaseCommand.LastName)
                .Must(lastName => !string.IsNullOrWhiteSpace(lastName))
                .WithSeverity(Severity.Error)
                .WithMessage("LastName can't be empty");
        }
    }

}
