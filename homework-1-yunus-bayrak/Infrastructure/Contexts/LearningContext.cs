using homework_1_yunus_bayrak.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_1_yunus_bayrak.Infrastructure.Contexts
{
    public class LearningContext : DbContext
    {
        public LearningContext(DbContextOptions<LearningContext> options)
        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("exampleDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Department
            modelBuilder.Entity<Course>()
                        .HasData(
                         new Course { Id = 1, Name = "C# deneme", CourseType = Domain.Enums.CourseType.DESKTOP, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 2, Name = "C# deneme2", CourseType = Domain.Enums.CourseType.DESKTOP, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 3, Name = "English", CourseType = Domain.Enums.CourseType.LANGUAGE, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 4, Name = "Web Service", CourseType = Domain.Enums.CourseType.SERVICE, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true },
                         new Course { Id = 5, Name = "How Machines Talk", CourseType = Domain.Enums.CourseType.AI, CreatedAt = DateTime.Now.AddDays(new Random().Next(-100, 100)), CreatedBy = "Me", Description = "Desc", Status = true }
                         );

        }
        public DbSet<Course> Courses { get; set; }
    }
}
