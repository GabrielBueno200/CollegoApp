using Domain.Repositories.Interfaces;
using Infrastructure.Repositories.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Extensions
{
    public static class InfrastructureRepositoriesExtensions{

        public static void AddRepositoriesSettings(this IServiceCollection services){

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        }

    }
}