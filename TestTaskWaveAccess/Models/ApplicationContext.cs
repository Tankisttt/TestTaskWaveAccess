using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskWaveAccess.Models
{
	public class ApplicationContext : DbContext
	{
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Actor> Actors { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userRole = new Role { RoleId = 1, Description = "admin", Name = "admin" };
            var adminUser = new User
            {
                UserId = 1, 
                Bio = "sd",
                BirthDate = DateTime.Now,
                Email = @"roman@gmail.com",
                IsBlocked = false,
                Password = "1234", 
                RegistrationDate = DateTime.Now,
                UserName = "Roman322"
            };
            var actor = new Actor { ActorId = 0, Bio = "cool", BirthYear = 1950, FullName = "Charly" };
            var genre = new Genre { GenreId = 1, Title = "Horror", Description = "horror genre of movies" };
            var movie = new Movie
            {
                MovieId = 0,
                Title = "Titanic",
                Description = "It drowned",
                AverageRating = 9.8f,
                ReleaseYear = 1997,
                NumVotes = 2022020
            };
            /*
            modelBuilder.Entity<Role>().HasData(new Role[] { userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            modelBuilder.Entity<Actor>().HasData(new Actor[] { actor });
            modelBuilder.Entity<Movie>().HasData(new Movie[] { movie });
            modelBuilder.Entity<Genre>().HasData(new Genre[] { genre });
            */
            modelBuilder.Entity<Genre>().ToTable("Genres");

            base.OnModelCreating(modelBuilder);
        }
    }
}
