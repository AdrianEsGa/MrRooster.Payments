using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MrRooster.Payments.Api.Features.PayPalCreateProduct;
using MrRooster.Payments.Infrastructure.Abstractions;
using MrRooster.Payments.Infrastructure.ServiceClients.PayPal;
using System;

namespace MrRooster.Payments.Api.Configuration.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services) =>
            services
            .AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PayPalCreateProductMappingProfile());

            }).CreateMapper());


        public static IServiceCollection AddServiceClients(this IServiceCollection services)
        {
            services
                .AddHttpClient<IPayPalServiceClient, PayPalServiceClient>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var config = provider.GetRequiredService<IConfiguration>();
                    client.BaseAddress = new Uri(config["PayPalServiceBaseUrl"]);
                });

            return services;
        }
    }
}
