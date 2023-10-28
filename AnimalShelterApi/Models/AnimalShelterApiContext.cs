using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : DbContext
  {
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Cat> Cats { get; set; }

    public AnimalShelterApiContext(DbContextOptions<AnimalShelterApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Dog>()
        .HasData(
        new Dog { DogId = 1, Name = "Bella", Sex = "Female", Age = 7, Personality = "Playful" },
        new Dog { DogId = 2, Name = "Max", Sex = "Female", Age = 10, Personality = "Loyal" },
        new Dog { DogId = 3, Name = "Charlie", Sex = "Male", Age = 2, Personality = "Curious" },
        new Dog { DogId = 4, Name = "Luna", Sex = "Female", Age = 4, Personality = "Shy" },
        new Dog { DogId = 5, Name = "Buddy", Sex = "Male", Age = 22, Personality = "Protective" },
        new Dog { DogId = 6, Name = "Max", Sex = "Male", Age = 22, Personality = "Friendly" }
      );
      builder.Entity<Cat>()
        .HasData(
        new Cat { CatId = 1, Name = "Whiskers", Sex = "Male", Age = 7, Personality = "Independent" },
        new Cat { CatId = 2, Name = "Oliver", Sex = "Female", Age = 10, Personality = "Affectionate" },
        new Cat { CatId = 3, Name = "Charlie", Sex = "Male", Age = 2, Personality = "Adventurous" },
        new Cat { CatId = 4, Name = "Daisy", Sex = "Female", Age = 4, Personality = "Lazy" },
        new Cat { CatId = 5, Name = "Buddy", Sex = "Male", Age = 22, Personality = "Mysterious" },
        new Cat { CatId = 6, Name = "Oliver", Sex = "Male", Age = 22, Personality = "Playful" }
      );
    }
  }
}