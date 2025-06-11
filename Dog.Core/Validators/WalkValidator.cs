namespace Dog.Core.Validators;

using Dog.Domain.Models;
using FluentValidation;

public class WalkValidator : AbstractValidator<Walk>
{
  public WalkValidator()
  {
    RuleFor(w => w.Dog)
      .NotNull()
      .WithMessage("Dog must be selected for the walk.");

    RuleFor(w => w.Date)
      .NotEmpty()
      .WithMessage("Walk date cannot be empty.")
      .LessThanOrEqualTo(DateTime.Now)
      .WithMessage("Walk date cannot be in the future.");

    RuleFor(w => w.DurationInMinutes)
      .GreaterThan(0)
      .WithMessage("Walk duration must be greater than zero.");
  }
}
