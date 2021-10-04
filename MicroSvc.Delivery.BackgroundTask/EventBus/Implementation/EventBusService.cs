namespace MicroSvc.Delivery.BackgroundTask.EventBus.Implementation
{
    using System;
    using System.Threading.Tasks;
    using MicroSvc.Delivery.BackgroundTask.EventBus.Interfaces;
    using Microsoft.Azure.ServiceBus;

    /// <summary>
    /// Event bus service
    /// </summary>
    /// <seealso cref="IEventBusService" />
    public class EventBusService : IEventBusService
    {
        /// <summary>
        /// The queue client factory
        /// </summary>
        private readonly IQueueClientFactory queueClientFactory;
        /// <summary>
        /// Initializes a new instance of the <see cref="EventBusService"/> class.
        /// </summary>
        /// <param name="queueClientFactory">The queue client factory.</param>
        public EventBusService(IQueueClientFactory queueClientFactory)
        {
            this.queueClientFactory = queueClientFactory;
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="queueName">The queue.</param>
        /// <returns>Task which can be waited</returns>
        public Task SendMessage(Message message, string queueName)
        {
            var queueClient = this.queueClientFactory.GetQueueClient(queueName);
            return queueClient.SendAsync(message);
        }
    }
}
