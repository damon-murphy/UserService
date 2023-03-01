using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.API.Application.Query;
using UserService.API.Application.Validation;
using UserService.Application.Command;
using UserService.Application.Validation;
using UserService.Domain;
using UserService.Domain.Interfaces;
using UserService.Resposity;
using UserService.Resposity.Interfaces;

namespace UserService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IValidator<CreateUserCommand>, ValidateCreateUser>();
            services.AddSingleton<IValidator<GetUserQuery>, ValidateGetUser>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
