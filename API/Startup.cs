using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Validators;
using Domain.Configurations.AutoMapper;
using API.Controllers;
using API.Repositories.Entities;
using API.Repositories.Interfaces;
using API.Services.Entities;
using API.Services.Interfaces;
using API.Utils;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            
            #region Identity and DbContext Configurations 

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
            .AddEntityFrameworkStores<DataContext>();

            #endregion

            #region FluentValidation

            services.AddValidatorsFromAssemblyContaining<UserRegisterDTOValidator>();


            #endregion

            #region Repositories DI
            
            services.AddScoped<IAccountRepository, AccountRepository>();

            #endregion

            #region ServicesDI
            
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ResponseResult>();

            #endregion

            #region AutoMapper DI
            
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            
            #endregion

            #region CorsConfigs

            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("*");
                });
            });

            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Collego API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
