using Domain.Repositories.Interfaces;
using Infrastructure.Repositories.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Settings
{
    public static class RepositoriesSettings{

        public static void AddRepositoriesSettings(this IServiceCollection services){

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

        }

    }
}