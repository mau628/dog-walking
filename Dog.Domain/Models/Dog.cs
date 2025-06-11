namespace Dog.Domain.Models;

/// <summary>
/// Represents a dog in the dog walking management system.
/// </summary>
public class Dog : BaseEntity
{
  /// <summary>
  /// Name of the dog.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Breed of the dog.
  /// </summary>
  public string Breed { get; set; } = string.Empty;

  /// <summary>
  /// Date of birth of the dog.
  /// </summary>
  public DateTime DateOfBirth { get; set; } = DateTime.Now.Date;

  /// <summary>
  /// Owner of the dog. References to Client entity.
  /// </summary>
  public virtual Client Owner { get; set; } = new Client();

  /// <summary>
  /// Collection of walks associated with the dog.
  /// </summary>
  public virtual ICollection<Walk> Walks { get; set; } = new List<Walk>();
}
