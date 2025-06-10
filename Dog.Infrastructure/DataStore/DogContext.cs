namespace Dog.Infrastructure.DataStore;

using Domain.Models;
using Microsoft.EntityFrameworkCore;

public class DogContext : DbContext
{
  public DbSet<Dog> Dogs { get; set; }
  public DbSet<Client> Clients { get; set; }
  public DbSet<Walk> Walks { get; set; }
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
