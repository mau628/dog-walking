namespace Dog.Presentation;

using System.Linq;
using Dog.Domain;
using Dog.Infrastructure.DataStore;
using Dog.Infrastructure.DataStore.Repositories;
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
          var forms = typeof(Program).Assembly
            .GetTypes()
            .Where(t =>
              t.BaseType == typeof(Form)
              && t.IsAssignableTo(typeof(IBaseForm))
              && !t.IsAbstract
              && !t.IsInterface)
            .ToList();

          forms.ForEach(form =>
          {
            services.AddTransient(form);
          });
        });
  }

  private static void AddDataStore(this IServiceCollection services)
  {
    services.AddDbContext<DogContext>();
    services.AddRepository<Domain.Models.Dog>();
    services.AddRepository<Domain.Models.Client>();
    services.AddRepository<Domain.Models.Walk>();
  }

  private static void AddRepository<T>(this IServiceCollection services) where T : BaseEntity
  {
    services.AddScoped<IRepository<T>, Repository<T>>();
  }
}
