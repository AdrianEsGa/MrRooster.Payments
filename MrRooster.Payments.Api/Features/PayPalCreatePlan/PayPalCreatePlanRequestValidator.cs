using FluentValidation;

namespace MrRooster.Payments.Api.Features.PayPalCreatePlan
{
    public class PayPalCreatePlanRequestValidator : AbstractValidator<PayPalCreatePlanRequest>
    {
        public PayPalCreatePlanRequestValidator()
        {
            RuleFor(m => m.ProductId).NotNull().MinimumLength(5);
            RuleFor(m => m.BillingCycle).NotNull();
        }
    }
}
