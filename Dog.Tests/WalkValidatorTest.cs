namespace Dog.Tests;

using System;
using Dog.Core.Validators;
using Dog.Domain.Models;
using FakeItEasy;
using FluentValidation.Results;
using NUnit.Framework;

[TestFixture]
public class WalkValidatorTest
{
  private WalkValidator _validator;

  [SetUp]
  public void SetUp()
  {
    _validator = new WalkValidator();
  }

  [Test]
  public void Validate_AllFieldsValid_ReturnsSuccess()
  {
    var walk = new Walk
    {
      Dog = A.Fake<Dog>(),
      Date = DateTime.Now.Date,
      DurationInMinutes = 30
    };

    var result = _validator.Validate(walk);

    Assert.IsTrue(result.IsValid);
  }

  [Test]
  public void Validate_DogIsNull_ReturnsFailure()
  {
    var walk = new Walk
    {
      Dog = null,
      Date = DateTime.Now,
      DurationInMinutes = 30
    };

    var result = _validator.Validate(walk);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Dog must be selected")));
  }

  [Test]
  public void Validate_DateIsDefault_ReturnsFailure()
  {
    var walk = new Walk
    {
      Dog = A.Fake<Dog>(),
      Date = default,
      DurationInMinutes = 30
    };

    var result = _validator.Validate(walk);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Walk date cannot be empty")));
  }

  [Test]
  public void Validate_DateIsInFuture_ReturnsFailure()
  {
    var walk = new Walk
    {
      Dog = A.Fake<Dog>(),
      Date = DateTime.Now.AddMinutes(1),
      DurationInMinutes = 30
    };

    var result = _validator.Validate(walk);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Walk date cannot be in the future")));
  }

  [Test]
  public void Validate_DurationIsZero_ReturnsFailure()
  {
    var walk = new Walk
    {
      Dog = A.Fake<Dog>(),
      Date = DateTime.Now,
      DurationInMinutes = 0
    };

    var result = _validator.Validate(walk);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Walk duration must be greater than zero")));
  }

  [Test]
  public void Validate_DurationIsNegative_ReturnsFailure()
  {
    var walk = new Walk
    {
      Dog = A.Fake<Dog>(),
      Date = DateTime.Now,
      DurationInMinutes = -10
    };

    var result = _validator.Validate(walk);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Walk duration must be greater than zero")));
  }

  [Test]
  public void Validate_DateIsExactlyNow_ReturnsSuccess()
  {
    var walk = new Walk
    {
      Dog = A.Fake<Dog>(),
      Date = DateTime.Now.Date,
      DurationInMinutes = 1
    };

    var result = _validator.Validate(walk);

    Assert.IsTrue(result.IsValid);
  }

  [Test]
  public void Validate_MinimumPositiveDuration_ReturnsSuccess()
  {
    var walk = new Walk
    {
      Dog = A.Fake<Dog>(),
      Date = DateTime.Now.Date,
      DurationInMinutes = 1
    };

    var result = _validator.Validate(walk);

    Assert.IsTrue(result.IsValid);
  }

  [Test]
  public void Validate_MultipleFailures_AllErrorsReturned()
  {
    var walk = new Walk
    {
      Dog = null,
      Date = DateTime.Now.AddDays(1),
      DurationInMinutes = 0
    };

    var result = _validator.Validate(walk);

    Assert.IsFalse(result.IsValid);
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Dog must be selected")));
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Walk date cannot be in the future")));
    Assert.That(result.Errors, Has.Some.Matches<ValidationFailure>(e => e.ErrorMessage.Contains("Walk duration must be greater than zero")));
  }
}
