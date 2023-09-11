using Microsoft.AspNetCore.Mvc;
using ChavezLA1.Models;

namespace ChavezLA1.Controllers
{
    public class InstructorController : Controller
    {
        
        List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1,
                FirstName = "Ariana",
                LastName = "Grande",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("28/09/2020")
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "Juan Ponce",
                LastName = "Enrile",
                Rank = Rank.AssistantProfessor,
                IsTenured = IsTenured.Probationary,
                HiringDate = DateOnly.Parse("17/07/2021")
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Arvey",
                LastName = "Chan",
                Rank = Rank.Instructor,
                IsTenured = IsTenured.Probationary,
                HiringDate = DateOnly.Parse("01/12/2020")
            },
            new Instructor()
            {
                Id = 4,
                FirstName = "Sandra",
                LastName = "Bullock",
                Rank = Rank.AssociateProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("07/09/2020")
            },
        };
        public IActionResult Index()
        {
            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? Instructor = InstructorList.FirstOrDefault(st => st.Id == id);
            if (Instructor != null)
            {
                return View(Instructor);
            }

            return View();
        }


    }
}