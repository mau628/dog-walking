namespace Dog.Core.Services.Interfaces;

using Dog.Domain.Models;

public interface IClientService
{
  public Client GetClientOrDefault(Guid id);
  public List<Dog> GetDogsByClientId(Guid clientId);
  public void Upsert(Client client);
  public void Delete(Guid id);
}
