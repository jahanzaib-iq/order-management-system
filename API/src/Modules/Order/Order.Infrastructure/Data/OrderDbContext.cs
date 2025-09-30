
namespace Order.Infrastructure.Data;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options), IOrderDbContext
{
    DatabaseFacade IOrderDbContext.Database => this.Database;
    
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
        modelBuilder.HasDefaultSchema("order");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}