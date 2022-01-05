using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalCreatePlan
{
    public class PayPalCreatePlanRequest
    {
        [Required]
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PayPalCreatePlanBillingCycle BillingCycle { get; set; }
    }

    public class PayPalCreatePlanBillingCycle
    {
        public PayPalCreatePlanFrequency Frequency { get; set; }
        public int TotalCycles { get; set; }
        public PayPalCreatePlanFixedPrice FixedPrice { get; set; }
    }

    public class PayPalCreatePlanFrequency
    {
        public string IntervalUnit { get; set; }
        public int IntervalCount { get; set; }
    }

    public class PayPalCreatePlanFixedPrice
    {
        public string Value { get; set; }
        public string CurrencyCode { get; set; }
    }
}
