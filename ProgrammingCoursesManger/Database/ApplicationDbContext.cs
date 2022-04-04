using Microsoft.EntityFrameworkCore;

using ProgrammingCoursesManger.Database.Models;

namespace ProgrammingCoursesManger.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Topics)
                .WithOne(c => c.Course)
                .HasForeignKey(t => t.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course
                    {
                        Id = 1,
                        Name = "Kurs C# I",
                        Description = "Podstawy języka C#"
                    },
                    new Course
                    {
                        Id = 2,
                        Name = "Kurs C# II",
                        Description = "Skomplikowane strukury języka C# oraz praktyczne przykłady zastosowania"
                    },
                    new Course
                    {
                        Id = 3,
                        Name = "Kurs Python I",
                        Description = "Podstawy języka węży"
                    },
                    new Course
                    {
                        Id = 4,
                        Name = "Kurs Python II",
                        Description = "Jak otworzyć chodowlę węży"
                    },
                    new Course
                    {
                        Id = 5,
                        Name = "Kurs HTML/JS",
                        Description = "Nauka projektowania stron internetowych od podstaw"
                    },
                    new Course
                    {
                        Id = 6,
                        Name = "Kurs HTML/JS/TS",
                        Description = "Omówienie projektowania stron internetowych zarówno statycznych jak i SPA na przykładach w najpopularniejszych frameworkach JavaScript/TypeScript"
                    },
                    new Course
                    {
                        Id = 7,
                        Name = "Kurs Angular",
                        Description = "Wprowadzenie do frameworka Angular zarówno dla początkujących jak i zaawansowanych"
                    },
                    new Course
                    {
                        Id = 8,
                        Name = "Kurs React",
                        Description = "Wprowadzenie do frameworka React zarówno dla początkujących jak i zaawansowanych"
                    },
                    new Course
                    {
                        Id = 9,
                        Name = "Kurs Vue",
                        Description = "Wprowadzenie do frameworka Vue zarówno dla początkujących jak i zaawansowanych"
                    }
                );

            modelBuilder.Entity<Topic>()
                .HasData(
                    new Topic { Id = 1, CourseId = 1, Name = "C# I - Temat 1", Number = 1 },
                    new Topic { Id = 2, CourseId = 1, Name = "C# I - Temat 2", Number = 2 },
                    new Topic { Id = 3, CourseId = 1, Name = "C# I - Temat 3", Number = 3 },

                    new Topic { Id = 4, CourseId = 2, Name = "C# II - Temat 1", Number = 1 },
                    new Topic { Id = 5, CourseId = 2, Name = "C# II - Temat 2", Number = 2 },
                    new Topic { Id = 6, CourseId = 2, Name = "C# II - Temat 3", Number = 3 },

                    new Topic { Id = 7, CourseId = 3, Name = "Python I - Temat 1", Number = 1 },
                    new Topic { Id = 8, CourseId = 3, Name = "Python I - Temat 2", Number = 2 },
                    new Topic { Id = 9, CourseId = 3, Name = "Python I - Temat 3", Number = 3 },
                    new Topic { Id = 10, CourseId = 3, Name = "Python I - Temat 4", Number = 4 },
                    new Topic { Id = 11, CourseId = 3, Name = "Python I - Temat 5", Number = 5 },

                    new Topic { Id = 12, CourseId = 4, Name = "Python II - Temat 1", Number = 1 },
                    new Topic { Id = 13, CourseId = 4, Name = "Python II - Temat 2", Number = 2 },

                    new Topic { Id = 14, CourseId = 5, Name = "HTML", Number = 1 },
                    new Topic { Id = 15, CourseId = 5, Name = "JavaScript", Number = 2 },

                    new Topic { Id = 16, CourseId = 6, Name = "HTML", Number = 1 },
                    new Topic { Id = 17, CourseId = 6, Name = "JavaScript - Temat 1", Number = 2 },
                    new Topic { Id = 18, CourseId = 6, Name = "JavaScript - Temat 2", Number = 3 },
                    new Topic { Id = 19, CourseId = 6, Name = "JavaScript - Temat 3", Number = 4 },
                    new Topic { Id = 20, CourseId = 6, Name = "JavaScript - Temat 4", Number = 5 },
                    new Topic { Id = 21, CourseId = 6, Name = "TypeScript - Temat 1", Number = 6 },
                    new Topic { Id = 22, CourseId = 6, Name = "TypeScript - Temat 2", Number = 7 },
                    new Topic { Id = 23, CourseId = 6, Name = "Angular", Number = 8 },
                    new Topic { Id = 24, CourseId = 6, Name = "React", Number = 9 },
                    new Topic { Id = 25, CourseId = 6, Name = "Vue", Number = 10 },

                    new Topic { Id = 26, CourseId = 7, Name = "JavaScript", Number = 1 },
                    new Topic { Id = 27, CourseId = 7, Name = "Angular - Temat 1", Number = 2 },
                    new Topic { Id = 28, CourseId = 7, Name = "Angular - Temat 2", Number = 3 },
                    new Topic { Id = 29, CourseId = 7, Name = "Angular - Temat 3", Number = 4 },
                    new Topic { Id = 30, CourseId = 7, Name = "Angular - Temat 4", Number = 5 },

                    new Topic { Id = 31, CourseId = 8, Name = "JavaScript", Number = 1 },
                    new Topic { Id = 32, CourseId = 8, Name = "React - Temat 1", Number = 2 },
                    new Topic { Id = 33, CourseId = 8, Name = "React - Temat 2", Number = 3 },
                    new Topic { Id = 34, CourseId = 8, Name = "React - Temat 3", Number = 4 },

                    new Topic { Id = 35, CourseId = 9, Name = "JavaScript", Number = 1 },
                    new Topic { Id = 36, CourseId = 9, Name = "Vue - Temat 1", Number = 2 },
                    new Topic { Id = 37, CourseId = 9, Name = "Vue - Temat 2", Number = 3 }
                );
        }
    }
}