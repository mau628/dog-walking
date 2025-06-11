namespace Dog.Infrastructure.DataStore;

using Dog.Domain;
using Dog.Infrastructure.DataStore.Repositories;
using Microsoft.Extensions.DependencyInjection;

public static class DataStoreRegistration
{
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
