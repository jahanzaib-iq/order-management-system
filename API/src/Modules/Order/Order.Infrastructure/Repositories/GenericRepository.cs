
namespace Order.Infrastructure.Repositories;

public class GenericRepository<T>(IOrderDbContext context) : IGenericRepository<T> 
    where T: BaseEntity
{
    protected readonly DbSet<T> Entities = context.Set<T>();
    
    
    public Task<IQueryable<T>> Table(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ToListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}