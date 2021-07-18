using System.Net.NetworkInformation;
using System.Buffers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Application.Security.Entities;
using Microsoft.AspNetCore.Mvc.Authorization;
using API.Security.Extensions.Customs;

namespace API.Security.Extensions
{

    public static class JWTSecurityExtensions {

        public static void AddJWTSettings(this IServiceCollection services, IConfiguration Configuration,
                                          IWebHostEnvironment Environment){
            
            // JWT data settings from appsettings.json
            var JWTSettingsSection = Configuration.GetSection("JWTSettings");
            services.Configure<TokenSettings>(JWTSettingsSection);

            var JWTSettings = JWTSettingsSection.Get<TokenSettings>();
            var key = Encoding.ASCII.GetBytes(JWTSettings.Secret);

            // policy: authorization necessary to all controllers (except AllowAnonymous annotated)
            services.AddControllers(options => {
                var policy = 
                    new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });
            
            // token validation parameters (dependecy injection)
            var JwtValidationParams = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = true,
                ValidAudience = JWTSettings.Audience,
                ValidIssuer = JWTSettings.Issuer,
                ValidateLifetime = true,
            };

            services.AddSingleton(JwtValidationParams);


            //authentication
            services.AddAuthentication(options => {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options => {

                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = JwtValidationParams;

                options.Events = new JwtBearerEvents() {
                    
                    OnAuthenticationFailed = ctx => ctx.HandleAuthenticationError(Environment),

                    OnChallenge = ctx => ctx.HandleUnauthorizedError(),

                    OnForbidden = ctx => ctx.HandleForbbidenError()

                };

            });
        }

    }

}