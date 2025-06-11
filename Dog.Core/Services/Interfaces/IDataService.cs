namespace Dog.Core.Services.Interfaces;

using System;
using Dog.Domain;

public interface IDataService<T> where T : BaseEntity, new()
{
  public T GetEntityOrDefault(Guid id);
  public T Upsert(T client);
  public void Delete(Guid id);
  public IEnumerable<T> GetFiltered(Func<T, bool> filter);
}
