using Domain.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User.Validators
{
    public class CreateUserCommandValidator : UserCommandValidatorBase<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository UserRepository)
            : base(UserRepository)
        {
            ValidateNameIsUniqueOnCreate();
        }
    }
}
