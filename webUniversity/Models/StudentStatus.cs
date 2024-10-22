using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class StudentStatus
    {
        [Key]
        public int? studentStatusTypeID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public List<Student> Student { get; set; } = new();
    }
}
