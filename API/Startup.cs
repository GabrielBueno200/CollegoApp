
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.Security.Extensions;
using API.Infrastructure.Extensions;
using API.Application.Extensions;
using API.Mappers.Extensions;
using API.Validation.Extensions;
using API.Extensions;
using API.Swagger.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

//API Project: Presentation Layer

namespace API
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDatabaseSettings(Configuration);
            
            services.AddJWTSettings(Configuration, Environment);

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCorsSettings();

            services.AddRepositoriesSettings();

            services.AddServicesSettings();

            services.AddAutoMapperSettings();

            services.AddFluentValidationSettings();


            services.AddSwaggerSettings();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
