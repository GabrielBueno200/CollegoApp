using API.Repositories.Entities;
using API.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.Settings
{
    public static class RepositoriesSettings{

        public static void AddRepositoriesSettings(this IServiceCollection services){

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

        }

    }
}