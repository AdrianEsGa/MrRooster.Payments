using FluentValidation;

namespace MrRooster.Payments.Api.Models
{
    public class PayPalCreateProductRequestValidator : AbstractValidator<PayPalCreateProductRequest>
    {
        public PayPalCreateProductRequestValidator()
        {
            RuleFor(m => m.Name).NotNull();
        }
    }
}
