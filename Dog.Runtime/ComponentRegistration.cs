namespace Dog.Runtime;

using Dog.Core;
using Dog.Infrastructure.DataStore;
using Dog.Presentation;
using Microsoft.Extensions.Hosting;

/// <summary>
/// Registers all components in the Dog application.
/// </summary>
internal static class ComponentRegistration
{
  /// <summary>
  /// Creates a host builder for the Dog application.
  /// </summary>
  /// <returns>An IHostBuilder configured with all necessary services.</returns>
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