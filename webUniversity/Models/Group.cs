using System.ComponentModel.DataAnnotations;

namespace webUniversity.Models
{
    public class Group
    {
        [Key]
        public int? groupID { get; set; }

        public string? code { get; set; }

        public string? name { get; set; }

        public List<Student> Student { get; set; } = new();
    }
}
