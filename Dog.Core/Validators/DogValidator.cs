namespace Dog.Core.Validators;

using Dog.Domain.Models;
using FluentValidation;

/// <summary>
/// Validator for the Dog model.
/// </summary>
public class DogValidator : AbstractValidator<Dog>
{
  public DogValidator()
  {
    RuleFor(dog => dog.Name)
      .NotEmpty().WithMessage("Name is required.")
      .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

    RuleFor(dog => dog.Breed)
      .NotEmpty().WithMessage("Breed is required.")
      .MaximumLength(50).WithMessage("Breed cannot exceed 50 characters.");

    RuleFor(dog => dog.DateOfBirth)
      .NotEmpty().WithMessage("Date of Birth is required.")
      .LessThanOrEqualTo(DateTime.Now).WithMessage("Date of Birth cannot be in the future.");

    RuleFor(dog => dog.Owner)
      .NotNull().WithMessage("Owner is required.")
      .SetValidator(new ClientValidator());
  }
}
