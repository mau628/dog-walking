using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;
using FluentValidation;

namespace Dog.Core.Services;
public class ClientService : IClientService
{
  private readonly IRepository<Client> _clientRepository;
  private readonly IRepository<Domain.Models.Dog> _dogRepository;
  private IValidator<Client> _validator;

  public ClientService(
    IRepository<Client> clientRepository,
    IRepository<Domain.Models.Dog> dogRepository,
    IValidator<Client> validator
  )
  {
    _clientRepository = clientRepository;
    _dogRepository = dogRepository;
    _validator = validator;
  }

  public Client? GetClientOrDefault(Guid id)
  {
    return _clientRepository.Find(id) ?? new Client();
  }

  public List<Domain.Models.Dog> GetDogsByClientId(Guid clientId)
  {
    return _dogRepository
      .Filter(c => c.Owner.Id == clientId)
      .ToList();
  }

  public void Upsert(Client client)
  {
    if (client == null)
    {
      throw new ArgumentNullException(nameof(client), "Client cannot be null.");
    }
    var validationResult = _validator.Validate(client);
    if (!validationResult.IsValid)
    {
      throw new ValidationException(validationResult.Errors);
    }
    if (client.Id != default)
    {
      _clientRepository.Edit(client);
    }
    else
    {
      _clientRepository.Add(client);
    }
  }

  public void Delete(Guid id)
  {
    var client = _clientRepository.Find(id);
    if (client != null)
    {
      _clientRepository.Delete(client);
    }
  }
}
