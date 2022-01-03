using System.Text.Json.Serialization;


namespace MrRooster.Payments.Infrastructure.ServiceClients.PayPal
{
    public class PayPalProduct
    {
        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("description")]
        public string Description;

        [JsonPropertyName("type")]
        public string Type;

        [JsonPropertyName("category")]
        public string Category;

        [JsonPropertyName("image_url")]
        public string ImageUrl;

        [JsonPropertyName("home_url")]
        public string HomeUrl;
    }

    public class PayPalProductCreated
    {
    }
}
