using Infrastructure;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Extensions
{
    public static class InfrastructureDatabaseExtensions {

        public static void AddDatabaseSettings(this IServiceCollection services, IConfiguration Configuration){

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

        }
        
    }
}