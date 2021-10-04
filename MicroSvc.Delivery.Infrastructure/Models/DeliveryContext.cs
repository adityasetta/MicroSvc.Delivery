namespace MicroSvc.Delivery.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    using MicroSvc.Delivery.Domain.Entities;

    using System;
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options) : base(options)
        {
        }

        public DbSet<Delivery> Delivery { get; set; }
    }
}
