using Microsoft.AspNetCore.Mvc;

namespace ChavezLA1.Models
{
    public enum Course
    {
        BSIT, BSCS, BSIS
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set;}
        public DateTime DateEnrolled { get; set; }

    }
}
