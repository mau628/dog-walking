namespace Dog.Runtime;

using System.Linq;
using Dog.Domain;
using Dog.Infrastructure.DataStore;
using Dog.Presentation.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal static class ComponentRegistration
{
  public static IHostBuilder CreateHostBuilder()
  {
    return Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
          services.AddScoped<IFormFactory, FormFactory>();
          services.AddDataStore();

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
        });
  }

}