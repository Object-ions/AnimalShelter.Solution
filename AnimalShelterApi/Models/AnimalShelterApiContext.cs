using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }

    public AnimalShelterApiContext(DbContextOptions<AnimalShelterApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Bella", Species = "Dog", Sex = "Female", Age = 7 },
          new Animal { AnimalId = 2, Name = "Max", Species = "Dog", Sex = "Female", Age = 10 },
          new Animal { AnimalId = 3, Name = "Charlie", Species = "Dog", Sex = "Male", Age = 2 },
          new Animal { AnimalId = 4, Name = "Luna", Species = "Dog", Sex = "Female", Age = 4 },
          new Animal { AnimalId = 5, Name = "Buddy", Species = "Dog", Sex = "Male", Age = 22 }
          new Animal { AnimalId = 5, Name = "Max", Species = "Dog", Sex = "Male", Age = 22 }
        );
    }
  }
}