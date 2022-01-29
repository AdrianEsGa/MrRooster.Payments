using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MrRooster.Payments.Api.Features.PayPalCreatePlan;
using MrRooster.Payments.Api.Features.PayPalCreateProduct;
using MrRooster.Payments.Api.Features.PayPalCreateSubscription;
using MrRooster.Payments.Api.Features.PayPalGetProduct;
using MrRooster.Payments.Infrastructure.Abstractions;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System;
using System.Net.Http.Headers;

namespace MrRooster.Payments.Api.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services) =>
            services
            .AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PayPalCreateProductMappingProfile());
                cfg.AddProfile(new PayPalGetProductMappingProfile());
                cfg.AddProfile(new PayPalCreatePlanMappingProfile());
                cfg.AddProfile(new PayPalCreateSubscriptionMappingProfile());

            }).CreateMapper());


        public static IServiceCollection AddServiceClients(this IServiceCollection services, IConfiguration configuration)
        {
            var paypalBaseUrl = configuration["PayPalServiceBaseUrl"];

            services.AddHttpClient<IPayPalAuthServiceClient, PayPalAuthServiceClient>(client =>
            {
                client.BaseAddress = new Uri(paypalBaseUrl);
            });

            services.AddHttpClient<IPayPalServiceClient, PayPalServiceClient>(client =>
            {
                client.BaseAddress = new Uri(paypalBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
               
            return services;
        }
    }
}
