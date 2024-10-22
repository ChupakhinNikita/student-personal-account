using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public partial class User
    {
        [Key]
        public int userID { get; set; }

        public int authID { get; set; }

        public string? role { get; set; }

        public string? login { get; set; }

        public string? password { get; set; }

        public List<Student> Student { get; set; } = new();
    }
}
