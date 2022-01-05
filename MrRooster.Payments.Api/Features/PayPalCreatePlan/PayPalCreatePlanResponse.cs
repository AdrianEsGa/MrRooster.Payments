using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalCreatePlan
{
    public class PayPalCreatePlanResponse
    {
        [Required]
        public string PlanId { get; set; }
    }
}
