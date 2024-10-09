using TrialsSystem.UserTaskService.Api.Exceptions.Base;

namespace TrialsSystem.UserTaskService.Api.Middlewares
{
    public class ExceptionUserTaskMiddleware
    {
        private readonly ILogger<ExceptionUserTaskMiddleware> _logger;

        public ExceptionUserTaskMiddleware(ILogger<ExceptionUserTaskMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
                context.Response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case ServiceException se:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    default:
                        _logger.LogCritical("System error occurred. Message: {message}. Inner exception: {innerException}. Stack trace: {stackTrace}",
                            e.Message,
                            e.InnerException?.Message,
                            e.StackTrace);
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
            }
        }
    }
}
