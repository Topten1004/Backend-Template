using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }

        public void Delete(Guid id)
        {
            var entity = _dbContext.User.FirstOrDefault(b => b.Id == id);
            _dbContext.User.Remove(entity);
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await _dbContext.User.AnyAsync(b => b.Email.Equals(email));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.User.AsNoTracking().ToListAsync();
        }

        public User GetById(Guid id)
        {
            return _dbContext.User.FirstOrDefault(b => b.Id == id);
        }
    }
}
