namespace Dog.Presentation;

using System;
using Dog.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

public interface IFormFactory
{
  T? Create<T>() where T : Form, IBaseForm;
}

public class FormFactory : IFormFactory
{
  private readonly IServiceScope _scope;

  public FormFactory(IServiceScopeFactory scopeFactory)
  {
    _scope = scopeFactory.CreateScope();
  }

  public T? Create<T>() where T : Form, IBaseForm
  {
    return _scope.ServiceProvider.GetService<T>();
  }
}