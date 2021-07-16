using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Settings
{
    public static class SwaggerSettings {

        public static void AddSwaggerSettings (this IServiceCollection services) {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Collego API", Version = "v1" });
            });

        }
        
    }
}