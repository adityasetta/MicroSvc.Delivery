namespace MicroSvc.Delivery.BackgroundTask.EventBus.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus;

    /// <summary>
    /// Event bus service
    /// </summary>
    public interface IEventBusService
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Task which can be waited</returns>
        Task SendMessage(Message message, string queueName);
    }
}