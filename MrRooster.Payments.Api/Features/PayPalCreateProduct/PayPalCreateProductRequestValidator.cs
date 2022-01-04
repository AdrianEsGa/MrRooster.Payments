using FluentValidation;

namespace MrRooster.Payments.Api.Features.PayPalCreateProduct
{
    public class PayPalCreateProductRequestValidator : AbstractValidator<PayPalCreateProductRequest>
    {
        public PayPalCreateProductRequestValidator()
        {
            RuleFor(m => m.Name).NotNull().MinimumLength(5);
            RuleFor(m => m.Description).NotNull().MinimumLength(5);
        }
    }
}
