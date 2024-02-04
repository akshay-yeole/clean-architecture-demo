using application.Features.Product.Commands;
using FluentValidation;

namespace application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is Required");

            RuleFor(x => x.Rate).NotNull().NotEmpty().WithMessage("{PropertyName} is Required").GreaterThan(0);

        }
    }
}
