using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Security.Extensions.Customs
{
    public static class CustomUnathorizedResponse {

        public static Task HandleUnauthorizedError(this JwtBearerChallengeContext ctx){
           
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
        }

    }
}