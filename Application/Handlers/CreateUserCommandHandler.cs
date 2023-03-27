using Application.Commands;
using Application.Mapper;
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
    public class CreateUserCommandHandler : CommandHandlerBase, ICommandHandler<CreateUserCommand>
    {
        private readonly IValidator<CreateUserCommand> _createUserCommandValidaor;
        private readonly IUserRepository _UserRepository;

        public CreateUserCommandHandler(IValidator<CreateUserCommand> UserCommandValidaor,
            IUserRepository UserRepository)
        {
            _createUserCommandValidaor = UserCommandValidaor;
            _UserRepository = UserRepository;
        }

        public async Task<Result> HandleAsync(CreateUserCommand command)
        {
            var validationResult = await ValidateAsync(command, _createUserCommandValidaor);

            if (validationResult.IsValid)
            {
                var User = UserMapper.CommandToEntity(command);
                User.Created = DateTime.UtcNow;
                User.Updated = DateTime.UtcNow;
                _UserRepository.Add(User);
                _UserRepository.SaveChanges();
            }

            return Return();
        }
    }
}
