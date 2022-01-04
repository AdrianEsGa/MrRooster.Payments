using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MrRooster.Payments.Infrastructure.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        private readonly string PayPalClientId;
        private readonly string PayPalSecret;

        public PayPalServiceClient(HttpClient httpClient, ILogger<PayPalServiceClient> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            PayPalClientId = configuration[nameof(PayPalClientId)];
            PayPalSecret = configuration[nameof(PayPalSecret)];
        }

        public async Task<PayPalProduct> CreateProduct(PayPalProduct product)
        {
            var oauth = await GetOAuth();
            var path = string.Concat(_httpClient.BaseAddress, PayPalEndpoints.CREATE_PRODUCT);

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(oauth.TokenType, oauth.AccessToken);

            var content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Product created!!");
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<PayPalProduct>(json);
            }
            else
            {
                throw new Exception();
            }
        }

        private async Task<PayPalOAuth> GetOAuth()
        {
            var path = string.Concat(_httpClient.BaseAddress, PayPalEndpoints.GET_TOKEN);
            var content = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" }
            };

            var secret = Encoding.ASCII.GetBytes(PayPalClientId + ":" + PayPalSecret);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(secret));

            var response = await _httpClient.PostAsync(path, new FormUrlEncodedContent(content));

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<PayPalOAuth>(json);
            }

            throw new Exception(); 
           
        }
    }
}
