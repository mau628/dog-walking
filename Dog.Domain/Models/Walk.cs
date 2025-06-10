namespace Dog.Domain.Models;

public class Walk : BaseEntity
{
  public DateTime Date { get; set; }
  public TimeSpan Duration { get; set; }
  public virtual Dog Dog { get; set; } = new Dog();
  public string Notes { get; set; } = string.Empty;
}
