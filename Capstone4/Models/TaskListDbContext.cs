using Capstone4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone4.Models
{
    public class TaskListDbContext : DbContext
    {
        public TaskListDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasData(
                new Tasks(1, "06554c8c-9508-449d-bcb0-93d5e638adb4", "lol", DateTime.Parse("08/08/2020"), false)
                );
        }
    }
}