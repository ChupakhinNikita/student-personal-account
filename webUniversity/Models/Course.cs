using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Course
    {
        [Key]
        public int? courseID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public string? index { get; set; }
    }
}
