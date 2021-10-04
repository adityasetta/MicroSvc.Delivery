namespace MicroSvc.Delivery.BackgroundTask
{
    using System;

    public class BackgroundServiceOptions
    {
        public string DeliveryQueue { get; set; }
        public int TimeIntervalInMilliSeconds { get; set; }
        public int BatchSize { get; set; }
        public int MaxConcurrentCalls { get; set; }
    }
}
