namespace Dog.Presentation;

using System.Diagnostics.CodeAnalysis;
using Dog.Core.Services;
using Dog.Core.Services.Interfaces;
using Dog.Domain;
using Dog.Domain.Models;
using Dog.Presentation.Forms;
using Dog.Presentation.Mock;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Registers all forms in the Dog application.
/// This class scans the assembly for types that implement the IBaseForm interface.
/// </summary>
[ExcludeFromCodeCoverage]
public static class FormsRegistration
{
  /// <summary>
  /// Registers the forms in the service collection.
  /// </summary>
  /// <param name="services">The service collection to add forms to.</param>
  public static void AddPresentation(this IServiceCollection services)
  {
    services.AddForms();
    services.AddMockedServices();
  }

  private static void AddForms(this IServiceCollection services)
  {
    services.AddScoped<IFormFactory, FormFactory>();
    //Add all forms
    var forms = typeof(frmMain).Assembly
      .GetTypes()
      .Where(t =>
        t.IsAssignableTo(typeof(IBaseForm))
        && !t.IsAbstract
        && !t.IsInterface)
      .ToList();

    forms.ForEach(form =>
    {
      services.AddTransient(form);
    });
  }

  private static void AddMockedServices(this IServiceCollection services)
  {
    services.AddScoped<IRepository<User>, UserRepository>();
    services.AddScoped<IDataService<User>, DataService<User>>();
  }

}
