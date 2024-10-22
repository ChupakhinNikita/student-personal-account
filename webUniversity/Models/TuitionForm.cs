using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class TuitionForm
    {
        [Key]
        public int? tuitionFormlID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public string? addName { get; set; }

        public List<Student> Student { get; set; } = new();
    }
}
