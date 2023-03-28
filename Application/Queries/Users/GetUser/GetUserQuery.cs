using Application.Interfaces;
using Domain.Entities;

namespace Application.Queries.Users.GetUser
{
    public class GetUserQuery : IQuery<User>
    {
        public Guid UserId { get; set; }
    }
}