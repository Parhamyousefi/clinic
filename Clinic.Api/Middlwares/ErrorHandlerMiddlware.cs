using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Net;
using System.Text.Json;

namespace Clinic.Api.Middlwares
{
    public class ErrorHandlerMiddlware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException a:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case SecurityTokenExpiredException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { exceptionMessage = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
