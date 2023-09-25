using Microsoft.AspNetCore.Mvc;
using ChavezLA1.Models;
using ChavezLA1.Services;

namespace ChavezLA1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public InstructorController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        List<Instructor> InstructorList = new List<Instructor>
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
        public IActionResult Index()
        {
            return View(_fakeData.InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? Instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
            if (Instructor != null)
            {
                return View(Instructor);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            _fakeData.InstructorList.Add(newInstructor);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id) {
            Instructor? Instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == Id);
            return Instructor != null ? View(Instructor) : NotFound();
        }

        [HttpPost]

        public IActionResult Edit(Instructor instructorChange)
        {
            Instructor? Instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == instructorChange.Id);
                if(Instructor != null)
            {
                Instructor.Id= instructorChange.Id;
                Instructor.FirstName = instructorChange.FirstName;
                Instructor.LastName = instructorChange.LastName;
                Instructor.IsTenured = instructorChange.IsTenured;
                Instructor.Rank = instructorChange.Rank;
                Instructor.HiringDate = instructorChange.HiringDate;
            }
                return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Instructor instructorDelete)
        {
            Instructor? Instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == instructorDelete.Id);
            if (Instructor != null)//was the instructor found?
            {
                return View(Instructor);
            }

            return NotFound();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Instructor? Instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
            if (Instructor != null)//was the instructor found?
            {
                _fakeData.InstructorList.Remove(Instructor);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }

}