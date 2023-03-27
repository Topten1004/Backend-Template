using Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User
{
    public class DeleteUserCommand : CommandBase
    {
        public Guid Id { get; set; }
    }
}
