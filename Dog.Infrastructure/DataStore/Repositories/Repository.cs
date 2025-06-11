using Microsoft.EntityFrameworkCore;

namespace Dog.Infrastructure.DataStore.Repositories;

/// <summary>
/// Generic repository interface for managing entities in the dog walking management system.
/// </summary>
/// <typeparam name="T">Type of the entity, must inherit from BaseEntity.</typeparam>
public class Repository<T> : Domain.IRepository<T> where T : Domain.BaseEntity
{
  private readonly DogContext _context;
  public Repository(DogContext context)
  {
    _context = context;
  }

  /// <summary>
  /// Adds a new entity to the repository.
  /// </summary>
  /// <param name="entity">The entity to add.</param>
  /// <returns>Returns the added entity with its Id set.</returns>
  public T Add(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }
    entity.Id = new Guid();
    entity.CreatedAt = DateTime.Now;

    var result = _context.Set<T>().Add(entity);
    _context.SaveChanges();
    return result.Entity;
  }

  /// <summary>
  /// Edits an existing entity in the repository.
  /// </summary>
  /// <param name="entity">The entity to edit, must have a valid Id.</param>
  /// <returns>Returns the edited entity.</returns>
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

  /// <summary>
  /// Deletes an entity from the repository.
  /// </summary>
  /// <param name="entity">The entity to delete, must have a valid Id.</param>
  public void Delete(T entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }

    _context.Set<T>().Remove(entity);
    _context.SaveChanges();
  }

  /// <summary>
  /// Finds an entity by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the entity to find.</param>
  /// <returns>Returns the found entity, or null if not found.</returns>
  public T? Find(Guid id)
  {
    if (id == default)
    {
      return null;
    }

    return _context.Set<T>().Find(id);
  }

  /// <summary>
  /// Retrieves all entities from the repository.
  /// </summary>
  /// <param name="filter">Filter function to apply to the entities.</param>
  /// <returns>Returns an IQueryable collection of entities that match the filter.</returns>
  public IQueryable<T> GetFiltered(Func<T, bool> filter)
  {
    return _context.Set<T>().AsNoTracking().Where(filter).AsQueryable();
  }

}
