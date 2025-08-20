using Serilog;
using System.Net;

namespace Clinic.Api.Middlwares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            object result;

            Log.Error(exception, "Unhandled exception at {Path}", context.Request.Path);

            switch (exception)
            {
                case AppException appEx:
                    statusCode = HttpStatusCode.BadRequest;
                    result = new { appEx.ErrorId, appEx.Description };
                    break;

                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    result = new { ErrorId = 404, Description = "Resource not found" };
                    break;

                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    result = new { ErrorId = 401, Description = "Unauthorized" };
                    break;

                default:
                    result = new { ErrorId = 500, Description = "An unexpected error occurred" };
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
