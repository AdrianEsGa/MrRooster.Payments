using Microsoft.Extensions.Logging;
using MrRooster.Payments.Infrastructure.Abstractions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MrRooster.Payments.Infrastructure.ServiceClients.PayPal
{
    public class PayPalServiceClient : IPayPalServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PayPalServiceClient> _logger;

        public PayPalServiceClient(IPayPalAuthServiceClient authClient, HttpClient httpClient, ILogger<PayPalServiceClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            var auth = authClient.GetAuth().Result;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth.TokenType, auth.AccessToken);
        }

        public async Task<PayPalProduct> CreateProduct(PayPalProduct product)
        {
            var path = string.Concat(_httpClient.BaseAddress, PayPalEndpoints.Products.CREATE_PRODUCT);

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(path, content);

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Product created!!");
                return JsonConvert.DeserializeObject<PayPalProduct>(json);
            }

            _logger.LogError(json);
            throw new Exception();
        }

        public async Task<PayPalProduct> GetProduct(string productId)
        {
            var path = _httpClient.BaseAddress + PayPalEndpoints.Products.GET_PRODUCT + productId;

            var response = await _httpClient.GetAsync(path);

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PayPalProduct>(json);
            }

            _logger.LogError(json);
            throw new Exception();
        }

        public async Task<PayPalPlan> CreatePlan(PayPalPlan plan)
        {
            var path = string.Concat(_httpClient.BaseAddress, PayPalEndpoints.Plans.CREATE_PLAN);

            var content = new StringContent(JsonConvert.SerializeObject(plan), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(path, content);

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Plan created!!");
                return JsonConvert.DeserializeObject<PayPalPlan>(json);
            }

            _logger.LogError(json);
            throw new Exception();
        }

        public async Task<PayPalSubscriptionCreated> CreateSubscription(PayPalSubscription subscription)
        {
            var path = string.Concat(_httpClient.BaseAddress, PayPalEndpoints.Subscriptions.CREATE_SUBSCRIPTION);

            var content = new StringContent(JsonConvert.SerializeObject(subscription), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(path, content);

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PayPalSubscriptionCreated>(json);
            }
    
            _logger.LogError(json);
             throw new Exception();          
        }

    }
}
