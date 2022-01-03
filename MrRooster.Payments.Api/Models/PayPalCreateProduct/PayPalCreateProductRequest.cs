using System.Text.Json.Serialization;


namespace MrRooster.Payments.Api.Models.PayPalCreateProduct
{
    public class PayPalCreateProductRequest
    {
        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("description")]
        public string Description;

        [JsonPropertyName("type")]
        public string Type;

        [JsonPropertyName("category")]
        public string Category;
    }
}
