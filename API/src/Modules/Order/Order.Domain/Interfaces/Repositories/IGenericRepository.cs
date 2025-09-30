using System.Linq.Expressions;
using Domain.Shared;

namespace Order.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IQueryable<T>> Table(Expression<Func<T, bool>> predicate);
    Task<List<T>> ToListAsync();
    Task<T> GetById(Guid id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
    Task<int> SaveChangesAsync();
}