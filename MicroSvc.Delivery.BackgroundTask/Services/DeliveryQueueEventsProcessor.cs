namespace MicroSvc.Delivery.BackgroundTask.Services
{
    using Microsoft.Azure.ServiceBus;
    using Microsoft.Extensions.DependencyInjection;

    using MicroSvc.Delivery.ApplicationService.Interfaces;
    using MicroSvc.Delivery.Domain.Models.InboundEvents;
    using MicroSvc.Delivery.Domain.Entities;

    using Newtonsoft.Json;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeliveryQueueEventsProcessor
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        public IQueueClient QueueClient { get; internal set; }

        public DeliveryQueueEventsProcessor(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task HandleMessageAsync(Message message, CancellationToken cancellationToken)
        {
            using(var scope = this.serviceScopeFactory.CreateScope())
            {
                var deliveryService = scope.ServiceProvider.GetService<IDeliveryService>();

                var body = string.Empty;
                DeliveryEvent deliveryEvent = null;
                try
                {
                    body = Encoding.UTF8.GetString(message.Body);
                    deliveryEvent = JsonConvert.DeserializeObject<DeliveryEvent>(body);
                }
                catch(JsonException ex)
                {
                    this.QueueClient?.DeadLetterAsync(message.SystemProperties.LockToken, "DezerializeFailed", ex.Message);
                    return;
                }

                if(!deliveryEvent.TryGetNotificationType(out var deliveryType))
                {
                    return;
                }

                var deliveryItem = new Delivery
                {
                    Id = Guid.NewGuid(),
                    TransactionId = deliveryEvent.TransactionId,
                    CustomerId = deliveryEvent.CustomerId,
                    Address = deliveryEvent.Address,
                    Status = deliveryType.ToString()
                };

                await deliveryService.AddDelivery(deliveryItem);
            }
        }

        public Task HandleExceptionAsync(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            // Add logger here

            return Task.CompletedTask;
        }
    }
}
