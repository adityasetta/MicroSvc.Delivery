namespace MicroSvc.Delivery.Infrastructure.Repositories
{
    using MicroSvc.Delivery.Domain.Repositories;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DeliveryContext deliveryContext;

        /// <summary>
        /// The disposed flag.
        /// </summary>
        private bool disposed = false;

        public UnitOfWork(DeliveryContext deliveryContext)
        {
            this.deliveryContext = deliveryContext;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return this.deliveryContext.SaveChangesAsync();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing">True if any managed resourced needs to be disposed, false otherwise.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.deliveryContext?.Dispose();
                this.disposed = true;
            }
        }
    }
}
