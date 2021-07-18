using API.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace API.Mappers.Extensions
{
    public static class AutoMapperExtensions {

        public static void AddAutoMapperSettings(this IServiceCollection services){
            
            services.AddAutoMapper(typeof(UserProfile).Assembly);

        }
        
    }
}