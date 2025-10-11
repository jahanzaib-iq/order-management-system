
using Customer.Domain.Entities.Identity;
using Customer.Domain.Interfaces.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Customer.Infrastructure.Data;

public class CustomerDbContext(DbContextOptions<CustomerDbContext> options)
  : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options), ICustomerDbContext
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
    modelBuilder.Entity<ApplicationUser>(b =>
    {
      b.HasMany(e => e.UserRoles)
          .WithOne(e => e.User)
          .HasForeignKey(ur => ur.UserId)
          .IsRequired();
    });

    modelBuilder.Entity<ApplicationRole>(b =>
    {
      b.HasMany(e => e.UserRoles)
          .WithOne(e => e.Role)
          .HasForeignKey(ur => ur.RoleId)
          .IsRequired();
    });
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    base.OnModelCreating(modelBuilder);
  }
}
