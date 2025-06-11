namespace Dog.Domain;

public interface IRepository<T> where T : BaseEntity
{
  T Add(T entity);
  T Edit(T entity);
  void Delete(T entity);
  T? Find(Guid id);
  IQueryable<T> GetFiltered(Func<T, bool> filter);
}
