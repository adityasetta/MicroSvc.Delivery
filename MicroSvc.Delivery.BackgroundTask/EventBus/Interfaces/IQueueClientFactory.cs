namespace MicroSvc.Delivery.BackgroundTask.EventBus.Interfaces
{
    using Microsoft.Azure.ServiceBus;

    /// <summary>
    /// Queue client factory
    /// </summary>
    public interface IQueueClientFactory
    {
        /// <summary>
        /// Gets the queue client.
        /// </summary>
        /// <param name="queueName">The queue.</param>
        /// <returns>Queue client</returns>
        IQueueClient GetQueueClient(string queueName);
    }
}
