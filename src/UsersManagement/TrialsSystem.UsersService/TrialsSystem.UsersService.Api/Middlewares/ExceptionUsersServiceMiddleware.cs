using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TrialsSystem.UsersService.Api.Exceptions.Base;
using TrialsSystem.UsersService.Api.Exceptions.UserExceptions;

namespace TrialsSystem.UsersService.Api.Middlewares
{
    public class ExceptionUsersServiceMiddleware
    {
        private readonly ILogger<ExceptionUsersServiceMiddleware> _logger;
        private readonly RequestDelegate _next;
        public ExceptionUsersServiceMiddleware(RequestDelegate next, ILogger<ExceptionUsersServiceMiddleware> logger)
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
            catch(Exception e)
            {
                switch (e)
                {
                    case ServiceException se:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case ValidationException ve:
                        context.Response.StatusCode= StatusCodes.Status400BadRequest;
                        break;
                    default:
                        _logger.LogCritical("System error occurred. Message: {message}. Inner exception: {innerException}. Stack trace: {stackTrace}",
                            e.Message,
                            e.InnerException?.Message,
                            e.StackTrace);
                        break;
                }
            }
        }

    }
}
