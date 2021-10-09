using EventBus.Messages.Common;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Ordering.Application.Extensions;
using Product.API.Data;
using Product.API.EventBusConsumer;
using Product.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Product.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config => {

                config.AddConsumer<CreateOrderConsumer>();
                config.AddConsumer<CampaignConsumer>();

                config.UsingRabbitMq((ctx, cfg) => {
                    cfg.Host(Configuration["EventBusSettings:HostAddress"]);

                    cfg.ReceiveEndpoint(EventBusConstants.CreateOrderQueue, c =>
                    {
                        c.ConfigureConsumer<CreateOrderConsumer>(ctx);
                    });
                    cfg.ReceiveEndpoint(EventBusConstants.CampaignDiscountQueue, c =>
                    {
                        c.ConfigureConsumer<CampaignConsumer>(ctx);
                    });
                });
            });
            services.AddMassTransitHostedService();


            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
            });

            services.AddScoped<IProductContext, ProductContext>();
            services.AddScoped<IItemRepository, ItemRepository>();
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
            });
        }
    }
}
