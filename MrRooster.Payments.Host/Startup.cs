using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace MrRooster.Payments.Host
{
    public class Startup
    {
        public const string CorsPolicyName = "AllowAll";
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Api.Infrastructure.Configuration.ConfigureServices(services, Configuration);

            services
                .AddCors(options =>
                {
                    options.AddPolicy(name: CorsPolicyName,
                        builder =>
                        {
                            builder
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                        });
                })               
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MrRooster.Payments", Version = "v1" });
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseRouting();

            Func<IApplicationBuilder, IApplicationBuilder> configureHost = host =>
                 host
                     .UseCors(CorsPolicyName)
                     .UseAuthentication()
                    ;

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MrRooster.Payments v1"));
            }

            Api.Infrastructure.Configuration.Configure(app, env, configureHost);
        }
    }
}
