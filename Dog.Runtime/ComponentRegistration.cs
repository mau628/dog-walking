namespace Dog.Runtime;

using Dog.Core;
using Dog.Infrastructure.DataStore;
using Dog.Presentation;
using Microsoft.Extensions.Hosting;

internal static class ComponentRegistration
{
  public static IHostBuilder CreateHostBuilder()
  {
    return Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
          services.AddDataStore();
          services.AddDogServices();
          services.AddForms();
        });
  }

}