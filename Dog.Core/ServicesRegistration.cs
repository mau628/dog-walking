namespace Dog.Core;

using Dog.Core.Services;
using Dog.Core.Services.Interfaces;
using Dog.Core.Validators;
using Dog.Domain;
using Dog.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class ServicesRegistration
{
  public static void AddDogServices(this IServiceCollection services)
  {
    services.AddDataServices();
    services.AddValidators();
  }

  private static void AddDataServices(this IServiceCollection services)
  {
    services.AddDataService<Client>();
    services.AddDataService<Dog>();
    services.AddDataService<Walk>();
  }

  private static void AddDataService<T>(this IServiceCollection services) where T : BaseEntity, new()
  {
    services.AddScoped<IDataService<T>, DataService<T>>();
  }

  private static void AddValidators(this IServiceCollection services)
  {
    services.AddScoped<IValidator<Client>, ClientValidator>();
    services.AddScoped<IValidator<Dog>, DogValidator>();
    services.AddScoped<IValidator<Walk>, WalkValidator>();
  }
}
