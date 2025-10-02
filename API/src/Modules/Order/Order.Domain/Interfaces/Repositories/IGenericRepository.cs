using System.Linq.Expressions;
using Domain.Shared;

namespace Order.Domain.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IQueryable<T>> Table(Expression<Func<T, bool>> predicate);
    Task<List<T>> ToListAsync();
    Task<T> GetById(object id);
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<int> SaveChangesAsync();
}
