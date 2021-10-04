namespace MicroSvc.Delivery.BackgroundTask.EventBus.Implementation
{
    using System.Collections.Concurrent;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using MicroSvc.Delivery.BackgroundTask.EventBus.Interfaces;
    using Microsoft.Azure.ServiceBus;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Microsoft.Extensions.Options;

    /// <summary>
    /// Queue client factory
    /// </summary>
    /// <seealso cref="IQueueClientFactory" />
    [ExcludeFromCodeCoverage]
    public class QueueClientFactory : IQueueClientFactory
    {
        /// <summary>
        /// The queue client mappings
        /// </summary>
        private readonly ConcurrentDictionary<string, IQueueClient> queueClientMappings = new ConcurrentDictionary<string, IQueueClient>();

        /// <summary>
        /// The settings
        /// </summary>
        private readonly ServiceBusSettings settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClientFactory"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public QueueClientFactory(IOptionsMonitor<ServiceBusSettings> options)
        {
            Contract.Assert(options != null);

            this.settings = options.CurrentValue;
        }

        /// <summary>
        /// Gets the queue client.
        /// </summary>
        /// <param name="queueName">The queue.</param>
        /// <returns>
        /// Queue client
        /// </returns>
        public IQueueClient GetQueueClient(string queueName)
        {
            if (this.queueClientMappings.TryGetValue(queueName, out var client))
            {
                return client;
            }

            // Can use TokenProvider.CreateAadTokenProvider for AD token provider
            // SASKey is configured at name space level not at queue level
            var tokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(this.settings.SASKeyName, this.settings.SASKey);
            client = new QueueClient(this.settings.ServiceBusEndpoint, queueName, tokenProvider, retryPolicy: RetryPolicy.Default);

            if (!string.IsNullOrWhiteSpace(this.settings.SASKeyName) && !string.IsNullOrWhiteSpace(this.settings.SASKey))
            {
                // don't cache it if the settings are wrong as we want the message to be written to the log repeatedly
                this.queueClientMappings.TryAdd(queueName, client);
            }
            return client;
        }
    }
}
