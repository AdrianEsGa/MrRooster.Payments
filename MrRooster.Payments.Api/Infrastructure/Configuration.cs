using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MrRooster.Payments.Application.Commands;
using System;
using MediatR;
using MrRooster.Payments.Api.Configuration.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MrRooster.Payments.Api.Features.PayPalCreateProduct;

namespace MrRooster.Payments.Api.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(opt =>
                        {
                           opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                           opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                  })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PayPalCreateProductRequestValidator>())
                .Services
                .AddMediatR(typeof(PayPalCreateProductCommand).Assembly)
                .AddCustomAutoMapper()
                .AddServiceClients();

            return services;
        }

        public static IApplicationBuilder Configure(IApplicationBuilder app, IWebHostEnvironment environment,
    Func<IApplicationBuilder, IApplicationBuilder> configureHost, Func<IEndpointRouteBuilder, IEndpointRouteBuilder> configureEndpoints = null)
        {
            var appBuilder = app;

            configureHost(appBuilder)
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    if (configureEndpoints != null)
                        configureEndpoints(endpoints);
                });



            return appBuilder;
        }
    }
}


