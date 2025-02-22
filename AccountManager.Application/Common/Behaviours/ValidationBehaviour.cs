using AccountManager.Application.Common.Exceptions;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManager.Application.Common.Behaviours
{
    public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var firstError = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)       
                .Where(x => x != null)           
                .FirstOrDefault();

            if (firstError != null)
            {
                throw new BadRequestException(firstError.PropertyName, firstError.ErrorMessage);
            }

            return await next();
        }
    }
}
