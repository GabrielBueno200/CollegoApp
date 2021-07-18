using Application.Core.Notifications;
using Application.Services.Entities;
using Application.Services.Interfaces;
using Application.Security.Services.Entities;
using Application.Security.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace API.Application.Extensions
{
    public static class ApplicationServicesExtensions {

        public static void AddServicesSettings(this IServiceCollection services){

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<ITokenRefresherService, TokenRefresherService>();
            services.AddScoped<NotificationsContext>();

        }

    }
}