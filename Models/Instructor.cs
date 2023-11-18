using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChavezLA1.Models
{
    public enum Rank
    {
        Instructor, AssistantProfessor, AssociateProfessor, Professor
    }

    public enum IsTenured
    {
        Permanent, Probationary
    }
    public class Instructor
    {
        [Required(ErrorMessage = "Please add Id")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please enter your first name")]

        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Display(Name = "Status")]
        
        public IsTenured IsTenured { get; set; }

        [Display(Name = "Rank")]
       
        public Rank Rank { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter your hiring date")]
        public DateTime HiringDate { get; set; }

    }
}