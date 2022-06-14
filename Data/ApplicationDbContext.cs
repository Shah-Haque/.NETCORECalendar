using dotnetcoreCalendar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dotnetcoreCalendar.Data
{
    /// <summary>
    /// The code is a class that inherits from the IdentityDbContext class.
    /// It has two properties: Events and Locations.
    /// The code also contains an override of OnModelCreating, which is called when the model is being created.
    /// In this method, it sets up its properties to be DbSet objects with their respective names as Event and Location.
    /// The code is a part of the application's DbContext class.
    /// The code above is an example of how to configure the database context for use with Entity Framework Core.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Event> Events { get; set; } 
        public DbSet<Location> Locations { get; set; }
    }
}
