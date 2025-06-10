namespace Dog.Domain;

using System.ComponentModel.DataAnnotations;

public abstract class BaseEntity
{
  [Key]
  public Guid Id { get; set; }
  public DateTime CreatedAt { get; set; }
}
