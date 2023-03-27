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
    public class UpdateUserCommandHandler : CommandHandlerBase, ICommandHandler<UpdateUserCommand>
    {
        private readonly IValidator<UpdateUserCommand> _updateUserCommandValidaor;
        private readonly IUserRepository _UserRepository;

        public UpdateUserCommandHandler(IValidator<UpdateUserCommand> UserCommandValidaor,
            IUserRepository UserRepository)
        {
            _updateUserCommandValidaor = UserCommandValidaor;
            _UserRepository = UserRepository;
        }

        public async Task<Result> HandleAsync(UpdateUserCommand command)
        {
            var validationResult = await ValidateAsync(command, _updateUserCommandValidaor);

            if (validationResult.IsValid)
            {
                var User = UserMapper.CommandToEntity(command);
                _UserRepository.Update(User);
                _UserRepository.SaveChanges();
            }

            return Return();
        }
    }
}
