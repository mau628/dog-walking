namespace Dog.Core;

using Dog.Core.Services;
using Dog.Core.Services.Interfaces;
using Dog.Core.Validators;
using Dog.Domain.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class ServicesRegistration
{
  public static void AddDogServices(this IServiceCollection services)
  {
    services.AddScoped<IClientService, ClientService>();
    services.AddValidators();
  }

  private static void AddValidators(this IServiceCollection services)
  {
    services.AddScoped<IValidator<Client>, ClientValidator>();
  }
}
