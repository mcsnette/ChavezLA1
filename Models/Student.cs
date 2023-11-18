using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ChavezLA1.Models
{
    public enum Course
    {
        BSIT, BSCS, BSIS
    }
    public class Student
    {
        
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }


        public Course Course { get; set;}
       
        [Display(Name = "Date Enrolled")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter your hiring date")]
        public DateTime DateEnrolled { get; set; }

    }
}
