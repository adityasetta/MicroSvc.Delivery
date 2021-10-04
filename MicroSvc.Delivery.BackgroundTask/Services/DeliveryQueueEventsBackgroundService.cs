namespace MicroSvc.Delivery.BackgroundTask.Services
{
    using Microsoft.Azure.ServiceBus;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    using MicroSvc.Delivery.BackgroundTask.EventBus.Interfaces;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeliveryQueueEventsBackgroundService : BackgroundService
    {
        private readonly string queueName;

        private readonly int maxConcurrentCalls;

        private readonly IQueueClientFactory queueClientFactory;

        private readonly DeliveryQueueEventsProcessor eventsProcessor;

        public DeliveryQueueEventsBackgroundService(
            IOptionsMonitor<BackgroundServiceOptions> backgroundSetting,
            IQueueClientFactory queueClientFactory,
            DeliveryQueueEventsProcessor eventsProcessor
            )
        {
            this.queueName = backgroundSetting.CurrentValue.DeliveryQueue;
            this.maxConcurrentCalls = backgroundSetting.CurrentValue.MaxConcurrentCalls;
            this.queueClientFactory = queueClientFactory;
            this.eventsProcessor = eventsProcessor;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() => { 
                // may log stopping service
            });

            var queueClient = this.queueClientFactory.GetQueueClient(this.queueName);
            this.eventsProcessor.QueueClient = queueClient;
            var messageHandlerOptions = new MessageHandlerOptions(this.eventsProcessor.HandleExceptionAsync)
            {
                AutoComplete = true,
                MaxConcurrentCalls = this.maxConcurrentCalls
            };
            queueClient.RegisterMessageHandler(this.eventsProcessor.HandleMessageAsync, messageHandlerOptions);

            return Task.CompletedTask;
        }
    }
}
