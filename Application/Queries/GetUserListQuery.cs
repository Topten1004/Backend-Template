using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Queries
{
    public class GetUserListQuery : IRequest<List<User>>
    {
    }
}
