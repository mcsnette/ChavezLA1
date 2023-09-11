﻿using Microsoft.AspNetCore.Mvc;

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
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IsTenured IsTenured { get; set; }

        public Rank Rank { get; set; }

        public DateOnly HiringDate { get; set; }

    }
}