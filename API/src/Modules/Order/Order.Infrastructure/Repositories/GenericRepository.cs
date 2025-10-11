
namespace Order.Infrastructure.Repositories;

public class GenericRepository<T>(IOrderDbContext context) : IGenericRepository<T>
    where T : BaseEntity
{

  protected readonly DbSet<T> dbEntities = context.Set<T>();

  private readonly IOrderDbContext context = context;


  public Task<IQueryable<T>> Table(Expression<Func<T, bool>> predicate) => Task.FromResult(dbEntities.Where(predicate).AsQueryable());

  public async Task<List<T>> ToListAsync() => await dbEntities.ToListAsync();

  public async Task<T?> GetById(object id) => await dbEntities.FindAsync(id);

  public Task Insert(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(Convert.ToString(nameof(T)));
    }

    return InsertEntity(entity);
  }

  private async Task InsertEntity(T entity)
  {
    await this.dbEntities.AddAsync(entity);
    await this.SaveChangesAsync();
  }

  public Task Update(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(T).ToString());
    }

    return this.UpdateEntity(entity);
  }

  private async Task UpdateEntity(T entity)
  {
    dbEntities.Attach(entity);
    this.context.Entry(entity).State = EntityState.Modified;
    await this.SaveChangesAsync();
    await Task.FromResult(default(T));
  }

  public Task Delete(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(T).ToString());
    }

    return this.DeleteEntity(entity);
  }

  private async Task DeleteEntity(T entity)
  {
    dbEntities.Attach(entity);
    this.context.Entry(entity).State = EntityState.Deleted;
    await this.SaveChangesAsync();
    await Task.FromResult(default(T));
  }

  public Task<int> SaveChangesAsync()
  {
    throw new NotImplementedException();
  }
}
