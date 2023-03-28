using Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommandHandler<in T> where T : CommandBase
    {
        Task<Result> HandleAsync(T command);
    }
}
