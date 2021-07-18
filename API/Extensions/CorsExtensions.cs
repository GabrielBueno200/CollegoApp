using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class CorsExtensions {

        public static void AddCorsSettings(this IServiceCollection services){

            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("*");
                });
            });

        }
        
    }
}