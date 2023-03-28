using MediatR;

namespace Application.Interfaces
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}