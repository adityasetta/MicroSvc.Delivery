namespace MicroSvc.Delivery.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using MicroSvc.Delivery.Domain.Entities;
    using MicroSvc.Delivery.Domain.Repositories;

    public class DeliveryRepository : BaseRepository<Delivery>, IDeliveryRepository
    {
        private readonly DeliveryContext deliveryContext;

        public DeliveryRepository(DeliveryContext deliveryContext) : base(deliveryContext)
        {
            this.deliveryContext = deliveryContext;
        }

        public void Add(Delivery deliverys) => deliveryContext.Delivery.Add(deliverys);

        public void Delete(Delivery delivery) => deliveryContext.Delivery.Remove(delivery);

        public void Edit(Delivery delivery) => deliveryContext.Delivery.Update(delivery);

        public async Task<List<Delivery>> GetDeliverys() => await deliveryContext.Delivery.ToListAsync().ConfigureAwait(false);
    }
}
