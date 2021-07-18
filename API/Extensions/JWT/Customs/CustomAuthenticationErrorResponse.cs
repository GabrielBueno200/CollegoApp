using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Security.Extensions.Customs
{
    public static class CustomAuthenticationErrorResponse
    {

        public static Task HandleAuthenticationError(this AuthenticationFailedContext ctx, IWebHostEnvironment Environment)
        {

            ctx.NoResult();
            ctx.Response.ContentType = "application/json";
            ctx.Response.StatusCode = (int) HttpStatusCode.InternalServerError;


            string errorMessage;

            if (ctx.Exception != null && ctx.Exception.GetType() == typeof(SecurityTokenExpiredException))
                errorMessage = "Seu token de autenticação já expirou, faça o processo de login novamente!";
            else
                errorMessage = "Algum erro ocorreu durante o seu processo de autenticação!";

            object jsonObject =
                    Environment.IsDevelopment()
                    ? new { message = errorMessage, exception = ctx.Exception.ToString() }
                    : new { message = errorMessage };

            var responseContent =
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(jsonObject));


            ctx.Response.Body.WriteAsync(responseContent).GetAwaiter();

            return Task.CompletedTask;
        }

    }
}