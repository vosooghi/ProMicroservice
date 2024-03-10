﻿using Ground.Extensions.MessageBus.Abstractions;
using Ground.Extensions.MessageBus.RabbitMQ;
using Ground.Extensions.MessageBus.RabbitMQ.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Ground.Extensions.DependencyInjection
{
    public static class RabbitMqMessageBusServiceCollectionExtensions
    {
        public static IServiceCollection AddGroundRabbitMqMessageBus(this IServiceCollection services, IConfiguration configuration, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)
        {
            services.Configure<RabbitMqOptions>(configuration);
            services.AddServices();
            return services;
        }

        public static IServiceCollection AddGroundRabbitMqMessageBus(this IServiceCollection services, IConfiguration configuration, string sectionName, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)
        {
            services.AddGroundRabbitMqMessageBus(configuration.GetSection(sectionName));
            return services;
        }

        public static IServiceCollection AddGroundRabbitMqMessageBus(this IServiceCollection services, Action<RabbitMqOptions> setupAction, List<Type>? commands = null, Dictionary<string, List<Type>>? events = null)
        {
            services.Configure(setupAction);
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptions<RabbitMqOptions>>();
                var factory = new ConnectionFactory()
                {
                    //Uri = new Uri(options.Value.Url)
                    HostName = options.Value.Url
                };
                var connection = factory.CreateConnection();
                return connection;
            });
            services.AddScoped<ISendMessageBus, RabbitMqSendMessageBus>();

            services.AddSingleton<IReceiveMessageBus, RabbitMqReceiveMessageBus>();
            return services;
        }

        public static void ReceiveCommandFromRabbitMqMessageBus(this IServiceProvider serviceProvider, params string[] commands)
        {
            if (commands is null)
            {
                throw new ArgumentNullException(nameof(commands));
            }
            var receiveMessageBus = serviceProvider.GetRequiredService<IReceiveMessageBus>();
            foreach (var command in commands)
            {
                receiveMessageBus.Receive(command);
            }
        }

        public static void ReceiveEventFromRabbitMqMessageBus(this IServiceProvider serviceProvider, params KeyValuePair<string, string>[] events)
        {
            if (events is null)
            {
                throw new ArgumentNullException(nameof(events));
            }
            var receiveMessageBus = serviceProvider.GetRequiredService<IReceiveMessageBus>();
            foreach (var @event in events)
            {
                receiveMessageBus.Subscribe(@event.Key, @event.Value);
            }
        }
    }
}
