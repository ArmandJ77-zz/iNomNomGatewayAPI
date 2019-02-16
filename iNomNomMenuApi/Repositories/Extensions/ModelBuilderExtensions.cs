using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using System;

namespace Repositories.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    Name = "Lunch Menu",
                    DateCreated = DateTime.Now,
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, MenuId = 1,Name = "Nom your face off Sandwich",Description = "It has everything you ever wanted in a sandwich. enough said", Price = 100.00,TimeToPrep = 20},
                new MenuItem { Id = 2, MenuId = 1,Name = "I'm a vegan", Description = "Disappointed", Price = 200.00, TimeToPrep = 60},
                new MenuItem { Id = 3, MenuId = 1,Name = "Anti vegan burger", Description = "200g beef patty mixed with 10% sirloin, 10% rump and 80% more beef", Price = 120, TimeToPrep = 30},
                new MenuItem { Id = 4, MenuId = 1,Name = "Hawaiian pizza", Description = "Yes people pineapple on pizza, #dealwithit", Price = 50.00, TimeToPrep = 25},
                new MenuItem { Id = 5, MenuId = 1,Name = "Greek salad", Description = "Good luck finding the feta or olives", Price = 80.00, TimeToPrep = 5},
                new MenuItem { Id = 6, MenuId = 1,Name = "Uber eats special", Description = "Because you never know what you gonna get", Price = 100, TimeToPrep = 20}
            );
        }
    }
}
