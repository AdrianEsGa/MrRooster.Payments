using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalCreateSubscription
{
    public class PayPalCreateSubscriptionRequest
    {
        [Required]
        public string PlanId { get; set; }
        public string Locale { get; set; }
        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
