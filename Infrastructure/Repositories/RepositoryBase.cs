using Domain.Interfaces;
using Infrastructure.Contexts;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        protected readonly DBContext _dbContext;

        public RepositoryBase(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int SaveChanges() => _dbContext.SaveChangesAsync().Result;

        public void Add(T entity) => _dbContext.Add(entity);
        public void Update(T entity) => _dbContext.Update(entity);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }

}
