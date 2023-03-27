using Domain.Core.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> ExistsAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        User GetById(Guid id);
        void Delete(Guid id);
    }
}
