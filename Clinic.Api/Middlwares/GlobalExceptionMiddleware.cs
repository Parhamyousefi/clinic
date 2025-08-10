using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

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
                await HandleGlobalExceptionAsync(context, ex);
            }
        }

        private static async Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            Log.Error(exception, "Unhandled exception caught by GlobalExceptionMiddleware");

            var response = context.Response;
            response.ContentType = "application/json";

            HttpStatusCode statusCode;
            string message;
            object details = null;


            switch (exception)
            {
                // Validation errors
                case ValidationException validationEx:
                    statusCode = HttpStatusCode.BadRequest;
                    message = validationEx.Message;
                    details = validationEx.ValidationResult;
                    break;

                // Bad request from invalid arguments
                case ArgumentException argEx:
                case ArgumentNullException argNullEx:
                    statusCode = HttpStatusCode.BadRequest;
                    message = argEx?.Message ?? argNullEx?.Message;
                    break;

                // Unauthorized or Forbidden
                case UnauthorizedAccessException:
                    statusCode = HttpStatusCode.Unauthorized;
                    message = "Unauthorized access.";
                    break;
                case InvalidOperationException opEx when opEx.Message.Contains("Forbidden", StringComparison.OrdinalIgnoreCase):
                    statusCode = HttpStatusCode.Forbidden;
                    message = opEx.Message;
                    break;

                // Not found
                case KeyNotFoundException notFoundEx:
                    statusCode = HttpStatusCode.NotFound;
                    message = notFoundEx.Message;
                    break;

                // Database errors
                case DbUpdateException dbUpdateEx:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "A database error occurred while processing your request.";
                    details = dbUpdateEx.InnerException?.Message ?? dbUpdateEx.Message;
                    break;
                case SqlException sqlEx:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "A SQL Server error occurred.";
                    details = sqlEx.Message;
                    break;

                // Business logic exceptions
                case ApplicationException appEx:
                    statusCode = HttpStatusCode.BadRequest;
                    message = appEx.Message;
                    break;

                // Default fallback for unknown exceptions
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "An unexpected error occurred.";
                    break;
            }

            response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new
            {
                success = false,
                error = message,
                details,
                statusCode = response.StatusCode,
                timestamp = DateTime.UtcNow
            });

            await response.WriteAsync(result);
        }
    }
}
