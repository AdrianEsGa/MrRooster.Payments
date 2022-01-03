using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MrRooster.Payments.Api.Models;
using MrRooster.Payments.Application.Commands.PayPal;
using System;
using MediatR;
using MrRooster.Payments.Api.Configuration.Extensions;

namespace MrRooster.Payments.Api.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddControllers()
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


