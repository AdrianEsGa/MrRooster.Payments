using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalCreatePlan
{
    public class PayPalCreatePlanRequest
    {
        [Required]
        public string ProductId { get; set; }
        public string Name { get; set; }
        public PayPalCreatePlanBillingCycle BillingCycle { get; set; }
    }

    public class PayPalCreatePlanBillingCycle
    {
        public PayPalCreatePlanFrequency Frequency { get; set; }
        public PayPalCreatePlanFixedPrice FixedPrice { get; set; }
    }

    public class PayPalCreatePlanFrequency
    {
        //The possible values are:
        //DAY.A daily billing cycle.
        //WEEK.A weekly billing cycle.
        //MONTH.A monthly billing cycle.
        //YEAR.A yearly billing cycle.

        public string IntervalUnit { get; set; }
        public int IntervalCount { get; set; }
    }

    public class PayPalCreatePlanFixedPrice
    {
        public string Value { get; set; }
    }
}
