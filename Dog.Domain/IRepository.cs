namespace Dog.Domain;

public interface IRepository<TEntity>
      where TEntity : BaseEntity
{
  void Add(TEntity entity);
  void Edit(TEntity entity);
  void Delete(TEntity entity);
  TEntity? Find(Guid id);
  IQueryable<TEntity> Filter(Func<TEntity, bool> filter);
  IQueryable<TEntity> GetAll();
}
