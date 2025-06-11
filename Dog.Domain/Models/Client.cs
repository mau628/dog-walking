namespace Dog.Domain.Models;

/// <summary>
/// Represents a client in the dog walking management system.
/// </summary>
public class Client : BaseEntity
{
  /// <summary>
  /// Name of the client.
  /// </summary>
  public string Name { get; set; } = string.Empty;

  /// <summary>
  /// Email address of the client.
  /// </summary>
  public string Email { get; set; } = string.Empty;

  /// <summary>
  /// Phone number of the client.
  /// </summary>
  public string PhoneNumber { get; set; } = string.Empty;

  /// <summary>
  /// Collection of dogs owned by the client.
  /// </summary>
  public virtual ICollection<Dog> Dogs { get; set; } = new List<Dog>();
}
