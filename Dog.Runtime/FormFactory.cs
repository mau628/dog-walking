namespace Dog.Runtime;

using Dog.Domain;
using Microsoft.Extensions.DependencyInjection;

public class FormFactory : IFormFactory
{
  private readonly IServiceScope _scope;

  public FormFactory(IServiceScopeFactory scopeFactory)
  {
    _scope = scopeFactory.CreateScope();
  }

  public T? Create<T>() where T : IBaseForm
  {
    return _scope.ServiceProvider.GetService<T>();
  }
}