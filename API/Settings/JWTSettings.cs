using System.Threading.Tasks;
using System;
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

namespace API.Settings
{
    public class JWTPayload {
        
        public string Issuer { get; set; }

        public string Audience { get; set; }
        
        public int Expires_In { get; set; } 
        
        public string Secret { get; set; }
        
    }

    public static class JWTSettings {

        public static void AddJWTSettings(this IServiceCollection services, IConfiguration Configuration, 
                                          IWebHostEnvironment Environment){
            
            var JWTSettingsSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTPayload>(JWTSettingsSection);

            var JWTSettings = JWTSettingsSection.Get<JWTPayload>();
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
                    ValidIssuer = JWTSettings.Issuer,
                    ValidateLifetime = true,

                };

                options.Events = new JwtBearerEvents(){
                    OnAuthenticationFailed = ctx => {
                        
                        ctx.NoResult();
                        ctx.Response.ContentType = "application/json";
                        ctx.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                        
                        string errorMessage = "An error has ocurred during your authentication proccess";

                        object jsonObject = 
                                Environment.IsDevelopment()
                                ? new { message = errorMessage, exception = ctx.Exception.ToString()} 
                                :  new { message = errorMessage };
                        
                        var responseContent = 
                            Encoding.UTF8.GetBytes(JsonSerializer.Serialize(jsonObject)); 


                        ctx.Response.Body.WriteAsync(responseContent).GetAwaiter();

                        return Task.CompletedTask;
                        
                    }
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