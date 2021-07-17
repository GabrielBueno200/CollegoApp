using Microsoft.Extensions.DependencyInjection;

namespace API.Settings
{
    public static class CorsSettings {

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