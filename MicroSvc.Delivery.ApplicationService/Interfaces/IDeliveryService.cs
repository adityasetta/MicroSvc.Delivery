namespace MicroSvc.Delivery.ApplicationService.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MicroSvc.Delivery.Domain.Entities;

    public interface IDeliveryService
    {
        Task AddDelivery(Delivery deliverys);
        Task DeleteDelivery(Delivery delivery);
        Task EditDelivery(Delivery delivery);
        Task<List<Delivery>> GetDeliverys();
    }
}
