using Dog.Domain;
using Dog.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Dog.Presentation
{
  public static class FormsRegistration
  {
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
}
