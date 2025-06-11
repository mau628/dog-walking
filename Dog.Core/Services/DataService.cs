namespace Dog.Core.Services;

using Dog.Core.Services.Interfaces;
using Dog.Domain;
using FluentValidation;

/// <summary>
/// IDataService interface for managing entities of type T.
/// </summary>
/// <typeparam name="T">Type of the entity, must inherit from BaseEntity.</typeparam>
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

  /// <summary>
  /// Retrieves an entity by its ID.
  /// </summary>
  /// <param name="id">The unique identifier of the entity.</param>
  /// <returns>The entity if found; otherwise, null.</returns>
  public T GetEntityOrDefault(Guid id)
  {
    if (id == default)
    {
      return new T();
    }
    return _repository.Find(id) ?? new T();
  }

  /// <summary>
  /// Upserts an entity, either inserting a new one or updating an existing one.
  /// </summary>
  /// <param name="client">The entity to upsert.</param>
  /// <returns>The upserted entity.</returns>
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

  /// <summary>
  /// Deletes an entity by its ID.
  /// </summary>
  /// <param name="id">The unique identifier of the entity to delete.</param>
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

  /// <summary>
  /// Retrieves all entities of type T using a filter function.
  /// </summary>
  /// <param name="filter">Filter function to apply to the entities.</param>
  /// <returns>An enumerable collection of entities of type T.</returns>
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
