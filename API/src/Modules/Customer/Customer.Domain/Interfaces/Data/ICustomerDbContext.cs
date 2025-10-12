namespace Customer.Domain.Interfaces.Data;

public interface ICustomerDbContext
{
  DbSet<T> Set<T>() where T : BaseEntity;

  Task<int> SaveChangesAsync();

  EntityEntry Entry(object entity);

  DatabaseFacade Database { get; }
}
