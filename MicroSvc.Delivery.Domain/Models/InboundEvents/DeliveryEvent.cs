namespace MicroSvc.Delivery.Domain.Models.InboundEvents
{
    using MicroSvc.Delivery.Domain.Models.Enum;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeliveryEvent
    {
        public Guid CustomerId { get; set; }

        public Guid TransactionId { get; set; }

        public string Address { get; set; }

        public string EventType { get; set; }

        public DateTime SendDateTime { get; set; }

        public bool TryGetNotificationType(out DeliveryType deliveryType)
        {
            return Enum.TryParse(this.EventType, out deliveryType);
        }
    }
}
