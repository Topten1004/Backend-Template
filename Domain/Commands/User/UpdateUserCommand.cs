using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.User
{
    public class UpdateUserCommand : UserCommandBase
    {
        public Guid Id { get; set; }
    }
}
