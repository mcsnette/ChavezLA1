using System;
using ChavezLA1.Models;
using ChavezLA1.Services;

namespace ChavezLA1.Services
{
    public class MyFakeDataService : IMyFakeDataService
    {
        public List<Student> StudentList { get; }
        public List<Instructor> InstructorList { get; }

        //Constructor
        public MyFakeDataService()
        {
            StudentList = new List<Student>()
            {
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
                }
            };

            InstructorList = new List<Instructor>()
                {
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
                },
            };

        }

    }
}
