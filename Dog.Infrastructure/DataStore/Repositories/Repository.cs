using Microsoft.EntityFrameworkCore;

namespace Dog.Infrastructure.DataStore.Repositories;

internal class Repository<T> : Domain.IRepository<T> where T : Domain.BaseEntity
{
  private readonly DogContext _context;
  public Repository(DogContext context)
  {
    _context = context;
  }

  public T Add(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }
    entity.Id = new Guid();
    entity.CreatedAt = DateTime.UtcNow;

    var result = _context.Set<T>().Add(entity);
    _context.SaveChanges();
    return result.Entity;
  }

  public T Edit(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }

    var result = _context.Set<T>().Update(entity);
    _context.SaveChanges();
    return result.Entity;
  }

  public void Delete(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }

    _context.Set<T>().Remove(entity);
    _context.SaveChanges();
  }

  public T? Find(Guid id)
  {
    if (id == default)
    {
      return null;
    }

    return _context.Set<T>().Find(id);
  }

  public IQueryable<T> GetFiltered(Func<T, bool> filter)
  {
    return _context.Set<T>().AsNoTracking().Where(filter).AsQueryable();
  }

}
