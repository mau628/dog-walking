namespace Dog.Core.Services;

using Dog.Core.Services.Interfaces;
using Dog.Domain;
using FluentValidation;

public class DataService<T> : IDataService<T> where T : BaseEntity, new()
{
  private readonly IRepository<T> _repository;
  private readonly IValidator<T> _validator;

  public DataService(
    IRepository<T> repository,
    IValidator<T> validator
  )
  {
    _repository = repository;
    _validator = validator;
  }

  public T GetEntityOrDefault(Guid id)
  {
    if (id == default)
    {
      return new T();
    }
    return _repository.Find(id) ?? new T();
  }

  public T Upsert(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
    }

    var validationResult = _validator.Validate(entity);
    if (!validationResult.IsValid)
    {
      throw new ValidationException(validationResult.Errors);
    }

    T result;
    if (entity.Id != default)
    {
      result = _repository.Edit(entity);
    }
    else
    {
      result = _repository.Add(entity);
    }

    return result;
  }

  public void Delete(Guid id)
  {
    if (id == default)
    {
      throw new ArgumentException("ID cannot be default value.", nameof(id));
    }

    var entity = _repository.Find(id);
    if (entity != null)
    {
      _repository.Delete(entity);
    }
  }

  public IEnumerable<T> GetFiltered(Func<T, bool> filter)
  {
    if (filter == null)
    {
      throw new ArgumentNullException(nameof(filter), "Filter cannot be null.");
    }

    var result = _repository.GetFiltered(filter).AsQueryable();
    return result;
  }
}
