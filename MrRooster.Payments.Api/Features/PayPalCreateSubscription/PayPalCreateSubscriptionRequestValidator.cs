using FluentValidation;

namespace MrRooster.Payments.Api.Features.PayPalCreateSubscription
{
    public class PayPalCreateSubscriptionRequestValidator : AbstractValidator<PayPalCreateSubscriptionRequest>
    {
        public PayPalCreateSubscriptionRequestValidator()
        {
            RuleFor(m => m.PlanId).NotNull().MinimumLength(5);
            RuleFor(m => m.Locale).NotNull();
            RuleFor(m => m.ReturnUrl).NotNull();
            RuleFor(m => m.CancelUrl).NotNull();
        }
    }
}
