using Dog.Domain.Models;
using FluentValidation;

namespace Dog.Core.Validators;

public class ClientValidator : AbstractValidator<Client>
{
  public ClientValidator()
  {
    RuleFor(client => client.Name)
      .NotEmpty().WithMessage("Name is required.")
      .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

    RuleFor(client => client.Email)
      .EmailAddress().WithMessage("Invalid email format.")
      .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

    RuleFor(client => client.PhoneNumber)
      .Matches(@"^[0-9]{3}(-?)[0-9]{3}(-?)[0-9]{4}$").WithMessage("Invalid phone number format.");
  }
}
