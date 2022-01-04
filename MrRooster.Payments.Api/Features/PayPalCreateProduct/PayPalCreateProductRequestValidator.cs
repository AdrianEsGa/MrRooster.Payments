using FluentValidation;

namespace MrRooster.Payments.Api.Features.PayPalCreateProduct
{
    public class PayPalCreateProductRequestValidator : AbstractValidator<PayPalCreateProductRequest>
    {
        public PayPalCreateProductRequestValidator()
        {
            RuleFor(m => m.Name).NotNull().MinimumLength(5);
            RuleFor(m => m.Description).NotNull();
            RuleFor(m => m.Type).NotNull();
            RuleFor(m => m.Category).NotNull();
        }
    }
}
