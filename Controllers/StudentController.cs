using Microsoft.AspNetCore.Mvc;
using ChavezLA1.Models;


namespace ChavezLA1.Controllers
{
    public class StudentController : Controller
    {
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
            return View(StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? Student = StudentList.FirstOrDefault(st => st.Id == id);
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
            StudentList.Add(newStudent);
            return View("Index", StudentList);
        }

        public IActionResult Edit(int Id)
        {
            Student? Student = StudentList.FirstOrDefault(st => st.Id == Id);
            return Student != null ? View(Student) : NotFound();
        }

        [HttpPost]

        public IActionResult Edit(Student studentChange)
        {
            Student? Student = StudentList.FirstOrDefault(st => st.Id == studentChange.Id);
            if (Student != null)
            {
                Student.Id = studentChange.Id;
                Student.Name = studentChange.Name;
                Student.Course = studentChange.Course;
                Student.DateEnrolled = studentChange.DateEnrolled;
            }
            return View("Index", StudentList);
        }
    }

}