using application.Exceptions;
using FluentValidation;
using MediatR;

namespace application.Validators
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Pre-Process
            if (_validator.Any())
            {
                var validationContext = new ValidationContext<TRequest>(request);
                var result = await Task.WhenAll(_validator.Select(v=>v.ValidateAsync(validationContext, cancellationToken)));
                var failures = result.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                
                if (failures.Count > 0)
                {
                    throw new ValidationErrorException(failures);
                }
            }

            //Next-Process
            var response = await next();

            //Post-Process

            return response;
        }
    }
}
