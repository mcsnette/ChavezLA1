using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using ChavezLA1.Models;
using ChavezLA1.Services;


namespace ChavezLA1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public StudentController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }


        List<Student> StudentList = new List<Student>
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
            },
        };
        public IActionResult Index()
        {
            return View(_fakeData.StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? Student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
            if (Student != null)
            {
                return View(Student);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            _fakeData.StudentList.Add(newStudent);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            Student? Student = _fakeData.StudentList.FirstOrDefault(st => st.Id == Id);
            return Student != null ? View(Student) : NotFound();
        }

        [HttpPost]

        public IActionResult Edit(Student studentChange)
        {
            Student? Student = _fakeData.StudentList.FirstOrDefault(st => st.Id == studentChange.Id);
            if (Student != null)
            {
                Student.Id = studentChange.Id;
                Student.Name = studentChange.Name;
                Student.Course = studentChange.Course;
                Student.DateEnrolled = studentChange.DateEnrolled;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Student studentDelete)
        {
            Student? Student = _fakeData.StudentList.FirstOrDefault(st => st.Id == studentDelete.Id);
            if (Student != null)//was the instructor found?
            {
                return View(Student);
            }

            return NotFound();

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Student? Student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
            if (Student != null)//was the student found?
            {
                _fakeData.StudentList.Remove(Student);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}