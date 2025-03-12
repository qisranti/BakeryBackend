namespace FinalBakery.Api
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);  
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "An error occurred while processing the request.");

                
                if (ex is InvalidOperationException)
                {
                    
                    httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await httpContext.Response.WriteAsJsonAsync(new { message = ex.Message });
                }
                else
                {
                    
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await httpContext.Response.WriteAsJsonAsync(new { message = "An unexpected error occurred." });
                }
            }
        }
    }
}
