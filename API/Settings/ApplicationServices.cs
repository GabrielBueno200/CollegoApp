using Application.Core.Notifications;
using Application.Services.Entities;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.Settings
{
    public static class ServicesSettings {

        public static void AddServicesSettings(this IServiceCollection services){

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<NotificationsContext>();

        }

    }
}