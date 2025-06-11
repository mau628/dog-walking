namespace Dog.Domain;

/// <summary>
/// Generic repository interface for managing entities in the dog walking management system.
/// </summary>
/// <typeparam name="T">Type of the entity, must inherit from BaseEntity.</typeparam>
public interface IRepository<T> where T : BaseEntity
{
  /// <summary>
  /// Adds a new entity to the repository.
  /// </summary>
  /// <param name="entity">The entity to add.</param>
  /// <returns>Returns the added entity with its Id set.</returns>
  T Add(T entity);

  /// <summary>
  /// Edits an existing entity in the repository.
  /// </summary>
  /// <param name="entity">The entity to edit, must have a valid Id.</param>
  /// <returns>Returns the edited entity.</returns>
  T Edit(T entity);

  /// <summary>
  /// Deletes an entity from the repository.
  /// </summary>
  /// <param name="entity">The entity to delete, must have a valid Id.</param>
  void Delete(T entity);

  /// <summary>
  /// Finds an entity by its unique identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the entity to find.</param>
  /// <returns>Returns the found entity, or null if not found.</returns>
  T? Find(Guid id);

  /// <summary>
  /// Retrieves all entities from the repository.
  /// </summary>
  /// <param name="filter">Filter function to apply to the entities.</param>
  /// <returns>Returns an IQueryable collection of entities that match the filter.</returns>
  IQueryable<T> GetFiltered(Func<T, bool> filter);
}
