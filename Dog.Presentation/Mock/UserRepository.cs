namespace Dog.Presentation.Mock;

using System;
using System.Linq;
using Dog.Domain.Models;

/// <summary>
/// Mock repository for managing User entities in the dog walking management system.
/// This repository is used for testing purposes and does not implement all methods.
/// It provides basic functionality to add and filter users with an in-memory list.
/// </summary>
public class UserRepository : Domain.IRepository<User>
{
  private readonly List<User> _users = new List<User>();
  public User Add(User entity)
  {
    if (entity == null)
    {
      throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
    }

    entity.Id = Guid.NewGuid();
    entity.CreatedAt = DateTime.Now;
    _users.Add(entity);
    return entity;
  }

  public User Edit(User entity)
  {
    throw new NotImplementedException("This method is not implemented in the mock repository.");
  }

  public void Delete(User entity)
  {
    throw new NotImplementedException("This method is not implemented in the mock repository.");
  }

  public User? Find(Guid id)
  {
    throw new NotImplementedException("This method is not implemented in the mock repository.");
  }

  public IQueryable<User> GetFiltered(Func<User, bool> filter)
  {
    if (filter == null)
    {
      throw new ArgumentNullException(nameof(filter), "Filter cannot be null");
    }

    return _users.AsQueryable().Where(filter).AsQueryable();
  }

}
