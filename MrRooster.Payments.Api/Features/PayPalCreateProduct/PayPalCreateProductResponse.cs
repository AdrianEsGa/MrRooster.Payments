using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalCreateProduct
{
    public class PayPalCreateProductResponse
    {

        [Required]
        public string ProductId { get; set; }

    }
}
