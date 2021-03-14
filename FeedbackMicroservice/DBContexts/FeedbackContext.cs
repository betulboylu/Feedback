using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackMicroservice.Models;
using Microsoft.EntityFrameworkCore;


namespace FeedbackMicroservice.DBContexts
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "For Honor"
                }
                );

            modelBuilder.Entity<Session>().HasData(
                new Session
                {
                    Id = 1,
                    GameId = 1
                },
                new Session
                {
                    Id = 2,
                    GameId = 1
                },
                new Session
                {
                    Id = 3,
                    GameId = 1
                }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "User1"
                },
                 new User
                 {
                     Id = 2,
                     Name = "User2",
                 },
                  new User
                  {
                      Id = 3,
                      Name = "User3",
                  }
                );
        }

    }
}
