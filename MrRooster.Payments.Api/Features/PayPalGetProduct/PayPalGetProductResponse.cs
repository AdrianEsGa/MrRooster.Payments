using Newtonsoft.Json;
using System;

namespace MrRooster.Payments.Api.Features.PayPalGetProduct
{
    public class PayPalGetProductResponse
    {

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("create_time")]
        public DateTime CreateTime;

        [JsonProperty("update_time")]
        public DateTime UpdateTime;

    }
}
