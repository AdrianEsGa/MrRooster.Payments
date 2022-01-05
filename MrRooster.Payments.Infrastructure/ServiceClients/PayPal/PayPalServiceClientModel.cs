using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MrRooster.Payments.Infrastructure.ServiceClients.PayPal
{

    public class PayPalOAuth
    {
        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }
    }

    public class PayPalProduct
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

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("home_url")]
        public string HomeUrl { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("links")]
        public List<PayPalLink> Links { get; set; }
    }

    public class PayPalLink
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("rel")]
        public string Rel { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("encType")]
        public string EncType { get; set; }
    }

    public class PayPalPlan
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("product_id")]
        public string ProductId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("usage_type")]
        public string UsageType { get; set; }

        [JsonProperty("billing_cycles")]
        public List<PayPalBillingCycle> BillingCycles { get; set; }

        [JsonProperty("payment_preferences")]
        public PayPalPaymentPreferences PaymentPreferences { get; set; }

        [JsonProperty("taxes")]
        public PayPalTaxes Taxes { get; set; }

        [JsonProperty("quantity_supported")]
        public bool QuantitySupported { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("links")]
        public List<PayPalLink> Links { get; set; }
    }

    public class PayPalFrequency
    {
        [JsonProperty("interval_unit")]
        public string IntervalUnit { get; set; }

        [JsonProperty("interval_count")]
        public int IntervalCount { get; set; }
    }

    public class PayPalFixedPrice
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class PayPalPricingScheme
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("fixed_price")]
        public PayPalFixedPrice FixedPrice { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }
    }

    public class PayPalBillingCycle
    {
        [JsonProperty("frequency")]
        public PayPalFrequency Frequency { get; set; }

        [JsonProperty("tenure_type")]
        public string TenureType { get; set; }

        [JsonProperty("sequence")]
        public int Sequence { get; set; }

        [JsonProperty("total_cycles")]
        public int TotalCycles { get; set; }

        [JsonProperty("pricing_scheme")]
        public PayPalPricingScheme PricingScheme { get; set; }
    }

    public class PayPalSetupFee
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
    }

    public class PayPalPaymentPreferences
    {
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        [JsonProperty("auto_bill_outstanding")]
        public bool AutoBillOutstanding { get; set; }

        [JsonProperty("setup_fee")]
        public PayPalSetupFee SetupFee { get; set; }

        [JsonProperty("setup_fee_failure_action")]
        public string SetupFeeFailureAction { get; set; }

        [JsonProperty("payment_failure_threshold")]
        public int PaymentFailureThreshold { get; set; }
    }

    public class PayPalTaxes
    {
        [JsonProperty("percentage")]
        public string Percentage { get; set; }

        [JsonProperty("inclusive")]
        public bool Inclusive { get; set; }
    }

    public class PayPalName
    {
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }
    }

    public class Subscriber
    {
        [JsonProperty("name")]
        public PayPalName Name { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
    }

    public class PaymentMethod
    {
        [JsonProperty("payer_selected")]
        public string PayerSelected { get; set; }

        [JsonProperty("payee_preferred")]
        public string PayeePreferred { get; set; }
    }

    public class ApplicationContext
    {
        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("shipping_preference")]
        public string ShippingPreference { get; set; }

        [JsonProperty("user_action")]
        public string UserAction { get; set; }

        [JsonProperty("payment_method")]
        public PaymentMethod PaymentMethod { get; set; }

        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }

        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }
    }

    public class PayPalSubscription
    {
        [JsonProperty("plan_id")]
        public string PlanId { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        [JsonProperty("application_context")]
        public ApplicationContext ApplicationContext { get; set; }
    }


}
