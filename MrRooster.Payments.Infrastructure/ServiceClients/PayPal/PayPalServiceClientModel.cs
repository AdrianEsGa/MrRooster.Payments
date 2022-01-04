using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MrRooster.Payments.Infrastructure.ServiceClients.PayPal
{

    public static class PayPalEndpoints
    {
        public static string GET_TOKEN = "v1/oauth2/token";
        public static string CREATE_PRODUCT = "v1/catalogs/products";
        public static string GET_PRODUCT = "v1/catalogs/products/";
    }

    public class PayPalProduct
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

        [JsonProperty("image_url")]
        public string ImageUrl;

        [JsonProperty("home_url")]
        public string HomeUrl;

        [JsonProperty("create_time")]
        public DateTime CreateTime;

        [JsonProperty("update_time")]
        public DateTime UpdateTime;

        [JsonProperty("links")]
        public List<PayPalLink> Links;
    }

    public class PayPalOAuth
    {
        [JsonProperty("scope")]
        public string Scope;

        [JsonProperty("access_token")]
        public string AccessToken;

        [JsonProperty("token_type")]
        public string TokenType;

        [JsonProperty("app_id")]
        public string AppId;

        [JsonProperty("expires_in")]
        public int ExpiresIn;

        [JsonProperty("nonce")]
        public string Nonce;
    }

    public class PayPalLink
    {
        [JsonProperty("href")]
        public string Href;

        [JsonProperty("rel")]
        public string Rel;

        [JsonProperty("method")]
        public string Method;
    }

}
