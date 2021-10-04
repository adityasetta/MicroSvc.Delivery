namespace MicroSvc.Delivery.Domain.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Unit of work for atomic transactions
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Saves changes to the datastore
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>count of records effected</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
