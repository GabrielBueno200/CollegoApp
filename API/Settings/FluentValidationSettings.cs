using Application.Core.DTOs.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Settings
{
    public static class FluentValidationSettings {

        public static void AddFluentValidationSettings(this IServiceCollection services){

            services.AddValidatorsFromAssemblyContaining<UserRegisterDTOValidator>();
        }
         
    }
}