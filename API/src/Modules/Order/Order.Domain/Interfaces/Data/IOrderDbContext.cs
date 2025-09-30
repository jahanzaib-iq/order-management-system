
namespace Order.Domain.Interfaces.Data;

public interface IOrderDbContext
{
    DbSet<T> Set<T>() where T : BaseEntity;
    
    Task<int> SaveChangesAsync();
    
    EntityEntry Entry(object entity);
    
    DatabaseFacade Database { get; }
}