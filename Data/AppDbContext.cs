using ChavezLA1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChavezLA1.Data
{
    public class AppDbContext : IdentityDbContext<User>  // DbContext 
    {
        public DbSet<Student> Students { get; set; }
        public DbSet <Instructor> Instructors { get; set; }

        //constructor
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) {}

        //data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "Noel Cansino",
                    Course = Course.BSIT,
                    DateEnrolled = DateTime.Parse("28/09/2020")
                },
              new Student()
              {
                  Id = 2,
                  Name = "Lara Gatchalian",
                  Course = Course.BSCS,
                  DateEnrolled = DateTime.Parse("28/09/2020")
              },
              new Student()
              {
                  Id = 3,
                  Name = "Esther Avila",
                  Course = Course.BSIS,
                  DateEnrolled = DateTime.Parse("28/09/2020")
              });

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Ariana",
                    LastName = "Grande",
                    Rank = Rank.Professor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("28/09/2020")
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "Juan Ponce",
                    LastName = "Enrile",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Probationary,
                    HiringDate = DateTime.Parse("17/07/2021")
                },
                new Instructor()
                {
                    Id = 3,
                    FirstName = "Arvey",
                    LastName = "Chan",
                    Rank = Rank.Instructor,
                    IsTenured = IsTenured.Probationary,
                    HiringDate = DateTime.Parse("01/12/2020")
                },
                new Instructor()
                {
                    Id = 4,
                    FirstName = "Sandra",
                    LastName = "Bullock",
                    Rank = Rank.AssociateProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("07/09/2020")
           });
        }
    }
}
