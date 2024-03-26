using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Abstractions;
using Services.Implementations;
using Services.Repositories.Abstractions;
using System;
using System.IO;
using System.Linq;
using System.Transactions;
using WebApi.Configs;
using WebApi.Consumers;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // команда дл€ создани€ нужного контейнера
            // docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Development.json", true)
                .Build();

            if (configuration.Get<ApplicationConfig>() is not IApplicationConfig receptionConfig)
                throw new ConfigurationException("Ќе удалось прочитать конфигурацию сервиса");

            string connection = configuration!.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connection))
                throw new ConfigurationException("Ќе удалось прочитать строку подключени€");

            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

            builder.Services.AddTransient<IMessageLogic, MessageLogic>();
            builder.Services.AddTransient<IPatientRepository, PatientRepository>();
            builder.Services.AddTransient<IPatientService, PatientService>();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<CallCenterConsumer>();


                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(receptionConfig.BusConfig.Host, receptionConfig.BusConfig.Port, receptionConfig.BusConfig.Path, h =>
                    {
                        h.Username(receptionConfig.BusConfig.Username);
                        h.Password(receptionConfig.BusConfig.Password);
                    });

                    cfg.UseTransaction(_ =>
                    {
                        _.Timeout = TimeSpan.FromSeconds(20);
                        _.IsolationLevel = IsolationLevel.ReadCommitted;
                    });

                    cfg.ReceiveEndpoint(new TemporaryEndpointDefinition(), e =>
                    {
                        e.ConfigureConsumer<CallCenterConsumer>(context);
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "/swagger/{documentName}/swagger.json";
                });
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            // валидаци€ данных
            // статус подтвержден
        }
    }
}