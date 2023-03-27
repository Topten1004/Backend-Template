using Application.Handlers;
using Application.Queries;
using Domain.Commands.User.Validators;
using Domain.Commands.User;
using Domain.Core.Interfaces;
using Domain.Interfaces.Repositories;
using FluentValidation;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

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

            // dbcontext
            services.AddDbContext<DBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //data
            services.AddScoped<IUserRepository, UserRepository>();

            //validators
            services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
            services.AddScoped<IValidator<DeleteUserCommand>, DeleteUserCommandValidator>();

            //commandHandlers
            services.AddScoped<ICommandHandler<CreateUserCommand>, CreateUserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();

            //queries
            services.AddScoped<IUserQueries, UserQueries>();
        }
    }
}
