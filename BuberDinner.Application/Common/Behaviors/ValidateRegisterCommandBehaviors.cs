using BuberDinner.Application.Services.Authentication;
using BuberDinner.Application.Services.Authentication.Commands.Register;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors
{
    public class ValidateRegisterCommandBehaviors : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidateRegisterCommandBehaviors(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request,
                                                          RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
                                                          CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            
            if(validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors
                            .ConvertAll(ValidationFailure => 
                            Error.Validation(
                                ValidationFailure.PropertyName, ValidationFailure.ErrorMessage));
            return errors;
        }
    }
}