using Application.Auth;
using Application.Interfaces;
using Application.Users;
using Infrastructure.Configuration;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(
                configuration.GetSection("JwtSettings")
            );

            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            // Register generic repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Register feature-specific repositories
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddHttpContextAccessor();

            return services;
        }
    }
}
