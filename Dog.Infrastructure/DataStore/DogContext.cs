namespace Dog.Infrastructure.DataStore;

using System.Diagnostics.CodeAnalysis;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Represents the database context for the Dog application.
/// This context manages the connection to the SQLite database and provides access to the DbSet properties for each model.
/// </summary>
[ExcludeFromCodeCoverage]
public class DogContext : DbContext
{
  /// <summary>
  /// Gets or sets the DbSet for the Dog model.
  /// </summary>
  public DbSet<Dog> Dogs { get; set; }

  /// <summary>
  /// Gets or sets the DbSet for the Client model.
  /// </summary>
  public DbSet<Client> Clients { get; set; }

  /// <summary>
  /// Gets or sets the DbSet for the Walk model.
  /// </summary>
  public DbSet<Walk> Walks { get; set; }

  /// <summary>
  /// Gets the path to the SQLite database file.
  /// </summary>
  public string DbPath { get; private set; }

  public DogContext()
  {
    SetDbPath();
  }

  public DogContext(DbContextOptions<DogContext> options) : base(options)
  {
    SetDbPath();
  }

  private void SetDbPath()
  {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    DbPath = Path.Join(path, "dog-walking.db");
  }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options
        .UseLazyLoadingProxies()
        .UseSqlite($"Data Source={DbPath}");
}
