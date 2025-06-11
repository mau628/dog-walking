namespace Dog.Domain.Models;

/// <summary>
/// Represents a walk in the dog walking management system.
/// </summary>
public class Walk : BaseEntity
{
  /// <summary>
  /// Date of the walk.
  /// </summary>
  public DateTime Date { get; set; } = DateTime.Now.Date;

  /// <summary>
  /// Duration of the walk in minutes.
  /// </summary>
  public int DurationInMinutes { get; set; }

  /// <summary>
  /// Dog that was walked. References to Dog entity.
  /// </summary>
  public virtual Dog Dog { get; set; } = new Dog();

  /// <summary>
  /// Notes or comments about the walk.
  /// </summary>
  public string Notes { get; set; } = string.Empty;
}
