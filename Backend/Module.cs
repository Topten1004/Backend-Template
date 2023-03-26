using Domain.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    public static class Module
    {
        public static void Register(this IServiceCollection services)
        {
            // data
            services.AddScoped<IUserRepository, UserRepository>();

            // validators

        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
