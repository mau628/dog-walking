namespace Dog.Presentation;

using Dog.Domain;
using Dog.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Registers all forms in the Dog application.
/// This class scans the assembly for types that implement the IBaseForm interface.
/// </summary>
public static class FormsRegistration
{
  /// <summary>
  /// Registers the forms in the service collection.
  /// </summary>
  /// <param name="services">The service collection to add forms to.</param>
  public static void AddForms(this IServiceCollection services)
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
}
