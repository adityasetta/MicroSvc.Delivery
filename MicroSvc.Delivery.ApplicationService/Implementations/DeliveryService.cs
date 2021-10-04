namespace MicroSvc.Delivery.ApplicationService.Implementations
{
    using MicroSvc.Delivery.ApplicationService.Interfaces;
    using MicroSvc.Delivery.Domain.Repositories;
    using MicroSvc.Delivery.Domain.Entities;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository deliveryRepository;

        private readonly IUnitOfWork unitOfWork;

        public DeliveryService(IDeliveryRepository deliveryRepository, IUnitOfWork unitOfWork)
        {
            this.deliveryRepository = deliveryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddDelivery(Delivery deliverys)
        {
            deliveryRepository.Add(deliverys);
            await this.unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteDelivery(Delivery delivery)
        {
            deliveryRepository.Delete(delivery);
            await this.unitOfWork.SaveChangesAsync();
        }
        public async Task EditDelivery(Delivery delivery)
        {
            deliveryRepository.Edit(delivery);
            await this.unitOfWork.SaveChangesAsync();
        }
        public async Task<List<Delivery>> GetDeliverys()
        {
            return await deliveryRepository.GetDeliverys().ConfigureAwait(false);
        }
    }
}
