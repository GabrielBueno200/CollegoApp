using API.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace API.Settings
{
    public static class AutoMapperSettings {

        public static void AddAutoMapperSettings(this IServiceCollection services){
            
            services.AddAutoMapper(typeof(UserProfile).Assembly);

        }
        
    }
}