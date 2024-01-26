using KnowledgeZone.Domain.Exceptions;
using System.Net;

namespace KnowledgeZone.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Logger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, Logger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private async Task HandleAsync(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string massage = "Internal Server Error";

            if(ex is EntityNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                massage = ex.Message;
            }

            await context.Response.WriteAsync(massage);
            _logger.LogError(ex, ex.Message);
        }
    }
}
