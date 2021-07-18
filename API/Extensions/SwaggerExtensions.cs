using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Swagger.Extensions
{
    public static class SwaggerExtensions {

        public static void AddSwaggerSettings (this IServiceCollection services) {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Collego API", Version = "v1" });
            });

        }
        
    }
}