﻿// <auto-generated />
using AnimalShelterApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalShelterApi.Migrations
{
    [DbContext(typeof(AnimalShelterApiContext))]
    [Migration("20231028004128_AddPersonalityToAnimals")]
    partial class AddPersonalityToAnimals
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AnimalShelterApi.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Personality")
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CatId");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            Age = 7,
                            Name = "Whiskers",
                            Personality = "Independent",
                            Sex = "Male"
                        },
                        new
                        {
                            CatId = 2,
                            Age = 10,
                            Name = "Oliver",
                            Personality = "Affectionate",
                            Sex = "Female"
                        },
                        new
                        {
                            CatId = 3,
                            Age = 2,
                            Name = "Charlie",
                            Personality = "Adventurous",
                            Sex = "Male"
                        },
                        new
                        {
                            CatId = 4,
                            Age = 4,
                            Name = "Daisy",
                            Personality = "Lazy",
                            Sex = "Female"
                        },
                        new
                        {
                            CatId = 5,
                            Age = 22,
                            Name = "Buddy",
                            Personality = "Mysterious",
                            Sex = "Male"
                        },
                        new
                        {
                            CatId = 6,
                            Age = 22,
                            Name = "Oliver",
                            Personality = "Playful",
                            Sex = "Male"
                        });
                });

            modelBuilder.Entity("AnimalShelterApi.Models.Dog", b =>
                {
                    b.Property<int>("DogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Personality")
                        .HasColumnType("longtext");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("DogId");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            DogId = 1,
                            Age = 7,
                            Name = "Bella",
                            Personality = "Playful",
                            Sex = "Female"
                        },
                        new
                        {
                            DogId = 2,
                            Age = 10,
                            Name = "Max",
                            Personality = "Loyal",
                            Sex = "Female"
                        },
                        new
                        {
                            DogId = 3,
                            Age = 2,
                            Name = "Charlie",
                            Personality = "Curious",
                            Sex = "Male"
                        },
                        new
                        {
                            DogId = 4,
                            Age = 4,
                            Name = "Luna",
                            Personality = "Shy",
                            Sex = "Female"
                        },
                        new
                        {
                            DogId = 5,
                            Age = 22,
                            Name = "Buddy",
                            Personality = "Protective",
                            Sex = "Male"
                        },
                        new
                        {
                            DogId = 6,
                            Age = 22,
                            Name = "Max",
                            Personality = "Friendly",
                            Sex = "Male"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}