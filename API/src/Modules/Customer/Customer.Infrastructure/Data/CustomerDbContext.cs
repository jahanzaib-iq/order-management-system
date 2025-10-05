using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Data;
using Domain.Shared;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace Customer.Infrastructure.Data
{
  public class CustomerDbContext(DbContextOptions<CustomerDbContext> options) : DbContext(options), ICustomerDbContext
  {
    DatabaseFacade ICustomerDbContext.Database => this.Database;

    public virtual DbSet<CustomerSeedingEntry>? SeedingEntries { get; set; }

    public new DbSet<T> Set<T>() where T : BaseEntity
    {
      return base.Set<T>();
    }

    public async Task<int> SaveChangesAsync()
    {
      return await base.SaveChangesAsync();
    }

    public override Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Update(object entity)
    {
      this.ChangeTracker.DetectChanges();
      return base.Update(entity);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("cust");
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      base.OnModelCreating(modelBuilder);
    }
  }
}
