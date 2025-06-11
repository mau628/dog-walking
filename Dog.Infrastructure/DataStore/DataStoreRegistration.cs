namespace Dog.Infrastructure.DataStore;

using Dog.Domain;
using Dog.Infrastructure.DataStore.Repositories;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Registers the data store and its repositories.
/// </summary>
public static class DataStoreRegistration
{
  /// <summary>
  /// Registers the data store and its repositories in the service collection.
  /// </summary>
  /// <param name="services">The service collection to add services to.</param>
  public static void AddDataStore(this IServiceCollection services)
  {
    services.AddDbContext<DogContext>();
    services.AddRepository<Domain.Models.Client>();
    services.AddRepository<Domain.Models.Dog>();
    services.AddRepository<Domain.Models.Walk>();
  }

  private static void AddRepository<T>(this IServiceCollection services) where T : BaseEntity
  {
    services.AddScoped<IRepository<T>, Repository<T>>();
  }
}
