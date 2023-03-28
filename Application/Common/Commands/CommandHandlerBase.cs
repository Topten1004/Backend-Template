using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public abstract class CommandHandlerBase
    {
        protected IEnumerable<string> Notifications;

        protected async Task<FluentValidation.Results.ValidationResult> ValidateAsync<T, TValidator>(
            T command,
            TValidator validator)
            where T : CommandBase
            where TValidator : IValidator<T>
        {
            var validationResult = await validator.ValidateAsync(command);
            Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            return validationResult;
        }

        public Result Return() => new Result(!Notifications.Any(), Notifications);
    }
}
