﻿using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public partial class Teacher
    {
        [Key]
        public int? IdTeacher { get; set; } = null!;

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronomic { get; set; }

        public string? Post { get; set; }

        public string? Degree { get; set; }

        public string? Title { get; set; }

        public string? Department { get; set; }
    }
}
