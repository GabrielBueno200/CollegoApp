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
                    
                    OnAuthenticationFailed = ctx => {

                        ctx.NoResult();
                        ctx.Response.ContentType = "application/json";
                        ctx.Response.StatusCode = (int) HttpStatusCode.InternalServerError;


                        string errorMessage = "Algum erro ocorreu durante o seu processo de autenticação!";

                        object jsonObject =
                                Environment.IsDevelopment()
                                ? new { message = errorMessage, exception = ctx.Exception.ToString() }
                                : new { message = errorMessage };

                        var responseContent =
                            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(jsonObject));


                        ctx.Response.Body.WriteAsync(responseContent).GetAwaiter();

                        return Task.CompletedTask;

                    },

                    OnChallenge = ctx => {

                        if (!ctx.Response.HasStarted){

                            ctx.Response.ContentType = "application/json";

                            ctx.Response.StatusCode = (int) HttpStatusCode.Unauthorized;

                            string errorMessage = "Você não está autorizado!";

                            object jsonObject = new { message = errorMessage };

                            var responseContent =
                                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(jsonObject));

                            ctx.Response.Body.WriteAsync(responseContent).GetAwaiter();

                        }

                        return Task.CompletedTask;

                    },

                    OnForbidden = ctx => {

                        ctx.NoResult();
                        ctx.Response.ContentType = "application/json";
                        ctx.Response.StatusCode = (int) HttpStatusCode.Forbidden;


                        string errorMessage = "Não permitido!";

                        object jsonObject = new { message = errorMessage };

                        var responseContent =
                            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(jsonObject));


                        ctx.Response.Body.WriteAsync(responseContent).GetAwaiter();

                        return Task.CompletedTask;

                    },

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

        }

    }

}