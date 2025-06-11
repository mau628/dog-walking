namespace Dog.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using Dog.Core.Services;
using Dog.Domain;
using FakeItEasy;
using FluentValidation;
using FluentValidation.Results;
using NUnit.Framework;

public class TestEntity : BaseEntity
{
  public string Name { get; set; }
}

[TestFixture]
public class DataServiceTests
{
  private IRepository<TestEntity> _repository;
  private IValidator<TestEntity> _validator;
  private DataService<TestEntity> _service;

  [SetUp]
  public void SetUp()
  {
    _repository = A.Fake<IRepository<TestEntity>>();
    _validator = A.Fake<IValidator<TestEntity>>();
    _service = new DataService<TestEntity>(_repository, _validator);
  }

  [Test]
  public void GetEntityOrDefault_WithDefaultId_ReturnsNewEntity()
  {
    var result = _service.GetEntityOrDefault(default);

    Assert.IsNotNull(result);
    Assert.AreEqual(default(Guid), result.Id);
  }

  [Test]
  public void GetEntityOrDefault_EntityExists_ReturnsEntity()
  {
    var id = Guid.NewGuid();
    var entity = new TestEntity { Id = id, Name = "Test" };
    A.CallTo(() => _repository.Find(id)).Returns(entity);

    var result = _service.GetEntityOrDefault(id);

    Assert.AreEqual(entity, result);
  }

  [Test]
  public void GetEntityOrDefault_EntityDoesNotExist_ReturnsNewEntity()
  {
    var id = Guid.NewGuid();
    A.CallTo(() => _repository.Find(id)).Returns(null);

    var result = _service.GetEntityOrDefault(id);

    Assert.IsNotNull(result);
    Assert.AreEqual(default(Guid), result.Id);
  }

  [Test]
  public void Upsert_NullEntity_ThrowsArgumentNullException()
  {
    Assert.Throws<ArgumentNullException>(() => _service.Upsert(null));
  }

  [Test]
  public void Upsert_InvalidEntity_ThrowsValidationException()
  {
    var entity = new TestEntity();
    var validationResult = new ValidationResult(new[] { new ValidationFailure("Name", "Required") });
    A.CallTo(() => _validator.Validate(entity)).Returns(validationResult);

    Assert.Throws<ValidationException>(() => _service.Upsert(entity));
  }

  [Test]
  public void Upsert_ValidEntityWithId_CallsEditAndReturnsResult()
  {
    var entity = new TestEntity { Id = Guid.NewGuid(), Name = "Test" };
    var validationResult = new ValidationResult();
    var editedEntity = new TestEntity { Id = entity.Id, Name = "Edited" };

    A.CallTo(() => _validator.Validate(entity)).Returns(validationResult);
    A.CallTo(() => _repository.Edit(entity)).Returns(editedEntity);

    var result = _service.Upsert(entity);

    Assert.AreEqual(editedEntity, result);
    A.CallTo(() => _repository.Edit(entity)).MustHaveHappened();
  }

  [Test]
  public void Upsert_ValidEntityWithoutId_CallsAddAndReturnsResult()
  {
    var entity = new TestEntity { Id = default, Name = "Test" };
    var validationResult = new ValidationResult();
    var addedEntity = new TestEntity { Id = Guid.NewGuid(), Name = "Test" };

    A.CallTo(() => _validator.Validate(entity)).Returns(validationResult);
    A.CallTo(() => _repository.Add(entity)).Returns(addedEntity);

    var result = _service.Upsert(entity);

    Assert.AreEqual(addedEntity, result);
    A.CallTo(() => _repository.Add(entity)).MustHaveHappened();
  }

  [Test]
  public void Delete_WithDefaultId_ThrowsArgumentException()
  {
    Assert.Throws<ArgumentException>(() => _service.Delete(default));
  }

  [Test]
  public void Delete_EntityExists_CallsDelete()
  {
    var id = Guid.NewGuid();
    var entity = new TestEntity { Id = id };
    A.CallTo(() => _repository.Find(id)).Returns(entity);

    _service.Delete(id);

    A.CallTo(() => _repository.Delete(entity)).MustHaveHappened();
  }

  [Test]
  public void Delete_EntityDoesNotExist_DoesNotCallDelete()
  {
    var id = Guid.NewGuid();
    A.CallTo(() => _repository.Find(id)).Returns(null);

    _service.Delete(id);

    A.CallTo(() => _repository.Delete(A<TestEntity>._)).MustNotHaveHappened();
  }

  [Test]
  public void GetFiltered_NullFilter_ThrowsArgumentNullException()
  {
    Assert.Throws<ArgumentNullException>(() => _service.GetFiltered(null));
  }

  [Test]
  public void GetFiltered_ValidFilter_ReturnsFilteredEntities()
  {
    var entities = new List<TestEntity>
            {
                new TestEntity { Id = Guid.NewGuid(), Name = "A" },
                new TestEntity { Id = Guid.NewGuid(), Name = "B" }
            };
    Func<TestEntity, bool> filter = e => e.Name == "A";
    A.CallTo(() => _repository.GetFiltered(filter!)).Returns(entities.Where(filter).AsQueryable());

    var result = _service.GetFiltered(filter);

    Assert.AreEqual(1, result.Count());
    Assert.AreEqual("A", result.First().Name);
  }
}
