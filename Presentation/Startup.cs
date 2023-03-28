using Application.Queries;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using Infrastructure.Interfaces.Repositories;
using Application.Interfaces;
using Application.Queries.Users.GetAllUsers;
using MediatR;
using Application.Commands.Users.UpdateUser;
using Application.Commands.Users.CreateUser;
using Application.Commands.Users.DeleteUser;

namespace Presentation
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend");
                c.DocExpansion(DocExpansion.None);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Backend",
                    Version = "v1",
                });
            });

            services.AddControllers();

            // dbContext
            services.AddDbContext<DBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // data
            services.AddScoped<IUserRepository, UserRepository>();

            // queries
            services.AddScoped<IUserQueries, UserQueries>();

            // mediatR
            services.AddMediatR(typeof(GetAllUsersQuery).Assembly);
            services.AddMediatR(typeof(UpdateUserCommand).Assembly);
            services.AddMediatR(typeof(CreateUserCommand).Assembly);
            services.AddMediatR(typeof(DeleteUserCommand).Assembly);

        }
    }
}
