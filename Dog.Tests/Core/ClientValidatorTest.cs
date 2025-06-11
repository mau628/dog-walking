namespace Dog.Tests.Core;

using Dog.Core.Validators;
using Dog.Domain.Models;
using FluentValidation.TestHelper;
using NUnit.Framework;

[TestFixture]
public class ClientValidatorTest
{
  private ClientValidator _validator;

  [SetUp]
  public void SetUp()
  {
    _validator = new ClientValidator();
  }

  [Test]
  public void Should_Pass_Validation_For_Valid_Client()
  {
    var client = new Client
    {
      Name = "John Doe",
      Email = "john.doe@example.com",
      PhoneNumber = "123-456-7890"
    };

    var result = _validator.TestValidate(client);

    result.ShouldNotHaveAnyValidationErrors();
  }

  [Test]
  public void Should_Fail_When_Name_Is_Empty()
  {
    var client = new Client
    {
      Name = "",
      Email = "john.doe@example.com",
      PhoneNumber = "123-456-7890"
    };

    var result = _validator.TestValidate(client);

    result.ShouldHaveValidationErrorFor(c => c.Name)
        .WithErrorMessage("Name is required.");
  }

  [Test]
  public void Should_Fail_When_Name_Exceeds_Max_Length()
  {
    var client = new Client
    {
      Name = new string('a', 101),
      Email = "john.doe@example.com",
      PhoneNumber = "123-456-7890"
    };

    var result = _validator.TestValidate(client);

    result.ShouldHaveValidationErrorFor(c => c.Name)
        .WithErrorMessage("Name cannot exceed 100 characters.");
  }

  [Test]
  public void Should_Fail_When_Email_Is_Invalid_Format()
  {
    var client = new Client
    {
      Name = "John Doe",
      Email = "not-an-email",
      PhoneNumber = "123-456-7890"
    };

    var result = _validator.TestValidate(client);

    result.ShouldHaveValidationErrorFor(c => c.Email)
        .WithErrorMessage("Invalid email format.");
  }

  [Test]
  public void Should_Fail_When_Email_Exceeds_Max_Length()
  {
    var client = new Client
    {
      Name = "John Doe",
      Email = new string('a', 101) + "@example.com",
      PhoneNumber = "123-456-7890"
    };

    var result = _validator.TestValidate(client);

    result.ShouldHaveValidationErrorFor(c => c.Email)
        .WithErrorMessage("Email cannot exceed 100 characters.");
  }

  [TestCase("1234567890")]
  [TestCase("123-456-7890")]
  [TestCase("123456-7890")]
  [TestCase("123-4567890")]
  public void Should_Pass_For_Valid_PhoneNumber_Formats(string phoneNumber)
  {
    var client = new Client
    {
      Name = "John Doe",
      Email = "john.doe@example.com",
      PhoneNumber = phoneNumber
    };

    var result = _validator.TestValidate(client);

    result.ShouldNotHaveValidationErrorFor(c => c.PhoneNumber);
  }

  [TestCase("123-45-67890")]
  [TestCase("12-3456-7890")]
  [TestCase("abc-def-ghij")]
  [TestCase("123456789")]
  [TestCase("12345678901")]
  [TestCase("")]
  public void Should_Fail_For_Invalid_PhoneNumber_Formats(string? phoneNumber)
  {
    var client = new Client
    {
      Name = "John Doe",
      Email = "john.doe@example.com",
      PhoneNumber = phoneNumber
    };

    var result = _validator.TestValidate(client);

    result.ShouldHaveValidationErrorFor(c => c.PhoneNumber)
        .WithErrorMessage("Invalid phone number format.");
  }

  [Test]
  public void Should_Fail_Multiple_Fields()
  {
    var client = new Client
    {
      Name = "",
      Email = "invalid-email",
      PhoneNumber = "invalid"
    };

    var result = _validator.TestValidate(client);

    result.ShouldHaveValidationErrorFor(c => c.Name);
    result.ShouldHaveValidationErrorFor(c => c.Email);
    result.ShouldHaveValidationErrorFor(c => c.PhoneNumber);
  }
}
