using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MrRooster.Payments.Api.Features.PayPalCreateProduct
{
    public class PayPalCreateProductRequest
    {

        [Required]
        public string Name;

        public string Description;

        public string Type;

        public string Category;
    }
}
