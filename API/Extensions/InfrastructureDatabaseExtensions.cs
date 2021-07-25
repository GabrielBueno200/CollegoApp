using Infrastructure;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services.ExternalMongoServices;

namespace API.Infrastructure.Extensions
{
    public static class InfrastructureDatabaseExtensions {

        public static void AddDatabaseSettings(this IServiceCollection services, IConfiguration Configuration){

            #region Identity and PostgresSQL
            
            services.AddDbContext<DataContext>(opt => {
                opt.UseNpgsql(Configuration["DBConnection:ConnectionString"]);
            });

            services.AddIdentity<User, IdentityRole>(options => {
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            #endregion

            #region MongoDb

            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoSettings"));

            services.AddSingleton<MongoDbClient>();

            #endregion

        }
        
    }
}