namespace Dog.Presentation;

using Dog.Domain;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Factory for creating forms in the Dog application.
/// </summary>
public class FormFactory : IFormFactory
{
  private readonly IServiceScope _scope;

  public FormFactory(IServiceScopeFactory scopeFactory)
  {
    _scope = scopeFactory.CreateScope();
  }

  /// <summary>
  /// Creates a form of type T that implements IBaseForm.
  /// </summary>
  /// <typeparam name="T">Type of the form to create, must implement IBaseForm.</typeparam>
  /// <returns>An instance of the form type T, or null if not registered.</returns>
  public T? Create<T>() where T : IBaseForm
  {
    return _scope.ServiceProvider.GetService<T>();
  }
}