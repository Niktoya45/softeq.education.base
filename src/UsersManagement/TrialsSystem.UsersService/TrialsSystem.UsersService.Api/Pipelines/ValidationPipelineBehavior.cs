using MediatR;
using FluentValidation;
using System.ComponentModel;

namespace TrialsSystem.UsersService.Api.Pipelines
{
    public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<AbstractValidator<TRequest>> _validators;
        public ValidationPipelineBehavior(IEnumerable<AbstractValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Select(validator => validator.Validate(context))
                                                              .Where(vres => !vres.IsValid);

            if (failures.Any())
            {
                var errors = failures.SelectMany(vres => vres.Errors).ToList();
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
