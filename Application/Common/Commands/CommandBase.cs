using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface CommandBase : IRequest
    {

    }

    public interface CommandBase<out TResult> : IRequest<TResult>
    {
    }
}
