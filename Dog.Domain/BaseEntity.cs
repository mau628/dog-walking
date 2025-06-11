namespace Dog.Domain;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Base class for all entities in the dog walking management system.
/// </summary>
public abstract class BaseEntity
{
  /// <summary>
  /// Unique identifier for the entity.
  /// </summary>
  [Key]
  public Guid Id { get; set; }

  /// <summary>
  /// Date and time when the entity was created.
  /// </summary>
  public DateTime CreatedAt { get; set; }
}
