using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalGetProduct
{
    public class PayPalGetProductRequest
    {

        [Required]
        public string ProductId { get; set; }

    }
}
