namespace Dog.Domain.Models;
public class Dog : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public string Breed { get; set; } = string.Empty;
  public DateTime DateOfBirth { get; set; }
  public virtual Client Owner { get; set; } = new Client();
  public ICollection<Walk> Walks { get; set; } = new List<Walk>();
}
