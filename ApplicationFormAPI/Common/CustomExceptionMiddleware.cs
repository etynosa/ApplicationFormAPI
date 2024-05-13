using System.Net;

namespace ApplicationFormAPI.Common
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex} \n Inner Exception => {ex.InnerException} \n Stack Trace => {ex.StackTrace}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                //System.ArgumentNullException => "Null Argument Exception",
                // System.ArgumentException => "Argument Exception",
                // System.InvalidOperationException => "Invalid Operation Exception",
                // System.IO.FileNotFoundException => "File Not Found Exception",
               Microsoft.Azure.Cosmos.CosmosException => "Resource not found",
                _ => "Internal Server Error from the Custom middleware."
            };


            if (exception is Microsoft.Azure.Cosmos.CosmosException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"{message} \n {exception.Message}"
            }.ToString());
        }
    }
}
