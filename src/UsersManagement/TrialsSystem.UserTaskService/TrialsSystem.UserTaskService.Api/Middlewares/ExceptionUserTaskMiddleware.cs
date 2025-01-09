using TrialsSystem.UserTaskService.Api.Exceptions.Base;
using TrialsSystem.UserTaskService.Domain.Exceptions;
using TrialsSystem.UserTaskService.Infrastructure.Exceptions;

namespace TrialsSystem.UserTaskService.Api.Middlewares
{
    public class ExceptionUserTaskMiddleware
    {
        private readonly ILogger<ExceptionUserTaskMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionUserTaskMiddleware(RequestDelegate next, ILogger<ExceptionUserTaskMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                context.Response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception e)
            {
                switch (e)
                {
                    case ServiceException se:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case DomainException de:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;

                    case InfrastructureException ie:

                        switch (ie) {
                            case UserTaskExistsException tee:
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                break;
                            case InnerDbException dbe:
                                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                break;
                        }
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
