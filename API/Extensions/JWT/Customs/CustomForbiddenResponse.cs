using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Security.Extensions.Customs
{
    public static class CustomForbiddenResponse {

        public static Task HandleForbbidenError(this ForbiddenContext ctx){

            ctx.NoResult();
            ctx.Response.ContentType = "application/json";
            ctx.Response.StatusCode = (int) HttpStatusCode.Forbidden;


            string errorMessage = "Não permitido!";

            object jsonObject = new { message = errorMessage };

            var responseContent =
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(jsonObject));


            ctx.Response.Body.WriteAsync(responseContent).GetAwaiter();

            return Task.CompletedTask;

        }
    }
}