using Application.Core.DTOs.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace API.Validation.Extensions
{
    public static class FluentValidationExtensions {

        public static void AddFluentValidationSettings(this IServiceCollection services){

            services.AddValidatorsFromAssemblyContaining<UserRegisterDTOValidator>();
        }
         
    }
}