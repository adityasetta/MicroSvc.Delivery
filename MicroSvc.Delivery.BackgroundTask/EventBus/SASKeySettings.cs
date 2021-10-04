namespace MicroSvc.Delivery.BackgroundTask.EventBus
{
    /// <summary>
    /// Service bus settings
    /// </summary>
    public class ServiceBusSettings
    {
        /// <summary>
        /// Gets or sets the service bus endpoint.
        /// </summary>
        /// <value>
        /// The service bus endpoint.
        /// </value>
        public string ServiceBusEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the name of the SAS key.
        /// </summary>
        /// <value>
        /// The name of the SAS key.
        /// </value>
        public string SASKeyName { get; set; }

        /// <summary>
        /// Gets or sets the SAS key.
        /// </summary>
        /// <value>
        /// The SAS key.
        /// </value>
        public string SASKey { get; set; }
    }
}
