using Microsoft.EntityFrameworkCore;
using Pokemon_Review_App.Models;
using System.Collections.Generic;

namespace Pokemon_Review_App.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring relationships
            modelBuilder.Entity<PokemonCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(p => p.PokemonId);

            modelBuilder.Entity<PokemonCategory>()
                .HasOne(c => c.Category)
                .WithMany(pc => pc.PokemonCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwner>()
                .HasKey(po => new { po.PokemonId, po.OwnerId });

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(o => o.Owner)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(o => o.OwnerId);

            modelBuilder.Entity<PokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(po => po.PokemonOwners)
                .HasForeignKey(p => p.PokemonId);

            // Seeding data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Countries
            var countries = new[]
            {
                new Country { Id = 1, Name = "Kanto" },
                new Country { Id = 2, Name = "Saffron City" },
                new Country { Id = 3, Name = "Millet Town" }
            };

            // Categories
            var categories = new[]
            {
                new Category { Id = 1, Name = "Electric" },
                new Category { Id = 2, Name = "Water" },
                new Category { Id = 3, Name = "Leaf" }
            };

            // Reviewers
            var reviewers = new[]
            {
                new Reviewer { Id = 1, FirstName = "Teddy", LastName = "Smith" },
                new Reviewer { Id = 2, FirstName = "Taylor", LastName = "Jones" },
                new Reviewer { Id = 3, FirstName = "Jessica", LastName = "McGregor" }
            };

            // Pokemons
            var pokemons = new[]
            {
                new Pokemon { Id = 1, Name = "Pikachu", BirthDate = new DateTime(1903, 1, 1) },
                new Pokemon { Id = 2, Name = "Squirtle", BirthDate = new DateTime(1903, 1, 1) },
                new Pokemon { Id = 3, Name = "Venasaur", BirthDate = new DateTime(1903, 1, 1) }
            };

            // Reviews
            var reviews = new[]
            {
                new Review { Id = 1, Title = "Pikachu", Text = "Pickahu is the best pokemon, because it is electric", Rating = 5, ReviewerId = 1, PokemonId = 1 },
                new Review { Id = 2, Title = "Pikachu", Text = "Pickachu is the best at killing rocks", Rating = 5, ReviewerId = 2, PokemonId = 1 },
                new Review { Id = 3, Title = "Pikachu", Text = "Pickachu, pickachu, pikachu", Rating = 1, ReviewerId = 3, PokemonId = 1 },

                new Review { Id = 4, Title = "Squirtle", Text = "Squirtle is the best pokemon, because it is electric", Rating = 5, ReviewerId = 1, PokemonId = 2 },
                new Review { Id = 5, Title = "Squirtle", Text = "Squirtle is the best at killing rocks", Rating = 5, ReviewerId = 2, PokemonId = 2 },
                new Review { Id = 6, Title = "Squirtle", Text = "Squirtle, squirtle, squirtle", Rating = 1, ReviewerId = 3, PokemonId = 2 },

                new Review { Id = 7, Title = "Venasaur", Text = "Venasaur is the best pokemon, because it is electric", Rating = 5, ReviewerId = 1, PokemonId = 3 },
                new Review { Id = 8, Title = "Venasaur", Text = "Venasaur is the best at killing rocks", Rating = 5, ReviewerId = 2, PokemonId = 3 },
                new Review { Id = 9, Title = "Venasaur", Text = "Venasaur, Venasaur, Venasaur", Rating = 1, ReviewerId = 3, PokemonId = 3 }
            };

            // Owners
            var owners = new[]
            {
                new Owner { Id = 1, FirstName = "Jack", LastName = "London", Gym = "Brocks Gym", CountryId = 1 },
                new Owner { Id = 2, FirstName = "Harry", LastName = "Potter", Gym = "Mistys Gym", CountryId = 2 },
                new Owner { Id = 3, FirstName = "Ash", LastName = "Ketchum", Gym = "Ashs Gym", CountryId = 3 }
            };

            // PokemonOwners
            var pokemonOwners = new[]
            {
                new PokemonOwner { PokemonId = 1, OwnerId = 1 },
                new PokemonOwner { PokemonId = 2, OwnerId = 2 },
                new PokemonOwner { PokemonId = 3, OwnerId = 3 }
            };

            // PokemonCategories
            var pokemonCategories = new[]
            {
                new PokemonCategory { PokemonId = 1, CategoryId = 1 },
                new PokemonCategory { PokemonId = 2, CategoryId = 2 },
                new PokemonCategory { PokemonId = 3, CategoryId = 3 }
            };

            // Apply the seed data
            modelBuilder.Entity<Country>().HasData(countries);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Reviewer>().HasData(reviewers);
            modelBuilder.Entity<Pokemon>().HasData(pokemons);
            modelBuilder.Entity<Review>().HasData(reviews);
            modelBuilder.Entity<Owner>().HasData(owners);
            modelBuilder.Entity<PokemonOwner>().HasData(pokemonOwners);
            modelBuilder.Entity<PokemonCategory>().HasData(pokemonCategories);
        }
    }
}
