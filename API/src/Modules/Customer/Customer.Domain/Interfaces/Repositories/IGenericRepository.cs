using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Domain.Interfaces.Repositories
{
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
}
