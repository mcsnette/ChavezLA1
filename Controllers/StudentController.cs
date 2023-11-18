using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ChavezLA1.Models;
using ChavezLA1.Services;
using ChavezLA1.Data;
using Microsoft.AspNetCore.Authorization;

namespace ChavezLA1.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _dbContext;

        //constructor
        public StudentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View(_dbContext.Students);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? Student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
            if (Student != null)//was student found?
                return View(Student);

            return NotFound();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            if (!ModelState.IsValid) //if the data is invalid
            {
                return View();//go back to the VIew
            }

            _dbContext.Students.Add(newStudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Student? Student = _dbContext.Students.FirstOrDefault(st => st.Id == Id);
            if (Student != null)
                return View(Student);
                    
            return NotFound();
        }

        [HttpPost]

        public IActionResult Edit(Student studentChange)
        {
            Student? Student = _dbContext.Students.FirstOrDefault(st => st.Id == studentChange.Id);
            if (Student != null)
            {
                Student.Id = studentChange.Id;
                Student.Name = studentChange.Name;
                Student.Course = studentChange.Course;
                Student.DateEnrolled = studentChange.DateEnrolled;
            }

            if (!ModelState.IsValid) //if the data is invalid
            {
                return View();//go back to the VIew
            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Student studentDelete)
        {
            Student? Student = _dbContext.Students.FirstOrDefault(st => st.Id == studentDelete.Id);
            if (Student != null)//was the student found?
            {
                return View(Student);
            }

            return NotFound();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Student? Student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
            if (Student != null)//was the student found?
            {
                _dbContext.Students.Remove(Student);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}