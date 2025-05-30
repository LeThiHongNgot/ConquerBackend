using ConquerBackend.Domain.Error;
using ConquerBackend.Shared;
using System.Net;
using System.Text.Json;

namespace ConquerBackend.Presentation.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorType error = ex switch
            {
                AppException appEx => appEx.Error,
                UnauthorizedAccessException => Errors.Unauthorized,
                _ => Errors.Unknown
            };

            var response = new
            {
                code = error.Code,
                message = error.Message,
                details = ex.Message
            };

            context.Response.StatusCode = error.StatusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
    public class AppException : Exception
    {
        public ErrorType Error { get; }

        public AppException(ErrorType error, string? details = null)
            : base(details ?? error.Message)
        {
            Error = error;
        }
    }

}
