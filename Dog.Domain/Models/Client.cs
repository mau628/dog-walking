namespace Dog.Domain.Models;

public class Client : BaseEntity
{
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string PhoneNumber { get; set; } = string.Empty;
  public ICollection<Dog> Dogs { get; set; } = new List<Dog>();
}
