namespace Dog.Tests;

using System;
using Dog.Core.Validators;
using Dog.Domain.Models;
using FakeItEasy;
using FluentValidation;
using FluentValidation.Results;
using NUnit.Framework;

[TestFixture]
public class DogValidatorTest
{
  private DogValidator _validator;

  [SetUp]
  public void SetUp()
  {
    _validator = new DogValidator();
  }

  [Test]
  public void Validate_AllFieldsValid_ReturnsSuccess()
  {
    var owner = new Client
    {
      Name = "John Doe",
      Email = "john@email.com",
      PhoneNumber = "1234567890",
      CreatedAt = DateTime.Now,
      Id = Guid.NewGuid()
    };

    var dog = new Dog
    {
      Name = "Buddy",
      Breed = "Labrador",
      DateOfBirth = DateTime.Now.AddYears(-2),
      Owner = owner
    };

    var result = _validator.Validate(dog);

    Assert.IsTrue(result.IsValid);
  }

  [Test]
  public void Validate_NameIsEmpty_ReturnsFailure()
  {
    var dog = new Dog
    {
      Name = "",
      Breed = "Labrador",
      DateOfBirth = DateTime.Now.AddYears(-2),
      Owner = A.Fake<Client>()
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Name is required")));
  }

  [Test]
  public void Validate_NameTooLong_ReturnsFailure()
  {
    var dog = new Dog
    {
      Name = new string('A', 101),
      Breed = "Labrador",
      DateOfBirth = DateTime.Now.AddYears(-2),
      Owner = A.Fake<Client>()
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Name cannot exceed 100 characters")));
  }

  [Test]
  public void Validate_BreedIsEmpty_ReturnsFailure()
  {
    var dog = new Dog
    {
      Name = "Buddy",
      Breed = "",
      DateOfBirth = DateTime.Now.AddYears(-2),
      Owner = A.Fake<Client>()
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Breed is required")));
  }

  [Test]
  public void Validate_BreedTooLong_ReturnsFailure()
  {
    var dog = new Dog
    {
      Name = "Buddy",
      Breed = new string('B', 51),
      DateOfBirth = DateTime.Now.AddYears(-2),
      Owner = A.Fake<Client>()
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Breed cannot exceed 50 characters")));
  }

  [Test]
  public void Validate_DateOfBirthIsDefault_ReturnsFailure()
  {
    var dog = new Dog
    {
      Name = "Buddy",
      Breed = "Labrador",
      DateOfBirth = default,
      Owner = A.Fake<Client>()
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Date of Birth is required")));
  }

  [Test]
  public void Validate_DateOfBirthInFuture_ReturnsFailure()
  {
    var dog = new Dog
    {
      Name = "Buddy",
      Breed = "Labrador",
      DateOfBirth = DateTime.Now.AddDays(1),
      Owner = A.Fake<Client>()
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Date of Birth cannot be in the future")));
  }

  [Test]
  public void Validate_OwnerIsNull_ReturnsFailure()
  {
    var dog = new Dog
    {
      Name = "Buddy",
      Breed = "Labrador",
      DateOfBirth = DateTime.Now.AddYears(-2),
      Owner = null
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Owner is required")));
  }

  [Test]
  public void Validate_OwnerIsInvalid_ReturnsFailure()
  {
    // Arrange: Use a real ClientValidator that will fail (simulate invalid client)
    var invalidClient = new Client { Name = "" }; // Assuming ClientValidator requires Name
    var dog = new Dog
    {
      Name = "Buddy",
      Breed = "Labrador",
      DateOfBirth = DateTime.Now.AddYears(-2),
      Owner = invalidClient
    };

    var validator = new DogValidator();
    var result = validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.PropertyName.Contains("Owner")));
  }

  [Test]
  public void Validate_MultipleFailures_AllErrorsReturned()
  {
    var dog = new Dog
    {
      Name = "",
      Breed = "",
      DateOfBirth = DateTime.Now.AddDays(1),
      Owner = null
    };

    var result = _validator.Validate(dog);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Name is required")));
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Breed is required")));
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Date of Birth cannot be in the future")));
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Owner is required")));
  }

  [Test]
  public void Validate_DateOfBirthIsExactlyNow_ReturnsSuccess()
  {
    var owner = new Client
    {
      Name = "John Doe",
      Email = "john@email.com",
      PhoneNumber = "1234567890",
      CreatedAt = DateTime.Now,
      Id = Guid.NewGuid()
    };

    var dog = new Dog
    {
      Name = "Buddy",
      Breed = "Labrador",
      DateOfBirth = DateTime.Now.Date,
      Owner = owner
    };

    var result = _validator.Validate(dog);

    Assert.IsTrue(result.IsValid);
  }
}
