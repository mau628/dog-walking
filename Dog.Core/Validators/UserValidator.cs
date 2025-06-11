namespace Dog.Core.Validators;
using Dog.Domain.Models;
using FluentValidation;

public class UserValidator : AbstractValidator<User>
{
  public UserValidator()
  {
    RuleFor(user => user.Username)
      .NotEmpty().WithMessage("Username is required.")
      .MinimumLength(1).WithMessage("Username must be at least 1 character long.")
      .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.");

    RuleFor(user => user.Password)
      .NotEmpty().WithMessage("Password is required.")
      .MinimumLength(1).WithMessage("Password must be at least 1 characters long.")
      .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.");
  }
}
