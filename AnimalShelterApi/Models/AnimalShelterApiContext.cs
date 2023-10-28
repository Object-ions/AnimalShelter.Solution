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
      builder.Entity<Dog>()
        .HasData(
          new Dog { DogId = 1, Name = "Bella", Sex = "Female", Age = 7 },
          new Dog { DogId = 2, Name = "Max", Sex = "Female", Age = 10 },
          new Dog { DogId = 3, Name = "Charlie", Sex = "Male", Age = 2 },
          new Dog { DogId = 4, Name = "Luna", Sex = "Female", Age = 4 },
          new Dog { DogId = 5, Name = "Buddy", Sex = "Male", Age = 22 }
          new Dog { DogId = 5, Name = "Max", Sex = "Male", Age = 22 }
        );
      builder.Entity<Cat>()
        .HasData(
          new Cat { CatId = 1, Name = "Whiskers", Sex = "Male", Age = 7 },
          new Cat { CatId = 2, Name = "Oliver", Sex = "Female", Age = 10 },
          new Cat { CatId = 3, Name = "Charlie", Sex = "Male", Age = 2 },
          new Cat { CatId = 4, Name = "Daisy", Sex = "Female", Age = 4 },
          new Cat { CatId = 5, Name = "Buddy", Sex = "Male", Age = 22 }
          new Cat { CatId = 5, Name = "Oliver", Sex = "Male", Age = 22 }
        );
    }
  }
}