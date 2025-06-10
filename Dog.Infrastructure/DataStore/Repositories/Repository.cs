namespace Dog.Infrastructure.DataStore.Repositories;

internal class Repository<TEntity> : Domain.IRepository<TEntity> where TEntity : Domain.BaseEntity
{
  private readonly DogContext _context;
  public Repository(DogContext context)
  {
    _context = context;
  }

  public void Add(TEntity entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }
    entity.Id = new Guid();
    entity.CreatedAt = DateTime.UtcNow;

    _context.Set<TEntity>().Add(entity);
    _context.SaveChanges();
  }

  public void Edit(TEntity entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }

    _context.Set<TEntity>().Update(entity);
    _context.SaveChanges();
  }

  public void Delete(TEntity entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }

    _context.Set<TEntity>().Remove(entity);
    _context.SaveChanges();
  }

  public TEntity? Find(Guid id)
  {
    if (id == default)
    {
      return null;
    }

    return _context.Set<TEntity>().Find(id);
  }

  public IQueryable<TEntity> Filter(Func<TEntity, bool> filter)
  {
    return _context.Set<TEntity>().Where(filter).AsQueryable();
  }

  public IQueryable<TEntity> GetAll()
  {
    return _context.Set<TEntity>().AsQueryable();
  }
}
