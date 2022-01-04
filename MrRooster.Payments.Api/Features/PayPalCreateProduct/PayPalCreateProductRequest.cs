using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalCreateProduct
{
    public class PayPalCreateProductRequest
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
