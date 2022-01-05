using Newtonsoft.Json;
using System;

namespace MrRooster.Payments.Api.Features.PayPalGetProduct
{
    public class PayPalGetProductResponse
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }

    }
}
