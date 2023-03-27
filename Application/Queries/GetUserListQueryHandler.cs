using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly IUserRepository _UserRepository;

        public UserQueries(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<IEnumerable<Domain.Entities.User>> GetAllAsync()
        {
            return await _UserRepository.GetAllAsync();
        }
    }

    public interface IUserQueries
    {
        Task<IEnumerable<Domain.Entities.User>> GetAllAsync();
    }
}
