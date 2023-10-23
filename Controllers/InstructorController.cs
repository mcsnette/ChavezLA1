using Microsoft.AspNetCore.Mvc;
using ChavezLA1.Models;
using ChavezLA1.Services;
using ChavezLA1.Data;
using Microsoft.EntityFrameworkCore;

namespace ChavezLA1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDbContext _dbContext;

        public InstructorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? Instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
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
            _dbContext.Instructors.Add(newInstructor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id) {
            Instructor? Instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == Id);
            return Instructor != null ? View(Instructor) : NotFound();
        }

        [HttpPost]

        public IActionResult Edit(Instructor instructorChange)
        {
            Instructor? Instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == instructorChange.Id);
                if(Instructor != null)
            {
                Instructor.Id= instructorChange.Id;
                Instructor.FirstName = instructorChange.FirstName;
                Instructor.LastName = instructorChange.LastName;
                Instructor.IsTenured = instructorChange.IsTenured;
                Instructor.Rank = instructorChange.Rank;
                Instructor.HiringDate = instructorChange.HiringDate;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Instructor instructorDelete)
        {
            Instructor? Instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == instructorDelete.Id);
            if (Instructor != null)//was the instructor found?
            {
                return View(Instructor);
            }

            return NotFound();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Instructor? Instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (Instructor != null)//was the instructor found?
            {
                _dbContext.Instructors.Remove(Instructor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }

}