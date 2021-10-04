namespace MicroSvc.Delivery.Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MicroSvc.Delivery.Domain.Entities;

    public interface IDeliveryRepository : IRepository<Delivery>
    {
        void Add(Delivery deliverys);
        void Delete(Delivery delivery);
        void Edit(Delivery delivery);
        Task<List<Delivery>> GetDeliverys();
    }
}
