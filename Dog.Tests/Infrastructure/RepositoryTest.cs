namespace Dog.Tests.Infrastructure;

using System;
using Dog.Domain;
using Dog.Infrastructure.DataStore;
using Dog.Infrastructure.DataStore.Repositories;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

public class TestEntity : BaseEntity
{
  public string Name { get; set; } = string.Empty;
}

[TestFixture]
public class RepositoryTests
{
  private DogContext _context;
  private DbSet<TestEntity> _dbSet;
  private Repository<TestEntity> _repository;

  [TearDown]
  public void TearDown()
  {
    _context.Dispose();
  }

  [SetUp]
  public void SetUp()
  {
    _context = A.Fake<DogContext>(options => options.CallsBaseMethods());
    _dbSet = A.Fake<DbSet<TestEntity>>(options => options.CallsBaseMethods());
    A.CallTo(() => _context.Set<TestEntity>()).Returns(_dbSet);
    _repository = new Repository<TestEntity>(_context);
  }

  [Test]
  public void Add_ShouldThrow_WhenEntityIsNull()
  {
    Assert.Throws<ArgumentNullException>(() => _repository.Add(null));
  }


  [Test]
  public void Edit_ShouldThrow_WhenEntityIsNull()
  {
    Assert.Throws<ArgumentNullException>(() => _repository.Edit(null));
  }


  [Test]
  public void Delete_ShouldThrow_WhenEntityIsNull()
  {
    Assert.Throws<ArgumentNullException>(() => _repository.Delete(null));
  }

  [Test]
  public void Find_ShouldReturnNull_WhenIdIsDefault()
  {
    var result = _repository.Find(default);
    Assert.IsNull(result);
  }

  [Test]
  public void Find_ShouldReturnEntity_WhenFound()
  {
    var id = Guid.NewGuid();
    var entity = new TestEntity { Id = id };
    A.CallTo(() => _dbSet.Find(id)).Returns(entity);

    var result = _repository.Find(id);

    Assert.AreEqual(entity, result);
  }

}
