namespace Dog.Core.Services.Interfaces;

using System;
using Dog.Domain;

/// <summary>
/// IDataService interface for managing entities of type T.
/// </summary>
/// <typeparam name="T">Type of the entity, must inherit from BaseEntity.</typeparam>
public interface IDataService<T> where T : BaseEntity, new()
{
  /// <summary>
  /// Retrieves an entity by its ID.
  /// </summary>
  /// <param name="id">The unique identifier of the entity.</param>
  /// <returns>The entity if found; otherwise, null.</returns>
  public T GetEntityOrDefault(Guid id);

  /// <summary>
  /// Upserts an entity, either inserting a new one or updating an existing one.
  /// </summary>
  /// <param name="client">The entity to upsert.</param>
  /// <returns>The upserted entity.</returns>
  public T Upsert(T client);

  /// <summary>
  /// Deletes an entity by its ID.
  /// </summary>
  /// <param name="id">The unique identifier of the entity to delete.</param>
  public void Delete(Guid id);

  /// <summary>
  /// Retrieves all entities of type T using a filter function.
  /// </summary>
  /// <param name="filter">Filter function to apply to the entities.</param>
  /// <returns>An enumerable collection of entities of type T.</returns>
  public IEnumerable<T> GetFiltered(Func<T, bool> filter);
}
