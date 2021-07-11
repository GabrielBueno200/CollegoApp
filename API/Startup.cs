using System.Text;
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
using API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

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
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => {
                options.Events.OnRedirectToLogin = ctx => { 
                    ctx.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = ctx => {
                    ctx.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };
            });

            #endregion

            #region FluentValidation

            services.AddValidatorsFromAssemblyContaining<UserRegisterDTOValidator>();

            #endregion

            #region Dependency Injection

                #region Repositories 
                
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IAccountRepository, AccountRepository>();
                services.AddScoped<IProfileRepository, ProfileRepository>();

                #endregion

                #region Services
                
                services.AddScoped<IAccountService, AccountService>();
                services.AddScoped<IProfileService, ProfileService>();
                services.AddScoped<ResponseResult>();

                #endregion

                #region AutoMapper 
                
                services.AddAutoMapper(typeof(UserProfile).Assembly);
                
                #endregion

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

            #region JTWConfigs

            var JWTSettingsSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(JWTSettingsSection);

            var JWTSettings = JWTSettingsSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(JWTSettings.Secret);

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = true,
                    ValidAudience = JWTSettings.Audience,
                    ValidIssuer = JWTSettings.Issuer
                };
            });

            services.AddAuthorization(options => {
                options.AddPolicy(
                    "Bearer", 
                     new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build()
                );
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
            if (env.IsDevelopment()) {
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
