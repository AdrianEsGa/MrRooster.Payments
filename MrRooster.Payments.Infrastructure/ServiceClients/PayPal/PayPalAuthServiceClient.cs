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
    public class PayPalAuthServiceClient : IPayPalAuthServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PayPalAuthServiceClient> _logger;

        private readonly string PayPalClientId;
        private readonly string PayPalSecret;

        public PayPalAuthServiceClient(HttpClient httpClient, ILogger<PayPalAuthServiceClient> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            PayPalClientId = configuration[nameof(PayPalClientId)];
            PayPalSecret = configuration[nameof(PayPalSecret)];
        }

        public async Task<PayPalOAuth> GetAuth()
        {
            var path = string.Concat(_httpClient.BaseAddress, PayPalEndpoints.GET_TOKEN);
            var content = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" }
            };

            var token = Encoding.ASCII.GetBytes(PayPalClientId + ":" + PayPalSecret);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(token));

            var response = await _httpClient.PostAsync(path, new FormUrlEncodedContent(content));

            var json = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {           
                return JsonConvert.DeserializeObject<PayPalOAuth>(json);
            }

            _logger.LogError(json);
            throw new Exception();
        }
    }
}
